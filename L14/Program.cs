using System.IO;
using static System.Net.Mime.MediaTypeNames;
namespace L14;

class Program {
   static void Main (string[] args) {
      /*
      string str = "hello";
      foreach (var ch in str)
         Console.WriteLine ($"{ch} ");

      //foreach ~~ IEnumerable

      IEnumerable<char> enumerable = str;
      IEnumerator<char> enumerator = enumerable.GetEnumerator ();
      while (enumerator.MoveNext ())
         Console.WriteLine ($"{enumerator.Current}");
      foreach (var s in FileLines ("../../../../test.txt"))
         Console.WriteLine (s);
      */


      string[] FileLines (string fileName) {
         List<string> lines = [];
         string line = "";
         var stm = File.Open (fileName, FileMode.Open);
         var sr = new StreamReader (stm);
         for (; ; ) {
            int n = sr.Read ();
            //            int n = stm.ReadByte (); //streadreader on stream
            if (n == -1) break;
            if (n == '\r') continue;
            if (n == '\n') {
               lines.Add (line); line = ""; continue;
            }
            line += (char)n;
         }
         if (line != "") lines.Add (line);
         sr.Dispose ();
         stm.Dispose ();
         return lines.ToArray ();
      }
      //using Disposable

      int count = 0;

      IEnumerable<string> FileLines2 (string fileName) {
         List<string> lines = [];
         string line = "";
         using (var stm = File.Open (fileName, FileMode.Open))
         using (var sr = new StreamReader (stm)) {
            for (; ; ) {
               int n = sr.Read ();
               count++;
               if (n == -1) break;
               if (n == '\r') continue;
               // if (n == '\n') { lines.Add (line); line = ""; continue; }
               if (n == '\n') { yield return line; line = ""; continue; }  // multiple returns fn doesn't finish, caller will control. state
               line += (char)n;
            }
         }
         //if (line != "") lines.Add (line); //after last line word doesn't ccontains \n
         if (line != "") yield return line;
         //return [.. lines];
      }

      //      string word = FileLines2 ("../../../../Data/words.txt").First (a => a.Length >= 20);
      foreach (var s in FileLines2 ("../../../../Data/words.txt").Where (s => s.Length >= 20)) 
         Console.WriteLine (s);
      Console.WriteLine (FileLines2 ("../../../../Data/words.txt").Any ());
      Console.WriteLine (count);
   }
}
