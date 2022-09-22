using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Menu
    {
        public int SelectedIndex { get; set; }
        public string[] Options { get; set; }
        public string Prompt { get; set; }

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        // function to display whatever options is current 
        // later going to be product list and settings and customer cart and so on
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string CurrentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{prefix} << {CurrentOption} >>");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            // function updates everything drawn on screen every time user presses Up/Down
            // functionality is essentially the same as Snake, although maybe more simple really
            // it cycles through the provided array of options ;
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                keyPressed = Console.ReadKey().Key;
                // update SelectedIndex - increased or decreased based on up/down arrow
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    // these two if statements makes sure that the menu cyces back to start/end
                    // instead of going off the screen
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);


            return SelectedIndex;
        }


    }
}
