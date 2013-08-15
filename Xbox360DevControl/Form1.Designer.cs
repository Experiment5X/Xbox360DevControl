namespace XboxCheatEngine
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisonnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOpenTray = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCustomCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstModules = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.consoleProperties = new System.Windows.Forms.PropertyGrid();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstCommitedMemory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnNewSearch = new System.Windows.Forms.Button();
            this.chkExtendedSearch = new System.Windows.Forms.CheckBox();
            this.lstMemScanResults = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearchMemory = new System.Windows.Forms.Button();
            this.cmbxBitwidth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoHex = new System.Windows.Forms.RadioButton();
            this.rdoDecimal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.tipMemoryScan = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(644, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisonnect});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(63, 22);
            this.toolStripDropDownButton1.Text = "Console";
            // 
            // btnConnect
            // 
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(133, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // btnDisonnect
            // 
            this.btnDisonnect.Name = "btnDisonnect";
            this.btnDisonnect.Size = new System.Drawing.Size(133, 22);
            this.btnDisonnect.Text = "Disconnect";
            this.btnDisonnect.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenTray,
            this.btnCustomCommand});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(82, 22);
            this.toolStripDropDownButton2.Text = "Commands";
            // 
            // btnOpenTray
            // 
            this.btnOpenTray.Name = "btnOpenTray";
            this.btnOpenTray.Size = new System.Drawing.Size(205, 22);
            this.btnOpenTray.Text = "Open Tray";
            this.btnOpenTray.Click += new System.EventHandler(this.btnOpenTray_Click);
            // 
            // btnCustomCommand
            // 
            this.btnCustomCommand.Name = "btnCustomCommand";
            this.btnCustomCommand.Size = new System.Drawing.Size(205, 22);
            this.btnCustomCommand.Text = "Send Custom Command";
            this.btnCustomCommand.Click += new System.EventHandler(this.btnCustomCommand_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstModules);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(636, 404);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Modules";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lstModules
            // 
            this.lstModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lstModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstModules.FullRowSelect = true;
            this.lstModules.Location = new System.Drawing.Point(3, 3);
            this.lstModules.Name = "lstModules";
            this.lstModules.Size = new System.Drawing.Size(630, 398);
            this.lstModules.TabIndex = 0;
            this.lstModules.UseCompatibleStateImageBehavior = false;
            this.lstModules.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Base Address";
            this.columnHeader5.Width = 113;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Size";
            this.columnHeader6.Width = 83;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Timestamp";
            this.columnHeader8.Width = 83;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Data Address";
            this.columnHeader9.Width = 86;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Data Size";
            this.columnHeader10.Width = 78;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Thread";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.consoleProperties);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(636, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // consoleProperties
            // 
            this.consoleProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleProperties.Location = new System.Drawing.Point(3, 3);
            this.consoleProperties.Name = "consoleProperties";
            this.consoleProperties.Size = new System.Drawing.Size(630, 398);
            this.consoleProperties.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstCommitedMemory);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(636, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Committed Memory";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstCommitedMemory
            // 
            this.lstCommitedMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstCommitedMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommitedMemory.FullRowSelect = true;
            this.lstCommitedMemory.Location = new System.Drawing.Point(3, 3);
            this.lstCommitedMemory.Name = "lstCommitedMemory";
            this.lstCommitedMemory.Size = new System.Drawing.Size(630, 398);
            this.lstCommitedMemory.TabIndex = 0;
            this.lstCommitedMemory.UseCompatibleStateImageBehavior = false;
            this.lstCommitedMemory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Base";
            this.columnHeader1.Width = 197;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 231;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Protection";
            this.columnHeader3.Width = 181;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(644, 430);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.btnNewSearch);
            this.tabPage4.Controls.Add(this.chkExtendedSearch);
            this.tabPage4.Controls.Add(this.lstMemScanResults);
            this.tabPage4.Controls.Add(this.btnSearchMemory);
            this.tabPage4.Controls.Add(this.cmbxBitwidth);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.rdoHex);
            this.tabPage4.Controls.Add(this.rdoDecimal);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.txtSearchValue);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(636, 404);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Memory Scanner";
            // 
            // btnNewSearch
            // 
            this.btnNewSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSearch.Image")));
            this.btnNewSearch.Location = new System.Drawing.Point(239, 7);
            this.btnNewSearch.Name = "btnNewSearch";
            this.btnNewSearch.Size = new System.Drawing.Size(36, 22);
            this.btnNewSearch.TabIndex = 10;
            this.tipMemoryScan.SetToolTip(this.btnNewSearch, "Start a new search");
            this.btnNewSearch.UseVisualStyleBackColor = true;
            this.btnNewSearch.Click += new System.EventHandler(this.btnNewSearch_Click);
            // 
            // chkExtendedSearch
            // 
            this.chkExtendedSearch.AutoSize = true;
            this.chkExtendedSearch.Location = new System.Drawing.Point(200, 57);
            this.chkExtendedSearch.Name = "chkExtendedSearch";
            this.chkExtendedSearch.Size = new System.Drawing.Size(108, 17);
            this.chkExtendedSearch.TabIndex = 9;
            this.chkExtendedSearch.Text = "Extended Search";
            this.chkExtendedSearch.UseVisualStyleBackColor = true;
            // 
            // lstMemScanResults
            // 
            this.lstMemScanResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7});
            this.lstMemScanResults.FullRowSelect = true;
            this.lstMemScanResults.Location = new System.Drawing.Point(11, 82);
            this.lstMemScanResults.Name = "lstMemScanResults";
            this.lstMemScanResults.Size = new System.Drawing.Size(294, 307);
            this.lstMemScanResults.TabIndex = 8;
            this.lstMemScanResults.UseCompatibleStateImageBehavior = false;
            this.lstMemScanResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Address";
            this.columnHeader7.Width = 258;
            // 
            // btnSearchMemory
            // 
            this.btnSearchMemory.Enabled = false;
            this.btnSearchMemory.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchMemory.Image")));
            this.btnSearchMemory.Location = new System.Drawing.Point(200, 7);
            this.btnSearchMemory.Name = "btnSearchMemory";
            this.btnSearchMemory.Size = new System.Drawing.Size(33, 22);
            this.btnSearchMemory.TabIndex = 7;
            this.tipMemoryScan.SetToolTip(this.btnSearchMemory, "Scan your Xbox\'s memory for a value");
            this.btnSearchMemory.UseVisualStyleBackColor = true;
            this.btnSearchMemory.Click += new System.EventHandler(this.btnSearchMemory_Click);
            // 
            // cmbxBitwidth
            // 
            this.cmbxBitwidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxBitwidth.FormattingEnabled = true;
            this.cmbxBitwidth.Items.AddRange(new object[] {
            "[08] Byte",
            "[16] Word",
            "[32] Dword",
            "[64] Qword"});
            this.cmbxBitwidth.Location = new System.Drawing.Point(70, 55);
            this.cmbxBitwidth.Name = "cmbxBitwidth";
            this.cmbxBitwidth.Size = new System.Drawing.Size(124, 21);
            this.cmbxBitwidth.TabIndex = 6;
            this.cmbxBitwidth.SelectedIndexChanged += new System.EventHandler(this.cmbxBitwidth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bit Width:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base:";
            // 
            // rdoHex
            // 
            this.rdoHex.AutoSize = true;
            this.rdoHex.Location = new System.Drawing.Point(150, 35);
            this.rdoHex.Name = "rdoHex";
            this.rdoHex.Size = new System.Drawing.Size(44, 17);
            this.rdoHex.TabIndex = 3;
            this.rdoHex.Text = "Hex";
            this.rdoHex.UseVisualStyleBackColor = true;
            this.rdoHex.CheckedChanged += new System.EventHandler(this.rdoHex_CheckedChanged);
            // 
            // rdoDecimal
            // 
            this.rdoDecimal.AutoSize = true;
            this.rdoDecimal.Checked = true;
            this.rdoDecimal.Location = new System.Drawing.Point(81, 35);
            this.rdoDecimal.Name = "rdoDecimal";
            this.rdoDecimal.Size = new System.Drawing.Size(63, 17);
            this.rdoDecimal.TabIndex = 2;
            this.rdoDecimal.TabStop = true;
            this.rdoDecimal.Text = "Decimal";
            this.rdoDecimal.UseVisualStyleBackColor = true;
            this.rdoDecimal.CheckedChanged += new System.EventHandler(this.rdoHex_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Value:";
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.Location = new System.Drawing.Point(70, 9);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(124, 20);
            this.txtSearchValue.TabIndex = 0;
            this.txtSearchValue.TextChanged += new System.EventHandler(this.txtSearchValue_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 455);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Xbox360 Dev Control";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnConnect;
        private System.Windows.Forms.ToolStripMenuItem btnDisonnect;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem btnOpenTray;
        private System.Windows.Forms.ToolStripMenuItem btnCustomCommand;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lstModules;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid consoleProperties;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lstCommitedMemory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RadioButton rdoHex;
        private System.Windows.Forms.RadioButton rdoDecimal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.ComboBox cmbxBitwidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstMemScanResults;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnSearchMemory;
        private System.Windows.Forms.CheckBox chkExtendedSearch;
        private System.Windows.Forms.Button btnNewSearch;
        private System.Windows.Forms.ToolTip tipMemoryScan;
    }
}

