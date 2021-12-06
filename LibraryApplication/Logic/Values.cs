using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class Values
    {
        public const int AMOUNT_OF_CLASSES = 10;

        public const int AMOUNT_OF_OPTIONS_REPLACE = 10;

        public const int AMOUNT_OF_OPTIONS_IDENTIFY_QUESTIONS = 4;

        public const int AMOUNT_OF_OPTIONS_IDENTIFY_ANSWERS = 7;

        public const int AMOUNT_OF_DEWEY_CATEGORIES = 10;

        public const string IDENTIFY_TABLE_NAME = "SCORES_Identify_Areas";
        public const string CALL_NUMBERS_TABLE_NAME = "Scores_Call_Numbers";

        public Dictionary<char, string> valuesAndNumbers = new Dictionary<char, string>();
        public Dictionary<string, char> valuesAndNumbersCategory = new Dictionary<string, char>();

        public const string CLASS_000 = "General works";
        public const string CLASS_100 = "Philosophy and Psychology";
        public const string CLASS_200 = "Religion";
        public const string CLASS_300 = "Social Sciences";
        public const string CLASS_400 = "Language";
        public const string CLASS_500 = "Pure Science";
        public const string CLASS_600 = "Technology";
        public const string CLASS_700 = "Arts and recreation";
        public const string CLASS_800 = "Literature";
        public const string CLASS_900 = "History and Geography";
    

        public string[] getCategories()
        {
            string[] categories = new string[AMOUNT_OF_DEWEY_CATEGORIES];
            categories[0] = CLASS_000;
            categories[1] = CLASS_100;
            categories[2] = CLASS_200;
            categories[3] = CLASS_300;
            categories[4] = CLASS_400;
            categories[5] = CLASS_500;
            categories[6] = CLASS_600;
            categories[7] = CLASS_700;
            categories[8] = CLASS_800;
            categories[9] = CLASS_900;
            return categories;
        }



        public Dictionary<char,string> getValuesAndNumbers_numbersAsKey()
        {
            valuesAndNumbers.Add('0', CLASS_000);
            valuesAndNumbers.Add('1', CLASS_100);
            valuesAndNumbers.Add('2', CLASS_200);
            valuesAndNumbers.Add('3', CLASS_300);
            valuesAndNumbers.Add('4', CLASS_400);
            valuesAndNumbers.Add('5', CLASS_500);
            valuesAndNumbers.Add('6', CLASS_600);
            valuesAndNumbers.Add('7', CLASS_700);
            valuesAndNumbers.Add('8', CLASS_800);
            valuesAndNumbers.Add('9', CLASS_900);

            return valuesAndNumbers;
        }

        public Dictionary<string, char> getValuesAndNumbers_categoryAsKey()
        {

            valuesAndNumbersCategory.Add(CLASS_000, '0');
            valuesAndNumbersCategory.Add(CLASS_100, '1');
            valuesAndNumbersCategory.Add(CLASS_200, '2');
            valuesAndNumbersCategory.Add(CLASS_300, '3');
            valuesAndNumbersCategory.Add(CLASS_400, '4');
            valuesAndNumbersCategory.Add(CLASS_500, '5');
            valuesAndNumbersCategory.Add(CLASS_600, '6');
            valuesAndNumbersCategory.Add(CLASS_700, '7');
            valuesAndNumbersCategory.Add(CLASS_800, '8');
            valuesAndNumbersCategory.Add(CLASS_900, '9');

            return valuesAndNumbersCategory;
        }

    }
}
