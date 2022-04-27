using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class Dragon : EntityBase
    {
        Rectangle rect;
        byte[][] walks = { Media.Drag_0, Media.Drag_1, Media.Drag_2, Media.Drag_3 };
        int i = 0;
        public Dragon(Canvas canvas) : base(canvas)
        {
            X = 50;
            Y = (int)canvas.Height - 290;
            Height = 85;
            Width = 120;
            rect = Rect;
            rect.Width = Width;
            rect.Height = Height;
            rect.Fill = Helper.GetImage(walks[i]);
            rect.Margin = GetPosition();
        }

        public override void Draw()
        {
            Canvas.Children.Add(rect);
        }

        public void Mover()
        {
            rect.Fill = Helper.GetImage(walks[i]);
            i++;
            if (i > 3)
                i = 0;
        }

        public override void Gravity()
        {
            base.Gravity();
            if (Y >= (int)Canvas.Height - 290)
            {
                Y = (int)Canvas.Height - 290;
            }

            rect.Margin = GetPosition();
        }

        public void Jump()
        {
            rect.Margin = GetPosition();
            FallVelocity = JUMPFORCE;

        }
    }
}
