﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BatchImageEdit
{

    public class ImageEdit
    {
        public List<Image> m_PECSFronts;
        public List<Image> m_PECSBacks;
        public ImageEdit(bool multi)
        {
            m_PECSFronts = new List<Image>();
            m_PECSBacks = new List<Image>();

            if (!multi)
            {
                try
                {
                    
                    m_PECSBacks.Add(Image.FromFile("Images/Prescription.front"));
                    //m_PECSBacks.Add(Image.FromFile("Images/"))
                }
                catch
                {
                    Console.WriteLine("Failed to load image!");
                }
            }
            else
            {
                try
                {
                    m_PECSFronts = Directory.GetFiles("Images", "*.0_1",
                        SearchOption.AllDirectories).Select(Image.FromFile).ToList();
                    m_PECSBacks = Directory.GetFiles("Images", "*.0_2",
                        SearchOption.AllDirectories).Select(Image.FromFile).ToList();
                }
                catch
                {
                    Console.WriteLine("Failed to grab multiple images!");
                }
            }

        }

        public void EditAndSaveImages()
        {
            // Edit fronts
            // Edit fronts
            for (int i = 0; i < m_PECSFronts.Count; i++)
            {
                Pen blackPen = new Pen(Color.Black, 3);

                //Rectangle 
                Rectangle Address = new Rectangle(242, 30, 638, 270);

                using (var graphics = Graphics.FromImage(m_PECSFronts[i]))
                {
                    graphics.FillRectangle(Brushes.Purple, Address);
                }

                m_PECSFronts[i].Save(String.Format("Output/E{0}NE05.jpg", i + 1), ImageFormat.Jpeg);
            }

            // Edit backs
            for (int i = 0; i < m_PECSBacks.Count; i++)
            {
                Pen blackPen = new Pen(Color.Black, 3);
            

                Rectangle Address = new Rectangle(68, 820, 810, 540);

                //Rectangle 
            

                using (var graphics = Graphics.FromImage(m_PECSBacks[i]))
                {
                    graphics.FillRectangle(Brushes.Purple, Address);
                }

                m_PECSBacks[i].Save(String.Format("Output/E{0}NE05.jpg", (i + 1).ToString().PadLeft(6, '0')), ImageFormat.Jpeg);

            }
        }

    }
}