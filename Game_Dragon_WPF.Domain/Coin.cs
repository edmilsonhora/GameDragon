using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class Coin : EntityBase
    {
        Rectangle rect;
        byte[][] coins = { Media.Coin_0, Media.Coin_1, Media.Coin_2, Media.Coin_3, Media.Coin_4, Media.Coin_5, Media.Coin_6 };
        int i;
        public Coin(Canvas canvas, int espaco) : base(canvas)
        {
            X = (int)canvas.Width + 70 + espaco;
            Y = (int)canvas.Height - 270;
            Height = 40;
            Width = 30;
            rect = Rect;
            rect.Fill = Helper.GetImage(coins[i]);            
        }

        public override void Draw()
        {
            Canvas.Children.Add(rect);
        }

        public void Move(Dragon dragon)
        {

            if (this.Area.IntersectsWith(dragon.Area))
            {
                IsAlive = false;
                Canvas.Children.Remove(rect);
                dragon.Cash += 10;
            }
            else
            {
                X -= 4;
                rect.Fill = Helper.GetImage(coins[i]);
                rect.Margin = GetPosition();
                i++;
                if (i > 6)
                    i = 0;
            }
        }
    }
}
