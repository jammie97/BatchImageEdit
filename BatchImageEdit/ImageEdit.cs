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

        public void EditFrontImages()
        {
            try
            {
                Console.WriteLine("Reading Front Images...");
                //m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                //    SearchOption.AllDirectories).Select(Image.FromFile).ToList();
                //m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                //    SearchOption.AllDirectories);

                m_PECSFronts = GetFileNames("Images", "*.0_1");
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading front images!");
            }


            // Edit fronts
            for (int i = 0; i < m_PECSFronts.Length; i++)
            {

                //Rectangle 
                Rectangle Address = new Rectangle(242, 30, 638, 270);
                
                Image temp = Image.FromFile("Images\\" + m_PECSFronts[i]);

                using (var graphics = Graphics.FromImage(temp))
                {
                    graphics.FillRectangle(Brushes.Purple, Address);
                }

                //string FileName = m_PECSFronts[i].Split()

                temp.Save(String.Format("Output/{0}_F.jpg", m_PECSFronts[i].Split(new char[] { '.'})[0], ImageFormat.Jpeg));

                Console.Clear();
                Console.WriteLine("#1 - Editing Front PECs: {0}/ {1}", i, m_PECSFronts.Length);
            }
        }

        public void EditBackImages()
        {
            try
            {
                Console.WriteLine("Reading Back Images...");
                //m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                //    SearchOption.AllDirectories).Select(Image.FromFile).ToList();
                //m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                //    SearchOption.AllDirectories);

                m_PECSBacks = GetFileNames("Images", "*.0_2");
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading front images!");
            }


            // Edit fronts
            for (int i = 0; i < m_PECSFronts.Length; i++)
            {

                //Rectangle 
                Rectangle Address = new Rectangle(242, 30, 638, 270);

                Image temp = Image.FromFile("Images\\" + m_PECSBacks[i]);

                using (var graphics = Graphics.FromImage(temp))
                {
                    graphics.FillRectangle(Brushes.Purple, Address);
                }

                //string FileName = m_PECSFronts[i].Split()

                temp.Save(String.Format("Output/{0}_B.jpg", m_PECSBacks[i].Split(new char[] { '.' })[0], ImageFormat.Jpeg));

                Console.Clear();
                Console.WriteLine("#2 - Finished Back PECs: {0}/ {1}", i, m_PECSBacks.Length);
            }
        }


    }
}
