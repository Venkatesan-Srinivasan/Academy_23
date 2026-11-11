using System.ComponentModel.DataAnnotations;
using System.IO.MemoryMappedFiles;

namespace L12;

class Program {
   static void Main () {
      Drawing d1 = new ("Drawing1");
      d1.Name = "Another Drawing of 1";
      d1.Shapes.Add (new Circle (new Point (1, 2), 3));
      d1.Shapes.Add (new Rectangle (new Point (4, 5), 6, 7));
      d1.Shapes.Add (new Circle (new Point (12, 14), 3.5));

      var sw = new SWriter ("C:\\Users\\srinivasanve\\source\\repos\\Academy_23\\L12\\test.dg");
      d1.Save (sw);
      sw.Close ();
      var sr = new SReader ("C:\\Users\\srinivasanve\\source\\repos\\Academy_23\\L12\\test.dg");
      var d2 = new Drawing ();
      d2.Load (sr);
      sr.Close ();

      Display d = new Display ();
      d1.Draw (d);
      Console.WriteLine ();
      d2.Draw (d);

      /*
       *
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
      }*/

   }
}
