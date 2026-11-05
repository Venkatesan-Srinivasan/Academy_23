using System.IO.MemoryMappedFiles;

namespace L12;

class Program {
   static void Main () {
      Drawing d1 = new ("Drawing1");
      d1.Name = "Another Drawing of 1";
      d1.Shapes.Add (new Circle (new Point (1, 2), 3));
      d1.Shapes.Add (new Rectangle (new Point (4, 5), 6, 7));
      d1.Shapes.Add (new Circle (new Point (12, 14), 3.5));

      Circle c = new Circle (new (3, 5), 5); //same type\
      Shape s1 = c;  //circle reference to shape. and s1 to the circle object. upcast
      Point pos = s1.Position; //get position of shape.
                               //      Circle c1=s1; //downcast shape to circle. but this is not safe. if s1 was a rectangle, it would throw an exception.
      Circle c2 = (Circle)s1; //downcast shape reference to circle. s1 is a shape reference to a circle object. c2 is a circle reference to the same circle object.
      Rectangle r2 = (Rectangle)s1; //downcast shape reference to rectangle. s1 is a shape reference to a circle object. r3 is a rectangle reference to the same circle object. invalid cast exception
      //defencive

      if (s1.GetType ().Name == "Rectangle") {
         Rectangle r4 = (Rectangle)s1;
      }
      if (s1 is Rectangle) {
         Rectangle r3 = (Rectangle)s1;
      }//type pattern
      //soft cast
      Rectangle r5 = s1 as Rectangle; //downcast shape reference to rectangle. s1 is a shape reference to a circle object. r3 is a rectangle reference to the same circle object. null if not rectangle

      if (r5 != null) {
         r5.Width = 3;
      }

      if (s1 is Circle { Radius: < 0 } c1) {
         c1.Radius = 0; // if s1 is a circle with radius less than 0, then c1 is a circle reference to the same circle object. otherwise, c1 is null.
      }

   }
}

public readonly struct Point {
   public Point (double x, double y) => (X, Y) = (x, y);
   public override string ToString () => $"({X}, {Y})";
   public readonly double X, Y;
}
class Shape {
   public Shape (Point position) => Position = position;
   public Point Position { get; set; }

}
class Circle : Shape {
   public Circle (Point position, double radius) : base (position) => Radius = radius;
   public double Radius { get; set; }
}

class Rectangle : Shape {
   public Rectangle (Point position, double width, double height) : base (position) => (Width, Height) = (width, height);
   public double Width { get; set; }
   public double Height { get; set; }
}
class RoundRecatngle : Rectangle {
   public RoundRecatngle (Point position, double width, double height) : base (position, width, height) { }
}

class Drawing {
   public Drawing (string name) { Name = name; Shapes = new (); }
   public string Name { get; set; }
   public List<Shape> Shapes { get; }
}


abstract class Storable {
   public abstract void Save (SWriter w);
   public abstract void Load (SReader r);
}

class SWriter {
   public SWriter (string name) {
      if (File.Exists (name))
         File.Delete (name);
      mFile = new StreamWriter (name);
   }
   public SWriter Put (string s) {
      mFile.WriteLine (s);
      return this;
   }
   public SWriter Put (double d) {
      mFile.WriteLine (d);
      return this;
   }
   public SWriter Put (int i) {
      mFile.WriteLine (i);
      return this;
   }

   StreamWriter mFile;
}

class SReader {
   public SReader (string name) {
      mFile = new StreamReader (name);
   }
   public string GetString () => mFile.ReadLine ();
   public double GetDouble () => double.Parse (mFile.ReadLine ());
   public int GetInt () => int.Parse (mFile.ReadLine ());
   StreamReader mFile;
}