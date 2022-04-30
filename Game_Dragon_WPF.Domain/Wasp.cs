using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class Wasp : EntityBase
    {
        Rectangle rect;
        byte[][] flyes = { Media.Ves_0, Media.Ves_0, Media.Ves_2, Media.Ves_3, Media.Ves_4, Media.Ves_5, Media.Ves_6, Media.Ves_7 };
        int i = 0;
        int flyVelocity;
        public Wasp(Canvas canvas, Random random) : base(canvas)
        {
            flyVelocity = random.Next(10, 18);
            X = (int)Canvas.Width - 100;
            Y = random.Next(70, 360);
            Height = 100;
            Width = 90;
            rect = Rect;
            rect.Fill = Helper.GetImage(flyes[i]);
            rect.Margin = GetPosition();
        }

        public override void Draw()
        {
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

            X -= flyVelocity;
            rect.Fill = Helper.GetImage(flyes[i]);
            rect.Margin = GetPosition();
            i++;
            if (i > 7)
                i = 0;
        }

        public WaspFire Fire()
        {
            var newFire = new WaspFire(Canvas, this);
            newFire.Draw();
            return newFire;
        }
    }
}

