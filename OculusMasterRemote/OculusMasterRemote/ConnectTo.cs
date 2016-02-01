using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvergreenMasterRemote
{
    public partial class ConnectTo : Form
    {
        frm_Main main;
        public ConnectTo(frm_Main _main)
        {
            InitializeComponent();

            main = _main;

            txtb_ServerIP.Text = EvergreenMasterRemote.Properties.Settings.Default.ServerIP;
            chk_AutoConnect.Checked = EvergreenMasterRemote.Properties.Settings.Default.AutoConnect;
            txtb_UserName.Text = EvergreenMasterRemote.Properties.Settings.Default.Username;
            txtb_Password.Text = EvergreenMasterRemote.Properties.Settings.Default.Password;
            chk_RememberMe.Checked = EvergreenMasterRemote.Properties.Settings.Default.RememberMe;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            EvergreenMasterRemote.Properties.Settings.Default.ServerIP = txtb_ServerIP.Text;
            EvergreenMasterRemote.Properties.Settings.Default.AutoConnect = chk_AutoConnect.Checked;

            EvergreenMasterRemote.Properties.Settings.Default.Username = txtb_UserName.Text;
            EvergreenMasterRemote.Properties.Settings.Default.Password = txtb_Password.Text;

            EvergreenMasterRemote.Properties.Settings.Default.RememberMe = chk_RememberMe.Checked;

            EvergreenMasterRemote.Properties.Settings.Default.Save();

            main.setupConnection();
            Dispose();
        }
    }
}
