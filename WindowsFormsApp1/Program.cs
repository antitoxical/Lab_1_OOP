using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicShapes
{
    
    public abstract class MyShape
    {
        public abstract void Draw(Graphics g);
    }

   
    public class Line : MyShape
    {
        public Point Start;
        public Point End;

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

  
    public class Rectangle : MyShape
    {
        public Point Location;
        public Size Size;

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

 
    public class Circle : MyShape
    {
        public Point Location;
        public Size Size;   

        public Circle(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(Pens.Black, new System.Drawing.Rectangle(Location, Size));
        }
    }


    public class Triangle : MyShape
    {
        public Point Point1;
        public Point Point2;
        public Point Point3;

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



  
    public class Square : MyShape
    {
        public Point Location;
        public int Size;

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


    public class Trapezoid : MyShape
    {
        public Point Location;
        public int Base1;
        public int Base2;
        public int Height;

        public Trapezoid(Point location, int base1, int base2, int height)
        {
            Location = location;
            Base1 = base1;
            Base2 = base2;
            Height = height;
        }

        public override void Draw(Graphics g)
        {
            Point[] points = new Point[4];
            points[0] = Location;
            points[1] = new Point(Location.X + Base1, Location.Y);
            points[2] = new Point(Location.X + Base2, Location.Y + Height);
            points[3] = new Point(Location.X, Location.Y + Height);

            g.DrawPolygon(Pens.Black, points);
        }
    }



    public class ListOfShapes
    {
        private List<MyShape> shapes = new List<MyShape>();

        public void AddShape(MyShape shape)
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
            ListOfShapes shapeList = new ListOfShapes();
            shapeList.AddShape(new Line(new Point(20, 20), new Point(100, 20)));
            shapeList.AddShape(new Rectangle(new Point(150, 150), new Size(200, 100)));
            shapeList.AddShape(new Circle(new Point(200, 10), new Size(100, 100)));
            shapeList.AddShape(new Triangle(new Point(150, 100), new Point(180, 100), new Point(150, 10)));
            shapeList.AddShape(new Square(new Point(10, 150), 100));
            shapeList.AddShape(new Trapezoid(new Point(20, 40), 100, 80, 60));


            Form form = new Form();
            form.Width = 380; 
            form.Height = 300;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.Paint += (sender, e) =>
            {
                shapeList.DrawAll(e.Graphics);
            };
            Application.Run(form);
        }
    }
}
