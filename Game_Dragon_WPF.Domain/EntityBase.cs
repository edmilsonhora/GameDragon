using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Game_Dragon_WPF.Domain
{
    public abstract class EntityBase
    {
        protected const int GRAVITY = 3;
        protected const int JUMPFORCE = -29;
        public EntityBase(Canvas canvas)
        {
            IsAlive = true;
            Canvas = canvas;

        }

        public Canvas Canvas { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsAlive { get; set; }
        public int FallVelocity { get; set; }
        public MediaPlayer SoundPlayer { get; set; }
        public Rect Area { get { return GetArea(); } }
        public Rectangle Rect { get { return GetRetangle(); } }

        public abstract void Draw();
        public Thickness GetPosition()
        {
            return new Thickness(X, Y, X + Width, Y + Height);
        }

        private Rectangle GetRetangle()
        {
            return new Rectangle()
            {
                Height = this.Height,
                Width = this.Width
            };
        }

        public virtual void Gravity()
        {
            FallVelocity += GRAVITY;
            Y += FallVelocity;
            
        }

        public Rect GetArea()
        {
            return new Rect(new Point(X, Y), new Size(Width, Height));
        }
    }

}
