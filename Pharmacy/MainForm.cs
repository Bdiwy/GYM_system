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
    public partial class btnDel : Form
    {
        public btnDel()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try {

                // check that the user enter the file name
                if (txtFileName.Text.Trim() != "")
                {

                    // ID mustn't Repeated
                    StreamReader srCheck = new StreamReader(txtFileName.Text + ".txt");

                    // all data of the file in the valriable(strCheck)
                    string strCheck = srCheck.ReadToEnd();

                    // close the file 
                    srCheck.Close();


                    // check the "id syntax" that exist in the file 
                    /*
                    we deteremine the syntax is 
                    name + \t
                    id + \t
                    price + \t
                    */
                    if (strCheck.Contains(txtid.Text + "\t"))
                    {
                        MessageBox.Show("this ID is exist, please change it and try again.");
                    }
                    else
                    {

                        // select the file to append to it 
                        // true : if the file exist will append to it, and if not exist will create a new file 
                        StreamWriter sw = new StreamWriter(txtFileName.Text.Trim() + ".txt", true);

                        // store the data that exist on the text boxes into valriable 
                        string AllData = txtid.Text + "\t" +
                                         txtname.Text + "\t" +
                                         txtprice.Text + " LE";

                        // write the data in the file 
                        sw.WriteLine(AllData);

                        // close the file
                        sw.Close();

                        // print message to the user 
                        MessageBox.Show("Data Added To The File successfully.");

                        // clear the text in the textboxs
                        txtprice.Clear();
                        txtname.Clear();
                        txtid.Clear();

                        // put the curor on txtname
                        txtname.Focus();

                    }

                }
                else
                {

                    MessageBox.Show("please write the file name to write in it.");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try {

                if (txtFileName.Text.Trim() != "") {

                    // create new file if not exist
                    StreamWriter sw = new StreamWriter(txtFileName.Text + ".txt", true);
                    
                    // print message to the user 
                    MessageBox.Show("file created successfully.");
                    
                    // clear the txtFileName
                    txtFileName.Clear();
                    
                    // close the file
                    sw.Close();

                }
                else {

                    // print message to the user 
                    MessageBox.Show("please enter the file name");
                
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            /*
            =======================
            === search using ID ===
            =======================
            */
            try
            {
                // if txtID not empty work 
                if (txtid.Text.Trim() != "")
                {
                    // make streamReader to read lines in the file 
                    StreamReader sr = new StreamReader(txtFileName.Text + ".txt");
                    // carry line in every loop 
                    string line = "";
                    // used to if the ID found or not 
                    bool found = false;
                    do
                    {
                        // read each line
                        line = sr.ReadLine();
                        /* 
                        last of the loop must = null 
                       thus line != null work 
                        */
                        if (line != null)
                        {
                            // make array that split the line (ID,name,address)
                            // split the line if exist '\t'
                            string[] arrData = line.Split('\t');
                            // if get ID 
                            if (arrData[0] == txtid.Text)
                            {
                                // make found = true 
                                found = true;
                                // put the data in the txtBoxes
                                txtname.Text = arrData[1];
                                txtid.Text = arrData[0];
                                txtprice.Text = arrData[2];
                                // at the end stop Loop 
                                break;
                            }
                        }
                    }
                    // loop still running if the condition ture 
                    while (line != null);
                    // after loop, and after finishing close the file
                    sr.Close();
                    // if not found ID
                    if (!found)
                    {
                        MessageBox.Show("this ID not found");
                        txtid.Focus();
                        txtid.SelectAll();
                        txtname.Clear();
                        txtprice.Clear();
                    }
                }
                // if txtID is empty 
                else
                {
                    MessageBox.Show("please enter ID and try again.");
                    txtid.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Display dis = new Display();
            dis.Show();
            this.Hide();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtFileName.Text.Trim() != "") {

                    File.Delete(txtFileName.Text + ".txt");
                    MessageBox.Show("file deleted.");
                    txtFileName.Clear();

                }
                else {
                    MessageBox.Show("please enter the file name to delete it.");
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

            }
        }
    }