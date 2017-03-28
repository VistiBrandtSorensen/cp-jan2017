using System;

namespace mar14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hvor stor skal spillepladen være (4-9)?");
            int boardSize = int.Parse(Console.ReadLine());
            while (boardSize < 4 || boardSize > 9)
            {
                Console.WriteLine("Ugyldig størrelse, prøv igen:");
                boardSize = int.Parse(Console.ReadLine());
            }

            var board = new bool[boardSize][];
            var shots = new char[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                board[i] = new bool[boardSize];
                shots[i] = new char[boardSize];
                for (int j = 0; j < boardSize; j++)
                {
                    board[i][j] = false;
                    shots[i][j] = ' ';
                }
            }

            int shipSize = 3;
            int maxCoordinate = boardSize - shipSize + 1;

            Console.WriteLine("Skal skibet ligge vandret (V) eller lodret (L)?");
            string direction = Console.ReadLine();
            bool isHorizontal = direction.Equals("V", StringComparison.OrdinalIgnoreCase);

            Console.WriteLine("Hvor skibet ligge (x-koordinat) 1-{0}?", isHorizontal ? maxCoordinate : boardSize);
            int shipX = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Hvor skal skibet ligge (y-koordinat) 1-{0}?", isHorizontal ? boardSize : maxCoordinate);
            int shipY = int.Parse(Console.ReadLine()) - 1;

            for(int i = 0; i < shipSize; i++)
            {
                int x = isHorizontal
                    ? shipX + i
                    : shipX;
                
                int y = isHorizontal
                    ? shipY
                    : shipY + 1;
                
                board[x][y] = true;
            }

            bool isHit = false;
            while(!isHit)
            {
                Console.WriteLine("Hvor vil du skyde hen (x-koordinat)?");
                int shotX = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("Hvor vil du skyde hen (y-koordinat)?");
                int shotY = int.Parse(Console.ReadLine()) - 1;

                isHit = board[shotX][shotY];

                string hitText;
                if (isHit)
                {
                    shots[shotX][shotY] = 'X';
                    hitText = "Du ramte!!!";
                }
                else
                {
                    shots[shotX][shotY] = '*';
                    hitText = "Du missede!!!";
                }

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
                        Console.Write(shots[x][y]);
                    }
                    Console.WriteLine(" |");
                }
                Console.WriteLine(line);

                Console.WriteLine();
                Console.WriteLine(hitText);
                Console.WriteLine();
            }

        }

        // static bool IsShipSunk()
        // {

        // }
    }
}
