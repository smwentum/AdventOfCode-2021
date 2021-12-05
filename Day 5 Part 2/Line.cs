using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5_part_2
{
    internal class Line
    {
        public int x1 { get; set; }

        public int y1 { get; set; }

        public int x2 { get; set; }

        public int y2 { get; set; }

        public int isHorrizontal { get; set; }

        public Line(string LineInformation)
        {
            string LineInformationPt2 = LineInformation.Split('-')[0].Trim();
            x1 = int.Parse(LineInformationPt2.Split(',')[0]);
            y1 = int.Parse(LineInformationPt2.Split(',')[1]);
            LineInformationPt2 = LineInformation.Split('>')[1].TrimStart();
            x2 = int.Parse(LineInformationPt2.Split(',')[0]);
            y2 = int.Parse(LineInformationPt2.Split(',')[1]);


            if (x1 == x2)
            {
                isHorrizontal = 1;
                if (y1 > y2)
                {
                    swapPoints();
                }
            }
            else if (y1 == y2)
            {
                isHorrizontal = 0;
                if (x1 > x2)
                {
                    swapPoints();
                }
            }
            else if (Math.Abs(x1 - x2) == Math.Abs(y1 - y2))
            {
                //this is a diagonal line i think? 
                isHorrizontal = 2;
            }
            else
            {
                isHorrizontal = 3;
            }
        }

        private void swapPoints()
        {
            int x3, y3;
            x3 = x1;
            x1 = x2;
            x2 = x3;
            y3 = y1;
            y1 = y2;
            y2 = y3;
            
        }
    }
}
