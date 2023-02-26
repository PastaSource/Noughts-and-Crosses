namespace XandO
{
    internal class Program
    {
        // 2D array - game board
        static int[,] matrix =
        {
            {1,2,3},
            {4,5,6},
            {7,8,9}
        };
        static void Main(string[] args)
        {
            // will count up to 9 before terminating
            int choiceCounter = 0;
            // true is player 1, false is player 2
            bool player1Turn = true;
            // tracks whether players choice is allowed
            bool validChoice;
            // tracks whether players input is valid
            bool validInput;
            // true if someone won
            bool victory = false;

            // Generate board
            GenerateBoard();

            while (choiceCounter < 9)
            {
                if (VictoryCheck())
                {
                    victory = true;
                    break;
                }


                // set validChoice to default
                validChoice = false;
                // set validInput to default
                validInput = false;


                //string input = Console.ReadLine();
                string input;
                int choice = 0;

                while (!validInput)
                {
                    if (player1Turn)
                    {
                        Console.WriteLine("Player 1: Choose your field!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2: Choose your field!");
                    }

                    input = Console.ReadLine();

                    if (int.TryParse(input, out choice))
                    {
                        if (choice <= 9 && choice >= 0)
                        {
                            validInput = true;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("invalid choice, input must be between 0-9.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid choice, input must be between 0-9.");
                    }
                }

                // checks player input, if valid choice alters the matrix accordingly and updates
                // the game board. If not it will request the player to re-enter their input
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == choice)
                        {
                            // for Player1 the value in the matrix is set to 0, for player 2 it
                            // is set to -1
                            if (player1Turn)
                            {
                                matrix[i, j] = 0;
                            }
                            else
                            {
                                matrix[i, j] = -1;
                            }
                            choiceCounter++;
                            player1Turn = !player1Turn;
                            validChoice = true;
                            GenerateBoard();
                            break;
                        }
                    }
                }
                if (!validChoice)
                {
                    Console.WriteLine("Option not available, try again.");
                }

            }
            if (victory)
            {
                if (!player1Turn)
                {
                    Console.WriteLine("Gamo complete, Player 1 wins!!!");
                }
                else
                {
                    Console.WriteLine("Gamo complete, Player 2 wins!!!");
                }
            }
            else
            {
                Console.WriteLine("lol no one won");
            }
        }

        static void GenerateBoard()
        {
            Console.Clear();
            int counter = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine("     |     |");
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < 2)
                        if (matrix[i, j] == 0)
                        {
                            Console.Write($"  X  |");
                        }
                        else if (matrix[i, j] == -1)
                        {
                            Console.Write($"  O  |");
                        }
                        else
                        {
                            Console.Write($"  {counter}  |");
                        }
                    else
                        if (matrix[i, j] == 0)
                    {
                        Console.Write($"  X  ");
                    }
                    else if (matrix[i, j] == -1)
                    {
                        Console.Write($"  O  ");
                    }
                    else
                    {
                        Console.Write($"  {counter}  ");
                    }
                    counter++;
                }
                if (i < 2)
                {
                    Console.WriteLine("\n_____|_____|_____");
                }
                else
                {
                    Console.WriteLine("\n     |     |");
                }
            }
        }

        static bool VictoryCheck()
        {
            bool victory = false;

            // column & row checks
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // check player1 row victory
                if (matrix[i, 0] == 0 && matrix[i, 1] == 0 && matrix[i, 2] == 0)
                {
                    victory = true;
                    break;
                }
                // check player2 row victory
                else if (matrix[i, 0] == -1 && matrix[i, 1] == -1 && matrix[i, 2] == -1)
                {
                    victory = true;
                    break;
                }
                // check player 1 column victory
                else if (matrix[0, i] == 0 && matrix[1, i] == 0 && matrix[2, i] == 0)
                {
                    victory = true;
                    break;
                }
                // check player 2 column victory
                else if (matrix[0, i] == -1 && matrix[1, i] == -1 && matrix[2, i] == -1)
                {
                    victory = true;
                    break;
                }
            }

            // diagonal checks
            // top left to bottom right player 1 check
            if (matrix[0, 0] == 0 && matrix[1, 1] == 0 && matrix[2, 2] == 0)
            {
                victory = true;
            }
            // top left to bottom right player 2 check
            else if (matrix[0, 0] == -1 && matrix[1, 1] == -1 && matrix[2, 2] == -1)
            {
                victory = true;
            }
            // top right to bottom left player 1 check
            else if (matrix[0, 2] == 0 && matrix[1, 1] == 0 && matrix[2, 0] == 0)
            {
                victory = true;
            }
            // top right to bottom left player 2 check
            else if (matrix[0, 2] == -1 && matrix[1, 1] == -1 && matrix[2, 0] == -1)
            {
                victory = true;
            }

            return victory;
        }
    }
}
