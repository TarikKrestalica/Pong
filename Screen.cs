using System;
namespace Pong
{
    public class Screen
    {
        // Attributes: Its own title, its own position and its own display structure
        public string title;
        public int rows, columns;
        public char[,] display;

        // Constructor
        public Screen(string aTitle, int aRows, int aColumns)
        {
            title = aTitle;
            rows = aRows;
            columns = aColumns;
            // Use the screen position to create the display
            display = CreateScreen();   

        }

        // Initialize test screen
        public char[,] CreateScreen()
        {
            char[,] screen = new char[rows, columns];
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < columns; c++)
                    screen[r, c] = ' ';

            return screen;
        }

        // Display and Update screen
        public void DisplayScreen()
        {
            Console.WriteLine(title);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                    Console.Write(display[r, c]);

                Console.WriteLine();
            }
        }
        
    }
}
