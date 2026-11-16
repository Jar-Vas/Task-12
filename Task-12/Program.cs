using System.Linq.Expressions;

namespace Task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.WriteLine("Task-1");
            string filePathPrime = "prime.txt";
            string filePathFib = "fib.txt";
            int size = 100;
            int[] arr1 = new int[size];
            bool[] arr2 = new bool[size];
            bool[] arr3 = new bool[size];
            for (int i = 0; i < arr1.Count(); i++) { arr1[i] = rand.Next(1, int.MaxValue); arr2[i] = isPrime(arr1[i]); arr3[i] = isFib(arr1[i]); }
            //for (int i = 0; i < size; i++) { Console.WriteLine(arr2[i] + " " + arr3[i] + " " + arr1[i]); }
            File.WriteAllText(filePathPrime, ""); //clear and open
            File.WriteAllText(filePathFib, "");
            for (int i = 0; i < size; i++)
            {
                if (arr2[i]) { File.AppendAllText(filePathPrime, arr1[i].ToString() + " "); }  // Add with append
                if (arr3[i]) { File.AppendAllText(filePathFib, arr1[i].ToString() + " "); }
            }


            Console.WriteLine("Task-2");
            string filePath2 = "prime.txt";
            Console.Write("Input word to change: ");
            string wordToChange = Console.ReadLine();
            Console.Write("Input word change to: ");
            string wordChangeTo = Console.ReadLine();
            string data2 = File.ReadAllText(filePath2);
            string outData2 = "";
            for (int i = 0; i < data2.Count() - wordToChange.Count(); i++)
            {
                bool k = true;
                for (int j = 0; j < wordToChange.Count(); j++)
                {
                    if (data2[i+j] != wordToChange[j]) { k = false; break; }
                }
                if (k)
                {
                    outData2 += wordChangeTo;
                    i += wordToChange.Count() - 1;
                    //Console.WriteLine("Word fined");
                }
                else
                {
                    outData2 += data2[i];
                }
            }
            File.WriteAllText(filePath2, outData2);
            //Console.WriteLine(outData2);


            Console.WriteLine("Task-3");
            List<string> banWords = new List<string>();
            Console.Write("Write file path: ");
            string filePath3 = Console.ReadLine();
            Console.WriteLine("Write all words to ban or press ENTER to leave: ");
            string banWord;
            do
            {
                Console.Write("input: ");
                banWord = Console.ReadLine();
                banWords.Add(banWord);
            }
            while (banWord != "" && banWord != null);

            string data3 = File.ReadAllText(filePath3);
            string outData3 = "";
            foreach (string t in banWords)
            {
                for (int i = 0; i < data3.Count() - t.Count(); i++)
                {
                    bool k = true;
                    for (int j = 0; j < t.Count(); j++)
                    {
                        if (data3[i + j] != t[j]) { k = false; break; }
                    }
                    if (k)
                    {
                        for (int h = 0; h < t.Count(); h++)
                        {
                            outData3 += "#";
                        }
                        i += t.Count() - 1;
                        //Console.WriteLine("Word fined");
                    }
                    else
                    {
                        outData3 += data3[i];
                    }
                }
            }
            File.WriteAllText(filePath3, outData3);


            Console.WriteLine("Task-4");
            Console.Write("Write file path: ");
            string filePath4 = Console.ReadLine();
            string data4 = File.ReadAllText(filePath4);
            data4.Reverse();
            File.WriteAllText("reversed_" + filePath4, data4);

        }
        static bool isPrime(long number) // start
        {
            // O(sqrt(n)/2) in worth way. For long.max it be < 500M operation. For int.max in be < 50K operation
            if (number % 2 == 0) { return false; }
            for (int i = 3; i < ((int)Math.Sqrt(number)) + 1; i += 2)
            {
                if (number % i == 0) { return false; }
            }
            return true;
        }

        static bool isPerfectSquare(long number)
        {
            if (number < 0) return false;
            long root = (long)Math.Sqrt(number);
            return root * root == number;
        }

        static bool isFib(int number)
        {
            if (number < 0) return false;
            long n = number; 
            return isPerfectSquare(5 * n * n - 4) || isPerfectSquare(5 * n * n + 4); //magic formula
        }
    }
}
