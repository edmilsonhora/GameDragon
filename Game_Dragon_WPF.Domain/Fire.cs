using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class Fire : EntityBase
    {
        Rectangle rect;
        byte[][] fires = { Media.Fire_0, Media.Fire_1, Media.Fire_2, Media.Fire_3, Media.Fire_4, Media.Fire_5 };
        int i;
        public Fire(Canvas canvas, int x, int y) : base(canvas)
        {
            X = x;
            Y = y;
            Height = 111;
            Width = 62;
            rect = Rect;            
            rect.Fill = Helper.GetImage(fires[0]);
            rect.Margin = GetPosition();
        }

        public override void Draw()
        {
            if (!Canvas.Children.Contains(rect))
                Canvas.Children.Add(rect);
        }


        public void Hide()
        {
            if (!IsAlive)
                Canvas.Children.Remove(rect);
        }

        public void Move()
        {
            rect.Fill = Helper.GetImage(fires[i]);
            rect.Margin = GetPosition();
            i++;
            if (i > 5)
            {
                i = 0;
                IsAlive = false;
            }


        }
    }
}
