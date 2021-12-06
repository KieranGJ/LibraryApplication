using LibraryApplication.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApplication.Books
{
    public partial class ReplacingBooks : Form
    {
        #region Variables

        /// <summary>
        /// Created Global Variable
        /// 
        /// Amount of numbers refers to the number of panels the user must choose from
        /// </summary>
        
        
        private const int AMOUNT_OF_NUMBERS = Values.AMOUNT_OF_OPTIONS_REPLACE;

        int buttonsPressed = 0;
        string[] callNumbers_CorrectOrder = new string[AMOUNT_OF_NUMBERS];
        string[] callNumbers_WrongOrder = new string[AMOUNT_OF_NUMBERS];
        string[] answers = new string[AMOUNT_OF_NUMBERS];
        Generation gen = new Generation();
        Stopwatch stopwatch = new Stopwatch();
        User user = new User();
        History history = new History();
        int count = 0;
        int amountCorrect = 0;

        #endregion

        public ReplacingBooks()
        {

            InitializeComponent();          
            setup();
            
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

        #region Hardcode

        private void setInitialScoreLabelText()
        {
            
            score1.Text = "1  : ..........";
            name1.Text = "  ....";
            score2.Text = "2  : ..........";
            name2.Text = "  ....";
            score3.Text = "3  : ..........";
            name3.Text = "  ....";
            score4.Text = "4  : ..........";
            name4.Text = "  ....";
            score5.Text = "5  : ..........";
            name5.Text = "  ....";
            score6.Text = "6  : ..........";
            name6.Text = "  ....";
            score7.Text = "7  : ..........";
            name7.Text = "  ....";
            score8.Text = "8  : ..........";
            name8.Text = "  ....";
        }

        private void clearErrorProviders()
        {
            errorProvider0.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            correctError0.Clear();
            correctError1.Clear();
            correctError2.Clear();
            correctError3.Clear();
            correctError4.Clear();
        }

        private void hideAnswers()
        {
            a1.Visible = false;
            a2.Visible = false;
            a3.Visible = false;
            a4.Visible = false;
            a5.Visible = false;
            a6.Visible = false;
            a7.Visible = false;
            a8.Visible = false;
            a9.Visible = false;
            a10.Visible = false;

        }

        private void putAnswerDown(string answer)
        {
            switch (buttonsPressed)
            {
                case 1:
                    a1.Visible = true;
                    a1.Text = answer;
                    answers[0] = answer;
                    break;
                case 2:
                    a2.Visible = true;
                    a2.Text = answer;
                    answers[1] = answer;
                    break;
                case 3:
                    a3.Visible = true;
                    a3.Text = answer;
                    answers[2] = answer;
                    break;
                case 4:
                    a4.Visible = true;
                    a4.Text = answer;
                    answers[3] = answer;
                    break;
                case 5:
                    a5.Visible = true;
                    a5.Text = answer;
                    answers[4] = answer;
                    break;
                case 6:
                    a6.Visible = true;
                    a6.Text = answer;
                    answers[5] = answer;
                    break;
                case 7:
                    a7.Visible = true;
                    a7.Text = answer;
                    answers[6] = answer;
                    break;
                case 8:
                    a8.Visible = true;
                    a8.Text = answer;
                    answers[7] = answer;
                    break;
                case 9:
                    a9.Visible = true;
                    a9.Text = answer;
                    answers[8] = answer;
                    break;
                case 10:
                    a10.Visible = true;
                    a10.Text = answer;
                    answers[9] = answer;
                    break;
                default:
                    break;
            }
            checkIfEndOfGame();
        }

        private void makeOptionsVisible()
        {
            hideAnswers();

            o1.Visible = true;
            o2.Visible = true;
            o3.Visible = true;
            o4.Visible = true;
            o5.Visible = true;
            o6.Visible = true;
            o7.Visible = true;
            o8.Visible = true;
            o9.Visible = true;
            o10.Visible = true;

            buttonsPressed = 0;
        }

        #endregion

        #region Logic

        /// <summary>
        /// Takes the score and saves it into an SQLite database
        /// </summary>
        private void storeInfo()
        {
            sqliteLogic sl = new sqliteLogic();            
            user.Score = calculateScore();
            currentScoreLabel.Text = $"SCORE :  {user.Score}";
            user.Date_of_score = DateTime.Now.ToShortDateString();
            sl.sendDataToUserScores(user.Username, user.Score, user.Date_of_score,"SCORES");
        }

        /// <summary>
        /// Calculates the score
        /// </summary>
        private int calculateScore()
        {
            CalculateScore cs = new CalculateScore();
            int reusult = cs.CalculateTheScore((stopwatch.ElapsedMilliseconds / 1000), amountCorrect);

            return reusult;
        }

        /// <summary>
        /// Creates a game, passes a boolean to see if you need to restart the timer
        /// </summary>      
        private void generateGame(bool resetTimer)
        {

            try
            {
                if (resetTimer)
                {
                    stopTimer();
                    resetStopwatch();
                    startTimer();
                }

                makeOptionsVisible();
                string[] correct = new string[AMOUNT_OF_NUMBERS];
                string[] wrong = new string[AMOUNT_OF_NUMBERS];


                //Generate a list of random numbers
                callNumbers_CorrectOrder = gen.generateRandomLettersReplace();

                //Work around to prevent the two lists from sharing the same Address
                for (int i = 0; i < callNumbers_CorrectOrder.Length; i++)
                {
                    callNumbers_WrongOrder[i] = callNumbers_CorrectOrder[i];
                }

                //Randomize the string
                Randomize<string>(callNumbers_WrongOrder);

                o1.Text = callNumbers_WrongOrder[0];
                o2.Text = callNumbers_WrongOrder[1];
                o3.Text = callNumbers_WrongOrder[2];
                o4.Text = callNumbers_WrongOrder[3];
                o5.Text = callNumbers_WrongOrder[4];
                o6.Text = callNumbers_WrongOrder[5];
                o7.Text = callNumbers_WrongOrder[6];
                o8.Text = callNumbers_WrongOrder[7];
                o9.Text = callNumbers_WrongOrder[8];
                o10.Text = callNumbers_WrongOrder[9];

                gamePanel.Visible = true;
                leaderBoardPanel.Visible = false;
                startingPanel.Visible = false;

            }
            catch (Exception) { }

        }

        /// <summary>
        /// The initial Setup that is run when the Form is loaded
        /// </summary>
        private void setup()
        {
            hideAnswers();
            user = user.Instance();
            startButton.Enabled = false;
            gamePanel.Visible = true;
            //startingPanel.Visible = true;
            leaderBoardPanel.Visible = false;
            happyFace.Visible = false;
            setInitialScoreLabelText();
            generateGame(true);
            //startTimer();
            
        }





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
        /// Checks to see if your answers are correct or not and will diplay
        /// </summary>
        private void displayYourAnswerVsCorrectAnswer()
        {
            CreateString cs = new CreateString();

            if (!history.areCorrectAt(0))
            {
                errorProvider0.SetError(attempt0, $"Correct answer: {cs.createCorrectAndAttemptStrings(history.getCorrectAt(0))}");
            }
            else
            {
                correctError0.SetError(attempt0, "This answer is correct （＾ｖ＾）");
            }
            if (!history.areCorrectAt(1))
            {
                errorProvider1.SetError(attempt1, $"Correct answer: {cs.createCorrectAndAttemptStrings(history.getCorrectAt(1))}");
            }
            else
            {
                correctError1.SetError(attempt1, "This answer is correct （＾ｖ＾）");
            }
            if (!history.areCorrectAt(2))
            {
                errorProvider2.SetError(attempt2, $"Correct answer: {cs.createCorrectAndAttemptStrings(history.getCorrectAt(2))}");
            }
            else
            {
                correctError2.SetError(attempt2, "This answer is correct （＾ｖ＾）");
            }
            if (!history.areCorrectAt(3))
            {
                errorProvider3.SetError(attempt3, $"Correct answer: {cs.createCorrectAndAttemptStrings(history.getCorrectAt(3))}");
            }
            else
            {
                correctError3.SetError(attempt3, "This answer is correct （＾ｖ＾）");
            }
            if (!history.areCorrectAt(4))
            {
                errorProvider4.SetError(attempt4, $"Correct answer: {cs.createCorrectAndAttemptStrings(history.getCorrectAt(4))}");
            }
            else
            {
                correctError4.SetError(attempt4, "This answer is correct （＾ｖ＾）");
            }

            attempt0.Text = cs.createCorrectAndAttemptStrings(history.getAttemptAt(0));
            attempt1.Text = cs.createCorrectAndAttemptStrings(history.getAttemptAt(1));
            attempt2.Text = cs.createCorrectAndAttemptStrings(history.getAttemptAt(2));
            attempt3.Text = cs.createCorrectAndAttemptStrings(history.getAttemptAt(3));
            attempt4.Text = cs.createCorrectAndAttemptStrings(history.getAttemptAt(4));
        }

        /// <summary>
        /// Will check to see if the game has ended or if it just needs to display another set of numbers
        /// Counts the number of buttons pressed and how many times it has fired a positive
        /// </summary>
        private void checkIfEndOfGame()
        {
            if (buttonsPressed > AMOUNT_OF_NUMBERS - 1)
            {
                count++;
                countLabel.Text = $"{count + 1} / 5";
                
                history.SubmitCorrect(callNumbers_CorrectOrder);
                history.SubmitAttempt(answers);

                //Checks if the arrays are the exact same
                if (callNumbers_CorrectOrder.SequenceEqual(answers))
                {
                    // resultLabel.Visible = true;
                    amountCorrect++;
                    generateGame(false);
                    history.addIfTheyGotItCorrect(true);
                }
                else
                {
                    generateGame(false);
                    history.addIfTheyGotItCorrect(false);
                }

                if (count == 5)
                {
                    stopTimer();
                    storeInfo();
                    showTop10List();
                    DisplayStats();
                    displayYourAnswerVsCorrectAnswer();
                    leaderBoardPanel.Visible = true;
                    gamePanel.Visible = false;
                    startingPanel.Visible = false;
                    Sounds sound = new Sounds();
                    sound.Victory();
                }

            }
        }

        /// <summary>
        /// Displays the stats (˙ ͜ʟ˙ )
        /// </summary>
        private void DisplayStats()
        {

            timeRecord.Text = (stopwatch.ElapsedMilliseconds / 1000).ToString() + "s";
            correctRecord.Text = amountCorrect.ToString() + "/5";
            sqliteLogic sg = new sqliteLogic();
            highestScoreRecord.Text = sg.getHighestScore(user.Username,"SCORES").ToString();

        }

        /// <summary>
        /// Calls the SQLite file to populate the leaderboard
        /// Will try to populate all the fields
        /// If a field is empty then it will return
        /// </summary>
        /// 
        private void showTop10List()
        {
            Scores scores = new Scores();
            sqliteLogic sl = new sqliteLogic();
            scores = sl.getTop10Scores("SCORES");
            string score;
            string username;

            try
            {
                score = scores.getScoreAt(0).ToString();
                username = scores.getUsernameAt(0).ToString();
                score1.Text = $"1  :  {score}";
                name1.Text = username;

            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(1).ToString();
                username = scores.getUsernameAt(1).ToString();
                score2.Text = $"2  :  {score}";
                name2.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(2).ToString();
                username = scores.getUsernameAt(2).ToString();
                score3.Text = $"3  :  {score}";
                name3.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(3).ToString();
                username = scores.getUsernameAt(3).ToString();
                score4.Text = $"4  :  {score}";
                name4.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(4).ToString();
                username = scores.getUsernameAt(4).ToString();
                score5.Text = $"5  :  {score}";
                name5.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(5).ToString();
                username = scores.getUsernameAt(5).ToString();
                score6.Text = $"6  :  {score}";
                name6.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(6).ToString();
                username = scores.getUsernameAt(6).ToString();
                score7.Text = $"7  :  {score}";
                name7.Text = username;
            }
            catch (Exception) { return; }

            try
            {
                score = scores.getScoreAt(7).ToString();
                username = scores.getUsernameAt(7).ToString();
                score8.Text = $"8  :  {score}";
                name8.Text = username;
            }
            catch (Exception) { return; }

        }

        /// <summary>
        /// Sets the form to fullscreen (ᵔᴥᵔ)
        /// </summary>
        private void ReplacingBooks_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Plays a pop sound
        /// Will most likely be used when a button is pressed
        /// </summary>
        private void Pop()
        {
            Sounds sound = new Sounds();
            sound.Pop();
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

        #endregion

        #region On_Click Events

        /// <summary>
        /// Closes the application        ♪~ ᕕ(ᐛ)ᕗ
        /// </summary>

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Ox._Click are the panels that display the options
        /// </summary
        private void o1_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o1.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[0]);
            Pop();

        }

        private void o2_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o2.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[1]);
            Pop();
        }

        private void o3_Click(object sender, EventArgs e)
        {                      
            buttonsPressed++;
            o3.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[2]);
            Pop();
        }

        private void o4_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o4.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[3]);
            Pop();
        }
        private void o5_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o5.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[4]);
            Pop();
        }

        private void o6_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o6.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[5]);
            Pop();
        }

        private void o7_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o7.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[6]);
            Pop();
        }

        private void o8_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o8.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[7]);
            Pop();
        }

        private void o9_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o9.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[8]);
            Pop();
        }

        private void o10_Click(object sender, EventArgs e)
        {
            buttonsPressed++;
            o10.Visible = false;
            putAnswerDown(callNumbers_WrongOrder[9]);
            Pop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //startingPanel.Visible = false;
            //user.Username = usernameBox.Text;
            //generateGame(true);
            ////startTimer();
            //gamePanel.Visible = true;
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            amountCorrect = 0;
            count = 0;
            countLabel.Text = $"{count + 1} / 5";
            history.clearArrays();
            clearErrorProviders();
            timeLabel.Text = "00:00";
            leaderBoardPanel.Visible = false;
            startingPanel.Visible = false;
            gamePanel.Visible = true;
            generateGame(true);
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            StartScreen rb = new StartScreen();
            this.Hide();
            rb.ShowDialog();
            this.Close();
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            makeOptionsVisible();
            for (int i = 0; i < answers.Length; i++)
            {
                answers[i] = null;
            }
        }
        #endregion
       
        #region Mouse events

        /// <summary>
        /// Displays a face when the button is hovered over
        /// </summary>
      
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


        #endregion

        #region Misc
        private void attempt0_TextChanged(object sender, EventArgs e)
        {

        }

        private void leaderBoardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void homeTime_Click(object sender, EventArgs e)
        {
            StartScreen ss = new StartScreen();
            this.Hide();
            ss.ShowDialog();
            this.Close();
        }
    }
}
