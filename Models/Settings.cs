using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using System.Drawing;

namespace Image_Gallery.Models
{
    public class Settings
    {

        public int Id { set; get; }
        public int WindowColor { set; get; }
        public int SizeFont { set; get; }
        public int SizeIcon { set; get; }
        public int MenuColor { set; get; }


        public MetroColorStyle SelectWindowColor(int n)
        {
            WindowColor = n;
            MetroColorStyle style = MetroColorStyle.Default;
            switch (n)
            {
                case 1:
                    style = MetroColorStyle.Red;
                    break;
                case 2:
                    style = MetroColorStyle.Lime;
                    break;
                case 3:
                    style = MetroColorStyle.Blue;
                    break;
                case 4:
                    style = MetroColorStyle.Silver;
                    break;
                case 5:
                    style = MetroColorStyle.Black;
                    break;
                case 6:
                    style = MetroColorStyle.Green;
                    break;
            }

            return style;
        }
        public Color SelectMenuColor(int n)
        {
            MenuColor = n;
            Color color = Color.Transparent;
            switch (n)
            {
                case 1:
                    color = Color.Red;
                    break;
                case 2:
                    color = Color.Lime;
                    break;
                case 3:
                    color = Color.Blue;
                    break;
                case 4:
                    color = Color.Silver;
                    break;
                case 5:
                    color = Color.Black;
                    break;
                case 6:
                    color = Color.Green;
                    break;
            }
            return color;

        }
        public int SelectSizeFont(int n)
        {
            SizeFont = n;
            int size = 0;
            switch (n)
            {
                case 1:
                    size = 7;
                    break;
                case 2:
                    size = 10;
                    break;
                case 3:
                    size = 13;
                    break;
            }
            return size;
        }
        public int SelectSizeIcon(int n)
        {
            SizeIcon = n;
            int size = 0;
            switch (n)
            {
                case 1:
                    size = 90;
                    break;
                case 2:
                    size = 120;
                    break;
                case 3:
                    size = 150;
                    break;
                case 4:
                    size = 180;
                    break;
            }
            return size;
        }
    }
}

