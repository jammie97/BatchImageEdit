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
        public List<Image> m_PECSFronts;
        public List<Image> m_PECSBacks;
        public ImageEdit()
        {
            m_PECSFronts = new List<Image>();
            m_PECSBacks = new List<Image>();

            //if (!multi)
            //{
            //    try
            //    {
                    
            //        m_PECSBacks.Add(Image.FromFile("Images/Prescription.front"));
            //        //m_PECSBacks.Add(Image.FromFile("Images/"))
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Failed to load image!");
            //    }
            //}
            //else
            //{
            //    try
            //    {
            //        Console.WriteLine("Reading Front Images...");
            //        m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
            //            SearchOption.AllDirectories).Select(Image.FromFile).ToList();

            //        Console.WriteLine("Reading Back Images...");
            //        m_PECSBacks = Directory.GetFiles("Images", "*.0_2",
            //            SearchOption.AllDirectories).Select(Image.FromFile).ToList();
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Failed to grab multiple images!");
            //    }
            //}

        }

        public void EditFrontImages()
        {
            try
            {
                Console.WriteLine("Reading Front Images...");
                m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                    SearchOption.AllDirectories).Select(Image.FromFile).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading front images!");
            }


            // Edit fronts
            for (int i = 0; i < m_PECSFronts.Count; i++)
            {
                Console.Clear();
                Console.WriteLine("#1 - Editing Front PECs: {0}/ {1}", i, m_PECSFronts.Count);

                //Rectangle 
                Rectangle Address = new Rectangle(242, 30, 638, 270);

                using (var graphics = Graphics.FromImage(m_PECSFronts[i]))
                {
                    graphics.FillRectangle(Brushes.Purple, Address);
                }

                m_PECSFronts[i].Save(String.Format("Output/E{0}NE05_F.jpg", (i + 1).ToString().PadLeft(6, '0')), ImageFormat.Jpeg);
                m_PECSFronts[i] = null;
            }
        }

        public void EditBackImages()
        {
            try
            {
                Console.WriteLine("Reading Back Images...");
                m_PECSBacks = Directory.GetFiles("Images", "*.0_2",
                    SearchOption.AllDirectories).Select(Image.FromFile).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Error loading back images!");
            }


            // Edit backs
            for (int i = 0; i < m_PECSBacks.Count; i++)
            {
                Console.Clear();
                Console.WriteLine("#2 - Editing Back PECs: {0}/ {1}", i, m_PECSBacks.Count);

                Rectangle Address = new Rectangle(68, 820, 810, 540);

                //Rectangle 


                using (var graphics = Graphics.FromImage(m_PECSBacks[i]))
                {
                    graphics.FillRectangle(Brushes.Purple, Address);
                }

                m_PECSBacks[i].Save(String.Format("Output/E{0}NE05_B.jpg", (i + 1).ToString().PadLeft(6, '0')), ImageFormat.Jpeg);
                m_PECSBacks[i] = null;
            }
        }


    }
}
