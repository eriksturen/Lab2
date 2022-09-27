﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Menu
    {
        public int SelectedIndex { get; set; }
        public List<Product> Options { get; set; }
        public string Prompt { get; set; }


        // at this point I should probably create an override
        // that can create menus with other options than products
        // it gets a bit convoluted storing "back" options and so on in the product data file... 
        public Menu(string prompt, List<Product> options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        // function to display whatever options is current 
        // later going to be product list and settings and customer cart and so on

        // could change all of this so that it shows a Product instead of string for CurrentOption
        // also so that it takes a list of Products 
        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Count; i++)
            {
                string CurrentOption = Options[i].Name;
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
                        SelectedIndex = Options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Count)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);


            return SelectedIndex;
        }


    }
}
