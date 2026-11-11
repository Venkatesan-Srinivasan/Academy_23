namespace L12;

public readonly struct Point {
   public Point (double x, double y) => (X, Y) = (x, y);
   public override string ToString () => $"({X}, {Y})";
   public readonly double X, Y;
}
abstract class Shape : IStorable , IDrawable {
   public Shape () { }
   public Shape (Point position) => Position = position;
   public Point Position { get; set; }

   public virtual void Draw (Display d) {   }

   public virtual void Load (SReader r)
      => Position = new Point (r.GetD (), r.GetD ());
   public virtual SWriter Save (SWriter w) {
      w.Put (GetType ().Name);      //Simplifies here
      w.Put (Position.X).Put (Position.Y);
      return w;
   }
}

class Circle : Shape {
   public Circle () { }
   public Circle (Point position, double radius) : base (position) => Radius = radius;
   public double Radius { get; set; }
   public override void Load (SReader r) {
      base.Load (r); Radius = r.GetD ();
   }
   public override void Draw (Display d) => d.Arc (Position, Radius,0, 360);
   public  override SWriter Save (SWriter w) => base.Save (w).Put (Radius);
   //public override SWriter Save (SWriter w) {
   //   //w.Put ("Circle");    // Simplified
   //   base.Save (w);
   //   w.Put (Radius);
   //   return w;
   //}
}

class Rectangle : Shape {
   public Rectangle () { }
   public Rectangle (Point position, double width, double height) : base (position) => (Width, Height) = (width, height);
   public double Width { get; set; }
   public double Height { get; set; }
   public override void Load (SReader r) { base.Load (r); Width = r.GetD (); Height = r.GetD (); }
   public override void Draw (Display d) {
      Point br=new Point (Position.X+ Width, Position.Y + Height);
      Point tr = new Point (br.X, br.Y + Height);
      Point tl= new Point (Position.X,tr.Y);
      d.Line (Position, br);
      d.Line (br, tr);
      d.Line (tr, tl);
      d.Line (tl, Position);
   }
   public  override SWriter Save (SWriter w) => base.Save (w).Put (Width).Put (Height); // Chaining
   //w.Put ("Rectangle");    // Simplified

}
//class RoundRecatngle : Rectangle {
//   public RoundRecatngle (Point position, double width, double height) : base (position, width, height) { }
//}

class Drawing : IStorable ,IDrawable {
   public Drawing () { }
   public Drawing (string name) { Name = name; }
   public string Name { get; set; }
   public List<Shape> Shapes { get; } = new ();

   public void Draw (Display d) {
      d.Text (new (0, 0), Name);
      foreach (var s in Shapes)
         s.Draw (d);
   }

   public void Load (SReader r) {
      Name = r.GetS ();
      int count = r.GetN ();
      for (int i = 0; i < count; i++) {
         Shape s = r.GetS () switch {
            "Circle" => new Circle (),
            "Rectangle" => new Rectangle (),
            _ => throw new Exception ("Unknown shape")
         };
         s.Load (r);
         Shapes.Add (s);
      }
      if (r.GetS () != "EOF") throw new Exception ("Read error");
   }
   public SWriter Save (SWriter w) {
      w.Put (Name).Put (Shapes.Count);
      foreach (var s in Shapes)
         s.Save (w);
      return w.Put ("EOF");
   }
}