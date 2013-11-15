using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Projeto_StreetFighter.Other
{
    public partial class FrmQuit : Form
    {
        
        public FrmQuit()
        {
            InitializeComponent();
        }

        private void FrmQuit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                btnQUIT.Focus();
            else if (e.KeyCode == Keys.D)
                btnCancel.Focus();
        }
        

    }
}
