using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Logic
{
   public class DeweyRandom
    {
        /// <summary>
        /// Tier is the tree 
        /// It returns 3 random index values that can be used to access the
        /// third tier of the tree.
        /// The values are randomly generated based on the the max 
        /// amount of nodes in that tier of the tree which allows it to scale outwards instead of downwards
        /// </summary> 
        public int[] getRandomThirdLevelEntry(DeweyTree t1)
        {
            int[] indexes = new int[3];
            Random rnd = new Random();
            int upperIndex = t1.t1.Count;
            indexes[0] = rnd.Next(0,upperIndex);
            upperIndex = t1.t1[indexes[0]].t1.Count;
            indexes[1] = rnd.Next(0, upperIndex);
            upperIndex = t1.t1[indexes[0]].t1[indexes[1]].t1.Count;
            indexes[2] = rnd.Next(0, upperIndex);
        
            return indexes;
        }

        /// <summary>
        /// Takes a tree and an index, then returns 3 other indexes from the first nodes
        /// </summary>   
        public int[] fillFirstLevelEntriesWithDummies(int orginalIndex,DeweyTree t1)
        {

            Random rnd = new Random();
            int[] indexes = new int[4];
            indexes[0] = orginalIndex;
            List<int> possibilities = new List<int>();
            for (int i = 0; i < t1.t1.Count; i++)
            {
                possibilities.Add(i);
            }
            //Remove the original index from the option of generated indexes
            possibilities.Remove(orginalIndex);
            for (int i = 0; i < 3; i++)
            {
                indexes[i + 1] = possibilities[rnd.Next(0, possibilities.Count)];
                possibilities.Remove(indexes[0 + 1]);
            }
            indexes = putIndexesInOrder(indexes, t1);

            return indexes;
        }

        public int[] putIndexesInOrder(int[] indexes, DeweyTree t1)
        {

            //Bubble Sort
            bool swapped = true;
            int temp;
            char one;
            char two;
            while (swapped)
            {
                swapped = false;
                for (int i = 0; i < indexes.Length-1; i++)
                {
                    one = t1.t1[indexes[i]].call[0];
                    two = t1.t1[indexes[i+1]].call[0];
                    if (one > two)
                    {
                        temp = indexes[i];
                        indexes[i] = indexes[i+1];
                        indexes[i + 1] = temp;
                        swapped = true;
                    }
                }
            }





            return indexes;


          
        }

    }


}
