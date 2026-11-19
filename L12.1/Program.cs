using System.Text;

namespace L12._1;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ();
      string secretWord = GetSecretWord ();
      Console.OutputEncoding = Encoding.UTF8;
      List<string> lst = [];
      var dc = new DisplayConsole ();
      string keys = "";
      int currentLine = 0;
      dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst);
      for (; ; ) {
         if (lst.Count () == 6) {
            dc.PrintStatus ($"GameOver. The word is {secretWord}");
            return;
         }
         var option = Console.ReadKey (true).Key;
         char key = (char)option;
         if (key >= 'A' && key <= 'Z') {
            keys += key + " ";

            Console.Clear ();
            dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst);
            if (keys.Length > 10) {
               Console.Clear ();
               dc.DisplayBoard ("", keys.Length / 2, currentLine, lst);
               keys = keys.Remove (keys.Length - 2);
               dc.PrintStatus ("Word is greater than 5 letter, enter backspace to continue");

            }
         }
         if (option == ConsoleKey.Backspace && keys.Length != 0) {
            keys = keys.Remove (keys.Length - 2);
            Console.Clear ();
            dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst);
         }
         if (option == ConsoleKey.Enter && keys.Length == 10) {
            if (WordPresence (TrimmedStrings (keys))&& !lst.Contains (keys)) {
               lst.Add (keys);
               currentLine++;
               Console.Clear ();
               dc.DisplayBoard ("◌ · · · ·", keys.Length / 2, currentLine, lst);
            } else {
               Console.Clear ();
               dc.DisplayBoard ("◌ · · · ·", keys.Length / 2, currentLine, lst);
               if (lst.Contains (keys)) dc.PrintStatus ("The word is found");
               else dc.PrintStatus ("Word is not found");
            }
            keys = "";
         }
      }
   }
   #region Other Functions ------------------------------------------------------------------------

   public static bool WordPresence (string str) => File.ReadLines ("../../../../Data/Dict-5.txt")
                 .Any (line => line.Contains (str));
   public static string TrimmedStrings (string str) {
      string trimStr = "";
      foreach (var ch in str) if (char.IsLetter (ch)) trimStr += ch;
      return trimStr;
   }
   public static string GetSecretWord () {
      string[] words = File.ReadAllLines ("../../../../Data/puzzle-5.txt");
      int rd = new Random ().Next (0, words.Length);
      return words[rd];
   }
   void PrintGrayCode () => Console.ForegroundColor = ConsoleColor.Gray;

   void PrintGreenCode () => Console.ForegroundColor = ConsoleColor.Green;

   void PrintBlueCode () => Console.ForegroundColor = ConsoleColor.Blue;

   #endregion
}
class DisplayConsole {

   public void DisplayBoard (string ck, int chCount, int currentLine, List<string> lst) {
      Program p = new ();
      for (int i = 0, count = 5; i < 6; i++) {
         string circle = "◌ ", dot = "· ", print = "";
         if (i < currentLine) {
            PrintCentered (lst[i].Trim ()); continue;
         }
         print += (i == currentLine && chCount <= 5) ? ck + ((chCount < 5) ? circle : "") + PrintSymbols (dot, count - chCount - 1) :
                                                      PrintSymbols (dot, count);
         print = print.Trim ();
         PrintCentered (print);
      }
      DisplayKeypad ();
   }
   public void PrintStatus (string str) => PrintCentered (str);
   public void DisplayKeypad () {
      PrintCentered ($"{"───────────────────────────"}\n");
      for (int i = 0, count = 0; i < 4; i++) {
         string print = "";
         for (int j = 0; j < 7 && count < 26; j++, count++) {
            print += (char)(65 + count) + "   ";
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