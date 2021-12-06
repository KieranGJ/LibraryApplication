using LibraryApplication.Books;
using LibraryApplication.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApplication
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReplacingBooks rb = new ReplacingBooks();
            EnterUsername eu = new EnterUsername("ReplacingBooks");
            this.Hide();
            eu.ShowDialog();
            this.Close();
        }

        
        private void StartScreen_Load(object sender, EventArgs e)
        {

                  
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CallNumbers_Click(object sender, EventArgs e)
        {
            EnterUsername eu = new EnterUsername("CallNumbers");
            this.Hide();
            eu.ShowDialog();
            this.Close();

            //CallNumbers cn = new CallNumbers();
            //this.Hide();
            //cn.ShowDialog();
            //this.Close();
        }

        private void AreaIdentification_Click(object sender, EventArgs e)
        {
            //IdentifyAreas ia = new IdentifyAreas();
            EnterUsername eu = new EnterUsername("IdentifyAreas");
            this.Hide();
            eu.ShowDialog();
            this.Close();
        }
    }
}
