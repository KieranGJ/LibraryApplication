using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class Generation
    {

        const int AMOUNT_OF_NUMBERS_REPLACE = Values.AMOUNT_OF_OPTIONS_REPLACE;
        const int AMOUNT_OF_NUMBERS_IDENTIFY = Values.AMOUNT_OF_OPTIONS_IDENTIFY_QUESTIONS;

        Random rnd = new Random();
        string[] initials = new string[AMOUNT_OF_NUMBERS_REPLACE];
        
        /// <summary>
        /// Returns a dictionary where the category is the key
        /// </summary>
        public Dictionary<string,string> getIdentificationDictionary_KeyisCategory()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string[] categories = new string[AMOUNT_OF_NUMBERS_IDENTIFY];
            string[] callNumbers = new string[AMOUNT_OF_NUMBERS_IDENTIFY];

            //Genereate random categories
            categories = generateRandomCategories(AMOUNT_OF_NUMBERS_IDENTIFY);


            //Generate random numbers
            callNumbers = generateCallNumbers(AMOUNT_OF_NUMBERS_IDENTIFY);
            

            //Replace the first letter of each of the numbers
            callNumbers = manipulateCallsToMatchCategories(categories, callNumbers);

            //Add them to a dictionary
            for (int i = 0; i < categories.Length; i++)
            {
                values.Add(categories[i], callNumbers[i]);
            }
            
            //Send the dictionary through
            return values;
        }

        /// <summary>
        /// Takes an array of categories and an array of calls, then changes the first letter to the call to match 
        /// the category
        /// </summary> 
        /// <returns></returns>
        private string[] manipulateCallsToMatchCategories(string[] categories,string[] calls)
        {
            Values v = new Values();
            Dictionary<string, char> values = v.getValuesAndNumbers_categoryAsKey();

            //Checks the first letter of the number and then changes it to match the letter associated with the category
            for (int i = 0; i < categories.Length; i++)
            {
                calls[i] = calls[i].Remove(0, 1).Insert(0, values[categories[i]].ToString());
            }
            
            return calls;
        }

        /// <summary>
        /// Generates an array of categorys with no duplicates
        /// </summary>
     
        private string[] generateRandomCategories(int size)
        {
            Values v = new Values();
            string[] temp = new string[size];
            string[] cat = new string[Values.AMOUNT_OF_DEWEY_CATEGORIES];
            cat = v.getCategories();
            List<int> indexes = new List<int>();
            bool containsDuplicates = true;

            while (containsDuplicates)
            {
                containsDuplicates = false;
                indexes.Clear();
                for (int i = 0; i < size; i++)
                {
                    indexes.Add(rnd.Next(0, Values.AMOUNT_OF_DEWEY_CATEGORIES));                
                }
                
                containsDuplicates = checkArrayForDuplicates(indexes);
            }

            for (int i = 0; i < size; i++)
            {
                temp[i] = cat[indexes[i]];
            }
            
            return temp;
        }

        /// <summary>
        /// Returns a dictionary where the call number is the key
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> getIdentificationDictionary_CallIsKey()
        {

            string[] calls = new string[AMOUNT_OF_NUMBERS_IDENTIFY];
            //Fills calls with random calls
            calls = generateCallNumbers(calls.Length);
            Dictionary<string, string> dictionaryCalls = new Dictionary<string, string>();
            string temp;
            char character;
            //string category;

            //Adds the values to a dictionary with the call as the key and the Category as the value
            for (int i = 0; i < calls.Length; i++)
            {
                temp = calls[i];
                character = temp[0];
                dictionaryCalls.Add(temp, getDescription(character));
            }

            return dictionaryCalls;
        }

        private char getCallNumbers(string category)
        {
            Values v = new Values();
            Dictionary<string, char> valuesAndNumbers = v.getValuesAndNumbers_categoryAsKey();
            char number = valuesAndNumbers[category];
            return number;
        }

        private string getDescription(char character)
        {
            Values v = new Values();
            Dictionary<char, string> valuesAndNumbers = v.getValuesAndNumbers_numbersAsKey();           
            string category = valuesAndNumbers[character];
            return category;
          
        }


        /// <summary>
        /// Generates X amount of call numbers with no dupicates
        /// </summary>           
        public string[] generateCallNumbers(int amountOfCallNumbers)
        {
            StringBuilder sb = new StringBuilder();
            double[] numbers = new double[amountOfCallNumbers];
            string[] letters = new string[amountOfCallNumbers];
            char[] word = new char[3];
            bool duplicatesFound = true;
            string[] calls = new string[amountOfCallNumbers];
            bool duplicateClasses = true;

            while (duplicatesFound || duplicateClasses)
            {

                for (int j = 0; j < amountOfCallNumbers; j++)
                {

                    numbers[j] = Math.Round(rnd.NextDouble() * (1000 - 1) + 1, 2);

                    for (int i = 0; i < 3; i++)
                    {
                        int ascii_index = rnd.Next(65, 91); //ASCII character codes 65-90
                        word[i] = Convert.ToChar(ascii_index); //produces any char A-Z
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        sb.Append(word[i]);
                    }

                    letters[j] = sb.ToString();

                    sb.Clear();
                }

                duplicatesFound = checkArrayForDuplicates(numbers);
                var temp = convertTwoDigitToThreeDigit(numbers, amountOfCallNumbers);
                duplicateClasses = checkForDuplicateClasses(temp);

            }


            var numbersAsString = convertTwoDigitToThreeDigit(numbers, amountOfCallNumbers);

            //Combines the numbers and the initals
            for (int i = 0; i < numbersAsString.Length; i++)
            {
                sb.Append(numbersAsString[i]);
                sb.Append(" ");
                sb.Append(letters[i]);

                calls[i] = sb.ToString();
                sb.Clear();
            }
            return calls;
        }

        private bool checkForDuplicateClasses(string[] numbers)
        {
         
            List<char> chars = new List<char>();
            string temp;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                temp = numbers[i];               
                if (chars.Contains(temp[0]))
                {
                    return true;
                }
                chars.Add(temp[0]);
            }

            return false;
        }

        public string[] generateRandomLettersReplace()
        {
                        
            double[] numbers = new double[AMOUNT_OF_NUMBERS_REPLACE];

            char[] word = new char[3];
            
            string[] callNumbers = new string[AMOUNT_OF_NUMBERS_REPLACE];
            StringBuilder sb = new StringBuilder();
            bool duplicatesFound = true;

            while (duplicatesFound)
            {
          
                for (int j = 0; j < AMOUNT_OF_NUMBERS_REPLACE; j++)
                {
                
                    numbers[j] = Math.Round(rnd.NextDouble() * (1000 - 1) + 1, 2);

                    for (int i = 0; i < 3; i++)
                    {
                        int ascii_index = rnd.Next(65, 91); //ASCII character codes 65-90
                        word[i] = Convert.ToChar(ascii_index); //produces any char A-Z
                    }
                                   
                    for (int i = 0; i < 3; i++)
                    {
                        sb.Append(word[i]);
                    }

                    initials[j] = sb.ToString();

                    sb.Clear();
                }

                duplicatesFound = checkArrayForDuplicates(numbers);

            }

            Array.Sort(numbers);

            numbers = duplicateANumberInAnArray_And_SortInitials(numbers);          

            var numbersAsString = convertTwoDigitToThreeDigit(numbers, AMOUNT_OF_NUMBERS_REPLACE);


            for (int i = 0; i < numbersAsString.Length; i++)
            {
                sb.Append(numbersAsString[i]);
                sb.Append(" ");
                sb.Append(initials[i]);

                callNumbers[i] = sb.ToString();
                sb.Clear();
            }
                    
            return callNumbers;
        }
       /// <summary>
       /// Gets an array and returns a list of the index of all numbers in the array which 
       /// are less than 100
       /// </summary>
       /// <returns></returns>
        private List<int> getIndexesOfNumbersLessThan100(double[] numbers)
        {
            List<int> indexesLowerThan100 = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 100)
                {
                    indexesLowerThan100.Add(i);
                }
            }

            return indexesLowerThan100;
        }

        /// <summary>
        /// Takes a 2 digit number and converts it to a 3 digit number by adding 0 to the start
        /// of it
        /// </summary>
        /// <returns></returns>
        private string[] convertTwoDigitToThreeDigit(double[] numbers,int amount)
        {
            List<int> indexes = new List<int>();
            string[] numbersAsString = new string[amount];
            

            //Get the index numbers of all numbers lower than 100
            indexes = getIndexesOfNumbersLessThan100(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersAsString[i] = numbers[i].ToString();
            }

            if (indexes.Count > 0)
            {   
                //Convert the double array to a string array
                
                string temp;
                int index;

                //Convert all the two digit numbers to 3 digit numbers by adding a 0 before them
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < indexes.Count; i++)
                {
                    index = indexes[i];
                    temp = numbers[index].ToString();
                    sb.Append("0");
                    sb.Append(temp);
                    numbersAsString[index] = sb.ToString();
                    sb.Clear();
                }
            }
            
            return numbersAsString;
        }

        //Checks for duplicates in an array
        private bool checkArrayForDuplicates(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j != i)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;          
        }

        private bool checkArrayForDuplicates(List<int> numbers)
        {
         
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    //Must not compare the same index
                    if (j != i)
                    {
                        if (numbers[i] == numbers[j])
                        {
                           
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public double[] duplicateANumberInAnArray_And_SortInitials(double[] numbers)
        {

            int index1 = rnd.Next(4);
            int index2 = rnd.Next(4);

            while(index1 == index2)
            {
                index2 = rnd.Next(4);
            }

            numbers[index2] = numbers[index1];
            Array.Sort(numbers);

            string[] names = new string[2];


            double temp = 4000;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (temp == numbers[i])
                {
                    index1 = i - 1;
                    index2 = i;
                    break;
                }
                temp = numbers[i];
            }


            names[0] = initials[index1];
            names[1] = initials[index2];

            Array.Sort(names);

            initials[index1] = names[0];
            initials[index2] = names[1];


            return numbers;
        }

    }
}
