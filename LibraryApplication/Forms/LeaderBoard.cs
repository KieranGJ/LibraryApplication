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

    public partial class LeaderBoard : Form
    {
       
        sqliteLogic sq = new sqliteLogic();
        User user = new User();
        string tableName;
        public LeaderBoard(string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;
            user = user.Instance();
            DisplayStats();
            showTop10List();
        }

        private void DisplayStats()
        {
            scoreLabelAchieved.Text = user.Score.ToString();
            timeItTookLabel.Text = user.time + "s";
            if (user.amountCorrect != -1)
            {
                amountCorrectLabel.Text = user.amountCorrect + "/5";
            }
            else
            {
                amountCorrectLabel.Text = "";
            }
            
            sqliteLogic sg = new sqliteLogic();
            highestAchievedScore.Text = sg.getHighestScore(user.Username, tableName).ToString();

        }

        private void showTop10List()
        {
            Scores scores = new Scores();
            sqliteLogic sl = new sqliteLogic();
            scores = sl.getTop10Scores(tableName);
            string score;
            string username;

            try
            {
                score = scores.getScoreAt(0).ToString();
                username = scores.getUsernameAt(0).ToString();
                s1.Text = $"1  :  {score}";
                n1.Text = username;

            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(1).ToString();
                username = scores.getUsernameAt(1).ToString();
                s2.Text = $"2  :  {score}";
                n2.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(2).ToString();
                username = scores.getUsernameAt(2).ToString();
                s3.Text = $"3  :  {score}";
                n3.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(3).ToString();
                username = scores.getUsernameAt(3).ToString();
                s4.Text = $"4  :  {score}";
                n4.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(4).ToString();
                username = scores.getUsernameAt(4).ToString();
                s5.Text = $"5  :  {score}";
                n5.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(5).ToString();
                username = scores.getUsernameAt(5).ToString();
                s6.Text = $"6  :  {score}";
                n6.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(6).ToString();
                username = scores.getUsernameAt(6).ToString();
                s7.Text = $"7  :  {score}";
                n7.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(7).ToString();
                username = scores.getUsernameAt(7).ToString();
                s8.Text = $"8  :  {score}";
                n8.Text = username;
            }
            catch (Exception) { return; }

        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
     
        private void playButton_Click(object sender, EventArgs e)
        {
            switch (tableName)
            {
                case Values.IDENTIFY_TABLE_NAME:
                    IdentifyAreas id = new IdentifyAreas();
                    this.Hide();
                    id.ShowDialog();
                    this.Close();
                    break;
                case Values.CALL_NUMBERS_TABLE_NAME:
                    CallNumbers cn = new CallNumbers();
                    this.Hide();
                    cn.ShowDialog();
                    this.Close();
                    break;
                default:
                    StartScreen ss = new StartScreen();
                    this.Hide();
                    ss.ShowDialog();
                    this.Close();
                    break;

            }
            
        }

        private void backToHomeButon_Click(object sender, EventArgs e)
        {
            StartScreen ss = new StartScreen();
            this.Hide();
            ss.ShowDialog();
            this.Close();
        }
    }
}
