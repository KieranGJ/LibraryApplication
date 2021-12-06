using LibraryApplication.Logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApplication.Forms
{
    public partial class CallNumbers : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        DeweyRandom dr = new DeweyRandom();
        DeweyTree t1 = new DeweyTree();
        LogicClass l = new LogicClass();
        int count = 0;
        int amountOfFirstLevelsCorrect, amountOfSecondLevelsCorrect, amountOfThirdLevelsCorrect = 0;
        //tli = third level indexes
        int[] tli = new int[3];
        int[] indexes = new int[4];
        int currentTier;
        public CallNumbers()
        {
            InitializeComponent();
            setup();
        }
        private void setup()
        {
            loadJson();
            generateNewRound();

        }

        #region Timer
        /// <summary>
        /// Timer Region controls the use of the stopwatch and timer
        /// </summary>
        public void startTimer()
        {
            Timer1.Start();
            this.stopwatch.Start();
        }

        public void resetStopwatch()
        {

            this.stopwatch.Restart();
        }

        public void stopTimer()
        {
            Timer1.Stop();
            this.stopwatch.Stop();
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan elapsed = this.stopwatch.Elapsed;
            //timeLabel.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
            timeLabel.Text = string.Format("{0:00}:{1:00}", elapsed.Minutes, elapsed.Seconds);
        }

        #endregion

        /// <summary>
        /// Gets and loads three random indexes 
        /// that lead to a random value in the tree structure
        /// </summary>
        private void displayThirdLevelCategory()
        {
            tli = dr.getRandomThirdLevelEntry(t1);
            string category = t1.t1[tli[0]].t1[tli[1]].t1[tli[2]].category;

            Console.WriteLine($"First tier is : {t1.t1[tli[0]].call} {t1.t1[tli[0]].category}");
            Console.WriteLine($"Second tier is : {t1.t1[tli[0]].t1[tli[1]].call} {t1.t1[tli[0]].t1[tli[1]].category}");
            Console.WriteLine($"Third tier is : {t1.t1[tli[0]].t1[tli[1]].t1[tli[2]].call} {t1.t1[tli[0]].t1[tli[1]].t1[tli[2]].category}");
            CategoryLabel.Text = category.ToUpper();
            addTextToButtons();
        }
        private void addTextToButtons()
        {

            indexes = dr.fillFirstLevelEntriesWithDummies(tli[0], t1);
            //indexes = l.randomizeArray(indexes);
            o1.Text = $"{t1.t1[indexes[0]].call} {t1.t1[indexes[0]].category}";
            o2.Text = $"{t1.t1[indexes[1]].call} {t1.t1[indexes[1]].category}";
            o3.Text = $"{t1.t1[indexes[2]].call} {t1.t1[indexes[2]].category}";
            o4.Text = $"{t1.t1[indexes[3]].call} {t1.t1[indexes[3]].category}";

        }

        private void generateNewRound()
        {
            currentTier = 1;
            count++;
            countLabel.Text = $"{count}/5";
            disableOrEnableButtons(true);
            nextButton.Visible = false;
            instructionalLabel.Text = "Guess the First Level";
            labelsVisible(false);
            makeLabelsRedAgain();
            displayThirdLevelCategory();
            loadAnswersToAnswerLabels();
            startTimer();
        }

        private void makeLabelsRedAgain()
        {
            firstLevelLabel.ForeColor = Color.Red;
            secondLevelLabel.ForeColor = Color.Red;
            thirdLevelLabel.ForeColor = Color.Red;
        }
        private void labelsVisible(bool visibility)
        {
            firstLevelLabel.Visible = visibility;
            secondLevelLabel.Visible = visibility;
            thirdLevelLabel.Visible = visibility;
            rightOrWrong.Visible = visibility;
            nextButton.Visible = visibility;
        }

        private void displayRandomSecondTierOptions()
        {
            int[] options = { 0, 1, 2, 3 };
            //options = l.randomizeArray(options);
            o1.Text = $"{t1.t1[tli[0]].t1[options[0]].call} {t1.t1[tli[0]].t1[options[0]].category}";
            o2.Text = $"{t1.t1[tli[0]].t1[options[1]].call} {t1.t1[tli[0]].t1[options[1]].category}";
            o3.Text = $"{t1.t1[tli[0]].t1[options[2]].call} {t1.t1[tli[0]].t1[options[2]].category}";
            o4.Text = $"{t1.t1[tli[0]].t1[options[3]].call} {t1.t1[tli[0]].t1[options[3]].category}";

        }

        /// <summary>
        /// This is for testing purposes only
        /// </summary>
        private void displayRandomThirdTierOptions()
        {
            int[] options = { 0, 1, 2, 3 };
            o1.Text = $"{t1.t1[tli[0]].t1[tli[1]].t1[options[0]].call}";
            o2.Text = $"{t1.t1[tli[0]].t1[tli[1]].t1[options[1]].call}";
            o3.Text = $"{t1.t1[tli[0]].t1[tli[1]].t1[options[2]].call}";
            o4.Text = $"{t1.t1[tli[0]].t1[tli[1]].t1[options[3]].call}";

        }

        /// <summary>
        /// Loads the Json
        /// </summary>
        private void loadJson()
        {

            string text = System.IO.File.ReadAllText(@"DeweyClasses.txt");
            t1 = JsonConvert.DeserializeObject<DeweyTree>(text);

        }      
        
        private void loadAnswersToAnswerLabels()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(t1.t1[tli[0]].call);
            sb.Append(" ");
            sb.Append(t1.t1[tli[0]].category);
            firstLevelLabel.Text = sb.ToString();
            sb.Clear();
            sb.Append(t1.t1[tli[0]].t1[tli[1]].call);
            sb.Append(" ");
            sb.Append(t1.t1[tli[0]].t1[tli[1]].category);
            secondLevelLabel.Text = sb.ToString();
            sb.Clear();
            sb.Append(t1.t1[tli[0]].t1[tli[1]].t1[tli[2]].call);
            sb.Append(" ");
            sb.Append(t1.t1[tli[0]].t1[tli[1]].t1[tli[2]].category);
            thirdLevelLabel.Text = sb.ToString();
            sb.Clear();
        }
        private void disableOrEnableButtons(bool true_or_false)
        {
            o1.Enabled = true_or_false;
            o2.Enabled = true_or_false;
            o3.Enabled = true_or_false;
            o4.Enabled = true_or_false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            rightOrWrong.Text = "";
            rightOrWrong.Visible = true;
            var Button = (Button)sender;
            string answer = Button.Text;
            string correctAnswer = "???";
            switch (currentTier)
            {
                case 1:
                    correctAnswer = t1.t1[tli[0]].call;
                    if (answer[0] == correctAnswer[0])
                    {
                        amountOfFirstLevelsCorrect++;
                        firstLevelLabel.ForeColor = Color.Lime;
                        firstLevelLabel.Visible = true;
                        instructionalLabel.Text = "Guess the Second Level";
                    }
                    else
                    {
                        wasIncorrect();
                        break;
                    }
                    currentTier++;
                    displayRandomSecondTierOptions();
                    break;
                case 2:
                    correctAnswer = t1.t1[tli[0]].t1[tli[1]].call;
                    if (answer[1] == correctAnswer[1])
                    {
                        amountOfSecondLevelsCorrect++;
                        secondLevelLabel.ForeColor = Color.Lime;
                        secondLevelLabel.Visible = true;
                        instructionalLabel.Text = "Guess the Third Level Call";
                    }
                    else
                    {
                        wasIncorrect();
                        break;
                    }
                    currentTier++;
                    displayRandomThirdTierOptions();
                    break;
                case 3:
                    correctAnswer = t1.t1[tli[0]].t1[tli[1]].t1[tli[2]].call;
                    if (answer[2] == correctAnswer[2])
                    {
                        amountOfThirdLevelsCorrect++;
                        rightOrWrong.Text = "CORRECT !";
                        thirdLevelLabel.ForeColor = Color.Lime;
                        thirdLevelLabel.Visible = true;
                        nextButton.Visible = true;
                    }
                    else
                    {
                        wasIncorrect();

                        break;
                    }
                    currentTier++;
                    break;
                default:
                    break;
            }

            if (count > 4)
            {
                nextButton.Text = "Results";
                stopTimer();               
            }                                            
        }

        private void calculateScore()
        {
            //Every first level counts * 2 | second level counts * 4 | third level counts * 5
            
            CalculateScore cs = new CalculateScore();
            int score = cs.CalculateTheScore_CallNumbers((stopwatch.ElapsedMilliseconds / 1000), amountOfFirstLevelsCorrect,amountOfSecondLevelsCorrect,amountOfThirdLevelsCorrect);
            UserScores us = new UserScores();
            us.updateUserScores(stopwatch, score, -1, Values.CALL_NUMBERS_TABLE_NAME);
            
        }

        private void showLeaderboard()
        {
            LeaderBoard lb = new LeaderBoard(Values.CALL_NUMBERS_TABLE_NAME);
            this.Hide();
            lb.ShowDialog();
            this.Close();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeTime_Click(object sender, EventArgs e)
        {
            StartScreen ss = new StartScreen();
            this.Hide();
            ss.ShowDialog();
            this.Close();
        }

        private void CallNumbers_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void wasIncorrect()
        {
            disableOrEnableButtons(false);
            rightOrWrong.Text = "False";
            labelsVisible(true);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if(count > 4)
            {
                calculateScore();
                showLeaderboard();
            }             
            generateNewRound();
        }
    }
}
