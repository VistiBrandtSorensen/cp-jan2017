using System;

namespace mar14
{
    class Program
    {
        static void Main(string[] args)
        {
            // var player = new Player();
            var player1 = new Player();
            var player2 = new Player();

            int boardSize = 9;
            int shipSize = 3;
            int maxCoordinate = boardSize - shipSize + 1;

            bool isFirstPlayer = true;

            for(int i=0; i<2; i++)
            {
                Console.WriteLine("Skal skibet ligge vandret (V) eller lodret (L)?");
                string direction = Console.ReadLine();
                bool isHorizontal = direction.Equals("V", StringComparison.OrdinalIgnoreCase);

                int shipX = GetNumber(1, isHorizontal ? maxCoordinate : boardSize, "Hvor skal skibet ligge (x-koordinat)?") - 1;
                int shipY = GetNumber(1, isHorizontal ? boardSize : maxCoordinate, "Hvor skal skibet ligge (y-koordinat)?") - 1;

                if (isFirstPlayer == true)
                {
                    player1.PlaceShip(isHorizontal, shipX, shipY);
                }
                else
                {
                    player2.PlaceShip(isHorizontal, shipX, shipY);
                }

                isFirstPlayer = false;
            }

            isFirstPlayer = true;

            bool isHit = false;
            bool isSunk = false;
            while(!isSunk)
            {
                Player player;
                if (isFirstPlayer == true)
                {
                    player = player1;
                    isFirstPlayer = false;

                    Console.WriteLine("Spiller 1s tur!");
                }
                else
                {
                    player = player2;
                    isFirstPlayer = true;

                    Console.WriteLine("Spiller 2s tur!");
                }

                int shotX = GetNumber(1, boardSize, "Hvor vil du skyde hen (x-koordinat)?") - 1;
                int shotY = GetNumber(1, boardSize, "Hvor vil du skyde hen (y-koordinat)?") - 1;

                isHit = player.Shoot(shotX, shotY);
                isSunk = player.HasLost();

                Console.Clear();

                string line = "  -";
                string header = "   ";
                for (int z = 0; z < boardSize; z++)
                {
                    line += "----";
                    header += $" {z+1}  ";
                }

                Console.WriteLine(header);
                for (int y = 0; y < boardSize; y++)
                {
                    Console.WriteLine(line);
                    Console.Write(y + 1);
                    for (int x = 0; x < boardSize; x++)
                    {
                        Console.Write(" | ");
                        Console.Write(player.shots[x][y]);
                    }
                    Console.WriteLine(" |");
                }
                Console.WriteLine(line);

                string hitText = isHit
                    ? "Du ramte!!!"
                    : "Du missede!!!";

                Console.WriteLine();
                Console.WriteLine(hitText);
                Console.WriteLine();
            }
        }

        public static int GetNumber(int min, int max, string message)
        {
            Console.WriteLine("{0} ({1}-{2})", message, min, max);
            
            bool isAccepted = false;
            int number = 0;

            while (isAccepted == false)
            {
                string input = Console.ReadLine();
                
                isAccepted =
                    int.TryParse(input, out number) &&
                    number >= min &&
                    number <= max; 

                if (isAccepted == false)
                {
                    Console.WriteLine("Ugyldigt tal - prøv igen");
                }
            }

            return number;
        }

        public static bool GetIsHorizontal()
        {
            Console.WriteLine("Vandret eller lodret?");
            while(true)
            {
                string input = Console.ReadLine();
                if (input.StartsWith("V", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                else if (input.StartsWith("H", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                Console.WriteLine("Ugyldigt input");
            }
        }
    }
}
