using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysAndLists
{
    public class Arrays_List
    {
        public static void FriendLike()
        {
            List<string> Names = new List<string>();
            
            while (true)
            {
                var name = "";
                Console.WriteLine("Please enter a name or press ENTER to exit.");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    break;
                }
                else
                {
                    //trim method to delete any extra whitespace
                    name = name.Trim();
                    Names.Add(name);
                }

            }

            if (!Names.Any())
            {
                //list is empty
            }
            else
            {
                if (Names.Count == 1)
                {
                    Console.WriteLine("{0} likes your post.", Names[0]);
                }
                    
                else if (Names.Count == 2)
                {
                    Console.WriteLine("{0} and {1} like your post.", Names[0], Names[1]);
                }
                else
                {
                    Console.WriteLine("{0}, {1} and {2} others like your post.", Names[0], Names[1], (Names.Count - 2));
                }
            }
        }

        public static void ReverseName()
        {
            Console.WriteLine("Please enter your name.");
            var name = Console.ReadLine();
            name = name.Trim(); //make sure there are no white spaces
            var reveresedName = new Char[name.Length];
            for (int i = name.Length - 1; i >= 0; i--)// will go backwards through name
            {
                reveresedName[name.Length - (i + 1)] = name[i];//no new variabeles created to reverse name
                //logic in brackets plays with the math needed to go through 0-n and n-0 simultaneously
            }

            foreach (var letter in reveresedName)
            {
                Console.Write(letter);
            }

            Console.WriteLine();
        }

        public static void UniqueNumberSort()
        {
            var nums = new int[5];

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter the {0} number.", Enum.GetName(typeof(Numbers), i + 1));
                var input = Convert.ToInt32(Console.ReadLine());
                //Convert doesn't account for user error  (eg entering "abc")
                //exception must be thrown to handle this
                while (nums.Contains(input))
                {
                    Console.WriteLine("That number has already been entered. Please input a unique number.");
                    input = Convert.ToInt32(Console.ReadLine());
                }

                nums[i] = input;
            }

            Array.Sort(nums);
            Console.Write("The numbers sorted are: ");
            for(int i = 0; i < 5; i++)
            {
                Console.Write("{0} ", nums[i]);

            }
        }

        public static void DisplayUnique()
        {
            var uniqueNumbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Please enter a number.");
                var input = Console.ReadLine();//does not account for invalid input
                if (input == "Quit")
                    break;
                try
                {
                    var number = Convert.ToInt32(input);
                    if (!uniqueNumbers.Contains(number))
                    {
                        uniqueNumbers.Add(number);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("An in valid input was entered.");
                }
            }

            Console.WriteLine("The unique numbers entered were:");
            foreach (var num in uniqueNumbers)
            {
                Console.Write("{0}, ", num);
            }
        }

        public enum Numbers //for telling th user what number to enter
        {
            first = 1,
            second = 2,
            third = 3,
            fourth = 4,
            fifth = 5
        }

        public static void SmallestThree()
        {
            Console.WriteLine("Please enter a list of 5 or more comma seperated numbers.");
            try
            {
                var nums = new List<int>();
                while (true)
                {
                    var input = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Invalid List\nPlease re-try.");
                    }
                    else
                    {
                        foreach (var n in input.Split(','))
                        {
                            int num;
                            if (int.TryParse(n, out num))
                                nums.Add(num);
                        }

                        if (nums.Count < 5)
                        {
                            Console.WriteLine("Invalid List\nPlease re-try.");
                        }
                        else
                        {
                            break;
                        }
                    }

                } //break out of while loop

                //start finding smallest three
                int[] smallestThree = FindSmallestThree(nums);
                Console.WriteLine("The 3 smallest numbers entered were; {0}, {1}, {2}", smallestThree[0], smallestThree[1], smallestThree[2]);
            } //try block
            catch (FormatException)
            {
                Console.WriteLine("Format Exception thrown.");
            }
        }//end of method

        static int[] FindSmallestThree(List<int> input)
        {
            int[] small = new int[3];
            int currentSmall = input[0];
            int i = 0;
            while (true)
            {
                foreach (var n in input)
                {
                    if (currentSmall > n)
                    {
                        currentSmall = n;

                    }
                }
                small[i++] = currentSmall;

                input.Remove(currentSmall);
                currentSmall = input.First();
                if (i == 3)
                    break;
            }

            return small;
        }
    }
}
