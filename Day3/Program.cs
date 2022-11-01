namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //FirstChallenge();
            var inputLines = File.ReadAllLines("input.txt");
            
            var resultDict = FirstChallenge();
            var result = MarchTop(inputLines.ToList());

            var resultBottom = MarchBottom(inputLines.ToList());

        }

        static string MarchTop(List<string> inputLines, string input = "", int iter = 0)
        {
            //var firstOne = inputLines.Where(l => l.StartsWith("101"));

            var sortedEntries = inputLines.GroupBy(x => x.Substring(iter, 1), (beginning, entries) => new { Beginning = beginning, Entries = entries });

            if(inputLines.Count == 1)
            {
                Console.WriteLine("Found it! {0}", inputLines[0]);
                return inputLines[0];
            }

            var zeroes = sortedEntries.Single(s => s.Beginning == "0");
            var ones = sortedEntries.Single(s => s.Beginning == "1");
            
            if(ones.Entries.Count() >= zeroes.Entries.Count())
            {
                return MarchTop(ones.Entries.ToList(), input + "1", iter+1);
                
            } 
            else
            {
                return MarchTop(zeroes.Entries.ToList(), input + "0", iter + 1);
            }

        }

        static string MarchBottom(List<string> inputLines, string input = "", int iter = 0)
        {
            //var firstOne = inputLines.Where(l => l.StartsWith("101"));

            var sortedEntries = inputLines.GroupBy(x => x.Substring(iter, 1), (beginning, entries) => new { Beginning = beginning, Entries = entries });

            if (inputLines.Count == 1)
            {
                Console.WriteLine("Found it! {0}", inputLines[0]);
                return inputLines[0];
            }

            var zeroes = sortedEntries.Single(s => s.Beginning == "0");
            var ones = sortedEntries.Single(s => s.Beginning == "1");

            if (ones.Entries.Count() < zeroes.Entries.Count())
            {
                return MarchBottom(ones.Entries.ToList(), input + "1", iter + 1);

            }
            else
            {
                return MarchBottom(zeroes.Entries.ToList(), input + "0", iter + 1);
            }

        }

        static Dictionary<string,string> FirstChallenge()
        {
            var inputLines = File.ReadAllLines("input.txt");
            var outputDict = new Dictionary<string, string>();
            bool[,] lineArray = new bool[inputLines.Length,12];

            for (int i = 0; i < inputLines.Length; i++)
            {
                var line = inputLines[i];
                var lineChars = line.ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    lineArray[i, j] = lineChars[j].Equals('1') ? true : false;
                }
            }

            //100100110110

            int charCount = 12;
            string topResult = string.Empty;
            string bottomResult = string.Empty;
            for(int foo=0; foo<charCount; foo++)
            {
                int countOne = 0;
                for (int i = 0; i < inputLines.Length; i++)
                {
                    countOne += lineArray[i, foo] ? 1 : 0;
                }

                if (countOne > inputLines.Length / 2)
                {
                    topResult += "1";
                }
                else
                {
                    bottomResult += "0";
                }
            }

            outputDict.Add("top", topResult);
            outputDict.Add("bottom", bottomResult);
            return outputDict;
        }
    }
}