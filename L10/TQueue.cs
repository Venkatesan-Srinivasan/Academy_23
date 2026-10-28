namespace L10;

class TQueue<T> {
   public void Enqueue (T a) {
      if (mCount == mData.Length) {
         var tmp = new T[mCount * 2];
         for (int i = 0; i < mCount; i++)
            tmp[i] = mData[(mRead + i) % mCount];
         mData = tmp; mWrite = mCount; mRead = 0;
      }
      mData[mWrite] = a;
      mWrite = (mWrite + 1) % mData.Length;
      mCount++;
   }

   public T Dequeue () {
      if (IsEmpty) throw new Exception ("Queue empty");
      T a = mData[mRead];
      mRead = (mRead + 1) % mData.Length;
      mCount--;
      return a;
   }

   public bool IsEmpty => mCount == 0;

   T[] mData = new T[4];
   int mWrite;       // Position where the next Enqueue will happen
   int mRead;        // Position where the next Dequeue will happen
   int mCount;       // Count of elements in the queue
}