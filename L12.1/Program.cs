using System.Text;

namespace L12._1;

class Program {

   static void Main (string[] args) {

      var dc = new DisplayConsole ();
      Console.OutputEncoding = Encoding.UTF8;
      dc.DisplayBoard ();
      string keys = "";
      int currentLine = 0;
      for (; ; ) {
         var option = Console.ReadKey (true).Key;
         char key = (char)option;
         if (key >= 'A' && key <= 'Z') {
            keys += key + "  ";
            Console.Clear ();
            dc.UpdateBoard (keys, keys.Length / 3, currentLine);
         }
         if (option == ConsoleKey.Backspace && keys.Length != 0) {
            keys = keys.Remove (keys.Length - 3);
            Console.Clear ();
            dc.UpdateBoard (keys, keys.Length / 3, currentLine);
         }
         if (option == ConsoleKey.Enter && keys.Length == 15) {
            dc.UpdateBoard (keys, keys.Length / 3, currentLine);
            currentLine++;
            keys = "";
            dc.UpdateBoard (keys, keys.Length / 3, currentLine);
         }
      }
   }
   #region TestCode ----------------------------------------------
   /*
   protected static int origRow;
   protected static int origCol;

   protected static void WriteAt (string s, int x, int y) {
      try {
         Console.SetCursorPosition (origCol + x, origRow + y);
         Console.Write (s);
      } catch (ArgumentOutOfRangeException e) {
         Console.Clear ();
         Console.WriteLine (e.Message);
      }
   }

   public static void Main () {
      // Clear the screen, then save the top and left coordinates.
      Console.Clear ();
      origRow = Console.CursorTop;
      origCol = Console.CursorLeft;

      // Draw the left side of a 5x5 rectangle, from top to bottom.
      WriteAt ("+", 0, 0);
      WriteAt ("|", 0, 1);
      WriteAt ("|", 0, 2);
      WriteAt ("|", 0, 3);
      WriteAt ("+", 0, 4);

      // Draw the bottom side, from left to right.
      WriteAt ("-", 1, 4); // shortcut: WriteAt("---", 1, 4)
      WriteAt ("-", 2, 4); // ...
      WriteAt ("-", 3, 4); // ...
      WriteAt ("+", 4, 4);

      // Draw the right side, from bottom to top.
      WriteAt ("|", 4, 3);
      WriteAt ("|", 4, 2);
      WriteAt ("|", 4, 1);
      WriteAt ("+", 4, 0);

      // Draw the top side, from right to left.
      WriteAt ("-", 3, 0); // shortcut: WriteAt("---", 1, 0)
      WriteAt ("-", 2, 0); // ...
      WriteAt ("-", 1, 0); // ...
                           //
      WriteAt ("All done!", 0, 6);
      Console.WriteLine ();
   }

      //while (Console.ReadKey (true).Key== ConsoleKey.Escape ) {
      //   Console.Clear ();
      //   dc.DisplayBoard ();
      //}

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
   */
   #endregion
   #region Other Functions ------------------------------------------------------------------------
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
   #endregion
}
class DisplayConsole {
   public void DisplayBoard () {
      for (int i = 0; i < 6; i++) {
         string circle = "◌  ", dot = "·  ", print = "";
         for (int j = 0; j < 5; j++) {
            print += (i == 0 && j == 0) ? circle : dot;
         }
         print = print.Trim ();
         PrintCentered (print);
         Console.WriteLine ();
      }
      DisplayKeypad ();
   }
   public void UpdateBoard (string ck, int chCount, int currentLine) {
      for (int i = 0, count = 5; i < 6; i++) {
         string circle = "◌  ", dot = "·  ", print = "";
         print += (i == currentLine && chCount <= 5) ? ck + ((chCount < 5) ? circle : "") + PrintSymbols (dot, count - chCount - 1) :
         PrintSymbols (dot, count);
         print = print.Trim ();
         PrintCentered (print);
         Console.WriteLine ();
      }
      DisplayKeypad ();
   }
   public void DisplayKeypad () {
      PrintCentered ($"{"───────────────────────────────"}\n");
      for (int i = 0, count = 0; i < 4; i++) {
         string print = "";
         for (int j = 0; j < 7 && count < 26; j++, count++) {
            print += (char)(65 + count) + "    ";
         }
         print = print.Trim ();
         PrintCentered (print);
      }
   }
   string PrintSymbols (string str, int count) {
      string strOut = "";
      for (int i = 0; i < count; i++) strOut += str;
      return strOut;
   }
   void PrintCentered (string text) {
      int width = Console.WindowWidth;
      int left = (width - text.Length) / 2;
      Console.SetCursorPosition (left, Console.CursorTop);
      Console.WriteLine (text);
   }
}
class UpdateConsole : DisplayConsole { }