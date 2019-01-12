using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BatchImageEdit
{
    class Program
    {


        /// with lists 491 milliseconds!
        static void Main(string[] args)
        {
            Console.WriteLine("Batch Image Edit");

            ImageEdit editor = new ImageEdit();

            int index = 0;
            while(index != -1)
            {
                Console.WriteLine("What would you like to edit:");
                Console.WriteLine("1: Front and Back Images");
                Console.WriteLine("2: Front Images");
                Console.WriteLine("3: Back Images");
                Console.WriteLine("0: Exit");

                string Decision = Console.ReadLine();

                if(!Int32.TryParse(Decision, out index))
                {
                    index = 10;
                }

                switch (index)
                {
                    case 1:
                        editor.EditFrontImages();
                        editor.EditBackImages();
                        Console.WriteLine("Done front and back images!\n");
                        break;
                    case 2:
                        editor.EditFrontImages();
                        Console.WriteLine("Done front images!\n");
                        break;
                    case 3:
                        editor.EditBackImages();
                        Console.WriteLine("Done back images!\n");
                        break;
                    case 0:
                        index = -1;
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }
    }
}
