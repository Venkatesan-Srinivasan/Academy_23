using System;
using System.Collections.Generic;
using System.Text;

namespace L12;

class Display {
   public void Line(Point a, Point b) => Console.WriteLine ($"Line from {a} to {b}");
   public void Arc (Point cen, double radius, double start, double end) => Console.WriteLine ($"Arc {cen} from {start} to {end}");
   public void Text(Point pt, String text) => Console.WriteLine ($"Text {text} at {pt}");
}

interface IDrawable {
   public abstract void Draw (Display d);
}
