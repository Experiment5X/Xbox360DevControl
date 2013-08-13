using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace XboxCheatEngine
{
    public partial class CommandSender : Form
    {
        public CommandSender(XboxDevConsole console)
        {
            InitializeComponent();
            this.console = console;
        }

        class Command
        {
            private List<string> usages = new List<string>();

            public string CommandString { get; set; }
            public string Function { get; set; }
            public List<string> Usages { get { return usages; } }
        }

        List<Command> commands = new List<Command>();
        XboxDevConsole console;
        byte[] binaryData;

        private void CommandSender_Load(object sender, EventArgs e)
        {
            // this file contains all of the valid commands for the console, as well as information
            // about each command
            StreamReader commandsFile = new StreamReader("C:\\Users\\Adam\\Desktop\\commands.txt");

            string line;
            while ((line = commandsFile.ReadLine()) != null)
            {
                string[] tokens = line.Split(new char[] { ':' });

                Command command = new Command();
                command.CommandString = tokens[0];
                command.Function = tokens[1];

                for (int i = 2; i < tokens.Length; i++)
                    command.Usages.Add(tokens[i]);

                cmbxCommands.Items.Add(command.CommandString);
                commands.Add(command);
            }

            commandsFile.Close();
        }

        private void cmbxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxCommands.SelectedIndex == -1)
                return;

            Command curCommand = commands[cmbxCommands.SelectedIndex];

            txtCommandInfo.Text = "Function called: " + curCommand.Function + "\r\n";
            txtCommandInfo.Text += "Usage:\r\n";

            if (curCommand.Usages.Count == 0)
            {
                txtCommandInfo.Text += "\tNo arguments";
            }
            else
            {
                foreach (string usage in curCommand.Usages)
                    txtCommandInfo.Text += "\t" + curCommand.CommandString + " " + usage + "\r\n"; 
            }
        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            try
            {
                lstStrings.Items.Clear();
                binaryData = null;

                txtResponse.Text = console.SendTextCommand(cmbxCommands.Text);

                // only receive strings if it's neccessary
                if (txtResponse.Text.Contains("202"))
                {
                    foreach (string resp in console.RecieveStrings())
                        lstStrings.Items.Add(resp);
                    lstStrings.Enabled = true;
                }
                else
                {
                    lstStrings.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstStrings.SelectedIndex == -1)
                return;

            Clipboard.SetText(lstStrings.SelectedItem.ToString());
        }
    }
}
