using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shape;

namespace ShapeXface
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            Circle circle = new Circle();
            Display(circle);
            Display(rectangle);
            Console.ReadLine();
        }

        static void Display(Shape.Shape shape)
        {
            Console.WriteLine(string.Format("Perimiter: {0}. Area: {1}",
                shape.Perimeter, shape.Area));
        }
    }
}
