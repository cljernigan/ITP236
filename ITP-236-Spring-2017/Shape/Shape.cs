using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public abstract class Shape
    {
        public abstract float Perimeter { get; }
        public abstract float Area { get; }

    }
    public class Rectangle : Shape
    {

        public float Length { get; set; }
        public float Width { get; set; }

        public override float Perimeter
        {
            get { return (Length + Width) * 2; }
        }

        public override float Area
        {
            get { return Length * Width; }

        }

        public Rectangle() : this(1, 1)
        { }

        public Rectangle(float length, float width)
        {
            Length = length;
            Width = width;
        }



    }

    public class Circle : Shape
    {
        public float Radius { get; set; }
        public override float Perimeter
        {
            get { return 2*(float) Math.PI*Radius; }
        }

        public override float Area
        {
            get { return (float) Math.PI*Radius*Radius;}
        }

        public Circle() : this(1)
        {
        }

        public Circle(float radius)
        {
            Radius = radius;
        }
    }


}


