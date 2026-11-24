using System;
using System.Collections.Generic;
using System.Text;

namespace L12._1;
   class DisplayConsole {
      public void DisplayBoard (string ck, int chCount, int currentLine, List<string> lst, string secretWord) {
         for (int i = 0, count = 5; i < 6; i++) {
            string circle = "◌ ", dot = "· ", print = "";
            if (i < currentLine) {
               Validation (TrimmedStrings (lst[i]), secretWord); continue;
            }
            print += (i == currentLine && chCount <= 5) ?
               ck + ((chCount < 5) ? circle : "") + PrintSymbols (dot, count - chCount - 1)
               : PrintSymbols (dot, count);
            //print = print.Trim ();
            PrintCentered (print);
         }
         DisplayKeypad ();
      }
      Dictionary<char, ConsoleColor> keyPad = [];
      public void PrintStatus (string str) => PrintCentered (str);
      public void DisplayKeypad () {
         PrintCentered ("───────────────────────────\n");
         for (int i = 0; i < 26; i++) {
            char letter = (char)('A' + i);
            if (i % 7 == 0) {
               if (i > 0) Console.WriteLine ();
               Console.SetCursorPosition ((Console.WindowWidth - 25) / 2, Console.CursorTop);
            }
            Console.ForegroundColor = keyPad.GetValueOrDefault (letter, ConsoleColor.White);
            Console.Write (letter + "   ");
         }
         Console.ResetColor ();
         Console.WriteLine ();
         PrintCentered ("───────────────────────────\n");
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
      void Validation (string guess, string secret) {
         int left = (Console.WindowWidth - guess.Length * 2) / 2;
         Console.SetCursorPosition (left, Console.CursorTop);
         for (int i = 0; i < guess.Length; i++) {
            char c = guess[i];
            var color = c == secret[i] ? ConsoleColor.Green
                           : secret.Count (x => x == c) > guess.Where ((g, j) => g == c && (secret[j] == c || j < i)).Count () ? ConsoleColor.Blue
                           : ConsoleColor.DarkGray;
            WriteColored (guess[i], color);
            if (color == ConsoleColor.Green || !keyPad.TryGetValue (guess[i], out ConsoleColor value)
                || (color == ConsoleColor.Blue && value != ConsoleColor.Green))
               keyPad[guess[i]] = color;
         }
         Console.WriteLine ();
      }

      void WriteColored (char ch, ConsoleColor color) {
         Console.ResetColor ();
         Console.ForegroundColor = color;
         Console.Write (ch + " ");
         Console.ResetColor ();
      }
      public string TrimmedStrings (string str) {
         string trimStr = "";
         foreach (var ch in str) if (char.IsLetter (ch)) trimStr += ch;
         return trimStr;
      }
   }

