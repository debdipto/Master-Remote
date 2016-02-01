using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmaranthineServer;

namespace EvergreenMasterRemote
{
    public partial class PiClient : UserControl
    {
        frm_Main main;

        public PiClient(frm_Main _main)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            main = _main;
        }

        private void btn_ActivateDev1_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("ActivateDev1");
        }

        private void btn_ActivateDev2_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("ActivateDev2");
        }

        private void btn_ActivateDev3_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("ActivateDev3");
        }

        private void btn_ActivateDev4_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("ActivateDev4");
        }

        private void btn_DeactivateDev1_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("DeacActivateDev1");
        }

        private void btn_DeactivateDev2_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("DeacActivateDev2");
        }

        private void btn_DeactivateDev3_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("DeacActivateDev3");
        }

        private void btn_DeactivateDev4_Click(object sender, EventArgs e)
        {
            main.sendMnemonic("DeacActivateDev4");
        }
    }
}
