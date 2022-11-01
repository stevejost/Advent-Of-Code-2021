namespace Day2
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
            

            int horizDistance = 0;
            int vertDistance = 0;

            for(int i=0; i< inputLines.Length; i++)
            {
                var line = inputLines[i].Split(" ");

                int distance = int.Parse(line[1]);
                switch (line[0])
                {
                    case "forward":
                        horizDistance += distance;
                        break;
                    case "down":
                        vertDistance += distance;
                        break;
                    case "up":
                        if (vertDistance - distance < 0)
                        {
                            vertDistance = 0;
                            break;
                        }
                        else
                        {
                            vertDistance -= distance;
                        }
                        break;
                }
            }

            Console.WriteLine("Horiz: {0}", horizDistance);
            Console.WriteLine("Vert: {0}", vertDistance);
            Console.WriteLine(horizDistance * vertDistance);
            Console.ReadLine();
        }

        static void SecondChallenge()
        {
            var inputLines = File.ReadAllLines("input.txt");


            int horizDistance = 0;
            int aim = 0;
            int vertDistance = 0;

            for (int i = 0; i < inputLines.Length; i++)
            {
                var line = inputLines[i].Split(" ");

                int distance = int.Parse(line[1]);
                switch (line[0])
                {
                    case "forward":
                        horizDistance += distance;
                        vertDistance += aim * distance;
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                }
            }

            Console.WriteLine("Horiz: {0}", horizDistance);
            Console.WriteLine("Vert: {0}", vertDistance);
            Console.WriteLine(horizDistance * vertDistance);
            Console.ReadLine();
        }
    }
}