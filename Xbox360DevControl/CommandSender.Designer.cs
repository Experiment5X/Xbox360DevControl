namespace XboxCheatEngine
{
    partial class CommandSender
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
            this.cmbxCommands = new System.Windows.Forms.ComboBox();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommandInfo = new System.Windows.Forms.TextBox();
            this.lstStrings = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.cntxListCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cntxListCopy.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxCommands
            // 
            this.cmbxCommands.FormattingEnabled = true;
            this.cmbxCommands.Location = new System.Drawing.Point(97, 22);
            this.cmbxCommands.Name = "cmbxCommands";
            this.cmbxCommands.Size = new System.Drawing.Size(157, 21);
            this.cmbxCommands.TabIndex = 0;
            this.cmbxCommands.SelectedIndexChanged += new System.EventHandler(this.cmbxCommands_SelectedIndexChanged);
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(270, 20);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(75, 23);
            this.btnSendCommand.TabIndex = 1;
            this.btnSendCommand.Text = "Send";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Command:";
            // 
            // txtCommandInfo
            // 
            this.txtCommandInfo.Location = new System.Drawing.Point(15, 49);
            this.txtCommandInfo.Multiline = true;
            this.txtCommandInfo.Name = "txtCommandInfo";
            this.txtCommandInfo.ReadOnly = true;
            this.txtCommandInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommandInfo.Size = new System.Drawing.Size(330, 96);
            this.txtCommandInfo.TabIndex = 3;
            // 
            // lstStrings
            // 
            this.lstStrings.ContextMenuStrip = this.cntxListCopy;
            this.lstStrings.Enabled = false;
            this.lstStrings.FormattingEnabled = true;
            this.lstStrings.Location = new System.Drawing.Point(16, 264);
            this.lstStrings.Name = "lstStrings";
            this.lstStrings.Size = new System.Drawing.Size(330, 108);
            this.lstStrings.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Response:";
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(16, 180);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(330, 65);
            this.txtResponse.TabIndex = 9;
            // 
            // cntxListCopy
            // 
            this.cntxListCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.cntxListCopy.Name = "cntxListCopy";
            this.cntxListCopy.Size = new System.Drawing.Size(103, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // CommandSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 389);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstStrings);
            this.Controls.Add(this.txtCommandInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.cmbxCommands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CommandSender";
            this.Text = "Command Sender";
            this.Load += new System.EventHandler(this.CommandSender_Load);
            this.cntxListCopy.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxCommands;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommandInfo;
        private System.Windows.Forms.ListBox lstStrings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.ContextMenuStrip cntxListCopy;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}