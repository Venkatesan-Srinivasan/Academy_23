namespace P01._2;

class Program {
   static void Main () {
      Circle1 c1 = new ();
      c1.Draws (6, new Point { X = 9, Y = 4 });
      c1.Draws (new Point { X = 7, Y = 6 }, new Point { X = 4, Y = 2 });
      Line l = new ();
      l.Draw ();
      Line1 l1 = new ();
      l1.GetInfo1 ();
   }
}
class Shape {
   public void Draw () {
      Console.WriteLine ("shape is drawing");
   }
}
class Circle : Shape {

}
class Line : Shape {

}
class shapeCircle : Circle { }

