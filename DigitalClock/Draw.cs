using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    internal class Draw
    {
        private static double scale = 2.05;
        private static string delimeter = "XX";
        private static string filling = "x";
        public static List<string> Hands(List<string> lines, int hours)
        {
            if (hours > 12 || hours < 0)
            {
                throw new ArgumentException("invalid time");
            }

            int fullHeight = lines.Count;
            int center = lines.Count / 2;

            // Is the hour hand on the left side of the clock?
            bool leftSide = hours > 6; 

            // Defines which line the starting point is at.
            double angle = (double)hours / 6;
            angle = angle > 1 ? 1-(angle -1): angle; 
            int handSliceIndex = (int)((fullHeight-1) * angle);

            // How far from the center is the starting point?
            int fromCenterY = handSliceIndex > center ? handSliceIndex - center : center - handSliceIndex; 

            // How far in the X axis is the starting point from the center?
            double fromCenterX = Calc.Width((int)(fullHeight/2*scale), fromCenterY); 
            
            // By how many units does the hand have to approach the center each line to reach it with fromCenterY amount of steps?
            int perLineAdvancement = fromCenterY == 0 ? 0 : (int)Math.Ceiling(Math.Ceiling(fromCenterX) / fromCenterY)-1; 

            double advancement = 0;
            int advancementMultiplier = handSliceIndex > center ? -1 : 1;
            for (int i = 0; i <= fromCenterY; i++)
            {
                int sliceIndex = handSliceIndex + i*advancementMultiplier;
                var modSlice = lines[sliceIndex];
                int modFromCenterY = sliceIndex > center ? sliceIndex - center : center - sliceIndex;

                advancement += 1 * perLineAdvancement;

                int padding;
                if (fromCenterX == 0)
                {
                    padding = (int)Calc.Width(fullHeight, modFromCenterY);
                }
                else if (leftSide)
                {
                    padding = (int)Calc.Width(fullHeight, modFromCenterY) - (int)Calc.Width(fullHeight, fromCenterY) ;
                    padding += (int)advancement;
                }
                else
                {
                    padding = (int)Calc.Width(fullHeight, modFromCenterY) + (int)Calc.Width(fullHeight, fromCenterY);
                    padding -= (int)advancement;
                }

                int handWidth = 1;
                if (fromCenterY == 0)
                {
                    handWidth = (int)Calc.Width(fullHeight, 0);
                    padding -= handWidth;
                    if (leftSide)
                    {
                        padding = 0;
                    }
                    
                }

                var beginning = modSlice.Split(delimeter)[0];
                var middlePart = modSlice.Split(delimeter)[1];
                int originalLength = middlePart.Length;
                middlePart = new string(' ', padding) + new string('x', handWidth);
                middlePart += new string(' ', originalLength-middlePart.Length);
                lines[sliceIndex] = beginning + delimeter + middlePart + delimeter;
                lines[sliceIndex] = lines[sliceIndex].TrimEnd();
            }

            return lines;
        }
        public static List<string> Circle(int radius)
        {
            // Good ratio, otherwise the clock will either become too wide or high depending if the console is made bigger or smaller.
            scale = 2.05 + radius / 75;
            var lines = new List<string>();

            int lineWidth = radius * 2 + 10;
            for (int lineCount = 0; lineCount < radius*2+1; lineCount++)
            {
                int fromCenter = lineCount > radius ? lineCount - radius : radius - lineCount;
                double width = Calc.Width(radius*2, fromCenter)+1;
                double paddingOnSides = (lineWidth - width)/2-1;

                var finalLine = constructLine((int)(paddingOnSides*scale), (int)(width*scale));
                if (finalLine.Length > 1)
                {
                    lines.Add(finalLine);
                }
            }
            return lines;
        }
        private static string constructLine(int paddingOnSides, int width)
        {
            var paddingStr = new string(' ', paddingOnSides);
            var paddingStr2 = new string(' ', width);
            var finalLine = paddingStr + delimeter + paddingStr2 + delimeter;
            return finalLine;
        }
    }
}
