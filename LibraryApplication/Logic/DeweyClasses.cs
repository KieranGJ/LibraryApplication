using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
    public class DeweyClasses
    {
        /// <summary>
        /// Takes a smaller array, puts it into a larger one, then fills the rest of the larger array with dummy values
        /// </summary>
        public string[] addDummyClasses_CallIsKey(string[] calls, int arraySize)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Items in calls :");
            foreach (var item in calls)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
            List<string> filledArray = new List<string>();
            
            string[] allClasses = new string[10];
            

            //The intended array size cannot be smaller than the original array
            if (calls.Length > arraySize)
            {
                return calls;
            }

            //How many more values need to be added
            int difference = arraySize - calls.Length;

            allClasses = fillWithAllClasses(allClasses);

            for (int i = 0; i < calls.Length; i++)
            {
                filledArray.Add(calls[i]);
            }

            Random rnd = new Random();
            int index;
            string temp;
            bool duplicateDetected = true;

            //Loops to fill the rest of the values
            for (int i = 0; i < difference; i++)
            {
                duplicateDetected = true;
                //Makes sure a duplicate cannot be added
                while (duplicateDetected)
                {
                    index = rnd.Next(0, 10);
                    temp = allClasses[index];

                    //Checks if the array already contains that class
                    if (!filledArray.Contains(temp))
                    {
                        //If it doesn't contain that class then it add the value to the array
                        duplicateDetected = false;
                        filledArray.Add(temp);
                    }
                    else{duplicateDetected = true;}
                    
                }
            }

            string[] finalArray = new string[filledArray.Count];

            //Convert the List to an array
            for (int i = 0; i < filledArray.Count; i++)
            {
                finalArray[i] = filledArray[i];
            }

            Console.WriteLine("--------------------------");
            Console.WriteLine("Final array : ");
            foreach (var item in finalArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------");
            return finalArray;
        }

        /// <summary>
        /// Takes a smaller array, puts it into a larger one, then fills the rest of the larger array with dummy values
        /// </summary>
        public string[] addDummyClasses_CategoryIsKey(string[] calls, int arraySize)
        {

            if (arraySize < calls.Length)
            {
                return null;
            }
            string[] endArray = new string[arraySize];
            Random rnd = new Random();
            char[] word = new char[3];
            List<char> characters = new List<char>();
            List<string> callList = new List<string>();
            List<char> possibleCalls = getAllCallCharacters();
            
            //Take the first character to compare
            //Start filling a list with the current calls
            foreach (var item in calls)
            {
                characters.Add(item[0]);
                possibleCalls.Remove(item[0]);
                callList.Add(item);
            }

            //Randomize the possible call numbers
            possibleCalls = randomizeArray(possibleCalls);
            string result;
            StringBuilder sb = new StringBuilder();
            int difference = arraySize - callList.Count;
            double[] numbers = new double[difference];
            Generation g = new Generation();
            string[] restOfTheCallNumbers = g.generateCallNumbers(difference);
            for (int i = 0; i < restOfTheCallNumbers.Length; i++)
            {
                result = restOfTheCallNumbers[i];
                result = result.Remove(0, 1).Insert(0, possibleCalls[i].ToString());
                callList.Add(result);
            }

            for (int i = 0; i < callList.Count; i++)
            {
                //Checks to see if any 2 digit numbers slipped through (Possible if the number was a single digit number)
                //Then copies the first number and adds it to the front of the list
                if (callList[i][2] == ',')
                {
                    callList[i] = callList[i][0].ToString() + callList[i];
                }

                endArray[i] = callList[i];
            }

            return endArray;
        }

        //Takes an array and randomizes it
        private List<char> randomizeArray(List<char> array)
        {
            Random rnd = new Random();
            char temp;
            int index1;
            int index2;
            for (int i = 0; i < array.Count; i++)
            {
                index1 = rnd.Next(0, array.Count-1);
                index2 = rnd.Next(0, array.Count - 1);
                temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;
            }
            return array;
        }

        //Returns a list with chars 0-9
        private List<char> getAllCallCharacters()
        {
            char[] results = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<char> _char = new List<char>();

            foreach (var item in results)
            {
                _char.Add(item);
            }                                  
            return _char;
        }

        //Fills an array with every possible class
        private string[] fillWithAllClasses(string[] allClasses)
        {
            try
            {
                allClasses[0] = Values.CLASS_000;
                allClasses[1] = Values.CLASS_100;
                allClasses[2] = Values.CLASS_200;
                allClasses[3] = Values.CLASS_300;
                allClasses[4] = Values.CLASS_400;
                allClasses[5] = Values.CLASS_500;
                allClasses[6] = Values.CLASS_600;
                allClasses[7] = Values.CLASS_700;
                allClasses[8] = Values.CLASS_800;
                allClasses[9] = Values.CLASS_900;
                return allClasses;
            }
            catch (Exception)
            {            
                return allClasses;
            }



        }

        public string[] getClassesRandomized()
        {
            string[] classes = new string[Values.AMOUNT_OF_OPTIONS_IDENTIFY_ANSWERS];

            


            return classes;
        }

        
    }
}
