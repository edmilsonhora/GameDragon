using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class Boar : EntityBase
    {
        Rectangle rect;
        int i, velocity;
        byte[][] javs = { Media.Jav_0, Media.Jav_1, Media.Jav_2, Media.Jav_3};
        public Boar(Canvas canvas, Random random) : base(canvas)
        {
            velocity = 17;
            X = (int)Canvas.Width - 100;
            Y = (int)Canvas.Height - 230;
            Height = 67;
            Width = 99;
            rect = Rect;
            rect.Fill = Helper.GetImage(javs[i]);
            rect.Margin = GetPosition();            
        }

        public override void Draw()
        {
            if (!Canvas.Children.Contains(rect))
                Canvas.Children.Add(rect);
        }

        public void Move(List<Flame> flames, List<Fire> fires)
        {
            foreach (var flame in flames)
            {
                if (flame.Area.IntersectsWith(this.Area))
                {
                    IsAlive = false;
                    fires.Add(new Fire(Canvas, X, Y));
                    Canvas.Children.Remove(rect);
                    flame.Hide();
                    flame.IsAlive = false;
                }
            }

            X -= velocity;
            rect.Fill = Helper.GetImage(javs[i]);
            rect.Margin = GetPosition();
            i++;
            if (i > 3)
                i = 0;

        }
    }
}
