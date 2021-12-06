using LibraryApplication.Books;
using LibraryApplication.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApplication.Forms
{
    public partial class EnterUsername : Form
    {
        string intent;
        User user = new User();
        public EnterUsername(string intent)
        {
            this.intent = intent;
            InitializeComponent();
            startButton.Enabled = false;
            happyFace.Visible = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            user = user.Instance();
            user.Username = usernameBox.Text;
            switch (intent)
            {
                case "IdentifyAreas":
                    IdentifyAreas ia = new IdentifyAreas();
                    this.Hide();
                    ia.ShowDialog();
                    this.Close();
                    break;
                case "ReplacingBooks":
                    ReplacingBooks rb = new ReplacingBooks();
                    this.Hide();
                    rb.ShowDialog();
                    this.Close();
                    break;
                case "CallNumbers":
                    CallNumbers cn = new CallNumbers();
                    this.Hide();
                    cn.ShowDialog();
                    this.Close();
                    break;
                default:
                    Console.WriteLine("Intent not established");
                    break;

            }
        }

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            startButton.BackColor = Color.Black;
            startButton.ForeColor = Color.White;
            happyFace.Visible = true;
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            startButton.BackColor = Color.White;
            startButton.ForeColor = Color.Black;
            happyFace.Visible = false;
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            if (usernameBox.Text != "")
            {
                startButton.Enabled = true;
            }
            else
            {
                startButton.Enabled = false;
            }
        }

        private void EnterUsername_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
