using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{

    public class Flame : EntityBase
    {
        Rectangle rect;
       
        byte[][] walks = { Media.Bol_0, Media.Bol_2, Media.Bol_3, Media.Bol_4 };
        int i = 0;

        public Flame(Canvas canvas, int y) : base(canvas)
        {
            X = 140;
            Y = y + 43; //(int)canvas.Height - 247;
            Height = 30;
            Width = 66;

            rect = Rect;          
            rect.Fill = Helper.GetImage(walks[i]);
            rect.Margin = GetPosition();

            SoundPlayer = new MediaPlayer();
            SoundPlayer.Open(new Uri(Directory.GetCurrentDirectory() + "/Resources/Som_Fogo.mp3"));
            SoundPlayer.Play();
        }

        public override void Draw()
        {
            Canvas.Children.Add(rect);
            //Canvas.Children.Add(borda);
        }

        public void Move()
        {
            X += 29;
            rect.Fill = Helper.GetImage(walks[i]);
            rect.Margin = GetPosition();
            i++;
            if (i > 3)
                i = 0;
        }

        public void Hide()
        {
            Canvas.Children.Remove(rect);
        }
    }
}
