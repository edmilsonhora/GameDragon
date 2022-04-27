using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class WaspFire : EntityBase
    {
        Rectangle rect;
        byte[][] fires = { Media.VesFire_0, Media.VesFire_1, Media.VesFire_2, Media.VesFire_3 };
        int i;
        public WaspFire(Canvas canvas, Wasp wasp) : base(canvas)
        {
            X = wasp.X;
            Y = wasp.Y;
            Height = 30;
            Width = 30;
            rect = Rect;
            rect.Fill = Helper.GetImage(fires[i]);
            rect.Margin = GetPosition();

        }

        public override void Draw()
        {
            if(!Canvas.Children.Contains(rect))
            Canvas.Children.Add(rect);
        }

        public void Mover()
        {
            X -= 6;
            Y += 6;
            rect.Fill = Helper.GetImage(fires[i]);
            rect.Margin = GetPosition();
            i++;
            if (i > 3)
                i = 0;
        }
    }
}
