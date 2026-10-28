namespace L10;

using static State; //type name

class Program {
   static void Main (string[] args) {
      //lambda expression to test the ParseDouble function
      //var f1=(int a, int b) => a + b;
      //Func<int,int,int> f1=(int a, int b) => a + b;
      //int f2= f1(2,3);                                              //local variables
      var adder = (int a, int b) => a + b;
      int f = adder (10, 20);

      Print (3, 4, adder, "+");
      Print (3, 4, (a, b) => a * b, "*"); //passing parameters and evaluating

      void Print (int a, int b, Func<int, int, int> operation, string opname) =>
         Console.WriteLine ($"{a} {opname} {b} = {operation (a, b)}");

      Action<int> printSquare = (a) => Console.WriteLine (a * a);
      printSquare (5);

      Action printHello = () => Console.WriteLine ("Hello");
      printHello ();

      const double NaN = double.NaN;
      Dictionary<string, double> sTests = new () {
         ["-12"] = -12, ["+12"] = 12, ["12"] = 12, ["-+12"] = NaN, ["*12"] = NaN,
         ["12.3"] = 12.3, ["12.34"] = 12.34, ["12.-3"] = NaN, [".14"] = NaN,
         ["12."] = NaN, ["12~"] = NaN, ["a12"] = NaN, ["12b"] = NaN, ["12..3"] = NaN,
         ["12e3"] = 12000, ["12.3463"] = 12.3463, ["12.34e-2"] = 0.1234, ["12.3e"] = NaN,
         ["12.3e-+"] = NaN, ["12.3e+-3"] = NaN, ["12.34e5.-"] = NaN, [".e3"] = NaN,
         ["e4"] = NaN, ["12e"] = NaN, ["12.34 "] = 12.34, ["0.12"] = 0.12,
         ["12.0"] = 12, ["12.0e0"] = 12, ["0e0"] = 0, ["12.0e0"] = 12, ["+e3"] = NaN,
         ["123.456"] = 123.456, ["-12.35"] = -12.35, ["1e-3"] = 0.001
      };

      foreach (var (s, f1) in sTests) {
         double f2 = Math.Round (ParseDouble (s), 8);

         Console.ForegroundColor = Same (f1, f2)
             ? ConsoleColor.Green
             : ConsoleColor.Red;

         Console.Write ($"{s} => {f2} ");

         Console.ResetColor ();

         bool Same (double a, double b) {
            if (double.IsNaN (a))
               return double.IsNaN (b);
            return Math.Abs (a - b) < 1e-6;
         }
      }
      /*    |------------------------------------------->|
       * state A ------> + / - ------> state B ------> [0-9] ------> state C ------> . ------> state D ------> [0-9] ------> state E ------> e / E ------> state F ------> + / - ------> state G ------> [0-9] ------> state H
       */
      // Parses a double usind a Mealy machine. Returns NaN if the input is not a valid double.
      // See file:///Users/andrew/Downloads/CS-2024/L10/Program.cs for the state machine diagram.
      double ParseDouble (string input) {
         State s = A;
         Action none = () => { }; //Action: do nothing
         Action todo;
         double sign = 1, value = 0, exponent = 0, eSign = 1, fValue = 0.1;
         foreach (var ch in input.Trim () + "~") { // Catch I transition with ~
            int d = ch - '0'; //convert char to int

            (s, todo) = (s, ch) switch {
               (A, '+') => (B, none),
               (A, '-') => (B, () => sign = -1),
               (A or B or C, >= '0' and <= '9') => (C, () => value = value * 10 + d),

               (C, '.') => (D, none),
               (D or E, >= '0' and <= '9') => (E, () => { value = value + fValue * d; fValue /= 10; }),

               (C or E, 'e' or 'E') => (F, none),
               (F, '+') => (G, none),
               (F, '-') => (G, () => eSign = -1),
               (F or G or H, >= '0' and <= '9') => (H, () => exponent = exponent * 10 + d),
               (C or E or H, '~') => (I, none), //Marks: check of capturing the token
               _ => (Z, none),
            };
            todo ();    //each loop, executing the action associated with the transition
         }
         if (s == I) return sign * value * Math.Pow (10, eSign * exponent);
         //if (s == I) return double.Parse (input);
         return double.NaN;
      }
   }

   /*string Classify (int x, int y) {
      return (x, y) switch {
         (0, 0) => "Origin",
         (0, _) => "YAxis",
         (_, 0) => "XAxis",
         ( >= 0, >= 0) => "Q1",
         ( <= 0, >= 9) => "Q2",
         ( > 0, <= 0) => "Q3",
         ( <= 0, <= 0) => "Q4",
         _ => "Unknown",
      };
   }
   */
}
/*
 * States are defined as follows: A --> two digit accepted, B --> one digit not acccepted ,  I --> Terminaton and E
 * ERROR: when i staet A and no entry of next char* Two digit numbers are accepted.
 * The state machine is as follows:
 *                                            |---> (halts) --->state E
 *                                            |
 * PASS: state A -------> [1,..,9] -------> state B --------> [0,..,9] -------> (~) --------> state I
 *          ^                                                             |
 *          |_____________________________________________________________|

 */
enum State { A, B, C, D, E, F, G, H, I, Z }; //default index . A=0, B=1,..,Z=9

