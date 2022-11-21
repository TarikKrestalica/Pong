using System;
namespace Pong
{
    public class Ball
    {
        // Attributes: Its own character, its own position, and its own speed
        public char ballObject;
        public int rowPosition, columnPosition;
        public int rowSpeed, columnSpeed;

        // Constructor: Create ball, setup the position and the speed
        public Ball(char aBallObject, int aRowPosition, int aColumnPosition, int aRowSpeed, int aColumnSpeed)
        {
            ballObject = aBallObject;
            rowPosition = aRowPosition;
            columnPosition = aColumnPosition;
            rowSpeed = aRowSpeed;
            columnSpeed = aColumnSpeed;
        }

        // Display our ball
        public void DisplayBall(char[,] screen)
        {
            screen[rowPosition, columnPosition] = ballObject;
        }

        // Delete the ball's previous position, then move the ball
        public void MoveBall(char[,] screen)
        {
            screen[rowPosition, columnPosition] = ' ';
            rowPosition += rowSpeed;
            columnPosition += columnSpeed;
        }
        // When it reaches the top border
        public void BounceDown()
        {
            rowSpeed = 1;
        }
        // When it reaches bottom border
        public void BounceUp()
        {
            rowSpeed = -1;
        }

        // Reverse speed for ball
        public void ReverseDirection()
        {
            columnSpeed *= -1;
        }

        // Use the screen attributes to reset after going beyond the vertical constraint
        public void ResetToCenter(int aRowPos, int aColPos)
        {
            rowPosition = aRowPos;
            columnPosition = aColPos;
        }

    }
}
