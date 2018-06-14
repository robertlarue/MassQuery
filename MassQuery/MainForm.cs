using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
using System.Net.NetworkInformation;
using System.Xml;
using System.DirectoryServices;
using System.Text.RegularExpressions;
using System.Diagnostics;
using FastColoredTextBoxNS;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MassQuery
{
    public partial class MainForm : Form
    {
        delegate void ReturnDataCallback();
        delegate void LoadMachinesCallback();
        delegate void AddMachineCallback(string machineName);
        delegate void AddConfigCallback();
        delegate void UpdateStatusCallback(Dictionary<string,string> status);

        public DataTable mainTable = new DataTable();
        public DataTable cachedTable = new DataTable();
        public BindingList<string> configs = new BindingList<string>();
        public string currentConfigInDropdown = null;
        public BindingList<string> machines = new BindingList<string>();
        public BindingList<string> filteredMachines = new BindingList<string>();
        public List<string> machinesSuccess = new List<string>();
        public List<string> machinesError = new List<string>();
        public DataGridViewColumn sortColumn = null;
        public System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.None;
        public static string machineListPath = "";

        public static DateTime queryAllTimerStartTime;

        public CancellationTokenSource cancellationSource = new CancellationTokenSource();

        public static WavyLineStyle errorStyle = new WavyLineStyle(255, Color.Red);

        public IntPtr windowHandle;

        public MainForm()
        {
            InitializeComponent();
        }
        public void ReturnData()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.dataGridView.InvokeRequired)
            {
                ReturnDataCallback d = new ReturnDataCallback(ReturnData);
                try
                {
                    this.Invoke(d, new object[] { });
                }
                catch
                {
                    Application.Exit();
                }
            }
            else
            {
                machinesProcessingLabel.Text = string.Format("Processing: {0}", Interlocked.Read(ref Core.machinesProcessing));
                machinesSuccessfulLabel.Text = string.Format("Success: {0}", Interlocked.Read(ref Core.machinesSuccessful));
                machinesErrorLabel.Text = string.Format("Error: {0}", Interlocked.Read(ref Core.machinesError));

                Debug.WriteLine(string.Format("Refreshing Data Grid View with {0} rows from datatable",mainTable.Rows.Count));
                if (mainTable.Rows.Count > 0)
                {
                    if (sortColumn == null)
                    {
                        mainTable.DefaultView.Sort = "Hostname ASC";
                    }
                    else
                    {
                        if (mainTable.Columns.Contains(sortColumn.Name))
                        {
                            string sort = string.Format("[{0}] ", sortColumn.Name);
                            switch (sortOrder)
                            {
                                case System.Windows.Forms.SortOrder.Ascending:
                                    sort += "ASC";
                                    break;
                                case System.Windows.Forms.SortOrder.Descending:
                                    sort += "DESC";
                                    break;
                            }
                            mainTable.DefaultView.Sort = sort;
                        }
                        else
                        {
                            mainTable.DefaultView.Sort = "Hostname ASC";
                        }
                    }
                }
                bool autoSizeColumns = false;
                if(dataGridView.RowCount == 0)
                {
                    autoSizeColumns = true;
                }
                this.dataGridView.DataSource = mainTable;
                this.dataGridView.Refresh();
                if (autoSizeColumns) {
                    dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    foreach (DataGridViewColumn c in dataGridView.Columns)
                    if (c.Width > dataGridView.Width)
                    {
                        c.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        c.Width = dataGridView.Width;
                    }
                }
                Debug.WriteLine("Data Grid View Refresh Complete");
                queryAllTimer.Stop();
                updateQueryAllTimerLabel();
                queryBtn.Enabled = true;
                cancelBtn.Enabled = false;
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, windowHandle);
                filteredMachinesListBox.Refresh();
                UpdateStatus(new Dictionary<string, string> { { "queryStatusLabel", string.Format("{0} rows returned", mainTable.Rows.Count) } });
            }
        }

        public void AddMachine(string machineName)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.machinesListBox.InvokeRequired)
            {
                AddMachineCallback d = new AddMachineCallback(AddMachine);
                try
                {
                    this.Invoke(d, new object[] { machineName });
                }
                catch
                {
                    Application.Exit();
                }
            }
            else
            {
                machines.Add(machineName);
            }
        }

        public void LoadMachines()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.machinesListBox.InvokeRequired)
            {
                LoadMachinesCallback d = new LoadMachinesCallback(LoadMachines);
                try
                {
                    this.Invoke(d, new object[] { });
                }
                catch
                {
                    Application.Exit();
                }
            }
            else
            {
                UpdateStatus(new Dictionary<string, string> { { "queryStatusLabel", "" } });
                List<string> machinesSorted = machines.ToList();
                machinesSorted.Sort();
                machines = new BindingList<string>(machinesSorted);
                machinesListBox.DataSource = machines;
                filterMachines();
                filteredMachinesListBox.DataSource = filteredMachines;
            }
        }

        public void AddConfig()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.configFileTextBox.InvokeRequired)
            {
                AddConfigCallback d = new AddConfigCallback(AddConfig);
                try
                {
                    this.Invoke(d, new object[] { });
                }
                catch
                {
                    Application.Exit();
                }
            }
            else
            {
                List<string> configsSorted = configs.ToList();
                configsSorted.Sort();
                configsSorted.Insert(0, "Autosave Config");
                configs = new BindingList<string>(configsSorted);
                configFileTextBox.DataSource = configs;
                if (currentConfigInDropdown != null)
                {
                    configFileTextBox.SelectedIndex = configFileTextBox.FindStringExact(currentConfigInDropdown);
                }
                else
                {
                    configFileTextBox.SelectedIndex = 0;
                }
            }
        }

        public void UpdateStatus(Dictionary<string,string> status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.queryStatusStrip.InvokeRequired)
            {
                UpdateStatusCallback d = new UpdateStatusCallback(UpdateStatus);
                try
                {
                    this.Invoke(d, new object[] { status });
                }
                catch
                {
                    Application.Exit();
                }
            }
            else
            {
                foreach(string key in status.Keys)
                {
                    switch (key)
                    {
                        case "machinesProcessingLabel":
                            this.machinesProcessingLabel.Text = status[key];
                            Debug.WriteLine("statusStrip: " + status[key]);
                            break;
                        case "queryStatusLabel":
                            this.queryStatusLabel.Text = status[key];
                            break;
                        case "taskBarItemProgressState":
                            TaskbarManager.Instance.SetProgressState((TaskbarProgressBarState)System.Enum.Parse(typeof(TaskbarProgressBarState), status[key]), windowHandle);
                            break;
                        case "taskBarItemProgressValue":
                            try
                            {
                                TaskbarManager.Instance.SetProgressValue(int.Parse(status[key]), (int)Core.machinesTotal, windowHandle);
                                toolStripProgressBar.Value = int.Parse(status[key]);
                                toolStripProgressBar.Maximum = (int)Core.machinesTotal;
                            }
                            catch
                            {

                            }
                            break;
                        case "clearQueryBoxErrors":
                            clearQueryBoxErrors();
                            break;
                        case "highlightErrors":
                            Match match = Regex.Match(status[key], @"(\d+?),(\d+?)");
                            int line = int.Parse(match.Groups[1].ToString());
                            int column = int.Parse(match.Groups[2].ToString());
                            highlightError(line, column);
                            break;
                        case "machinesSuccessfulLabel":
                            this.machinesSuccessfulLabel.Text = status[key];
                            Debug.WriteLine("statusStrip: " + status[key]);
                            break;
                        case "machinesErrorLabel":
                            this.machinesErrorLabel.Text = status[key];
                            Debug.WriteLine("statusStrip: " + status[key]);
                            break;
                        case "returnMachinesSuccessMachinesList":
                            machinesSuccess.Add(status[key]);
                            Debug.WriteLine("Marking " + status[key] + " as success");
                            break;
                        case "returnMachinesErrorMachinesList":
                            machinesError.Add(status[key]);
                            Debug.WriteLine("Marking " + status[key] + " as error");
                            break;
                        case "totalMachinesLabel":
                            totalMachinesLabel.Text = string.Format("Total Machines: {0}", status[key]);
                            break;
                    }
                }

            }
        }

        private void clearQueryBoxErrors()
        {
            int errorStyleIndex = queryBox.GetStyleIndex(errorStyle);
            if (errorStyleIndex != -1)
            {
                StyleIndex errorStyleIndexEnum = (StyleIndex)System.Enum.Parse(typeof(StyleIndex), "Style" + errorStyleIndex);
                foreach (Line line in queryBox.TextSource)
                {
                    line.ClearStyle(errorStyleIndexEnum);
                }
            }
        }

        private void highlightError(int line, int column)
        {
            this.queryBox.GetRange(new Place(column - 1, line - 1), new Place(queryBox.GetLine(line - 1).Length, line - 1)).SetStyle(errorStyle);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            windowHandle = this.Handle;
            toolTip.SetToolTip(queryBtn, "Execute (F5)");
            LoadConfig();
            loadConfigFilesFromRepository(Properties.Settings.Default.configRepository);
        }

        private void LoadConfig()
        {
            dataGridView.DataSource = mainTable;
            this.machinesOUtextBox.Text = Properties.Settings.Default.OU;
            this.usernameInput.Text = Properties.Settings.Default.username;
            this.connStringPathInput.Text = Properties.Settings.Default.connStringPath;
            this.connStringXpathInput.Text = Properties.Settings.Default.xpath;
            this.machineFilterTextBox.Text = Properties.Settings.Default.machineFilter;
            machineListPath = Properties.Settings.Default.machineListPath;
            machinesOURadioBtn.Checked = Properties.Settings.Default.useMachinesFromOU;
            machinesListRadioBtn.Checked = Properties.Settings.Default.useMachineList;
            credsRadioBtn.Checked = Properties.Settings.Default.useSameCredentials;
            connStringRadioBtn.Checked = Properties.Settings.Default.useConnString;
            queryBox.Text = Properties.Settings.Default.query;
            if (Properties.Settings.Default.useMachineList)
            {
                fillMachinesListBoxFromFile(machineListPath);
            }
            else
            {
                loadMachinesFromActiveDiretory();
            }
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            Query(queryBox.Text);
        }

        public void Query(string query)
        {
            usernameInput.BackColor = SystemColors.Window;
            passwordInput.BackColor = SystemColors.Window;

            //Check if there are any machines
            if (filteredMachines.Count <= 0)
            {
                return;
            }

            //Check to see if SQL is Valid
            List<string> errors = Parse(query);
            if (errors != null)
            {
                DialogResult response = MessageBox.Show("The SQL query is not valid. Would you like to continue anyways?", "SQL Parse Error", MessageBoxButtons.YesNo);
                if (response == DialogResult.No)
                {
                    return;
                }
            }

            if(credsRadioBtn.Checked)
            {
                if(passwordInput.Text == "")
                {
                    tabControl.SelectedTab = machinesTabPage;
                    passwordInput.BackColor = Color.Yellow;
                    passwordInput.Focus();
                    return;
                }
                if (usernameInput.Text == "")
                {
                    tabControl.SelectedTab = machinesTabPage;
                    usernameInput.BackColor = Color.Yellow;
                    usernameInput.Focus();
                    return;
                }
            }
            sortColumn = dataGridView.SortedColumn;
            sortOrder = dataGridView.SortOrder;
            
            machinesProcessingLabel.Text = string.Format("Processing: {0}", filteredMachines.Count);
            machinesSuccessfulLabel.Text = "Success: 0";
            machinesErrorLabel.Text = "Error: 0";
            queryAllTimerLabel.Text = "Duration: 0:00.00";
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal,windowHandle);
            TaskbarManager.Instance.SetProgressValue(0,1,windowHandle);
            machinesError.Clear();
            machinesSuccess.Clear();
            queryBtn.Enabled = false;
            cancelBtn.Enabled = true;
            queryAllTimer.Start();
            queryAllTimerStartTime = DateTime.Now;
            cachedTable = mainTable.Copy();
            if (cachedTable.Rows.Count > 0)
            {
                if (sortColumn == null)
                {
                    cachedTable.DefaultView.Sort = "Hostname ASC";
                }
                else
                {
                    if (cachedTable.Columns.Contains(sortColumn.Name))
                    {
                        string sort = sortColumn.Name + " ";
                        switch (sortOrder)
                        {
                            case System.Windows.Forms.SortOrder.Ascending:
                                sort += "ASC";
                                break;
                            case System.Windows.Forms.SortOrder.Descending:
                                sort += "DESC";
                                break;
                        }
                        cachedTable.DefaultView.Sort = sort;
                    }
                    else
                    {
                        cachedTable.DefaultView.Sort = "Hostname ASC";
                    }
                }
            }
            dataGridView.DataSource = cachedTable;
            mainTable = null;
            mainTable = new DataTable();
            

            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.Add("query", query);
            queryParameters.Add("username", usernameInput.Text);
            queryParameters.Add("password", passwordInput.Text);
            queryParameters.Add("connectionStringFilePath", connStringPathInput.Text);
            queryParameters.Add("xpath", connStringXpathInput.Text);

            if (connStringRadioBtn.Checked)
            {
                queryParameters.Add("useConnectionStringFile", "true");
            }
            else if (credsRadioBtn.Checked)
            {
                queryParameters.Add("useConnectionStringFile", "false");
            }
            cancellationSource = new CancellationTokenSource();
            CancellationToken token = cancellationSource.Token;
            Thread queryStarterThread = new Thread(delegate ()
            {
                QueryStarter.StartAll(filteredMachines.ToList(), queryParameters, token);
            });
            queryStarterThread.Name = "sqlQueryMasterThread";
            queryStarterThread.Start();
            Core.activeThreads.Add(queryStarterThread);
        }

        private void loadMachinesBtn_Click(object sender, EventArgs e)
        {
            loadMachinesFromActiveDiretory();
        }

        private void loadMachinesFromActiveDiretory()
        {
            string directory = machinesOUtextBox.Text;
            //if (directory != "")
            //{
                machinesListBox.SelectedIndex = -1;
                machines.Clear();
                filteredMachines.Clear();

                UpdateStatus(new Dictionary<string, string> { { "queryStatusLabel", "Loading machines..." } });
                Thread queryMachinesThread = new Thread(QueryMachines.StartQuery);
                queryMachinesThread.Name = "activeDirectorySearchMasterThread";
                queryMachinesThread.Start(directory);
            //}
        }

        private void loadConfigFilesFromRepository(string directory)
        {
            configs = new BindingList<string>();
            configFileTextBox.DataSource = null;
            Thread queryConfigsThread = new Thread(QueryConfigs.StartQuery);
            queryConfigsThread.Name = "queryConfigsMasterThread";
            queryConfigsThread.Start(directory);
        }

        public void filterMachines()
        {
            try
            {
                Regex machineFilter = new Regex(machineFilterTextBox.Text);
                List<string> filteredMachinesList = machines.Where<string>(f => machineFilter.IsMatch(f)).ToList<string>();
                filteredMachines = new BindingList<string>(filteredMachinesList);
                filteredMachinesListBox.DataSource = filteredMachines;
                totalMachinesLabel.Text = string.Format("Total Machines: {0}", filteredMachines.Count);
            }
            catch
            {

            }
        }

        private void machineFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            filterMachines();
        }

        private void credsRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (credsRadioBtn.Checked)
            {
                usernameInput.Enabled = true;
                usernameLabel.Enabled = true;
                passwordInput.Enabled = true;
                passwordLabel.Enabled = true;
                connStringPathInput.Enabled = false;
                connStringPathLabel.Enabled = false;
                connStringXpathInput.Enabled = false;
                connStringXpathLabel.Enabled = false;
            }
            else
            {
                usernameInput.Enabled = false;
                usernameLabel.Enabled = false;
                passwordInput.Enabled = false;
                passwordLabel.Enabled = false;
                connStringPathInput.Enabled = true;
                connStringPathLabel.Enabled = true;
                connStringXpathInput.Enabled = true;
                connStringXpathLabel.Enabled = true;
            }
        }

        private void machinesOURadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (machinesOURadioBtn.Checked)
            {
                machinesOUtextBox.Enabled = true;
                machinesListTextBox.Enabled = false;
                openMachineListBtn.Enabled = false;
                loadMachinesBtn.Enabled = true;
            }
            else
            {
                machinesOUtextBox.Enabled = false;
                machinesListTextBox.Enabled = true;
                openMachineListBtn.Enabled = true;
                loadMachinesBtn.Enabled = false;
            }
        }

        private void openMachineListBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                machineListPath = openFileDialog.FileName;
                fillMachinesListBoxFromFile(openFileDialog.FileName);
            }
        }

        private void fillMachinesListBoxFromFile(string filePath)
        {
            machinesListTextBox.Text = Path.GetFileName(filePath);
            if (File.Exists(filePath))
            {
                string[] machineArray = File.ReadAllLines(filePath);
                machinesListBox.SelectedIndex = -1;
                machines.Clear();
                foreach (string machine in machineArray)
                {
                    machines.Add(machine);
                }
                machinesListBox.DataSource = machines;
                filterMachines();
            }
        }

        private void clearResultsBtn_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            mainTable.Rows.Clear();
            mainTable.Columns.Clear();
            dataGridView.DataSource = mainTable;
        }

        private void queryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(tabControl.SelectedTab == queryTabPage)
            {
                if(e.KeyCode == Keys.F5)
                {
                    e.SuppressKeyPress = true;
                    Query(queryBox.Text);
                }
            }
        }

        public List<string> Parse(string sql)
        {
            this.UpdateStatus(new Dictionary<string, string> { { "clearQueryBoxErrors", "" } });
            TSql100Parser parser = new TSql100Parser(false);
            TSqlFragment fragment;
            IList<ParseError> errors;
            fragment = parser.Parse(new StringReader(sql), out errors);
            if (errors != null && errors.Count > 0)
            {
                List<string> errorList = new List<string>();
                foreach (var error in errors)
                {
                    errorList.Add(string.Format("Line {0} Column {1} {2}", error.Line, error.Column, error.Message));
                    Dictionary<string, string> newError = new Dictionary<string, string>() { { "highlightErrors", string.Format("{0},{1}", error.Line, error.Column) } };
                    this.UpdateStatus(newError);
                }
                return errorList;
            }
            return null;
        }

        private void queryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thread parseQueryBoxThread = new Thread(delegate() { Parse(queryBox.Text); });
            parseQueryBoxThread.Name = "parseQueryBoxThread";
            parseQueryBoxThread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            Properties.Settings.Default.OU = this.machinesOUtextBox.Text;
            Properties.Settings.Default.username = this.usernameInput.Text;
            Properties.Settings.Default.connStringPath = this.connStringPathInput.Text;
            Properties.Settings.Default.xpath = this.connStringXpathInput.Text;
            Properties.Settings.Default.machineListPath = machineListPath;
            Properties.Settings.Default.query = queryBox.Text;
            Properties.Settings.Default.machineFilter = machineFilterTextBox.Text;
            Properties.Settings.Default.useMachinesFromOU = machinesOURadioBtn.Checked;
            Properties.Settings.Default.useMachineList = machinesListRadioBtn.Checked;
            Properties.Settings.Default.useSameCredentials = credsRadioBtn.Checked;
            Properties.Settings.Default.useConnString = connStringRadioBtn.Checked;
            Properties.Settings.Default.Save();
        }

        private void ImportConfig()
        {
            loadConfigFileDialog.InitialDirectory = Properties.Settings.Default.configRepository;
            DialogResult result = loadConfigFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string configFile = loadConfigFileDialog.FileName;
                string configFileWithoutExtension = Path.GetFileNameWithoutExtension(configFile);
                string importedConfigFile = IndexedFilename(Path.Combine(Properties.Settings.Default.configRepository, configFileWithoutExtension), "config");
                string importedConfigFileWithoutExtension = Path.GetFileNameWithoutExtension(configFile);

                File.Copy(configFile, importedConfigFile);
                Properties.Settings.Default.Load(importedConfigFile);
                LoadConfig();
                configs.Add(importedConfigFileWithoutExtension);
                List<string> configsSorted = configs.ToList();
                configsSorted.Sort();
                configs = new BindingList<string>(configsSorted);
                configFileTextBox.SelectedIndex = configFileTextBox.FindStringExact(configFileWithoutExtension);
            }
        }

        private string IndexedFilename(string stub, string extension)
        {
            int ix = 0;
            string filename = stub + "." + extension;
            do
            {
                ix++;
                filename = String.Format("{0}{1}.{2}", stub, ix, extension);
            } while (File.Exists(filename));
            return filename;
        }
        private void ExportConfig()
        {
            SaveConfig();
            string currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            saveConfigFileDialog.FileName = null;
            saveConfigFileDialog.InitialDirectory = Properties.Settings.Default.configRepository;
            DialogResult result = saveConfigFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.Copy(currentConfig, saveConfigFileDialog.FileName, true);
                loadConfigFilesFromRepository(Properties.Settings.Default.configRepository);

                string configFileWithoutExtension = Path.GetFileNameWithoutExtension(saveConfigFileDialog.FileName);
                currentConfigInDropdown = configFileWithoutExtension;
                //if (!configs.Contains(configFileWithoutExtension))
                //{
                //    configs.Add(configFileWithoutExtension);
                //}
                //List<string> configsSorted = configs.ToList();
                //configsSorted.OrderBy(s => s);
                //configs = new BindingList<string>(configsSorted);
            }
        }


        private void queryAllTimer_Tick(object sender, EventArgs e)
        {
            updateQueryAllTimerLabel();
        }

        private void updateQueryAllTimerLabel()
        {
            TimeSpan elapsed = queryAllTimerStartTime - DateTime.Now;
            queryAllTimerLabel.Text = string.Format("Duration {0}", elapsed.ToString("mm':'ss'.'ff"));
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CancelQuery();
        }

        private void CancelQuery()
        {
            cancellationSource.Cancel();
            Core.machinesProcessing = 0;
            ReturnData();
        }

        private void filteredMachinesListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (machinesSuccess.Contains(filteredMachines[e.Index]))
            {
                Debug.WriteLine(filteredMachines[e.Index] + " painting green");
                e.Graphics.FillRectangle(Brushes.PaleGreen, e.Bounds);
            }
            else if (machinesError.Contains(filteredMachines[e.Index]))
            {
                Debug.WriteLine(filteredMachines[e.Index] + " painting red");
                e.Graphics.FillRectangle(Brushes.LightPink, e.Bounds);
            }
            else
            {
                e.DrawBackground();
            }
            using (Brush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(filteredMachinesListBox.Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
            }
        }

        private void loadConfigButton_Click(object sender, EventArgs e)
        {
            ImportConfig();
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {

            ExportConfig();
        }

        private void configFileTextBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (configFileTextBox.SelectedIndex != 0)
            {
                string configFileWithoutExtension = configFileTextBox.SelectedItem.ToString();
                currentConfigInDropdown = configFileWithoutExtension;
                string configFilePath = Path.Combine(Properties.Settings.Default.configRepository, configFileWithoutExtension + ".config");
                Properties.Settings.Default.Load(configFilePath);
            }
            else
            {
                string currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                currentConfig = null;
                Properties.Settings.Default.Load(currentConfig);
            }
            LoadConfig();
        }

        private void configRepositoryButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog configRepoDialog = new CommonOpenFileDialog();
            configRepoDialog.InitialDirectory = Properties.Settings.Default.configRepository;
            configRepoDialog.IsFolderPicker = true;
            if (configRepoDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Properties.Settings.Default.configRepository = configRepoDialog.FileName;
                loadConfigFilesFromRepository(Properties.Settings.Default.configRepository);
            }
        }

        //private void removeMachineButton_Click(object sender, EventArgs e)
        //{
        //    string filter = machineFilterTextBox.Text;
        //    List<string> machinesToRemove = filteredMachinesListBox.SelectedItems.Cast<string>().ToList();
        //    Match matchMachineList = Regex.Match(filter, @"\^\(\?\!(.*?)\)\.\*(.*)");
        //    if (matchMachineList.Success)
        //    {
        //        string previouslyRemovedMachines = matchMachineList.Groups[1].Value;
        //        MatchCollection machineMatches = Regex.Matches(previouslyRemovedMachines, @"(\w+)");
        //        if (machineMatches.Count > 0)
        //        {
        //            foreach (Match matchingMachine in machineMatches)
        //            {
        //                machinesToRemove.Add(matchingMachine.Groups[1].Value);
        //            }
        //        }
        //        filter = matchMachineList.Groups[2].Value;
        //    }
        //    filter = string.Format("^(?!{1}).*{0}", filter, string.Join("|", machinesToRemove.Distinct()));
        //    machineFilterTextBox.Text = filter;
        //}

        private void removeMachineButton_Click(object sender, EventArgs e)
        {
            string filter = machineFilterTextBox.Text;
            string barePattern = null;
            string outputFilter = null;
            List<string> machinesToAdd = new List<string>();
            List<string> machinesToRemove = filteredMachinesListBox.SelectedItems.Cast<string>().ToList();
            Match matchRemList = Regex.Match(filter, @"\(\?\!(.*?)\)\.\*(.*)");
            if (matchRemList.Success)
            {
                string previouslyRemovedMachines = matchRemList.Groups[1].Value;
                MatchCollection machineMatches = Regex.Matches(previouslyRemovedMachines, @"(\w+)");
                if (machineMatches.Count > 0)
                {
                    foreach (Match matchingMachine in machineMatches)
                    {
                        machinesToRemove.Add(matchingMachine.Groups[1].Value);
                    }
                }
                barePattern = matchRemList.Groups[2].Value;
                //filter = string.Format("^(?!{1}).*(?<add>{0}|{2})", filter, string.Join("|", machinesToRemove.Distinct()), string.Join("|", machinesToAdd.Distinct()));
            }
            Match matchAddList = Regex.Match(filter, @"\(\?<add>(.*?)\)");
            if (matchAddList.Success)
            {
                string previouslyAddedMachines = matchAddList.Groups[1].Value;
                MatchCollection machineMatches = Regex.Matches(previouslyAddedMachines, @"([^|]+)");
                if (machineMatches.Count > 0)
                {
                    foreach (Match matchingMachine in machineMatches)
                    {
                        if (!machinesToRemove.Contains(matchingMachine.Groups[1].Value))
                        {
                            machinesToAdd.Add(matchingMachine.Groups[1].Value);
                        }
                    }
                }

            }
            else if(matchRemList.Success)
            {
                outputFilter = barePattern;
            }
            else
            {
                if (filter.Trim() != "")
                {
                    outputFilter = filter;
                }
                else
                {
                    outputFilter = ".*";
                }
            }

            if (machinesToAdd.Count > 0)
            {
                outputFilter = string.Format("(?<add>{0})", string.Join("|", machinesToAdd.Distinct().OrderBy(m => m)));
            }


            if (machinesToRemove.Count > 0)
            {
                outputFilter = string.Format("^(?!{0}).*{1}", string.Join("|", machinesToRemove.Distinct().OrderBy(m => m)), outputFilter);
            }
            machineFilterTextBox.Text = outputFilter;
        }

        private void addMachineButton_Click(object sender, EventArgs e)
        {
            string filter = machineFilterTextBox.Text;
            string barePattern = null;
            string outputFilter = null;
            List<string> machinesToAdd = machinesListBox.SelectedItems.Cast<string>().ToList();
            List<string> machinesToRemove = new List<string>();
            Match matchRemList = Regex.Match(filter, @"\(\?\!(.*?)\)(.*)");
            if (matchRemList.Success)
            {
                string previouslyRemovedMachines = matchRemList.Groups[1].Value;
                MatchCollection machineMatches = Regex.Matches(previouslyRemovedMachines, @"(\w+)");
                if (machineMatches.Count > 0)
                {
                    foreach (Match matchingMachine in machineMatches)
                    {
                        if (!machinesToAdd.Contains(matchingMachine.Groups[1].Value))
                        {
                            machinesToRemove.Add(matchingMachine.Groups[1].Value);
                        }
                    }
                }
                barePattern = matchRemList.Groups[2].Value;
                //filter = string.Format("^(?!{1}).*(?<add>{0}|{2})", filter, string.Join("|", machinesToRemove.Distinct()), string.Join("|", machinesToAdd.Distinct()));
            }
            Match matchAddList = Regex.Match(filter, @"\(\?<add>(.*?)\)");
            if (matchAddList.Success)
            {
                string previouslyAddedMachines = matchAddList.Groups[1].Value;
                MatchCollection machineMatches = Regex.Matches(previouslyAddedMachines, @"([^|]+)");
                if (machineMatches.Count > 0)
                {
                    foreach (Match matchingMachine in machineMatches)
                    {
                        machinesToAdd.Add(matchingMachine.Groups[1].Value);
                    }
                }
                
            }
            else if(matchRemList.Success)
            {
                machinesToAdd.Add(barePattern);
            }
            else
            {
                if (filter.Trim() != "")
                {
                    machinesToAdd.Add(filter);
                }
                else
                {
                    machinesToAdd.Add(".*");
                }
            }

            if (machinesToAdd.Count > 0)
            {
                outputFilter = string.Format("(?<add>{0})", string.Join("|", machinesToAdd.Distinct().OrderBy(m => m)));
            }

            if(machinesToRemove.Count > 0)
            {
                outputFilter = string.Format("^(?!{0}).*{1}", string.Join("|", machinesToRemove.Distinct().OrderBy(m => m)), outputFilter);
            }
            machineFilterTextBox.Text = outputFilter;
        }

        private void saveResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveResultsFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDataGridViewToCSV(saveResultsFileDialog.FileName);
            }
        }

        void SaveDataGridViewToCSV(string filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            var cellsSelected = dataGridView.SelectedCells;
            dataGridView.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = dataGridView.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            try
            {
                File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView.ClearSelection();
        }
    }
}
