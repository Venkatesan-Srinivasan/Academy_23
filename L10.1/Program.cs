// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2026.
// Copyright (c) Trumpf Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// A10.1: File name parser
// Program to implement file name parser with state machine
// Every file name has the components drive letter A to Z (uppercase) , colon, then one or more
// directory names followed by the actual file name which must always have an extension.
// Return tuple of four strings (drive letter, folder, actual file name and their extension).
// ------------------------------------------------------------------------------------------------

namespace L10._1;

using static State;

#region class Program -----------------------------------------------------------------------------
class Program {
   static void Main () {
      string[] fileNames = {
         @"C:\PROJECTS\METAMATION\TRAINING\PROGRAM.CS",
         @"D:\VIDEOS\MOVIES\ACTION\MOVIE.MKV",
         @"E:\PICTURES\VACATION\IMAGE.JPG",
         @"Z:\DOCUMENTS\PRACTICE.TXT",
         @"C:\\METAMATION\TRAINING\PROGRAM.CS",
         @"C:\PROGRAM.CS",
         @"N:\DOWNLOADS\\FLOW.PDF",
         @"WORK\TRAINING.SLNX",
         @"E:\PICTURES\VACATION\IMAGE1.JPG",
         @"D:\VIDEOS\MOVIES\ACTION\MOVIE.MK3",
         @"c:PROGRAM\TRAINING.SLNX",
         @"Z:\Documents\PRACTICE.TXT",
         @"N:\DOWNLOADS\CACHE.jpg"
      };
      foreach (var item in fileNames) {
         var result = FileParse (item);
         Console.WriteLine (result);
      }
   }
   public static (string drive, string directory, string filename, string extension) FileParse
      (string input) {
      State s = A;
      Action toDo;
      Action none = () => { };
      bool isDirectoryNotEmpty = false;
      string drive = "", directory = "", fileName = "", extension = "";
      foreach (char ch in input.Trim () + "~") {
         (s, toDo) = (s, ch) switch {
            (A, >= 'A' and <= 'Z') => (B, () => drive = $"{ch}"),
            (B, ':') => (C, none),
            (C, '\\') => (D, none),
            (D or E, >= 'A' and <= 'Z') => (E, () => fileName += ch),
            (E, '\\') => (D, () => { directory += directory.Length > 0 ? "-" + fileName : fileName;
               isDirectoryNotEmpty = true; fileName = ""; }),
            (E, '.') => (F, none),
            (F or G, >= 'A' and <= 'Z') => (G, () => extension += ch),
            (G, '~') => (H, none),
            _ => (Z, none)
         };
         toDo ();
      }
      if (s == H && isDirectoryNotEmpty) return (drive, directory, fileName, extension);
      return ("", "", "", "");
   }
}
#endregion

enum State { A, B, C, D, E, F, G, H, Z }