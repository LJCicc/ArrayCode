using System;

namespace sandBox
{
    class Program
    {
        static string[] positions = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        static void Board()
        {
            Console.WriteLine(" ~~~~~~~~~~~~~~~~");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", positions[1], positions[2], positions[3]);
            Console.WriteLine("| --------------- |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", positions[4], positions[5], positions[6]);
            Console.WriteLine("| --------------- |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |", positions[7], positions[8], positions[9]);
            Console.WriteLine(" ~~~~~~~~~~~~~~~~");
        }
        static void Main(string[] args)
        {    
            int choice = 0;
            int turnNumber = 0;
            bool unFinished = true;
            bool win = false;
            bool correctInput = false;
            int test = 0;
            

            while (unFinished == true && test == 0)
            {
                Console.WriteLine("Player 1 is O");
                Console.WriteLine("Player 2 is X");
                Board();
                Console.WriteLine("");

                if(turnNumber == 0) //loops for each turn
                {
                    Console.WriteLine("Player 1's turn");
                }
                else if(turnNumber == 1)
                {
                    Console.WriteLine("Player 2's turn");
                }

                while (correctInput == false)
                {
                    Console.WriteLine("Choose spot");
                    choice = int.Parse(Console.ReadLine());
                    if(choice >= 0)
                    {
                        if(choice < 10)
                        {
                            correctInput = true;
                        }
                    }
                    else
                    {
                        correctInput = false;
                        
                    }
                }
                
                correctInput = false; //to reset

                if (turnNumber == 0)
                {
                    if (positions[choice] == "X" || positions[choice] == "O")
                    {
                        Console.WriteLine("This position is already taken!");
                        continue;
                    }
                    else
                    {
                        positions[choice] = "O";
                    }
                }

                if(turnNumber == 1)
                {

                    if(positions[choice] == "O" || positions[choice] == "X")
                    {
                        Console.WriteLine("This position is already taken by the other player!");
                        continue;
                    }
                    else
                    {
                        positions[choice] = "X";
                    }
                }
                win = checkWin();
                if(win == false)
                {
                    if(turnNumber == 0)
                    {
                        turnNumber = 1;
                    }
                    else if(turnNumber == 1)
                    {
                        turnNumber = 0;
                    }
                    Console.Clear();
                }
                if (win == true)
                {
                    unFinished = false;
                }
            }
            Console.Clear();

            Board();

            for(int i = 0; i < 10; i++)
            {
                positions[i] = i.ToString();
            }
            if(win == true && turnNumber == 0)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine("Player 1 wins.");
            }
            else if(win == true && turnNumber == 1)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine("Player 2 wins.");
            }
            else if (win!=true)
            {
                Console.WriteLine("Draw?");
            }
        }
        static bool checkWin()
        {
            if(positions[1] == "O" && positions[2] == "O" && positions[3] == "O" || positions[1] == "X" && positions[2] == "X" && positions[3] == "X") //top horizontal
            {               
                return true;
            }
            else if(positions[4] == "O" && positions[5] == "O" && positions[6] == "O" || positions[4] == "X" && positions[5] == "X" && positions[6] == "X") //mid horizontal
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else if (positions[7] == "O" && positions[8] == "O" && positions[9] == "O" || positions[7] == "X" && positions[8] == "X" && positions[9] == "X") //bottom horizontal
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else if (positions[1] == "O" && positions[4] == "O" && positions[7] == "O" || positions[1] == "X" && positions[4] == "X" && positions[7] == "X") //first vertical
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else if (positions[2] == "O" && positions[5] == "O" && positions[8] == "O" || positions[2] == "X" && positions[5] == "X" && positions[8] == "X") //mid vertical
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else if (positions[3] == "O" && positions[6] == "O" && positions[9] == "O" || positions[3] == "X" && positions[6] == "X" && positions[9] == "X") //last vertical
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else if(positions[1] == "O" && positions[5] == "O" && positions[9] == "O" || positions[1] == "X" && positions[5] == "X" && positions[9] == "X") //l to r diagonal
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else if(positions[3] == "O" && positions[5] == "O" && positions[7] == "O" || positions[3] == "X" && positions[5] == "X" && positions[9] == "X") //r to l diagonal
            {
                Console.WriteLine("Game over!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
