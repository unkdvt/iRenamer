using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    lblpath.Text = folderBrowserDialog1.SelectedPath;
                    DirectoryInfo d = new DirectoryInfo(folderBrowserDialog1.SelectedPath);

                    foreach (DirectoryInfo s in d.GetDirectories())
                    {                                                
                        string name = s.FullName.Remove(0, s.FullName.LastIndexOf('\\') + 1).Trim();
                        string[] a = name.Split(new char[] { ' ' }, 2);
                        if (a.Length > 1)                        {
                            string number = a[0].Trim();
                            string fullname = a[1].Trim();
                            listBox1.Items.Add(number);
                            listBox2.Items.Add(fullname);
                            listBox3.Items.Add(fullname + " - " + number);
                        }
                    }
                    System.IO.Directory.CreateDirectory(folderBrowserDialog1.SelectedPath + "\\rename\\" + name.Split(' ')[1] + ' ' + name.Split(' ')[0]);
                }

            }
            catch { }
        }
    }
}
