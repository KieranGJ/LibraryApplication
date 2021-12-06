using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class Scores
    {
        List<string> username = new List<string>();
        List<int> score = new List<int>();
        List<string> Date_of_score = new List<string>();

        public List<string> getUsername()
        {
            return this.username;
        }

        public string getUsernameAt(int i)
        {
            return this.username[i];
        }

        public string getDate_of_scoreAt(int i)
        {
            return this.Date_of_score[i];
        }

        public int getScoreAt(int i)
        {
            return this.score[i];
        }

        public List<string> getDate_of_score()
        {
            return this.Date_of_score;
        }

        public List<int> getScore()
        {
            return this.score;          
        }

        public void clearScoreLists()
        {
            this.username.Clear();
            this.score.Clear();
            this.Date_of_score.Clear();
        }

        public void addUsername(string name)
        {
            this.username.Add(name);
        }

        public void addScore(int score)
        {
            this.score.Add(score);
        }

        public void addDate_of_score(string date)
        {
            this.Date_of_score.Add(date);
        }
    }
}
