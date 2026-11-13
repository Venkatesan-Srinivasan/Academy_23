using System.Text;

namespace L12._1;

class Program {

   static void Main (string[] args) {
      Console.OutputEncoding = Encoding.UTF8;
      DisplayBoard ();
      while (Console.ReadKey (true).Key != ConsoleKey.Escape) {
         Console.Clear ();
         DisplayBoard ();
      }

      //   int origWidth, width;
      //   int origHeight, height;
      //   string m1 = "The current window width is {0}, and the " +
      //               "current window height is {1}.";
      //   string m2 = "The new window width is {0}, and the new " +
      //               "window height is {1}.";
      //   string m4 = "  (Press any key to continue...)";

      //   // Step 1: Get the current window dimensions.
      //   //
      //   origWidth = Console.WindowWidth;
      //   origHeight = Console.WindowHeight;
      //   Console.WriteLine (m1, Console.WindowWidth,
      //                         Console.WindowHeight);
      //   Console.WriteLine (m4);
      //   Console.ReadKey (true);
      //   //
      //   // Step 2: Cut the window to 1/4 its original size.
      //   //
      //   width = origWidth / 2;
      //   height = origHeight / 2;
      //   Console.SetWindowSize (width, height);
      //   Console.WriteLine (m2, Console.WindowWidth,
      //                         Console.WindowHeight);
      //   Console.WriteLine (m4);
      //   Console.ReadKey (true);
      //   //
      //   // Step 3: Restore the window to its original size.
      //   //
      //   Console.SetWindowSize (origWidth, origHeight);
      //   Console.WriteLine (m1, Console.WindowWidth,
      //                         Console.WindowHeight);

   }
   public string GetSecretWord () {
      return "SecretWord";
   }
   void PrintGrayCode () => Console.ForegroundColor = ConsoleColor.Gray;

   void PrintGreenCode () => Console.ForegroundColor = ConsoleColor.Green;

   void PrintBlueCode () => Console.ForegroundColor = ConsoleColor.Blue;
   void Tries () {
      for (int i = 0; i < 6; i++) {
      }
   }

   static void DisplayBoard () {
      for (int i = 0; i < 6; i++) {
         if (i == 0) PrintCentered ($"{"◌  ·  ·  ·  ·"}\n");
         else PrintCentered ($"{"·  ·  ·  ·  ·"}\n");
      }
      PrintCentered ($"{"───────────────────────────────"}\n");
      PrintCentered ($"{"A    B    C    D    E    F    G"}");
      PrintCentered ($"{"H    I    J    K    L    M    N"}");
      PrintCentered ($"{"O    P    Q    R    S    T    U"}");
      PrintCentered ($"{"     V    W    X    Y    Z     "}");
      //Console.WriteLine ("Hello, World!");
   }

   static void PrintCentered (string text) {
      int width = Console.WindowWidth;
      int left = (width - text.Length) / 2;
      Console.SetCursorPosition (left, Console.CursorTop);
      Console.WriteLine (text);
   }
}
