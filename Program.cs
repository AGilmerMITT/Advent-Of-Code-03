namespace Advent_Of_Code_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int prioritySum = 0;
            bool collectingData = true;
            while (collectingData)
            {
                string bag = GetInput("Put bag here");
                prioritySum += ParseBag(bag);
                if (bag == "")
                {
                    collectingData = false;
                }
            }
            Console.WriteLine($"Full priority sum: {prioritySum}");
        }

        static string GetInput(string prompt)
        {
            bool validResult = false;
            string? input = null;
            while (!validResult)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (input != null)
                {
                    validResult = true;
                }
            }

            return input!;
        }

        static int ParseBag(string bag)
        {
            HashSet<char> firstCompartment = new HashSet<char>(bag[..(bag.Length / 2)]);
            HashSet<char> secondCompartment = new HashSet<char>(bag[(bag.Length / 2)..]);
            var overlap = firstCompartment.Intersect(secondCompartment).ToArray();

            if (overlap.Length > 0)
            {
                return GetPriority(overlap[0]);
            }

            return 0;
        }

        static int GetPriority(char letter)
        {
            if (char.IsLower(letter))
            {
                return letter + 1 - 'a';
            }

            return letter + 27 - 'A';
        }
    }
}