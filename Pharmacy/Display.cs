using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pharmacy
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnDel mf = new btnDel();
            mf.Show();
            this.Hide();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try {

                if (txtFileName.Text.Trim() != "") {

                    StreamReader sr = new StreamReader(txtFileName.Text + ".txt");
                    string AllData = sr.ReadToEnd();
                    sr.Close();
                    txtAll.Text = AllData;

                }
                else {
                    MessageBox.Show("please enter the file name");
                }

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtAll_EnabledChanged(object sender, EventArgs e)
        {

        }
    }
}
