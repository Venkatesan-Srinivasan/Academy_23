using System;
using System.Collections.Generic;
using System.Text;

namespace L10._2;

class TDeque<T> {

   public T DequeueFront () {
      if (IsEmpty) throw new Exception ("Queue empty");
      T value = mData[mHead];
      mData[mHead] = default!;
      mHead = (mHead + 1) % mData.Length;
      Count--;
      return value;
   }

   public T DequeueRear () {
      if (IsEmpty) throw new Exception ("Queue empty");
      mTail = (mTail - 1 + mData.Length) % mData.Length;
      T value = mData[mTail];
      mData[mTail] = default!;
      Count--;
      return value;
   }
   public void EnqueueFront (T a) {
      if (Count == mData.Length) Resize ();
      mHead = (mHead - 1 + mData.Length) % mData.Length;
      mData[mHead] = a;
      Count++;
   }
   public void EnqueueRear (T a) {
      if (Count == mData.Length) Resize ();
      mData[mTail] = a;
      mTail = (mTail + 1) % mData.Length;
      Count++;

   }
   public T PeekFront () {
      if (IsEmpty) throw new Exception ("Queue os empty");
      T value = DequeueFront ();
      EnqueueFront (value);
      return value;
   }
   public T PeekRear () {
      if (IsEmpty) throw new Exception ("Queue os empty");
      T value = DequeueRear ();
      EnqueueRear (value);
      return value;
   }
   void Resize () {
      T[] newData = new T[Count * 2];
      int firstPart = mData.Length - mHead;
      Array.Copy (mData, mHead, newData, 0, firstPart);
      Array.Copy (mData, 0, newData, firstPart, mHead);
      mData = newData;
      mHead = 0;
      mTail = Count;
   }

   public bool IsEmpty => Count == 0;
   public int Count { get; set; }
   T[] mData = new T[4];
   int mHead;
   int mTail;
}
