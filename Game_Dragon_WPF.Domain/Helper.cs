using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game_Dragon_WPF.Domain
{
   public static class Helper
    {
        public static ImageBrush GetImage(byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(bytes);
            image.EndInit();
            return new ImageBrush(image);
        }

        public static ImageBrush GetImageReverse(byte[] bytes)
        {
            throw new NotImplementedException();
            //MemoryStream ms = new MemoryStream();
            //Bitmap bm = new Bitmap(new MemoryStream(bytes));
            //bm.RotateFlip(RotateFlipType.Rotate180FlipY);
            //bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.StreamSource = ms;

            //image.EndInit();

            //return new ImageBrush(image);
        }
    }
}
