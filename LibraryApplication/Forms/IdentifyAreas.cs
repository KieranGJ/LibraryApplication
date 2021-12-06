#region imports
using LibraryApplication.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace LibraryApplication.Forms
{
    public partial class IdentifyAreas : Form
    {

        #region Variables
        //Drawing Variables
        Graphics g;
        int x = -1;
        int y = -1;
        Pen pen;


        int roundsPlayed;
        int amountCorrect = 0;
        int numberOfButtonsPressed = 0;
        int currentWorkingIndex = 0;
        //CorrectLabel
        bool moving = false;
        bool callNumberIsKey = true;

        User user = new User();
        string[] keyValues = new string[4];
        string[] valueValues = new string[4];

        string[] answeredKeys = new string[4];
        string[] answeredValues = new string[4];

        Stopwatch stopwatch = new Stopwatch();
        List<string> pressedButtons = new List<string>();
        Dictionary<string, string> calls = new Dictionary<string, string>();
        #endregion

        #region OnLoad
        public IdentifyAreas()
        {
            InitializeComponent();
            roundsPlayed = 1;     
            setupDrawing();
            generateGame();
            startTimer();
            disableOrEnableAnswerButtons(false);
            user = user.Instance();
            
        }
        private void IdentifyAreas_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

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

        #region Setting Up the game


        private void loadArrays_CategoryAsKey()
        {
            Generation g = new Generation();
            g.getIdentificationDictionary_KeyisCategory();
        }

        private void generateGame()
        {
            countLabel.Text = roundsPlayed.ToString() + "/5";
            //Rotate Between Call number identification and Category Identification
            if (callNumberIsKey) { callNumberIsKey = false; }
            else { callNumberIsKey = true; }

            loadCallArrays();
            loadQuestionsAndAnswers();
            loadArrays_CategoryAsKey();
        }

        private void loadCallArrays()
        {
            Generation g = new Generation();
            if (callNumberIsKey)
            {
                calls = g.getIdentificationDictionary_CallIsKey();
            }
            else
            {
                calls = g.getIdentificationDictionary_KeyisCategory();
            }

            int count = 0;
            foreach (KeyValuePair<string, string> item in calls)
            {
                keyValues[count] = item.Key;
                valueValues[count] = item.Value;
                count++;
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }

        private void loadQuestionsAndAnswers()
        {
            int sizeOfArray = 7;
            string[] callCategoriesWithDummyValues = new string[sizeOfArray];

            DeweyClasses g = new DeweyClasses();
            if (callNumberIsKey)
            {
                callCategoriesWithDummyValues = g.addDummyClasses_CallIsKey(valueValues, sizeOfArray);
            }
            else
            {
                callCategoriesWithDummyValues = g.addDummyClasses_CategoryIsKey(valueValues, sizeOfArray);
            }

            Randomize<string>(callCategoriesWithDummyValues);

            o1.Text = keyValues[0];
            a1.Text = callCategoriesWithDummyValues[0];

            o2.Text = keyValues[1];
            a2.Text = callCategoriesWithDummyValues[1];

            o3.Text = keyValues[2];
            a3.Text = callCategoriesWithDummyValues[2];

            o4.Text = keyValues[3];
            a4.Text = callCategoriesWithDummyValues[3];

            a5.Text = callCategoriesWithDummyValues[4];
            a6.Text = callCategoriesWithDummyValues[5];
            a7.Text = callCategoriesWithDummyValues[6];
        }

        #endregion

        #region Logic

        /// <summary>
        /// Takes an array and randomizes the content by looping through
        /// each instance of the array and replacing an index with another index
        /// </summary>     
        public static void Randomize<T>(T[] items)
        {
            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        /// <summary>
        /// Checks to see if the values from the answered arrays match the dictionary.
        /// </summary>      
        private bool checkIfCorrect()
        {
            string tempKey;
            string tempValue;
            bool correct = true;
            for (int i = 0; i < answeredValues.Length; i++)
            {
                tempKey = answeredKeys[i];
                tempValue = answeredValues[i];

                if (!tempValue.Equals(calls[tempKey]))
                {
                    correct = false;
                    break;
                }
            }
            return correct;
        }

        #endregion

        #region Navigate between forms
        private void showLeaderboard()
        {
            LeaderBoard lb = new LeaderBoard(Values.IDENTIFY_TABLE_NAME);
            this.Hide();
            lb.ShowDialog();
            this.Close();
        }

        private void homeTime_Click(object sender, EventArgs e)
        {
            StartScreen ss = new StartScreen();
            this.Hide();
            ss.ShowDialog();
            this.Close();
        }

        #endregion

        #region Drawing

        private void backPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }
        //Used to start the drawing
        private void drawLineStart()
        {
            moving = true;
            backPanel.Cursor = Cursors.Cross;
        }

        //Used to stop the drawing
        private void drawLineStop()
        {
            moving = false;
            x = -1;
            y = -1;
            backPanel.Cursor = Cursors.Default;
        }

        //Used to setup the drawing
        private void setupDrawing()
        {
            g = backPanel.CreateGraphics();
            //Makes the lines smoother
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 7);
            //Adds rouned tips to the pen
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }


        #endregion

        #region Buttons

        //When a button is pressed then the other buttons on that side need to be disabled
        private void disableOrEnableOptionButtons(bool option)
        {
            o1.Enabled = option;
            ob1.Enabled = option;

            o2.Enabled = option;
            ob2.Enabled = option;

            o3.Enabled = option;
            ob3.Enabled = option;

            o4.Enabled = option;
            ob4.Enabled = option;

            foreach (var button in pressedButtons)
            {
                disableSpecificButton(button);
            }

        }
        //When a button is pressed then the other buttons on that side need to be disabled
        private void disableOrEnableAnswerButtons(bool option)
        {
            a1.Enabled = option;
            ab1.Enabled = option;

            a2.Enabled = option;
            ab2.Enabled = option;

            a3.Enabled = option;
            ab3.Enabled = option;

            a4.Enabled = option;
            ab4.Enabled = option;

            a5.Enabled = option;
            ab5.Enabled = option;

            a6.Enabled = option;
            ab6.Enabled = option;

            a7.Enabled = option;
            ab7.Enabled = option;
        }


        //When one of the left buttons are pressed
        private void ob1_Click(object sender, EventArgs e)
        {

            disableOrEnableOptionButtons(false);
            disableOrEnableAnswerButtons(true);
            var Button = (Button)sender;

            bool safe = true;
            switch (Button.Name)
            {
                case "ob1":
                    pressedButtons.Add("ob1");
                    pen.Color = Color.Red;
                    currentWorkingIndex = 0;
                    answeredKeys[currentWorkingIndex] = o1.Text;
                    break;
                case "ob2":
                    pressedButtons.Add("ob2");
                    pen.Color = Color.Cyan;
                    currentWorkingIndex = 1;
                    answeredKeys[currentWorkingIndex] = o2.Text;
                    break;
                case "ob3":
                    pressedButtons.Add("ob3");
                    pen.Color = Color.Lime;
                    currentWorkingIndex = 2;
                    answeredKeys[currentWorkingIndex] = o3.Text;
                    break;
                case "ob4":
                    pressedButtons.Add("ob4");
                    pen.Color = Color.Yellow;
                    currentWorkingIndex = 3;
                    answeredKeys[currentWorkingIndex] = o4.Text;
                    break;
                default:
                    safe = false;
                    break;
            }

            //Gets the current location of your cursor
            var xPoint = Cursor.Position.X;

            var yPoint = Cursor.Position.Y;
            Point point = new Point(xPoint, yPoint);
            var clientPoint = PointToClient(point);

            yPoint = clientPoint.Y;
            xPoint = clientPoint.X;

            //Start Drawing
            x = xPoint;
            y = yPoint;
            if (safe)
            {
                drawLineStart();
            }
        }

        //When a right button is pressed
        private void ab1_Click(object sender, EventArgs e)
        {
            disableOrEnableOptionButtons(true);
            disableOrEnableAnswerButtons(false);
            numberOfButtonsPressed++;
            var Button = (Button)sender;
            bool safe = true;
            switch (Button.Name)
            {
                case "ab1":
                    answeredValues[currentWorkingIndex] = a1.Text;
                    break;
                case "ab2":
                    answeredValues[currentWorkingIndex] = a2.Text;
                    break;
                case "ab3":
                    answeredValues[currentWorkingIndex] = a3.Text;
                    break;
                case "ab4":
                    answeredValues[currentWorkingIndex] = a4.Text;
                    break;
                case "ab5":
                    answeredValues[currentWorkingIndex] = a5.Text;
                    break;
                case "ab6":
                    answeredValues[currentWorkingIndex] = a6.Text;
                    break;
                case "ab7":
                    answeredValues[currentWorkingIndex] = a7.Text;
                    break;
                default:
                    safe = false;
                    break;
            }
            if (safe)
            {
                drawLineStop();
            }

            if (numberOfButtonsPressed > 3)
            {
                roundsPlayed++;
                bool correct = checkIfCorrect();
                if (correct)
                {
                    amountCorrect++;
                }
                pressedButtons.Clear();
                disableOrEnableOptionButtons(true);
                numberOfButtonsPressed = 0;
                currentWorkingIndex = 0;
                g.Clear(backPanel.BackColor);
                if (roundsPlayed > 5)
                {
                    CalculateScore cs = new CalculateScore();
                    int score = cs.CalculateTheScore((stopwatch.ElapsedMilliseconds / 1000), amountCorrect);
                    UserScores us = new UserScores();
                    us.updateUserScores(stopwatch, score, amountCorrect,Values.IDENTIFY_TABLE_NAME);
                    showLeaderboard();
                }
                generateGame();
            }
        }

        //Used to exit the application
        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //When a button is pressed then the other buttons on that side need to be disabled
        private void disableSpecificButton(string buttonName)
        {
            switch (buttonName)
            {
                case "ob1":
                    ob1.Enabled = false;
                    o1.Enabled = false;
                    break;
                case "ob2":
                    ob2.Enabled = false;
                    o2.Enabled = false;
                    break;
                case "ob3":
                    ob3.Enabled = false;
                    o3.Enabled = false;
                    break;
                case "ob4":
                    ob4.Enabled = false;
                    o4.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        #endregion
    
    }
}
