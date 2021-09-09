using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static int randomNumber = 0;

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator!\nYou would like to generate a random activity? true/false: ");
            bool cont = bool.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();

                Console.WriteLine();

                Console.Write("What is your age? ");
                string userAge = Console.ReadLine();

                Console.WriteLine();

                Console.Write("You would like to see the current list of activities? true/false: ");
                bool seeList = bool.Parse(Console.ReadLine());

                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("You would like to add activities before generate one? true/false: ");
                    bool addToList = bool.Parse(Console.ReadLine());
                    Console.WriteLine();

                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();

                        activities.Add(userAddition);

                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.WriteLine("You would like to add more? true/false: ");
                        addToList = bool.Parse(Console.ReadLine());
                    }
                }
            
            
            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();
                
                randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];
                var activity = randomActivity;

                if (int.TryParse(userAge, out int age) && age < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {activity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(activity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Type true if you wish to get a new activity. If you don't want to get a new activity type false.");
                Console.WriteLine();
                cont = bool.Parse(Console.ReadLine());
            }
        }
    }
}
