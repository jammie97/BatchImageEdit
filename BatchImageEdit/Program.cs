using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BatchImageEdit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Batch Image Edit");

            ImageEdit editor = new ImageEdit(true);
            Console.WriteLine("Image Editor Constructed");

            Console.WriteLine("Editing and saving image");
            editor.EditAndSaveImages();


            Console.WriteLine("Done! Press any line to continue.");

            Console.ReadKey();
        }
    }
}
