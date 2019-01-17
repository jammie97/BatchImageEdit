using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BatchImageEdit
{

    public class ImageEdit
    {
        public string[] m_PECSFronts;
        public string[] m_PECSBacks;
        public bool m_Use0102Extension;

        public ImageEdit()
        {

        }

        private static string[] GetFileNames(string path, string filter)
        {
            string[] files = Directory.GetFiles(path, filter);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);
            return files;
        }

        public void EditFrontImages(string _inputPath, string _outputPath)
        {
            try
            {
                Console.WriteLine("Reading Front Images...");
                //m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                //    SearchOption.AllDirectories).Select(Image.FromFile).ToList();
                //m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                //    SearchOption.AllDirectories);

                // Uncomment when the already processed forms are reprocessed and recompile.
                //m_PECSFronts = GetFileNames(_inputPath, "*.0_1");
                if (m_Use0102Extension)
                {
                    m_PECSFronts = GetFileNames(_inputPath, "*.0_1");
                }
                else
                {
                    m_PECSFronts = GetFileNames(_inputPath, "*F.jpg");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading front images!");
            }

            //Rectangle 
            Rectangle Address = new Rectangle(242, 30, 638, 270);

            // Edit fronts
            for (int i = 0; i < m_PECSFronts.Length; i++)
            {


                Image temp = Image.FromFile(_inputPath + "\\" + m_PECSFronts[i]);

                using (var graphics = Graphics.FromImage(temp))
                {
                    graphics.FillRectangle(Brushes.DarkGreen, Address);
                }

                //string FileName = m_PECSFronts[i].Split()

                temp.Save(_outputPath + String.Format("\\{0}_F.jpg", m_PECSFronts[i].Split(new char[] { '.'})[0], ImageFormat.Jpeg));

                temp.Dispose();

                Console.Clear();
                Console.WriteLine("#1 - Editing Front PECs: {0}/ {1}", i, m_PECSFronts.Length);
            }
        }

        public void EditBackImages(string _inputPath, string _outputPath)
        {
            try
            {
                Console.WriteLine("Reading Back Images...");
                // Uncomment and recompile as release once all processed batches are reprocessed.

                //m_PECSBacks = GetFileNames(_inputPath, "*.0_2");
                if (m_Use0102Extension)
                {
                    m_PECSBacks = GetFileNames(_inputPath, "*.0_2");
                }
                else
                {
                    m_PECSBacks = GetFileNames(_inputPath, "*B.jpg");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading front images!");
            }

            //Rectangle 
            Rectangle Address = new Rectangle(68, 828, 810, 540);
            Rectangle Controlled = new Rectangle(484, 244, 480, 250);

            // Edit backs
            for (int i = 0; i < m_PECSBacks.Length; i++)
            {

                Image temp = Image.FromFile(_inputPath + "\\" + m_PECSBacks[i]);

                using (var graphics = Graphics.FromImage(temp))
                {
                    graphics.FillRectangle(Brushes.DarkGreen, Address);
                    graphics.FillRectangle(Brushes.DarkGreen, Controlled);
                }

                //string FileName = m_PECSFronts[i].Split()

                temp.Save(_outputPath + String.Format("\\{0}_B.jpg", m_PECSBacks[i].Split(new char[] { '.' })[0], ImageFormat.Jpeg));

                temp.Dispose();

                Console.Clear();
                Console.WriteLine("#2 - Finished Back PECs: {0}/ {1}", i, m_PECSBacks.Length);
            }
        }


    }
}
