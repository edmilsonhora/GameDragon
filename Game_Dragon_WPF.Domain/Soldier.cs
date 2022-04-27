using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    
    public class Soldier : EntityBase
    {
        int timeToJump;
        bool isJumping;
        Random random;
        Rectangle rect;
        byte[][] walks = { Media.Mon_0, Media.Mon_1, Media.Mon_2, Media.Mon_3, Media.Mon_4, Media.Mon_5, Media.Mon_6, Media.Mon_7 };
        int i = 0;
        int velocityWalk;
        public Soldier(Canvas canvas, Random random) : base(canvas)
        {
            this.random = random;
            velocityWalk = random.Next(9, 19);
            timeToJump = random.Next(8, 35);
            X = (int)Canvas.Width - 100;
            Y = (int)Canvas.Height - 270;           
            Height = 116;
            Width = 98;
            rect = Rect;           
            rect.Fill = Helper.GetImage(walks[i]);
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
                if (flame.Area.IntersectsWith(this.Area) && !isJumping)
                {
                    IsAlive = false;
                    fires.Add(new Fire(Canvas, X, Y));
                    Canvas.Children.Remove(rect);
                    flame.Hide();
                    flame.IsAlive = false;
                }
            }
           
            X -= velocityWalk;
            rect.Fill = Helper.GetImage(walks[i]);
            rect.Margin = GetPosition();
            i++;
            if (i > 7)
                i = 0;
        }

        

        public override void Gravity()
        {
            base.Gravity();
            if (Y >= (int)Canvas.Height - 270)
            {
                Y = (int)Canvas.Height - 270;
                isJumping = false;
            }               

            rect.Margin = GetPosition();
        }

        public void Jump()
        {
            if (timeToJump.Equals(0))
            {
                rect.Margin = GetPosition();
                X -= 120;
                FallVelocity = JUMPFORCE; 
                timeToJump = random.Next(35, 85);
                isJumping = true;
            }
            timeToJump--;
        }
    }
}
