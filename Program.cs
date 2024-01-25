using System;

namespace greatAdventure
{
    class versionOne
    {
        //private static int num;

        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            initValues(ref lives, ref magic, ref health, r);
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health, direction);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health, direction);
                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey " + name + "!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before its completion");

        }

        private static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win)
        {
            //throw new NotImplementedException();
            round++;
            Console.WriteLine("Round " + round);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("Magic: " + magic);
            Console.WriteLine("Health: " + health);
            if (round >= 25) win = true;
        }

        private static void actions(int v, ref int lives, ref int magic, ref int health, int direction)
        {
            //this code includes the possible actions for your adventure

            //throw new NotImplementedException();

            switch (v)
            {
                case 0:
                    Console.WriteLine("You met three bears who were not happy that their porridge was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of magic");
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by flying monkeys and had to be rescued by a young girl and a dog");
                    Console.WriteLine("You lost 2 units of health and magic and 1 life");
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You were attacked by a group of cute Persian cats");
                    Console.WriteLine("You lost 1 unit of health");
                    health -= 1;
                    break;
                case 3:
                    Console.WriteLine("You stepped on a landmine");
                    Console.WriteLine("You lost 2 units of health, 3 units of magic and 1 life");
                    health -= 2;
                    magic -= 3;
                    lives -= 1;
                    break;
                case 4:
                    Console.WriteLine("You were caught pirating a Nintendo game");
                    Console.WriteLine("You lost units of 5 magic and 1 life");
                    magic -= 5;
                    lives -= 1;
                    break;
                case 5:
                    Console.WriteLine("You saved a fellow traveler from a headless horseman.");
                    Console.WriteLine("The traveler granted you 2 units of health, magic and lives");
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a woman who lived in a house that resembled a shoe (she had a lot of kids).");
                    Console.WriteLine("You gain 3 units of health and magic");
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("You went in a cave and found a chest with goodies");
                    Console.WriteLine("You gain 3 units of health and magic, along with 3 lives");
                    health += 3;
                    magic += 3;
                    lives += 3;
                    break;
                case 8:
                    Console.WriteLine("You went in a cave and found a chest with goodies");
                    Console.WriteLine("The chest you found was a trapped chest. . . ");
                    Console.WriteLine("You lose 3 units of health");
                    health -= 3;
                    break;
                case 9:
                    Console.WriteLine("You robbed the magic store (and got away with it)");
                    Console.WriteLine("You gained 2 units of health and 5 units of magic");
                    health += 2;
                    magic += 5;
                    break;
                default:
                    Console.WriteLine("You saved a unicorn from a mean wizard.");
                    Console.WriteLine("You gain 2 lives and 2 units of magic");
                    magic += 2;
                    lives += 2;
                    break;
            }
        }

        private static int chooseDirection()
        {
            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and a 2 to travel right\r\n\r\n");
            int direction;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out direction))
                {
                    if (direction == 1 || direction == 2)
                    {
                        break; // Valid input, exit the loop
                    }
                    else
                    {
                        Console.WriteLine("You entered an invalid number, please enter 1 for left or 2 for right");
                    }
                }
                else
                {
                    Console.WriteLine("You entered an invalid input, please enter a valid integer.");
                }
            }
            return direction;
        }

        private static void initValues(ref int lives, ref int magic, ref int health, Random r)
        {
            lives = r.Next(10) + 1;
            magic = r.Next(15) + 5;
            health = r.Next(14) + 5;
        }
    }
}
