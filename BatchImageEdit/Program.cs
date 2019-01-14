using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BatchImageEdit
{
    class Program
    {


        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Batch Image Edit");

            ImageEdit editor = new ImageEdit();
            string InputPath = " ";
            string OutputPath = " ";
            // Choose input path
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select INPUT folder containing the prescriptions you wish to cover up.";
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    InputPath = dlg.SelectedPath;
                }
                else
                {
                    return;
                }
            }
            // Choose output path
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select OUTPUT folder you wish the covered prescriptions to be placed inside.";
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    OutputPath = dlg.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine("INPUT PATH: " + InputPath);
            Console.WriteLine("OUPUT PATH: " + OutputPath);

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
                        editor.EditFrontImages(InputPath, OutputPath);
                        editor.EditBackImages(InputPath, OutputPath);
                        Console.WriteLine("Done front and back images!\n");
                        break;
                    case 2:
                        editor.EditFrontImages(InputPath, OutputPath);
                        Console.WriteLine("Done front images!\n");
                        break;
                    case 3:
                        editor.EditBackImages(InputPath, OutputPath);
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
