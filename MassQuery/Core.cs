using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;
using System.IO;
using System.Xml;
using System.DirectoryServices;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MassQuery
{
    class Core
    {
        public static MainForm form = new MainForm();

        public static List<Thread> activeThreads = new List<Thread>();

        public static long machinesTotal = 0;
        public static long machinesProcessing = 0;
        public static long machinesSuccessful = 0;
        public static long machinesError = 0;
        public static long machinesQuerying = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(form = new MainForm());
        }
    }

    public static class QueryStarter
    {
        public static void StartAll(List<string> machines, Dictionary<string,string> queryParameters, CancellationToken token)
        {
            Debug.WriteLine("Total Machines to process: " + machines.Count);
            Core.machinesTotal = machines.Count;
            Core.machinesProcessing = machines.Count;
            Core.machinesError = 0;
            Core.machinesSuccessful = 0;
            foreach (string machine in machines)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                Thread queryThread = new Thread(delegate() {
                    QueryThread.Start(machine,queryParameters,token);
                });
                queryThread.Name = "sqlQueryMachineThread";
                queryThread.Start();
                Core.activeThreads.Add(queryThread);
            }
        }
    }

    public static class QueryThread
    {
        private delegate bool FileExistsDelegate(string folder);

        static bool FileExistsTimeout(string path, int millisecondsTimeout)
        {
            try
            {
                FileExistsDelegate callback = new FileExistsDelegate(File.Exists);
                IAsyncResult result = callback.BeginInvoke(path, null, null);

                if (result.AsyncWaitHandle.WaitOne(millisecondsTimeout, false))
                {
                    return callback.EndInvoke(result);
                }
                else
                {
                    callback.EndInvoke(result);  // Needed to terminate thread?

                    return false;
                }
            }

            catch (Exception)
            {
                return false;
            }
        }
        public static void UpdateMachinesProcessing(string machine, CancellationToken token)
        {
            //check cancellation token
            if (token.IsCancellationRequested)
            {
                Core.machinesProcessing = 0;
                return;
            }
            Interlocked.Decrement(ref Core.machinesProcessing);
            Debug.WriteLine("Finished processing " + machine + " " + Interlocked.Read(ref Core.machinesProcessing) + " machines currently processing");
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("machinesProcessingLabel", string.Format("Processing: {0}", Interlocked.Read(ref Core.machinesProcessing)));
            Core.form.UpdateStatus(status);
            Core.form.UpdateStatus(new Dictionary<string, string>() { {"taskBarItemProgressValue", (Interlocked.Read(ref Core.machinesTotal) - Interlocked.Read(ref Core.machinesProcessing)).ToString() } });
            if (Interlocked.Read(ref Core.machinesProcessing) == 0)
            {
                Debug.WriteLine("All queries complete " + machine + " was last machine to finish");
                Core.form.ReturnData();
                Core.form.UpdateStatus(new Dictionary<string, string>() { { "taskBarItemProgressStatus", "" } });
            }
        }

        public static void UpdateMachinesSuccessful(string machine)
        {
            Interlocked.Increment(ref Core.machinesSuccessful);
            Debug.WriteLine("Successfully processed " + machine + " " + Interlocked.Read(ref Core.machinesSuccessful) + " machines processed successfully");
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("machinesSuccessfulLabel", string.Format("Success: {0}", Interlocked.Read(ref Core.machinesSuccessful)));
            Core.form.UpdateStatus(status);
            Core.form.UpdateStatus(new Dictionary<string, string> { { "returnMachinesSuccessMachinesList", machine } });
        }

        public static void UpdateMachinesError(string machine)
        {
            Interlocked.Increment(ref Core.machinesError);
            Debug.WriteLine("Encountered error processing " + machine + " " + Interlocked.Read(ref Core.machinesError) + " machines encountered an error");
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("machinesErrorLabel", string.Format("Error: {0}", Interlocked.Read(ref Core.machinesError)));
            Core.form.UpdateStatus(status);
            Core.form.UpdateStatus(new Dictionary<string, string> { { "returnMachinesErrorMachinesList", machine } });
        }
        public static void Start(string machine, Dictionary<string,string> queryParameters,CancellationToken token)
        {
            string hostname = machine;
            string useConnectionStringFile = queryParameters["useConnectionStringFile"];
            string username = queryParameters["username"];
            string password = queryParameters["password"];
            string connectionStringFilePath = queryParameters["connectionStringFilePath"];
            string xpath = queryParameters["xpath"];
            string query = queryParameters["query"];
            bool machineOnline = false;
            for(int i = 0; i < 3; i++)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                try
                {
                    Ping testConnection = new Ping();
                    Debug.WriteLine("Pinging " + hostname);
                    PingReply reply = testConnection.Send(hostname, 1000);
                    if (reply.Status != IPStatus.Success)
                    {
                        Debug.WriteLine("Ping failed to " + hostname + " reply was " + reply.Status.ToString());
                    }
                    else if (reply.Status == IPStatus.Success) {
                        machineOnline = true;
                        break;
                    }
                }
                catch (PingException pe)
                {
                    Debug.WriteLine("Ping timeout to " + hostname + " " + pe.Message);
                }
            }
            if (token.IsCancellationRequested)
            {
                return;
            }
            if (!machineOnline)
            {
                UpdateMachinesError(hostname);
                UpdateMachinesProcessing(hostname, token);
                return;
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = hostname;
            if (useConnectionStringFile == "false")
            {
                builder.UserID = username;
                builder.Password = password;
            }
            else if (useConnectionStringFile == "true")
            {
                string connectionStringFilePathFull = @"\\" + hostname + @"\" + connectionStringFilePath;
                if (FileExistsTimeout(connectionStringFilePathFull, 5000))
                {
                    XmlDocument connectionStringFile = new XmlDocument();
                    connectionStringFile.Load(connectionStringFilePathFull);
                    XmlNodeList matchingNodes = connectionStringFile.SelectNodes(xpath);
                    string connectionString = matchingNodes[0].InnerText;
                    connectionString = Regex.Replace(connectionString, "Provider=.+?;", "");
                    builder.ConnectionString = connectionString;
                }
                else
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    Debug.WriteLine("Connection string file not found for " + hostname);
                    UpdateMachinesError(hostname);
                    UpdateMachinesProcessing(hostname, token);
                    return;
                }
            }
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                try
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    //token.Register(() => connection.Close());
                    connection.Open();
                    Debug.WriteLine("Connected to " + hostname);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        try
                        {
                            DataTable table = new DataTable();
                            Debug.WriteLine("Querying " + hostname);
                            if (token.IsCancellationRequested)
                            {
                                adapter.Dispose();
                                connection.Close();
                                return;
                            }
                            adapter.Fill(table);
                            Debug.WriteLine("Query returned " + table.Rows.Count + " rows from " + hostname);
                            if (!table.Columns.Contains("Hostname"))
                            {
                                table.Columns.Add("Hostname", typeof(string));
                            }
                            foreach (DataRow row in table.Rows)
                            {
                                row["Hostname"] = hostname;
                            }
                            Debug.WriteLine("Merging table from " + hostname);
                            if (token.IsCancellationRequested)
                            {
                                adapter.Dispose();
                                connection.Close();
                                return;
                            }
                            lock (Core.form.mainTable.Rows.SyncRoot)
                            {
                                Core.form.mainTable.Merge(table);
                            }
                            Debug.WriteLine("Table successfully merged from " + hostname);
                            UpdateMachinesSuccessful(hostname);
                            adapter.Dispose();
                        }
                        catch (Exception ex)
                        {
                            UpdateMachinesError(hostname);
                            Debug.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                            adapter.Dispose();
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    UpdateMachinesError(hostname);
                    Debug.WriteLine("Failed to connect to " + hostname);
                    Debug.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            if (token.IsCancellationRequested)
            {
                return;
            }
            UpdateMachinesProcessing(hostname, token);
        }
    }

    public static class QueryMachines
    {
        public static void StartQuery(object obj)
        {
            string directory = (string)obj;
            DirectoryEntry entry = new DirectoryEntry(@"LDAP://" + directory);
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = ("(objectClass=computer)");
            mySearcher.SizeLimit = int.MaxValue;
            mySearcher.PageSize = int.MaxValue;
            try
            {
                SearchResultCollection results = mySearcher.FindAll();
                Core.machinesQuerying = results.Count;
                foreach (SearchResult result in results)
                {
                    Thread getComputerNameThread = new Thread(QueryMachines.GetComputerName);
                    getComputerNameThread.Name = "getComputerNameThread";
                    getComputerNameThread.Start(result);
                }
            }
            catch
            {
                Core.machinesQuerying = 0;
            }
            mySearcher.Dispose();
            entry.Dispose();
        }

        public static void GetComputerName(object obj)
        {
            SearchResult resEnt = (SearchResult)obj;
            string ComputerName = resEnt.GetDirectoryEntry().Name;
            if (ComputerName.StartsWith("CN="))
            {
                ComputerName = ComputerName.Remove(0, "CN=".Length).ToUpper();
            }
            Debug.WriteLine(ComputerName);
            Core.form.machines.Add(ComputerName);
            Interlocked.Decrement(ref Core.machinesQuerying);
            if (Interlocked.Read(ref Core.machinesQuerying) == 0)
            {
                Core.form.AddMachine();
            }
        }
    }
}
