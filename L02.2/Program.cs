namespace L02._2;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Guess any  number from 1 to 127\nAnswer [Y}es or [N]o: ");
      int bit = 1;
      int divisor = 2;
      int result = 0;
      for (int i = 0; i < 7; i++) {
         Console.Write ($"Is the remainder is >= {bit} when divided by {divisor}: ");
         var option = Console.ReadKey (true).Key;
         if (option == ConsoleKey.Y) {
            Console.WriteLine ("Yes");
            result += bit;
         } else if (option == ConsoleKey.N) {
            Console.WriteLine ("No");
         } else {
            Console.WriteLine ("Invalid! Press [Y]es or [N]o ");
            i--;
            continue;
         }
         divisor *= 2;
         bit *= 2;
      }
      Console.WriteLine ($"Your guess number is {result}");
   }
}
