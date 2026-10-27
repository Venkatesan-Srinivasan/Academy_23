namespace L10;

class Program {
   static void Main (string[] args) {
      double NaN = double.NaN;
      Console.WriteLine ("Hello, World!");
      Dictionary<string, double> sTests = new () {
         ["-12"] = -12,
         ["+12"] = 12,
         ["12"] = 12,
         ["-+12"] = NaN,
         ["*12"] = NaN,
         ["12.3"] = 12.3,
         ["12.34"] = 12.34,
         ["12.-3"] = NaN,
         [".14"] = NaN,
         ["12."] = NaN,
         ["-12-"] = NaN,
         ["a12"] = NaN,
         ["12b"] = NaN,
         ["12..3"] = NaN,
         ["12e3"] = 12000,
         ["12.34e3"] = 12340,
         ["12.34E-2"] = 0.1234,
         ["12.3e+"] = NaN,
         ["12.3e-+3"] = NaN,
         ["12.3e+3"] = NaN,
         ["12.34e5."] = NaN,
         [".e3"] = NaN,
         ["e4"] = NaN,
         ["12e"] = NaN,
         [" 12.34 "] = 12.34,
         ["0.12"] = 0.12,
         ["12.0"] = 12,
         ["12e0"] = 12,
         ["0e0"] = 0,
         ["12.0e0"] = 12,
         ["+e3"] = NaN,
         ["123.456"] = 123.456
      };

      foreach (var (s, f1) in sTests) {
         double f2 = Math.Round (ParseDouble (s), 8);
         Console.ForegroundColor = f1 == f2 ? ConsoleColor.Black : ConsoleColor.Red;
         Console.Write ($"{s}=> {f2}     ");
         Console.ResetColor ();
         bool Same(double a, double b) {
            if(double.IsNaN(a)) return double.IsNaN (b);
            return Math.Abs (a - b) < 1e-6;
         }
      }
      double ParseDouble(string input) {
         if(double.TryParse(input,out var d)) return d;
         return double.NaN;
      }
   }
}
