using System.Data.Common;
using System.Numerics;
using System.Text;
namespace T06;

class Program {
   static void Main (string[] args) {
      Console.OutputEncoding = Encoding.UTF8;
      /*
      //Top Left Corner '┌───'
      string TLC = "";
      //Botttom Left Corner '└──-'
      string BLC = "\u2514\u2500\u2500\u2500";
      //Top Right Corner '┐'
      string TRC = "\u2510";
      //Bottom Right Corner '┘'
      string BRC = "\u2518";
      //Top Middle side '┬───'
      string TMS = "\u252c\u2500\u2500\u2500";
      //Left Middle side '├───'
      string LMS = "\u251c\u2500\u2500\u2500";
      //Bottom Middle side '┴──-'
      string BMS = "\u2534\u2500\u2500\u2500";
      //Right Middle side '┤'
      string RMS = "\u2524";
      //Centre Middle Pattern '┼───'
      string CMP = "\u253c\u2500\u2500\u2500";
      //Queen Vertical Line '|'
      string QVL = "\u2502   ";
      //Queen
      string QP = "\u2502 \u2655 ";
      //int m = int.Parse (Console.ReadLine ());
      //Console.WriteLine (m);
      */
      // Number of lines = Number of outer loop loop
      int n = 8;
      /*
 * ┌───┬───┬───┬───┬───┬───┬───┬───┬───┐
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───|
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * ├───┼───┼───┼───┼───┼───┼───┼───┼───┤
 * |   |   |   |   |   |   |   |   |   |
 * └──-┴──-┴──-┴──-┴──-┴──-┴──-┴──-┴──-┘
 */
      List<int[]> Solutions = [];
      Solve (n, Solutions);
      int count = 1;
      foreach (var arr in Solutions) {
         Console.WriteLine ($"\n{count++}");
         BoxPattern (n, arr);
      }
      void BoxPattern (int N, int[] boxPattern) {
         for (int row = 1; row <= 2 * N + 1; row++) {
            //first line
            if (row == 1)
               Console.WriteLine ($"┌───{Print ("┬───", N - 1)}┐");
            //middle lines
            else if (row % 2 != 0 && row != 2 * N + 1)
               Console.WriteLine ($"├───{Print ("┼───", N - 1)}┤");
            //last line
            else if (row == 2 * N + 1)
               Console.WriteLine ($"└──-{Print ("┴──-", N - 1)}┘");
            //Queens line
            else {
               for (int col = 1; col <= N; col++) {
                  string res = (col == boxPattern[row / 2 - 1] + 1) ? "\u2502 \u2655 " : "\u2502   ";
                  Console.Write (res);
               }
               Console.Write ("\u2502 \n");
            }
         }
      }
      /*
      void BoxPattern (int N, int[] boxPattern) {
         for (int row = 1; row <= 2 * N + 1; row++) {
            //first line
            if (row == 1) {
               Console.Write ("┌───");
               for (int col = 1; col <= N - 1; col++)
                  Console.Write ("┬───");
               Console.Write ("┐\n");
               //last line
            } else if (row == 2 * N + 1) {
               Console.Write ("└──-");
               for (int col = 1; col <= N - 1; col++)
                  Console.Write ("┴──-");
               Console.Write ("┘");
               //middle lines
            } else if (row % 2 != 0) {
               Console.Write ("├───");
               for (int col = 1; col <= N - 1; col++)
                  Console.Write ("┼───");
               Console.Write ("┤\n");
            } else {
               for (int col = 1; col <= N; col++) {
                  string res = (col == boxPattern[row / 2 - 1] + 1) ? "\u2502 \u2655 " : "\u2502   ";
                  Console.Write (res);
               }
               Console.Write ("\u2502 \n");
            }
         }
      }*/
      string Print (string input, int n) {
         string result = "";
         for (int i = 0; i < n; i++) result += input;
         return result;
      }
      void Solve (int n, List<int[]> solutions) {
         int[] board = new int[n];
         Place (board, 0, n, solutions);
      }
      bool Place (int[] board, int row, int n, List<int[]> solutions) {
         if (row == n) {
            solutions.Add ((int[])board.ToArray ());
            return false;
         }
         //choices: one queen per column in each row
         for (int col = 0; col < n; col++) {
            if (Safe (board, row, col)) {
               board[row] = col;
               //Backtrack: Remove last placed queen
               Place (board, row + 1, n, solutions);
            }
         }
         return false;
      }
      // No two queen can share column and diagonal
      bool Safe (int[] board, int row, int col) {
         for (int r = 0; r < row; r++) {
            int c = board[r];
            if (c == col || Math.Abs (c - col) == Math.Abs (r - row)) return false;
         }
         return true;
      }

      #region Pattern practice --------------------------------------
      // 1 number of lines =number of outer for loop
      // 2 Identify for every row number
      /* how many column number
       * types of elements
       * */
      // 3. What to print
      /*
      Pattern1 (n);
      Pattern2 (n);
      Pattern3 (n);
      Pattern4 (n);
      Pattern5 (n);
      Pattern6 (n);
      Pattern7 (n);
      Pattern8 (n);
      Pattern9 (n);
      Pattern10 (n);

      void Pattern1 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n; col++)
               Console.Write ("* ");
            Console.Write ("\n");
         }
      }
      void Pattern2 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= row; col++)
               Console.Write ("{0} ", col);
            Console.Write ("\n");
         }
      }
      void Pattern3 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n + 1 - row; col++)
               Console.Write ("* ");
            Console.Write ("\n");
         }
      }
       * [1,1]
       * [2,2]
       * [3,3]
       * [4,4]
       * [5,5]
       * [6,4]
       * [7,3]
       * [8,2]
       * [9,1]

      void Pattern4 (int n) {
         for (int row = 1; row <= 2 * n; row++) {
            if (row <= n)
               for (int col = 1; col <= row; col++)
                  Console.Write ("* ");
            else
               for (int col = 1; col <= 2 * n - row; col++)
                  Console.Write ("* ");
            Console.Write ("\n");
         }
      }

      void Pattern5 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n - row; col++)
               Console.Write ("  ");
            for (int col = 1; col <= row; col++)
               Console.Write ("* ");
            Console.Write ("\n");
         }
      }

      void Pattern6 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col < row; col++)
               Console.Write ("  ");
            for (int col = 1; col <= n - row + 1; col++)
               Console.Write (" *");
            Console.Write ("\n");
         }
      }

      /*
       * [1, 4,*,4]
       * [2, 3,*,1,*,3]
       * [3, 2,*,1,*,1,2]
       * [4, 1,*,1,*,1,*,1,*,1]
       * [5, *,1,*,1,*,1,*,1,*]

      void Pattern7 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n - row; col++)
               Console.Write ("  ");
            for (int col = 1; col <= row; col++)
               Console.Write ("*   ");
            Console.Write ("\n");
         }
      }
      void Pattern8 (int n) {
         for (int row = 1; row <= n; row++) {
            for (int col = 1; col < row; col++)
               Console.Write ("  ");
            for (int col = 1; col <= n - row + 1; col++)
               Console.Write (" *  ");
            Console.Write ("\n");
         }
      }

            *
          *   *
        *   *   *
      *   *   *   *
    *   *   *   *   *
  *   *   *   *   *   *
*   *   *   *   *   *   *
  *   *   *   *   *   *
    *   *   *   *   *
      *   *   *   *
        *   *   *
          *   *
            *

      void Pattern9 (int n) {
         for (int row = 1; row <= 2 * n; row++) {
            int space = (row <= n) ? n - row + 1 : row % n + 1;
            int stars = (row <= n) ? row : 2 * n - row;
            for (int col = 1; col < space; col++)
               Console.Write ("  ");
            for (int col = 1; col <= stars; col++)
               Console.Write ("*   ");
            Console.Write ("\n");
         }
      }
      /*
       * n=5
       *
    *
   * *
  * * *
 * * * *
* * * * *
 * * * *
  * * *
   * *
    *
      OL: 2*n-1
      Prespace: n-rows  + '*'
      Postspace: 2(n-1) -1+ '*'


              *
            *   *
          *       *
        *           *
      *               *
        *           *
          *       *
            *   *
              *
            *outer loop = 2*n -1
            *
            *prespace + * = 2(n-rows) on each loop
            *not in first and last line, postspace + * = (4 (rows-1)-1)
             *[1,  8,*]
             *[2,  6,*,3,*]
             *[3,  4,*,7,*]
             *[4,  2,*,11,*]
             *[5,   ,*,15,*]
             *[6,  2,*,11,*]
             *[7,  4,*,7,*]
             *[8,  6,*,3,*]
             *[9,  8,*]
     void Pattern10 (int n) {
         for (int row = 1; row < 2 * n; row++) {
            int mirror = row <= n ? row : 2 * n - row;
            int preSpace = 2 * (n - mirror);
            int postSpace = 4 * (mirror - 1) - 1;
            for (int col = 1; col <= preSpace; col++)
               Console.Write (' ');
            Console.Write ('*');
            for (int col = 1; col <= postSpace; col++)
               Console.Write (' ');
            if (row != 1 && row != 2 * n - 1) Console.Write ('*');
            Console.Write ("\n");
         }
      }
   }*/
      #endregion

      //choices: one queen per column in each row
      //constraint: No two queen can share same row, column and diagonal
      //Basecase: Whem you plave n queens
      //Backtrack: Remove last placed queen
   }
   /*
 * enum-> startline (TLS,BLS MLS)
 * enum-> mid elements( TMS,MLS,RMS)
 * */
}
