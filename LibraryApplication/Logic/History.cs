using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    class History
    {

        const int AMOUNT_OF_OPTIONS = Values.AMOUNT_OF_OPTIONS_REPLACE;
        List<string[]> correct = new List<string[]>();
        List<string[]> attempt = new List<string[]>();
        List<bool> ifCorrect = new List<bool>();

        //Return the string array at the index
        public string[] getCorrectAt(int i)
        {
            return this.correct[i];
        }

        public string[] getAttemptAt(int i)
        {
            return this.attempt[i];
        }

        public bool areCorrectAt(int i)
        {
            return this.ifCorrect[i];
        }
        //true means they got it right
        public void addIfTheyGotItCorrect(bool result)
        {
            ifCorrect.Add(result);
        }

        //Add a correct record
        public void SubmitCorrect(string[] correct)
        {
            string[] temp = new string[AMOUNT_OF_OPTIONS];

            for (int i = 0; i < correct.Length; i++)
            {
                temp[i] = correct[i];
            }
            this.correct.Add(temp);
        }

        //Add a attempt record
        public void SubmitAttempt(string[] attempt)
        {
            string[] temp = new string[AMOUNT_OF_OPTIONS];

            for (int i = 0; i < attempt.Length; i++)
            {
                temp[i] = attempt[i];
            }

            this.attempt.Add(temp);

        }

        public void clearArrays()
        {
            attempt.Clear();
            correct.Clear();
            ifCorrect.Clear();
        }
    }
}
