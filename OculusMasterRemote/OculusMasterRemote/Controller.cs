using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OculusClient;
using AmaranthineServer;
using Newtonsoft.Json;

namespace EvergreenMasterRemote
{
    public partial class Controller : UserControl
    {
        frm_Main main;
        public Controller(frm_Main _main)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            main = _main;
        }

        private void btn_MonitorOn_Click(object sender, EventArgs e)
        {
            main.sendMnemonic(((int)Mnemonics.Actions.monitorOn).ToString());
        }

        private void btn_VolumeUp_Click(object sender, EventArgs e)
        {
            main.sendMnemonic(((int)Mnemonics.Actions.volup).ToString());
        }

        private void btn_MonitorOff_Click(object sender, EventArgs e)
        {
            main.sendMnemonic(((int)Mnemonics.Actions.monitorOff).ToString());
        }

        private void btn_Mute_Click(object sender, EventArgs e)
        {
            main.sendMnemonic(((int)Mnemonics.Actions.mute).ToString());
        }

        private void btn_VolumeDown_Click(object sender, EventArgs e)
        {
            main.sendMnemonic(((int)Mnemonics.Actions.voldown).ToString());
        }
    }
}
