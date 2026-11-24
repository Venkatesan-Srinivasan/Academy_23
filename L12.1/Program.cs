using System.Text;

namespace L12._1;

class Program {
   static void Main (string[] args) {
      Console.CursorVisible = false;
      Console.OutputEncoding = Encoding.UTF8;
      List<string> lst = [];
      string keys = "";
      int currentLine = 0;
      var dc = new DisplayConsole ();
      string secretWord = GetSecretWord ();
      dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst, secretWord);
      for (; ; ) {
         if (lst.Count == 6) {
            dc.PrintStatus ($"GameOver. The word is {secretWord}");
            return;
         }
         var option = Console.ReadKey (true).Key;
         char key = (char)option;
         if (key >= 'A' && key <= 'Z') {
            keys += key + " ";
            Console.Clear ();
            dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst,secretWord);
            if (keys.Length > 10) {
               keys = keys[..^2];
               Console.Clear ();
               dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst, secretWord);
               dc.PrintStatus ("Word is greater than 5 letter, enter backspace to continue");
            }
         }
         if (option == ConsoleKey.Backspace && keys.Length != 0) {
            keys = keys[..^2];
            Console.Clear ();
            dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst, secretWord);
         }
         // 1. Checks for the entered words is present in the dictionary
         // 2. Add the word only when it is not already present in the list
         if (option == ConsoleKey.Enter && keys.Length == 10) {
            if (WordPresence (dc.TrimmedStrings (keys)) && !lst.Contains (keys)) {
               lst.Add (keys);
               currentLine++;
               Console.Clear ();
               dc.DisplayBoard ("◌ · · · ·", keys.Length / 2, currentLine, lst, secretWord); //next line
               if (dc.TrimmedStrings (keys) == secretWord) {
                  dc.PrintStatus ("You win!");
                  return;
               }
               keys = "";
            } else {
               Console.Clear ();
               dc.DisplayBoard (keys, keys.Length / 2, currentLine, lst, secretWord); // current line is not valid
               if (lst.Contains (keys)) {
                  dc.PrintStatus ("Word already guessed");
               } else dc.PrintStatus ($"{keys} is not a word");
            }
         }
      }
   }
   #region Other Functions ------------------------------------------------------------------------
   public static string GetSecretWord () {
      string[] words = File.ReadAllLines ("../../../../Data/puzzle-5.txt");
      int rd = new Random ().Next (0, words.Length);
      return words[rd];
   }
   public static bool WordPresence (string str) => File.ReadLines ("../../../../Data/Dict-5.txt")
                 .Any (line => line.Contains (str));
   #endregion
}