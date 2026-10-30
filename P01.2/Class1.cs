using System;
using System.Collections.Generic;
using System.Text;
namespace P01._2;

internal abstract class Class1 {
   string Name1 { get; set; }
   public Class1 (string name1) {
      Name1 = name1;
   }
   public void GetInfo1 () {
      Console.WriteLine ($"Drawing a {Name1}"); // i can override or left as it
   }
   public abstract void Draw1 ();
}
internal class Line1 : Class1 {
   public Line1 () : base ("Line") { }
   public override void Draw1 () {
      Console.WriteLine ("Drawing a straight line between two points.");
   }

   public new void GetInfo1 () {
      base.GetInfo1 ();
      Console.WriteLine ("Line is Drawing");
   }
}
public class Point {
   public int X { get; init; }
   public int Y { get; init; }
   public override string ToString () => $"({X}, {Y})";
}
internal class Circle1 : Class1 {

   public Circle1 () : base ("Circle") { }
   public void Draws (int radius, Point centerPoint) {
      Console.WriteLine ($"Drawing circle with radius {radius} center {centerPoint}");
   }
   public void Draws (Point point1, Point point2) {
      Console.WriteLine ($"Drawing circle with two points {point1} and {point2}");
   }
   public override void Draw1 () {
      Console.WriteLine ("Drawing a circle with a given radius.");
   }
}



// Demonstration
//class Program {
//   static void Main () {
//      //Shape[] shapes = { new Line (), new Polyline (), new Arc () };
//      //foreach (Shape shape in shapes) {
//      //   shape.GetInfo ();
//      //   shape.Draw ();
//      // Console.WriteLine ();
//      Arc1 a1 = new ();
//      a1.Draw ();
//      a1.GetInfo ();
//      Circle1 c1 = new ();
//      c1.Draw ();
//      c1.GetInfo ();

//      //creating circles
//      Circle1 c2 = new (new Point (2, 3), new Point (2, 3));
//      Circle1 c3 = new (8, new Point (2, 3));
//      c2.Draw ();
//      c2.GetInfo ();
//      c3.Draw ();
//      c3.GetInfo ();
//   }
//}





