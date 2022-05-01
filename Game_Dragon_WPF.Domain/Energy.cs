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
    public class Energy : EntityBase
    {
        Rectangle back;
        Rectangle front;
        public Energy(Canvas canvas) : base(canvas)
        {
            X = 20;
            Y = 20;
            Width = 240;
            Height = 30;
            back = Rect;
            front = Rect;
            back.Stroke = Brushes.Purple;
            back.Fill = Brushes.LightPink;
            front.Stroke = Brushes.Purple;
            front.Fill = Brushes.MediumPurple;
            front.Margin = GetPosition();
            back.Margin = GetPosition();
        }

        public override void Draw()
        {
            Canvas.Children.Add(back);
            Canvas.Children.Add(front);
        }

        public void Reduzir()
        {
            if(front.Width > 100)
            front.Width -= 1;
        }
    }
}
