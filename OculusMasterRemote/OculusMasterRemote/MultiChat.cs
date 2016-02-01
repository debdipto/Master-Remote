using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvergreenMasterRemote
{
    public partial class MultiChat : UserControl
    {
        frm_Main main;
        public MultiChat(frm_Main _main)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            main = _main;
        }

        public void sendData()
        {
            main.sendMnemonic(txtb_Input.Text);
            displayLine(EvergreenMasterRemote.Properties.Settings.Default.Username + ">" + txtb_Input.Text);
            txtb_Input.Text = String.Empty;
        }

        public void displayLine(String message)
        {
            txtb_Display.Text += message + Environment.NewLine;
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            sendData();
        }

        private void txtb_Input_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sendData();
            }
        }
    }
}
