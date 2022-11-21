using System;
using System.Threading;

namespace Pong
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Setup the Game Screen, Paddles, Ball
            Screen screen = new Screen("Pong by Tarik", 30, 80);
            Paddle player1 = new Paddle('#', 15, 77, 7);
            Paddle player2 = new Paddle('#', 15, 3, 7);
            Ball ball = new Ball('O', screen.rows / 2, screen.columns / 2, 1, 1);

            // Create my animation speed
            Random rnd = new Random();

            // Play the Game
            while (player1.score < 5 && player2.score < 5)
            {
                // Display score, create our keyboard input
                Console.WriteLine($"Player 1: {player1.score}  Player 2: {player2.score}");
                ConsoleKeyInfo input;
                do
                {
                    // Primary running loop throughout
                    while (Console.KeyAvailable == false)
                    { 
                        // Display the Setup 
                        player1.DisplayPaddle(screen.display);
                        player2.DisplayPaddle(screen.display);
                        ball.DisplayBall(screen.display);
                        screen.DisplayScreen();
                        

                        // Move Ball
                        ball.MoveBall(screen.display);

                        // Top border constraint: Top row, move down the rows
                        if (ball.rowPosition == 0)
                            ball.BounceDown();
                        // Bottom border constraint: Bottom row, move up the rows
                        else if (ball.rowPosition == screen.rows - 1)
                            ball.BounceUp();

                        // If the ball surpasses a vertical constraint
                        if (ball.columnPosition == 0 || ball.columnPosition == 79)
                        {
                            // Award the point to the appropriate player
                            if (ball.columnPosition == 0)
                                player1.score++;
                            else if (ball.columnPosition == 79)
                                player2.score++;

                            // Set the ball back to center
                            ball.ResetToCenter(screen.rows / 2, screen.columns / 2);

                            // Give a full paddle
                            player1.RefreshPaddle();
                            player2.RefreshPaddle();

                            // Terminate 
                            break;

                        }

                        // Check for Paddle Collisions
                        if (ball.columnPosition == player1.columnPosition)
                        {
                            if (player1.CollidesWithBall(screen.display, ball))
                                ball.ReverseDirection();
                        }

                        if (ball.columnPosition == player2.columnPosition)
                        {
                            if (player2.CollidesWithBall(screen.display, ball))
                                ball.ReverseDirection();
                        }

                        // Set random speed
                        int animationSpeed = rnd.Next(40, 91);
                        Thread.Sleep(animationSpeed);
                        Console.Clear();

                    }
                    input = Console.ReadKey(true);  // Store the input

                } while (input.Key != ConsoleKey.UpArrow && input.Key != ConsoleKey.DownArrow && input.Key != ConsoleKey.W && input.Key != ConsoleKey.S);

            // Break out the loop to check input

                // Player 1's paddle
                if (input.Key == ConsoleKey.UpArrow)
                {
                    // Has the paddle reached the top of the screen
                    if (player1.rowPosition - player1.centerOfPaddle > 0)
                        player1.MoveUp(screen.display);
                }
                if (input.Key == ConsoleKey.DownArrow)
                {
                    // Has the paddle reached the bottom of the screen
                    if (player1.rowPosition + player1.centerOfPaddle < screen.rows - 1)
                        player1.MoveDown(screen.display);
                }
                // Player 2's paddle
                if (input.Key == ConsoleKey.W)
                {
                    // Has the paddle reached the top of the screen
                    if (player2.rowPosition - player2.centerOfPaddle > 0)
                        player2.MoveUp(screen.display);
                }
                if (input.Key == ConsoleKey.S)
                {
                    // Has the paddle reached the bottom of the screen
                    if (player2.rowPosition + player2.centerOfPaddle < screen.rows - 1)
                        player2.MoveDown(screen.display);
                }

            }

            FindWinner(player1);
        }
        // Check if either player 1 or player 2 won
        public static void FindWinner(Paddle player1)
        {
            if (player1.score == 5)
                Console.WriteLine("Player 1 wins!");
            else
                Console.WriteLine("Player 2 wins!");
        }
    }
}
