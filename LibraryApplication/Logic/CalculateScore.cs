using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    class CalculateScore
    {
        //Returns the user score
        public int CalculateTheScore(double time, int amountCorrect)
        {
            
            double score;
            try
            {
                 score = (300 / time) * (amountCorrect * 100);
            }
            catch (Exception)
            {
                 score = (1) * (amountCorrect * 100);
            }

            return (int)Math.Round(score);
        }

        /// <summary>
        /// First levels are * 1
        /// Second levels are * 4 
        /// Third levels are * 8
        /// </summary>
       
        /// <returns></returns>
        internal int CalculateTheScore_CallNumbers(double time, int amountOfFirstLevelsCorrect, int amountOfSecondLevelsCorrect, int amountOfThirdLevelsCorrect)
        {
            double score;
            try
            {
                score = (300 / time) * ((amountOfFirstLevelsCorrect * 100) + (amountOfSecondLevelsCorrect*400) + (amountOfThirdLevelsCorrect*800));
            }
            catch (Exception)
            {

                score = (1) * ((amountOfFirstLevelsCorrect * 100) + (amountOfSecondLevelsCorrect * 400) + (amountOfThirdLevelsCorrect * 800));
            }
            return (int)Math.Round(score);
        }
    }
}
