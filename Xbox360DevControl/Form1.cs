using System;
using System.Windows.Forms;
using XDevkit;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace XboxCheatEngine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            EnableControls(false);
            cmbxBitwidth.SelectedIndex = 0;
        }

        XboxDevConsole console;
        XboxMemoryScanner scanner;
        bool searchStarted = false;

        private void button1_Click(object sender, EventArgs e)
        {
            string trash = Clipboard.GetText();
            string[] lines = trash.Split(new char[] { '\n' });
            string newText = "";

            foreach (string line in lines)
            {
                newText += line.Substring(11) + "\n";
            }

            Clipboard.SetText(newText);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InputDialog dialog = new InputDialog("Enter the console's name", "Console Name", "169.254.66.42");
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;
                string consoleName = dialog.GetText();

                console = new XboxDevConsole(consoleName);
                foreach (CommittedMemoryBlock block in console.CommittedMemory)
                {
                    ListViewItem item = new ListViewItem("0x" + block.Base.ToString("X8"));
                    item.SubItems.Add("0x" + block.Size.ToString("X8"));
                    item.SubItems.Add(block.Protection);

                    lstCommitedMemory.Items.Add(item);

                    cmbxMemRegion.Items.Add("0x" + block.Base.ToString("X8") + "\t|\t" + "0x" + block.Size.ToString("X8"));
                }
                cmbxMemRegion.Items.Add("All Regions");
                cmbxMemRegion.Items.Add("Custom");

                foreach (Module module in console.Modules)
                {
                    ListViewItem item = new ListViewItem(module.Name);
                    item.SubItems.Add("0x" + module.BaseAddress.ToString("X8"));
                    item.SubItems.Add("0x" + module.Size.ToString("X8"));
                    item.SubItems.Add(module.Timestamp.ToShortTimeString());
                    item.SubItems.Add("0x" + module.DataAddress.ToString("X8"));
                    item.SubItems.Add("0x" + module.DataSize.ToString("X8"));
                    item.SubItems.Add(module.Thread.ToString());

                    lstModules.Items.Add(item);
                }

                consoleProperties.SelectedObject = console;
                EnableControls(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.Disconnect();

            lstCommitedMemory.Items.Clear();
            lstModules.Items.Clear();
            consoleProperties.SelectedObject = null;

            EnableControls(false);
        }

        private void EnableControls(bool enabled)
        {
            tabControl1.Enabled = enabled;
            btnOpenTray.Enabled = enabled;
            btnCustomCommand.Enabled = enabled;
            btnDisonnect.Enabled = enabled;
            btnConnect.Enabled = !enabled;
        }

        private void btnCustomCommand_Click(object sender, EventArgs e)
        {
            CommandSender dialog = new CommandSender(console);
            dialog.ShowDialog();
        }

        private void btnOpenTray_Click(object sender, EventArgs e)
        {
            console.SendTextCommand("dvdeject");
        }

        private void txtSearchValue_TextChanged(object sender, EventArgs e)
        {
            btnSearchMemory.Enabled = CheckInput() && txtSearchValue.Text != "";
        }

        private bool CheckInput()
        {
            // I know this is gross, but i really don't see a way around it
            switch (cmbxBitwidth.SelectedIndex)
            {
                case 0:
                {
                    byte trash;
                    if (rdoDecimal.Checked)
                        txtSearchValue.ForeColor = (byte.TryParse(txtSearchValue.Text, out trash)) ? Color.Black : Color.Red;
                    else
                        txtSearchValue.ForeColor = (byte.TryParse(txtSearchValue.Text, System.Globalization.NumberStyles.HexNumber, null, out trash)) ? Color.Black : Color.Red;
                    break;
                }
                case 1:
                {
                    ushort trash;
                    if (rdoDecimal.Checked)
                        txtSearchValue.ForeColor = (ushort.TryParse(txtSearchValue.Text, out trash)) ? Color.Black : Color.Red;
                    else
                        txtSearchValue.ForeColor = (ushort.TryParse(txtSearchValue.Text, System.Globalization.NumberStyles.HexNumber, null, out trash)) ? Color.Black : Color.Red;
                    break;
                }
                case 2:
                {
                    uint trash;
                    if (rdoDecimal.Checked)
                        txtSearchValue.ForeColor = (uint.TryParse(txtSearchValue.Text, out trash)) ? Color.Black : Color.Red;
                    else
                        txtSearchValue.ForeColor = (uint.TryParse(txtSearchValue.Text, System.Globalization.NumberStyles.HexNumber, null, out trash)) ? Color.Black : Color.Red;
                    break;
                }
                case 3:
                {
                    ulong trash;
                    if (rdoDecimal.Checked)
                        txtSearchValue.ForeColor = (ulong.TryParse(txtSearchValue.Text, out trash)) ? Color.Black : Color.Red;
                    else
                        txtSearchValue.ForeColor = (ulong.TryParse(txtSearchValue.Text, System.Globalization.NumberStyles.HexNumber, null, out trash)) ? Color.Black : Color.Red;
                    break;
                }
            }

            return txtSearchValue.ForeColor == Color.Black;
        }

        private void cmbxBitwidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private async void btnSearchMemory_Click(object sender, EventArgs e)
        {
            // start a new search if one hasn't already been started, search through all of memory
            if (!searchStarted)
            {
                // find the heap blocks
                List<CommittedMemoryBlock> heapBlocks = new List<CommittedMemoryBlock>();
                foreach (CommittedMemoryBlock b in console.CommittedMemory)
                    if (b.Base == 0x82000000)
                        heapBlocks.Add(b);

                scanner = new XboxMemoryScanner(console, heapBlocks);

                // grab the user arguments from the UI
                ulong value = ulong.Parse(txtSearchValue.Text, (rdoHex.Checked) ? NumberStyles.HexNumber : NumberStyles.Integer);
                BitWidth bitWidth = (BitWidth)Math.Pow(2, cmbxBitwidth.SelectedIndex);

                // update the UI while searching
                btnSearchMemory.Enabled = false;

                // add all of the results to the list view
                foreach (uint instance in await scanner.FindValue(value, bitWidth))
                    lstMemScanResults.Items.Add("0x" + instance.ToString("X8"));

                // update the UI so the user can perform another search
                btnSearchMemory.Enabled = true;
                tipMemoryScan.SetToolTip(btnSearchMemory, "Search through the results for a new value");

                searchStarted = true;
            }
            // if a search has already been created then only search through the results already found for the updated value
            else
            {
                btnSearchMemory.Enabled = false;

                lstMemScanResults.Clear();
                foreach (uint address in await scanner.NarrowResults(ulong.Parse(txtSearchValue.Text, (rdoHex.Checked) ? NumberStyles.HexNumber : NumberStyles.Integer)))
                    lstMemScanResults.Items.Add("0x" + address.ToString("X8"));

                btnSearchMemory.Enabled = true;
            }
        }

        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void btnNewSearch_Click(object sender, EventArgs e)
        {
            // reset the search
            lstMemScanResults.Items.Clear();
            txtSearchValue.Text = "";
        }

        private void cmbxMemRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // only allow the user to enter a custom memory region if he/she selected 'Custom' from the combo box
            txtCustomMemAddr.Enabled = txtCustomMemLen.Enabled = cmbxMemRegion.SelectedIndex == cmbxMemRegion.Items.Count - 1;
        }
    }
}
