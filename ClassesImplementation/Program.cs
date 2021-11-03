using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            int height, width;

            int[,] array;
            Console.WriteLine("Please insert the height and width of your array");
            height = Convert.ToInt32(Console.ReadLine());
            width = Convert.ToInt32(Console.ReadLine());


            array = ArrayManager.CreateArray(height, width);
            Printer.Print(array);
            Console.WriteLine();
            Printer.Print(ArrayManager.GetDiagonal(array));
            Console.WriteLine(ArrayManager.GetMax(array));
            Console.WriteLine(ArrayManager.GetMin(array));
            Console.WriteLine(ArrayManager.GetMaxIndex(array));
            Console.WriteLine(ArrayManager.GetMinIndex(array));


            Console.ReadKey();
        }
    }

    class ArrayManager
    {
        /// <summary>
        /// Creates an Array with random numbers in it
        /// </summary>
        /// <param name="height">height of the array</param>
        /// <param name="width"> width of the array</param>
        /// <returns></returns>
        public static int[,] CreateArray(int height, int width)
        {
            int[,] array = new int[height, width];
            Random rnd = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    array[i, j] = rnd.Next(10);
                }
            }
            return array;
        }

        /// <summary>
        /// Gets the max element of the 1D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMax(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }
            return max;
        }

        /// <summary>
        /// Gets the max element of the 2D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMax(int[,] array)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (max < array[i, j])
                        max = array[i, j];
                }
            }
            return max;
        }

        /// <summary>
        /// Gets the min element of the 1D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMin(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i])
                    min = array[i];
            }
            return min;
        }

        /// <summary>
        /// Gets the min element of the 1D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMin(int[,] array)
        {
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (min > array[i, j])
                        min = array[i, j];
                }
            }
            return min;
        }

        /// <summary>
        /// Gets the main diagonal of the array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] GetDiagonal(int[,] array)
        {
            int[] diagonal = new int[array.GetLength(0)];
            if (array.GetLength(0) == array.GetLength(1))
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (i == j)
                            diagonal[i] = array[i, j];
                }
            return diagonal;
        }

        /// <summary>
        /// Gets the index of maximum element in 1D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMaxIndex(int[] array)
        {
            int maxIndex = 0;
            for(int i = 0; i < array.Length; i++) 
            { 
                if(array[i] == GetMax(array))
                {
                    maxIndex = i;
                    break;
                }
            }

            return maxIndex;
        }

        /// <summary>
        /// Gets the index of maximum element in 2D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static (int,int) GetMaxIndex(int[,] array)
        {
            int maxIndex1 = 0, maxIndex2 = 0;
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i,j] == GetMax(array))
                    {
                        maxIndex1 = i;
                        maxIndex2 = j;
                        break;
                    }
                        
                }
            }
            return (maxIndex1, maxIndex2);
        }

        /// <summary>
        /// Gets the index of minimum element in 1D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetMinIndex(int[] array)
        {
            int minIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == GetMin(array))
                {
                    minIndex = i;
                    break;
                }
            }

            return minIndex;
        }

        /// <summary>
        /// Gets the index of minimum element in 2D array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static (int, int) GetMinIndex(int[,] array)
        {
            int minIndex1 = 0, minIndex2 = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == GetMin(array))
                    {
                        minIndex1 = i;
                        minIndex2 = j;
                        break;
                    }

                }
            }
            return (minIndex1, minIndex2);
        }

        /// <summary>
        /// Swaps min and max elements of the 1D array
        /// </summary>
        /// <param name="array"></param>
        public static void Swap(int[] array)
        {
            int temp = array[GetMaxIndex(array)];
            array[GetMaxIndex(array)] = array[GetMinIndex(array)];
            array[GetMinIndex(array)] = temp;
        }


        /// <summary>
        /// Swaps min and max elements of the 2D array
        /// </summary>
        /// <param name="array"></param>
        public static void Swap(int[,] array)
        {
            int temp = array[GetMaxIndex(array).Item1, GetMaxIndex(array).Item2];
            array[GetMaxIndex(array).Item1, GetMaxIndex(array).Item2] = array[GetMinIndex(array).Item1, GetMinIndex(array).Item2]; ;
            array[GetMinIndex(array).Item1, GetMinIndex(array).Item2] = temp;

        }
    }


    static class Printer
    {
        /// <summary>
        /// Prints given 1D array
        /// </summary>
        /// <param name="array"></param>
        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Prints given 2D array
        /// </summary>
        /// <param name="array"></param>
        public static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
