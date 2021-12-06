using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    class CreateString
    {
        public string createCorrectAndAttemptStrings(string[] temp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" ");
            foreach (var item in temp)
            {
                
                sb.Append(item);

                var tryish = item[5];
                //Append an extra space if the item is a 2 digit double
                if (item[5].Equals(' '))
                {
                    sb.Append(" ");
                }
                sb.Append(" | ");
            }


            return sb.ToString();
        }

    }
}
