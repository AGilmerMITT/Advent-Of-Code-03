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
                string[] bags = { GetInput("First bag of group:"), GetInput("Second bag of group:"), GetInput("Third bag of group:") };

                //prioritySum += ParseBag(bag);
                //if (bag == "")
                //{
                //    collectingData = false;
                //}
                int priority = GetPriority(GetBadge(bags));
                prioritySum += priority;
                if (priority == 0)
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

        static char GetBadge(string[] bags)
        {
            if (bags.Length == 0)
            {
                throw new Exception("Must have bags for comparison");
            }

            IEnumerable<char> result = new List<char>(bags[0]);
            for (int i = 1; i < bags.Length; i++)
            {
                result = result.Intersect(bags[i]);
            }

            if (result.Count() > 1)
            {
                throw new Exception("Multiple potential badges found");
            }

            if (result.Count() == 0)
            {
                return '0';
            }

            return result.ToArray()[0];
        }

        static int GetPriority(char letter)
        {
            if (letter == '0')
            {
                return 0;
            }

            if (char.IsLower(letter))
            {
                return letter + 1 - 'a';
            }

            return letter + 27 - 'A';
        }
    }
}