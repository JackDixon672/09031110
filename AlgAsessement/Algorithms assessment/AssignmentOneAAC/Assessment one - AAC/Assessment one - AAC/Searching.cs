using System;

namespace Assessment_one___AAC
{
    class Searching
    {
        public int binarySearch(int[] array, int searchItem, int leftPointer, int rightPointer, bool reverse, int nearestValue = 0)
        {
            //If number is not found, return the nearest value index subtracted from negative one
            if (leftPointer > rightPointer) return -1 - nearestValue;

            int midPointer = (leftPointer + rightPointer) / 2;

            //Checking if the current mid value is closer to the search item than what is currently considered the nearest value
            nearestValue = checkNearest(array, searchItem, nearestValue, midPointer);

            if (searchItem == array[midPointer])
                //Return the current value if it matches the search item
                return midPointer; 
            //Recursively calling the method if necessary. Scenarios for both ascending and descending are accounted for
            else if ((searchItem > array[midPointer] && !reverse) || (searchItem < array[midPointer] && reverse))
                return binarySearch(array, searchItem, midPointer + 1, rightPointer, reverse, nearestValue);
            else
                return binarySearch(array, searchItem, leftPointer, midPointer - 1, reverse, nearestValue);           
        }

        public int fibonacciGenerator(int x)
        {
            //Generates a required fibonacci number
            if (x < 2) return x; else return fibonacciGenerator(x - 2) + fibonacciGenerator(x - 1);
        }

        public int fibonacciSearch(int[] array, int searchItem, bool reverse)
        {
            int nearestValue = 0;
            int m = 0;
            int offset = -1;

            //Finding the earliest fibonacci number that is larger than the array's length
            while (fibonacciGenerator(m) < array.Length) m++;

            while (fibonacciGenerator(m) > 1)
            {
                int i = Math.Min(offset + fibonacciGenerator(m - 2), array.Length - 1);
                nearestValue = checkNearest(array, searchItem, nearestValue, i);
                if ((searchItem > array[i] && !reverse) || (searchItem < array[i] && reverse))
                {
                    m--;
                    offset = i;
                }
                else if ((searchItem < array[i] && !reverse) | (searchItem > array[i] && reverse))
                    m -= 2;
                else
                    return i;
            }
            //If number is not found, return the nearest value index subtracted from negative one
            return -1 - nearestValue;
        }

        static int checkNearest(int[] array, int searchItem, int nearestValue, int index)
        {
            //Checking the absolute difference between the current nearest value and the current item being checked. Returning the one closest to the search item.
            if (Math.Abs(searchItem - array[nearestValue]) > Math.Abs(searchItem - array[index])) return index; else return nearestValue;
        }
    }

}
