namespace L12;

interface IStorable {
   SWriter Save (SWriter w);
   void Load (SReader r);
}

class SWriter {
   public SWriter (string name) {
      if (File.Exists (name)) File.Delete (name);
      mFile = new StreamWriter (name);
   }
   public SWriter Put (string s) { mFile.WriteLine (s); return this; }
   public SWriter Put (double d) { mFile.WriteLine (d); return this; }
   public SWriter Put (int i) { mFile.WriteLine (i); return this; }
   public void Close () {
      if (mFile != null) mFile.Dispose ();
      mFile = null;
   }
   StreamWriter mFile;
}

class SReader {
   public SReader (string name) {
      mFile = new StreamReader (name);
   }
   public string GetS () => mFile.ReadLine ();
   public double GetD () => double.Parse (mFile.ReadLine ());
   public int GetN () => int.Parse (mFile.ReadLine ());
   public void Close () {
      if (mFile != null) mFile.Dispose ();
      mFile = null;
   }
   StreamReader mFile;
}