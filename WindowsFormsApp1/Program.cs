using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicShapes
{
    
    public abstract class Shape
    {
        public abstract void Draw(Graphics g);
    }

   
    public class Line : Shape
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pens.Black, Start, End);
        }
    }

  
    public class Rectangle : Shape
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        public Rectangle(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(Location, Size));
        }
    }

 
    public class Ellipse : Shape
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        public Ellipse(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, new System.Drawing.Rectangle(Location, Size));
        }
    }


    public class Triangle : Shape
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        public Triangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override void Draw(Graphics g)
        {
            g.DrawPolygon(Pens.Black, new[] { Point1, Point2, Point3 });
        }
    }



  
    public class Square : Shape
    {
        public Point Location { get; set; }
        public int Size { get; set; }

        public Square(Point location, int size)
        {
            Location = location;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new System.Drawing.Rectangle(Location.X, Location.Y, Size, Size));
        }
    }

    
    public class ShapeList
    {
        private List<Shape> shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void DrawAll(Graphics g)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            ShapeList shapeList = new ShapeList();
            shapeList.AddShape(new Line(new Point(0, 0), new Point(100, 100)));
            shapeList.AddShape(new Rectangle(new Point(150, 150), new Size(200, 100)));
            shapeList.AddShape(new Ellipse(new Point(200, 10), new Size(100, 100)));
            shapeList.AddShape(new Triangle(new Point(150, 100), new Point(180, 100), new Point(150, 10)));
            shapeList.AddShape(new Square(new Point(10, 150), 100));

            
            Form form = new Form();
            form.Width = 380; 
            form.Height = 300;
            form.Paint += (sender, e) =>
            {
                shapeList.DrawAll(e.Graphics);
            };
            Application.Run(form);
        }
    }
}
