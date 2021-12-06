using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class UserScores
    {
        User user = new User();

        public UserScores()
        {
            user = user.Instance();
        }

        public void updateUserScores(Stopwatch stopwatch, int score, int amountCorrect, string tableName)
        {
            user.Score = score;
            user.time = (stopwatch.ElapsedMilliseconds / 1000).ToString();
            user.amountCorrect = amountCorrect;
            sqliteLogic sq = new sqliteLogic();
            sq.sendDataToUserScores(user.Username, score, DateTime.Now.ToShortDateString(), tableName);
           
        }

       

    }
}
