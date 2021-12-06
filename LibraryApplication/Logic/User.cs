using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class User
    {
        public int amountCorrect { get; set; }
        public string time { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string Date_of_score { get; set; }


        private static User myInstance;


        public User Instance()
        {
            if (myInstance == null)
                myInstance = new User();

            return myInstance;
        }
    }
}
