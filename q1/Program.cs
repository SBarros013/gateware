using System;
using System.Linq;

namespace q1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generating randomic array;
            var numbers = RandomicArray(10);

            Console.WriteLine(numbers.Max());
        }

        public static int[] RandomicArray(int size)
        {
            int[] numbers = new int[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
                numbers[i] = random.Next(1, 1000);

            return numbers;
        }
    }
}
