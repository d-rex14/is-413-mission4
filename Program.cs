using System;

// ============================================================================
// GROUP 1 CODE - DRIVER CLASS (Blane Santilli, Graham Fawson)
// ============================================================================

class Program
{
    static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Console.WriteLine("Player 1 is X, Player 2 is O");
        Console.WriteLine();

        // Create the game board array (9 positions)
        string[] gameBoard = new string[9];
        
        // Initialize the board with numbers 1-9
        for (int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i] = (i + 1).ToString();
        }

        // Game variables
        int currentPlayer = 1;
        bool gameWon = false;
        int turnCount = 0;

        // Create instance of supporting class
        GameHelper helper = new GameHelper();

        // Main game loop
        while (!gameWon && turnCount < 9)
        {
            // Print the current board
            helper.PrintBoard(gameBoard);
            
            // Get current player's symbol
            string playerSymbol = (currentPlayer == 1) ? "X" : "O";
            
            // Ask for player's choice
            Console.Write("Player " + currentPlayer + " (" + playerSymbol + "), enter your move (1-9): ");
            int choice;
            
            // Validate input is a number between 1-9
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9)
            {
                Console.Write("Invalid input! Please enter a number between 1-9: ");
            }
            
            // Validate the space is not already taken
            if (gameBoard[choice - 1] != "X" && gameBoard[choice - 1] != "O")
            {
                gameBoard[choice - 1] = playerSymbol;
                turnCount++;
                
                // Check for a winner
                string winner = helper.CheckWinner(gameBoard);
                
                if (winner != "")
                {
                    gameWon = true;
                    helper.PrintBoard(gameBoard);
                    Console.WriteLine();
                    Console.WriteLine("Congratulations! Player " + currentPlayer + " (" + winner + ") wins!");
                }
                else
                {
                    // Switch players
                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                }
            }
            else
            {
                Console.WriteLine("That space is already taken! Try again.");
            }
        }

        // Check for tie game
        if (!gameWon)
        {
            helper.PrintBoard(gameBoard);
            Console.WriteLine();
            Console.WriteLine("It's a tie! No one wins.");
        }

        Console.WriteLine();
        Console.WriteLine("Thanks for playing!");
    }
}


// ============================================================================
// GROUP 2 CODE - SUPPORTING CLASS (Devin Holderness, Joshua Schmitt)
// ============================================================================

class GameHelper
{
    // method to print the game board
    public void PrintBoard(string[] board)
    {
        Console.WriteLine();
        Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
        Console.WriteLine("-----------");
        Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
        Console.WriteLine("-----------");
        Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);
        Console.WriteLine();
    }

    // method to check if there is a winner
    public string CheckWinner(string[] board)
    {
        // check all rows
        for (int i = 0; i < 9; i += 3)
        {
            if (board[i] == board[i + 1] && board[i + 1] == board[i + 2])
            {
                return board[i];
            }
        }

        // check all columns
        for (int i = 0; i < 3; i++)
        {
            if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
            {
                return board[i];
            }
        }

        // check diagonal top-left to bottom-right
        if (board[0] == board[4] && board[4] == board[8])
        {
            return board[0];
        }

        // check diagonal top-right to bottom-left
        if (board[2] == board[4] && board[4] == board[6])
        {
            return board[2];
        }

        // no winner found
        return "";
    }
}