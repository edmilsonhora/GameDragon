using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public class BackGround : EntityBase
    {
        Rectangle rect;
        int _x;
        public BackGround(Canvas canvas, int x) : base(canvas)
        {
            X = _x = x;
            Y = 0;
            Height = (int)canvas.Height;
            Width = (int)canvas.Width;
            rect = new Rectangle();
            rect.Width = Width;
            rect.Height = Height;
            rect.Fill = Helper.GetImage(Media.Bg);

        }

        public override void Draw()
        {
            Canvas.Children.Add(rect);
        }

        public void Move()
        {
            X -= 4;
            rect.Margin = GetPosition();
            if (X < -1190)
                 X = 1200;

        }
    }
}
