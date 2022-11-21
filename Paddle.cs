using System;
namespace Pong
{
    public class Paddle
    {
        // Attributes: Its own individual block(template), its own position, its own length, its own bound, its own score and its own structure
        public char block;
        public int rowPosition, columnPosition;
        public int length, centerOfPaddle; 
        public int score = 0;   
        public char[] paddle;

        // Constructor
        public Paddle(char aBlock, int aRowPos, int aColumnPos, int aLength)
        {
            block = aBlock;
            rowPosition = aRowPos;
            columnPosition = aColumnPos;
            length = aLength;
            // Use the length to initialize my paddle structure
            paddle = CreatePaddle();
            // Use the center as an index to locate the middle of the paddle
            centerOfPaddle = length / 2;
        }

        // Create the paddle structure
        public char[] CreatePaddle()
        {
            // Place the block one by one
            char[] paddle = new char[length];
            for (int i = 0; i < length; i++)
                paddle[i] = block;

            return paddle;
        }
        // Examine my paddle, fill in the empty spaces
        public char[] RefreshPaddle()
        {
            // For each empty spot, refill the spot with the block
            for(int i = 0; i < length; i++)
            {
                if (paddle[i] != block)
                    paddle[i] = block;
            }
            return paddle;
        }
        // Display paddle onto screen 
        public void DisplayPaddle(char[,] screen)
        {
            for (int i = 0; i <= centerOfPaddle; i++)
            {
                switch (i)
                {
                    // First time, place the middle block at the center
                    case 0:
                        screen[rowPosition, columnPosition] = paddle[centerOfPaddle];
                        break;
                    // Otherwise, modify my row position and stretch it by the current factor
                    default:
                        screen[rowPosition + i, columnPosition] = paddle[centerOfPaddle + i];
                        screen[rowPosition - i, columnPosition] = paddle[centerOfPaddle - i];
                        break;
                }
            }
        }

        // Move Upwards
        public void MoveUp(char[,] screen)
        {
            // Find top of paddle
            int topOfPaddle = rowPosition - centerOfPaddle;
            for (int i = 0; i < length; i++)
            {
                // Delete the piece from the original position, move it one row up
                screen[topOfPaddle + i, columnPosition] = ' ';
                screen[(topOfPaddle + i) - 1, columnPosition] = paddle[i];
            }
            rowPosition--;  // Modify the paddle's row position
        }

        // Move Downwards
        public void MoveDown(char[,] screen)
        {
            // Find bottom of paddle
            int bottomOfPaddle = rowPosition + centerOfPaddle;
            for (int i = 0; i < length; i++)
            {
                // Delete the piece from the original position, move it one row up
                screen[bottomOfPaddle - i, columnPosition] = ' ';
                screen[(bottomOfPaddle - i) + 1, columnPosition] = paddle[i];
            }
            rowPosition++;  // Modify the paddle's row position
        }

        public bool CollidesWithBall(char[,] screen, Ball ball)
        {
            // Scan the entire paddle from top to bottom
            int startingPosition = rowPosition - centerOfPaddle;
            for (int i = 0; i < length; i++)
            {
                // Check the screen for the current character, then check for hash
                char currentBlock = screen[startingPosition + i, columnPosition];
                if (currentBlock == block)
                {
                    // If ball and piece meet, delete piece, then return true
                    if (ball.rowPosition == startingPosition + i)
                    {
                        paddle[i] = ' ';
                        return true;
                    }
                        
                }
            }

            return false;
        }
    }
}
