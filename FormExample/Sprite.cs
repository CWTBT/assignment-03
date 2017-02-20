using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
namespace FormExample
{
    public class Sprite
    {
        private Sprite parent = null;

        //instance variable
        private float x = 0;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        private float y = 0;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        private float scale = 1;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private float rotation = 0;

        /// <summary>
        /// The rotation in degrees.
        /// </summary>
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }


        public List<Sprite> children = new List<Sprite>();


        public void Kill()
        {
            parent.children.Remove(this);
        }

        //methods
        public void render(Graphics g)
        {
            Matrix original = g.Transform.Clone();
            g.TranslateTransform(x, y);
            g.ScaleTransform(scale, scale);
            g.RotateTransform(rotation);
            paint(g);
            foreach (Sprite s in children)
            {
                s.render(g);
            }
            g.Transform = original;
        }

        public virtual void paint(Graphics g)
        {

        }

        public virtual void act()
        {
           
        }

        public void add(Sprite s)
        {
            s.parent = this;
            children.Add(s);
        }



    }

    public class Box : Sprite
    {
        public int x;
        public int y;
        public int wcenter;
        public int hcenter;

        public override void act()
        {
            Random rand = new Random();
            x = rand.Next(wcenter-5, wcenter+5);
            y = rand.Next(hcenter-5, wcenter+5);
            base.act();
        }

        public override void paint(Graphics g)
        {
            Rectangle rect = new Rectangle(x, y, 100, 100);
            g.DrawRectangle(Pens.Black, rect);
            base.paint(g);
        }

        public Box()
        {
            x = 142;
            y = 131;
            wcenter = 142;
            hcenter = 131;
        }




    }
}
