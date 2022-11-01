namespace Advent2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstChallenge();
            SecondChallenge();
        }

        static void FirstChallenge()
        {
            var inputLines = File.ReadAllLines("input.txt");
            var input = inputLines.Select(int.Parse).ToArray();

            int increase = 0;
            int decrease = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > input[i - 1])
                {
                    increase++;
                }
                else if (input[i] < input[i - 1])
                {
                    decrease++;
                }

            }

            Console.WriteLine("Increase {0}", increase);
            Console.WriteLine("Decrease {0}", decrease);
            Console.ReadLine();
        }

        static void SecondChallenge()
        {
            var inputLines = File.ReadAllLines("input.txt");
            var input = inputLines.Select(int.Parse).ToArray();

            int increase = 0;
            int decrease = 0;

            var sums = new List<int>();

            for (int i = 2; i < input.Length; i++)
            {
                var slidingSum = input[i] + input[i - 1] + input[i - 2];
                sums.Add(slidingSum);
                
            }
            var sumsAry = sums.ToArray();
            for (int i = 1; i < sumsAry.Length; i++)
            {
                if (sumsAry[i] > sumsAry[i - 1])
                {
                    increase++;
                }
                else if (sumsAry[i] < sumsAry[i - 1])
                {
                    decrease++;
                }

            }

            Console.WriteLine("Increase {0}", increase);
            Console.WriteLine("Decrease {0}", decrease);
            Console.ReadLine();
        }

    }
}