namespace MassQuery
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.queryTabPage = new System.Windows.Forms.TabPage();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.queryBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.clearResultsBtn = new System.Windows.Forms.Button();
            this.machinesTabPage = new System.Windows.Forms.TabPage();
            this.machinesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filteredMachinesLabel = new System.Windows.Forms.Label();
            this.machinesListBox = new System.Windows.Forms.ListBox();
            this.filteredMachinesListBox = new System.Windows.Forms.ListBox();
            this.allMachinesLabel = new System.Windows.Forms.Label();
            this.addMachineButton = new System.Windows.Forms.Button();
            this.removeMachineButton = new System.Windows.Forms.Button();
            this.credentialSourcePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.connStringPathLabel = new System.Windows.Forms.Label();
            this.connStringPathInput = new System.Windows.Forms.TextBox();
            this.connStringXpathInput = new System.Windows.Forms.TextBox();
            this.connStringXpathLabel = new System.Windows.Forms.Label();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.credsRadioBtn = new System.Windows.Forms.RadioButton();
            this.connStringRadioBtn = new System.Windows.Forms.RadioButton();
            this.machineSourcePanel = new System.Windows.Forms.Panel();
            this.machinesOURadioBtn = new System.Windows.Forms.RadioButton();
            this.machinesListRadioBtn = new System.Windows.Forms.RadioButton();
            this.machinesOUtextBox = new System.Windows.Forms.TextBox();
            this.machinesListTextBox = new System.Windows.Forms.TextBox();
            this.openMachineListBtn = new System.Windows.Forms.Button();
            this.loadMachinesBtn = new System.Windows.Forms.Button();
            this.machineFilterLabel = new System.Windows.Forms.Label();
            this.machineFilterTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.totalMachinesLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.machinesProcessingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.queryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.queryStatusStrip = new System.Windows.Forms.StatusStrip();
            this.machinesSuccessfulLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.machinesErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.queryAllTimerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.queryAllTimer = new System.Windows.Forms.Timer(this.components);
            this.configFileLabel = new System.Windows.Forms.Label();
            this.configFileTextBox = new System.Windows.Forms.ComboBox();
            this.loadConfigButton = new System.Windows.Forms.Button();
            this.saveConfigButton = new System.Windows.Forms.Button();
            this.loadConfigFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveConfigFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.configRepositoryButton = new System.Windows.Forms.Button();
            this.saveResultsFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.dataGridContextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.queryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.queryBox)).BeginInit();
            this.machinesTabPage.SuspendLayout();
            this.machinesLayoutPanel.SuspendLayout();
            this.credentialSourcePanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.machineSourcePanel.SuspendLayout();
            this.queryStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ContextMenuStrip = this.dataGridContextMenuStrip;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(687, 176);
            this.dataGridView.TabIndex = 0;
            // 
            // dataGridContextMenuStrip
            // 
            this.dataGridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveResultsToolStripMenuItem});
            this.dataGridContextMenuStrip.Name = "dataGridContextMenuStrip";
            this.dataGridContextMenuStrip.Size = new System.Drawing.Size(164, 26);
            // 
            // saveResultsToolStripMenuItem
            // 
            this.saveResultsToolStripMenuItem.Name = "saveResultsToolStripMenuItem";
            this.saveResultsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveResultsToolStripMenuItem.Text = "Save Results As...";
            this.saveResultsToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveResultsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsToolStripMenuItem_Click);
            // 
            // queryBtn
            // 
            this.queryBtn.Location = new System.Drawing.Point(6, 6);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(75, 23);
            this.queryBtn.TabIndex = 2;
            this.queryBtn.Text = "Execute";
            this.queryBtn.UseVisualStyleBackColor = true;
            this.queryBtn.Click += new System.EventHandler(this.queryBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.queryTabPage);
            this.tabControl.Controls.Add(this.machinesTabPage);
            this.tabControl.Location = new System.Drawing.Point(3, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(698, 420);
            this.tabControl.TabIndex = 3;
            // 
            // queryTabPage
            // 
            this.queryTabPage.Controls.Add(this.cancelBtn);
            this.queryTabPage.Controls.Add(this.splitContainer);
            this.queryTabPage.Controls.Add(this.clearResultsBtn);
            this.queryTabPage.Controls.Add(this.queryBtn);
            this.queryTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryTabPage.Name = "queryTabPage";
            this.queryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.queryTabPage.Size = new System.Drawing.Size(690, 394);
            this.queryTabPage.TabIndex = 0;
            this.queryTabPage.Text = "Query";
            this.queryTabPage.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Location = new System.Drawing.Point(87, 6);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 35);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.queryBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer.Size = new System.Drawing.Size(687, 359);
            this.splitContainer.SplitterDistance = 179;
            this.splitContainer.TabIndex = 5;
            // 
            // queryBox
            // 
            this.queryBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.queryBox.AutoIndentCharsPatterns = "";
            this.queryBox.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.queryBox.BackBrush = null;
            this.queryBox.CharHeight = 15;
            this.queryBox.CharWidth = 7;
            this.queryBox.CommentPrefix = "--";
            this.queryBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.queryBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.queryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.queryBox.IsReplaceMode = false;
            this.queryBox.Language = FastColoredTextBoxNS.Language.SQL;
            this.queryBox.LeftBracket = '(';
            this.queryBox.Location = new System.Drawing.Point(0, 0);
            this.queryBox.Name = "queryBox";
            this.queryBox.Paddings = new System.Windows.Forms.Padding(0);
            this.queryBox.RightBracket = ')';
            this.queryBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.queryBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("queryBox.ServiceColors")));
            this.queryBox.Size = new System.Drawing.Size(687, 179);
            this.queryBox.TabIndex = 3;
            this.queryBox.Zoom = 100;
            this.queryBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.queryBox_TextChanged);
            // 
            // clearResultsBtn
            // 
            this.clearResultsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearResultsBtn.Location = new System.Drawing.Point(609, 6);
            this.clearResultsBtn.Name = "clearResultsBtn";
            this.clearResultsBtn.Size = new System.Drawing.Size(75, 23);
            this.clearResultsBtn.TabIndex = 4;
            this.clearResultsBtn.Text = "Clear Table";
            this.clearResultsBtn.UseVisualStyleBackColor = true;
            this.clearResultsBtn.Click += new System.EventHandler(this.clearResultsBtn_Click);
            // 
            // machinesTabPage
            // 
            this.machinesTabPage.Controls.Add(this.machinesLayoutPanel);
            this.machinesTabPage.Controls.Add(this.credentialSourcePanel);
            this.machinesTabPage.Controls.Add(this.machineSourcePanel);
            this.machinesTabPage.Controls.Add(this.machineFilterLabel);
            this.machinesTabPage.Controls.Add(this.machineFilterTextBox);
            this.machinesTabPage.Location = new System.Drawing.Point(4, 22);
            this.machinesTabPage.Name = "machinesTabPage";
            this.machinesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.machinesTabPage.Size = new System.Drawing.Size(690, 394);
            this.machinesTabPage.TabIndex = 1;
            this.machinesTabPage.Text = "Machines";
            this.machinesTabPage.UseVisualStyleBackColor = true;
            // 
            // machinesLayoutPanel
            // 
            this.machinesLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.machinesLayoutPanel.ColumnCount = 3;
            this.machinesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.machinesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.machinesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.machinesLayoutPanel.Controls.Add(this.filteredMachinesLabel, 2, 0);
            this.machinesLayoutPanel.Controls.Add(this.machinesListBox, 0, 1);
            this.machinesLayoutPanel.Controls.Add(this.filteredMachinesListBox, 2, 1);
            this.machinesLayoutPanel.Controls.Add(this.allMachinesLabel, 0, 0);
            this.machinesLayoutPanel.Controls.Add(this.addMachineButton, 1, 2);
            this.machinesLayoutPanel.Controls.Add(this.removeMachineButton, 1, 3);
            this.machinesLayoutPanel.Location = new System.Drawing.Point(6, 147);
            this.machinesLayoutPanel.Name = "machinesLayoutPanel";
            this.machinesLayoutPanel.RowCount = 5;
            this.machinesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.machinesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.machinesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.machinesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.machinesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.machinesLayoutPanel.Size = new System.Drawing.Size(531, 245);
            this.machinesLayoutPanel.TabIndex = 22;
            // 
            // filteredMachinesLabel
            // 
            this.filteredMachinesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filteredMachinesLabel.AutoSize = true;
            this.filteredMachinesLabel.Location = new System.Drawing.Point(283, 0);
            this.filteredMachinesLabel.Name = "filteredMachinesLabel";
            this.filteredMachinesLabel.Size = new System.Drawing.Size(245, 13);
            this.filteredMachinesLabel.TabIndex = 23;
            this.filteredMachinesLabel.Text = "Filtered Machines";
            // 
            // machinesListBox
            // 
            this.machinesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.machinesListBox.FormattingEnabled = true;
            this.machinesListBox.Location = new System.Drawing.Point(3, 19);
            this.machinesListBox.Name = "machinesListBox";
            this.machinesLayoutPanel.SetRowSpan(this.machinesListBox, 4);
            this.machinesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.machinesListBox.Size = new System.Drawing.Size(244, 223);
            this.machinesListBox.TabIndex = 5;
            // 
            // filteredMachinesListBox
            // 
            this.filteredMachinesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filteredMachinesListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filteredMachinesListBox.FormattingEnabled = true;
            this.filteredMachinesListBox.Location = new System.Drawing.Point(283, 19);
            this.filteredMachinesListBox.Name = "filteredMachinesListBox";
            this.machinesLayoutPanel.SetRowSpan(this.filteredMachinesListBox, 4);
            this.filteredMachinesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filteredMachinesListBox.Size = new System.Drawing.Size(245, 223);
            this.filteredMachinesListBox.TabIndex = 21;
            this.filteredMachinesListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.filteredMachinesListBox_DrawItem);
            // 
            // allMachinesLabel
            // 
            this.allMachinesLabel.AutoSize = true;
            this.allMachinesLabel.Location = new System.Drawing.Point(3, 0);
            this.allMachinesLabel.Name = "allMachinesLabel";
            this.allMachinesLabel.Size = new System.Drawing.Size(67, 13);
            this.allMachinesLabel.TabIndex = 22;
            this.allMachinesLabel.Text = "All Machines";
            // 
            // addMachineButton
            // 
            this.addMachineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addMachineButton.Location = new System.Drawing.Point(253, 76);
            this.addMachineButton.Name = "addMachineButton";
            this.addMachineButton.Size = new System.Drawing.Size(24, 51);
            this.addMachineButton.TabIndex = 24;
            this.addMachineButton.Text = ">";
            this.addMachineButton.UseVisualStyleBackColor = true;
            this.addMachineButton.Click += new System.EventHandler(this.addMachineButton_Click);
            // 
            // removeMachineButton
            // 
            this.removeMachineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeMachineButton.Location = new System.Drawing.Point(253, 133);
            this.removeMachineButton.Name = "removeMachineButton";
            this.removeMachineButton.Size = new System.Drawing.Size(24, 51);
            this.removeMachineButton.TabIndex = 25;
            this.removeMachineButton.Text = "<";
            this.removeMachineButton.UseVisualStyleBackColor = true;
            this.removeMachineButton.Click += new System.EventHandler(this.removeMachineButton_Click);
            // 
            // credentialSourcePanel
            // 
            this.credentialSourcePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.credentialSourcePanel.Controls.Add(this.tableLayoutPanel);
            this.credentialSourcePanel.Controls.Add(this.credsRadioBtn);
            this.credentialSourcePanel.Controls.Add(this.connStringRadioBtn);
            this.credentialSourcePanel.Location = new System.Drawing.Point(6, 62);
            this.credentialSourcePanel.Name = "credentialSourcePanel";
            this.credentialSourcePanel.Size = new System.Drawing.Size(531, 54);
            this.credentialSourcePanel.TabIndex = 20;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.usernameInput, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.connStringPathLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.connStringPathInput, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.connStringXpathInput, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.connStringXpathLabel, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.passwordInput, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.usernameLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.passwordLabel, 2, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(110, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(418, 45);
            this.tableLayoutPanel.TabIndex = 19;
            // 
            // usernameInput
            // 
            this.usernameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameInput.Enabled = false;
            this.usernameInput.Location = new System.Drawing.Point(68, 3);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(140, 20);
            this.usernameInput.TabIndex = 11;
            // 
            // connStringPathLabel
            // 
            this.connStringPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.connStringPathLabel.AutoSize = true;
            this.connStringPathLabel.Location = new System.Drawing.Point(3, 22);
            this.connStringPathLabel.Name = "connStringPathLabel";
            this.connStringPathLabel.Size = new System.Drawing.Size(48, 23);
            this.connStringPathLabel.TabIndex = 17;
            this.connStringPathLabel.Text = "File Path";
            this.connStringPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // connStringPathInput
            // 
            this.connStringPathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStringPathInput.Location = new System.Drawing.Point(68, 25);
            this.connStringPathInput.Name = "connStringPathInput";
            this.connStringPathInput.Size = new System.Drawing.Size(140, 20);
            this.connStringPathInput.TabIndex = 12;
            // 
            // connStringXpathInput
            // 
            this.connStringXpathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connStringXpathInput.Location = new System.Drawing.Point(274, 25);
            this.connStringXpathInput.Name = "connStringXpathInput";
            this.connStringXpathInput.Size = new System.Drawing.Size(141, 20);
            this.connStringXpathInput.TabIndex = 16;
            // 
            // connStringXpathLabel
            // 
            this.connStringXpathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.connStringXpathLabel.AutoSize = true;
            this.connStringXpathLabel.Location = new System.Drawing.Point(214, 22);
            this.connStringXpathLabel.Name = "connStringXpathLabel";
            this.connStringXpathLabel.Size = new System.Drawing.Size(36, 23);
            this.connStringXpathLabel.TabIndex = 18;
            this.connStringXpathLabel.Text = "XPath";
            this.connStringXpathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordInput
            // 
            this.passwordInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordInput.Enabled = false;
            this.passwordInput.Location = new System.Drawing.Point(274, 3);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(141, 20);
            this.passwordInput.TabIndex = 13;
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Enabled = false;
            this.usernameLabel.Location = new System.Drawing.Point(3, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 22);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Enabled = false;
            this.passwordLabel.Location = new System.Drawing.Point(214, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 22);
            this.passwordLabel.TabIndex = 15;
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // credsRadioBtn
            // 
            this.credsRadioBtn.AutoSize = true;
            this.credsRadioBtn.Location = new System.Drawing.Point(5, 6);
            this.credsRadioBtn.Name = "credsRadioBtn";
            this.credsRadioBtn.Size = new System.Drawing.Size(107, 17);
            this.credsRadioBtn.TabIndex = 9;
            this.credsRadioBtn.Text = "Same Credentials";
            this.credsRadioBtn.UseVisualStyleBackColor = true;
            this.credsRadioBtn.CheckedChanged += new System.EventHandler(this.credsRadioBtn_CheckedChanged);
            // 
            // connStringRadioBtn
            // 
            this.connStringRadioBtn.AutoSize = true;
            this.connStringRadioBtn.Checked = true;
            this.connStringRadioBtn.Location = new System.Drawing.Point(5, 32);
            this.connStringRadioBtn.Name = "connStringRadioBtn";
            this.connStringRadioBtn.Size = new System.Drawing.Size(99, 17);
            this.connStringRadioBtn.TabIndex = 10;
            this.connStringRadioBtn.TabStop = true;
            this.connStringRadioBtn.Text = "Conn String File";
            this.connStringRadioBtn.UseVisualStyleBackColor = true;
            // 
            // machineSourcePanel
            // 
            this.machineSourcePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.machineSourcePanel.Controls.Add(this.machinesOURadioBtn);
            this.machineSourcePanel.Controls.Add(this.machinesListRadioBtn);
            this.machineSourcePanel.Controls.Add(this.machinesOUtextBox);
            this.machineSourcePanel.Controls.Add(this.machinesListTextBox);
            this.machineSourcePanel.Controls.Add(this.openMachineListBtn);
            this.machineSourcePanel.Controls.Add(this.loadMachinesBtn);
            this.machineSourcePanel.Location = new System.Drawing.Point(6, 6);
            this.machineSourcePanel.Name = "machineSourcePanel";
            this.machineSourcePanel.Size = new System.Drawing.Size(531, 54);
            this.machineSourcePanel.TabIndex = 19;
            // 
            // machinesOURadioBtn
            // 
            this.machinesOURadioBtn.AutoSize = true;
            this.machinesOURadioBtn.Checked = true;
            this.machinesOURadioBtn.Location = new System.Drawing.Point(6, 7);
            this.machinesOURadioBtn.Name = "machinesOURadioBtn";
            this.machinesOURadioBtn.Size = new System.Drawing.Size(113, 17);
            this.machinesOURadioBtn.TabIndex = 0;
            this.machinesOURadioBtn.TabStop = true;
            this.machinesOURadioBtn.Text = "Machines from OU";
            this.machinesOURadioBtn.UseVisualStyleBackColor = true;
            this.machinesOURadioBtn.CheckedChanged += new System.EventHandler(this.machinesOURadioBtn_CheckedChanged);
            // 
            // machinesListRadioBtn
            // 
            this.machinesListRadioBtn.AutoSize = true;
            this.machinesListRadioBtn.Location = new System.Drawing.Point(6, 33);
            this.machinesListRadioBtn.Name = "machinesListRadioBtn";
            this.machinesListRadioBtn.Size = new System.Drawing.Size(113, 17);
            this.machinesListRadioBtn.TabIndex = 1;
            this.machinesListRadioBtn.Text = "Machines from List";
            this.machinesListRadioBtn.UseVisualStyleBackColor = true;
            // 
            // machinesOUtextBox
            // 
            this.machinesOUtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.machinesOUtextBox.Location = new System.Drawing.Point(126, 4);
            this.machinesOUtextBox.Name = "machinesOUtextBox";
            this.machinesOUtextBox.Size = new System.Drawing.Size(227, 20);
            this.machinesOUtextBox.TabIndex = 2;
            // 
            // machinesListTextBox
            // 
            this.machinesListTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.machinesListTextBox.Enabled = false;
            this.machinesListTextBox.Location = new System.Drawing.Point(125, 30);
            this.machinesListTextBox.Name = "machinesListTextBox";
            this.machinesListTextBox.ReadOnly = true;
            this.machinesListTextBox.Size = new System.Drawing.Size(227, 20);
            this.machinesListTextBox.TabIndex = 3;
            // 
            // openMachineListBtn
            // 
            this.openMachineListBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openMachineListBtn.Enabled = false;
            this.openMachineListBtn.Location = new System.Drawing.Point(358, 28);
            this.openMachineListBtn.Name = "openMachineListBtn";
            this.openMachineListBtn.Size = new System.Drawing.Size(170, 23);
            this.openMachineListBtn.TabIndex = 8;
            this.openMachineListBtn.Text = "Open List";
            this.openMachineListBtn.UseVisualStyleBackColor = true;
            this.openMachineListBtn.Click += new System.EventHandler(this.openMachineListBtn_Click);
            // 
            // loadMachinesBtn
            // 
            this.loadMachinesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadMachinesBtn.Location = new System.Drawing.Point(359, 4);
            this.loadMachinesBtn.Name = "loadMachinesBtn";
            this.loadMachinesBtn.Size = new System.Drawing.Size(169, 23);
            this.loadMachinesBtn.TabIndex = 4;
            this.loadMachinesBtn.Text = "Load Machines";
            this.loadMachinesBtn.UseVisualStyleBackColor = true;
            this.loadMachinesBtn.Click += new System.EventHandler(this.loadMachinesBtn_Click);
            // 
            // machineFilterLabel
            // 
            this.machineFilterLabel.AutoSize = true;
            this.machineFilterLabel.Location = new System.Drawing.Point(8, 125);
            this.machineFilterLabel.Name = "machineFilterLabel";
            this.machineFilterLabel.Size = new System.Drawing.Size(73, 13);
            this.machineFilterLabel.TabIndex = 7;
            this.machineFilterLabel.Text = "Machine Filter";
            // 
            // machineFilterTextBox
            // 
            this.machineFilterTextBox.Location = new System.Drawing.Point(87, 122);
            this.machineFilterTextBox.Name = "machineFilterTextBox";
            this.machineFilterTextBox.Size = new System.Drawing.Size(447, 20);
            this.machineFilterTextBox.TabIndex = 6;
            this.machineFilterTextBox.TextChanged += new System.EventHandler(this.machineFilterTextBox_TextChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "Machines";
            this.openFileDialog.Filter = "All files|*.*";
            // 
            // totalMachinesLabel
            // 
            this.totalMachinesLabel.Name = "totalMachinesLabel";
            this.totalMachinesLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.totalMachinesLabel.Size = new System.Drawing.Size(110, 17);
            this.totalMachinesLabel.Text = "Total Machines: 0";
            this.totalMachinesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // machinesProcessingLabel
            // 
            this.machinesProcessingLabel.Name = "machinesProcessingLabel";
            this.machinesProcessingLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.machinesProcessingLabel.Size = new System.Drawing.Size(86, 17);
            this.machinesProcessingLabel.Text = "Processing: 0";
            this.machinesProcessingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // queryStatusLabel
            // 
            this.queryStatusLabel.Name = "queryStatusLabel";
            this.queryStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.queryStatusLabel.Size = new System.Drawing.Size(162, 17);
            this.queryStatusLabel.Spring = true;
            // 
            // queryStatusStrip
            // 
            this.queryStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalMachinesLabel,
            this.machinesProcessingLabel,
            this.machinesSuccessfulLabel,
            this.machinesErrorLabel,
            this.queryAllTimerLabel,
            this.queryStatusLabel,
            this.toolStripProgressBar});
            this.queryStatusStrip.Location = new System.Drawing.Point(0, 425);
            this.queryStatusStrip.Name = "queryStatusStrip";
            this.queryStatusStrip.Size = new System.Drawing.Size(704, 22);
            this.queryStatusStrip.TabIndex = 4;
            this.queryStatusStrip.Text = "statusStrip1";
            // 
            // machinesSuccessfulLabel
            // 
            this.machinesSuccessfulLabel.Name = "machinesSuccessfulLabel";
            this.machinesSuccessfulLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.machinesSuccessfulLabel.Size = new System.Drawing.Size(70, 17);
            this.machinesSuccessfulLabel.Text = "Success: 0";
            this.machinesSuccessfulLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // machinesErrorLabel
            // 
            this.machinesErrorLabel.Name = "machinesErrorLabel";
            this.machinesErrorLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.machinesErrorLabel.Size = new System.Drawing.Size(54, 17);
            this.machinesErrorLabel.Text = "Error: 0";
            this.machinesErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // queryAllTimerLabel
            // 
            this.queryAllTimerLabel.Name = "queryAllTimerLabel";
            this.queryAllTimerLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.queryAllTimerLabel.Size = new System.Drawing.Size(105, 17);
            this.queryAllTimerLabel.Text = "Duration: 0:00.00";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // queryAllTimer
            // 
            this.queryAllTimer.Tick += new System.EventHandler(this.queryAllTimer_Tick);
            // 
            // configFileLabel
            // 
            this.configFileLabel.AutoSize = true;
            this.configFileLabel.Location = new System.Drawing.Point(110, 5);
            this.configFileLabel.Name = "configFileLabel";
            this.configFileLabel.Size = new System.Drawing.Size(37, 13);
            this.configFileLabel.TabIndex = 23;
            this.configFileLabel.Text = "Config";
            // 
            // configFileTextBox
            // 
            this.configFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFileTextBox.Location = new System.Drawing.Point(150, 1);
            this.configFileTextBox.Name = "configFileTextBox";
            this.configFileTextBox.Size = new System.Drawing.Size(322, 21);
            this.configFileTextBox.TabIndex = 23;
            this.configFileTextBox.SelectionChangeCommitted += new System.EventHandler(this.configFileTextBox_SelectionChangeCommitted);
            // 
            // loadConfigButton
            // 
            this.loadConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadConfigButton.Location = new System.Drawing.Point(543, 1);
            this.loadConfigButton.Name = "loadConfigButton";
            this.loadConfigButton.Size = new System.Drawing.Size(60, 20);
            this.loadConfigButton.TabIndex = 23;
            this.loadConfigButton.Text = "Import";
            this.loadConfigButton.UseVisualStyleBackColor = true;
            this.loadConfigButton.Click += new System.EventHandler(this.loadConfigButton_Click);
            // 
            // saveConfigButton
            // 
            this.saveConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveConfigButton.Location = new System.Drawing.Point(479, 1);
            this.saveConfigButton.Name = "saveConfigButton";
            this.saveConfigButton.Size = new System.Drawing.Size(60, 20);
            this.saveConfigButton.TabIndex = 23;
            this.saveConfigButton.Text = "Save";
            this.saveConfigButton.UseVisualStyleBackColor = true;
            this.saveConfigButton.Click += new System.EventHandler(this.saveConfigButton_Click);
            // 
            // saveConfigFileDialog
            // 
            this.saveConfigFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*";
            // 
            // configRepositoryButton
            // 
            this.configRepositoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configRepositoryButton.Location = new System.Drawing.Point(608, 1);
            this.configRepositoryButton.Name = "configRepositoryButton";
            this.configRepositoryButton.Size = new System.Drawing.Size(93, 20);
            this.configRepositoryButton.TabIndex = 24;
            this.configRepositoryButton.Text = "Open Repo";
            this.configRepositoryButton.UseVisualStyleBackColor = true;
            this.configRepositoryButton.Click += new System.EventHandler(this.configRepositoryButton_Click);
            // 
            // saveResultsFileDialog
            // 
            this.saveResultsFileDialog.Filter = "CSV (Comma Delimited)|*.csv";
            this.saveResultsFileDialog.Title = "Save Grid Results";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 447);
            this.Controls.Add(this.configFileLabel);
            this.Controls.Add(this.configFileTextBox);
            this.Controls.Add(this.loadConfigButton);
            this.Controls.Add(this.saveConfigButton);
            this.Controls.Add(this.configRepositoryButton);
            this.Controls.Add(this.queryStatusStrip);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Mass Query";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.dataGridContextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.queryTabPage.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.queryBox)).EndInit();
            this.machinesTabPage.ResumeLayout(false);
            this.machinesTabPage.PerformLayout();
            this.machinesLayoutPanel.ResumeLayout(false);
            this.machinesLayoutPanel.PerformLayout();
            this.credentialSourcePanel.ResumeLayout(false);
            this.credentialSourcePanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.machineSourcePanel.ResumeLayout(false);
            this.machineSourcePanel.PerformLayout();
            this.queryStatusStrip.ResumeLayout(false);
            this.queryStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage queryTabPage;
        private System.Windows.Forms.TabPage machinesTabPage;
        private System.Windows.Forms.Button loadMachinesBtn;
        private System.Windows.Forms.TextBox machinesListTextBox;
        private System.Windows.Forms.TextBox machinesOUtextBox;
        private System.Windows.Forms.RadioButton machinesListRadioBtn;
        private System.Windows.Forms.RadioButton machinesOURadioBtn;
        private System.Windows.Forms.Label machineFilterLabel;
        private System.Windows.Forms.TextBox machineFilterTextBox;
        private System.Windows.Forms.ListBox machinesListBox;
        private System.Windows.Forms.Button openMachineListBtn;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.TextBox connStringPathInput;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.RadioButton connStringRadioBtn;
        private System.Windows.Forms.RadioButton credsRadioBtn;
        private System.Windows.Forms.Label connStringXpathLabel;
        private System.Windows.Forms.Label connStringPathLabel;
        private System.Windows.Forms.TextBox connStringXpathInput;
        private System.Windows.Forms.Panel credentialSourcePanel;
        private System.Windows.Forms.Panel machineSourcePanel;
        private System.Windows.Forms.ListBox filteredMachinesListBox;
        private System.Windows.Forms.Button clearResultsBtn;
        private System.Windows.Forms.TableLayoutPanel machinesLayoutPanel;
        private System.Windows.Forms.Label allMachinesLabel;
        private System.Windows.Forms.Label filteredMachinesLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private FastColoredTextBoxNS.FastColoredTextBox queryBox;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripStatusLabel totalMachinesLabel;
        private System.Windows.Forms.ToolStripStatusLabel machinesProcessingLabel;
        private System.Windows.Forms.ToolStripStatusLabel queryStatusLabel;
        private System.Windows.Forms.StatusStrip queryStatusStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ToolStripStatusLabel machinesSuccessfulLabel;
        private System.Windows.Forms.ToolStripStatusLabel machinesErrorLabel;
        private System.Windows.Forms.Timer queryAllTimer;
        private System.Windows.Forms.ToolStripStatusLabel queryAllTimerLabel;
        private System.Windows.Forms.ComboBox configFileTextBox;
        private System.Windows.Forms.Label configFileLabel;
        private System.Windows.Forms.Button loadConfigButton;
        private System.Windows.Forms.Button saveConfigButton;
        private System.Windows.Forms.Button addMachineButton;
        private System.Windows.Forms.Button removeMachineButton;
        private System.Windows.Forms.OpenFileDialog loadConfigFileDialog;
        private System.Windows.Forms.SaveFileDialog saveConfigFileDialog;
        private System.Windows.Forms.Button configRepositoryButton;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ContextMenuStrip dataGridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveResultsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveResultsFileDialog;
    }
}

