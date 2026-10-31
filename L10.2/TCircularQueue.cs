using System;
using System.Collections.Generic;
using System.Text;

namespace L10._2 {
   class TCircularQueue<T> {
      public void TEnqueue (T a) {
         // Array full -> resize
         if (mUsed == mQueue.Length)
            Resize ();
         mQueue[mTail] = a;
         mTail = (mTail + 1) % mQueue.Length;
         mUsed++;
      }

      public T TDequeue () {
         CheckEmpty ();
         T value = mQueue[mHead];
         mHead = (mHead + 1) % mQueue.Length;
         mUsed--;
         return value;
      }


      public T TPeek () {
         CheckEmpty ();
         return mQueue[mHead];
      }

      public int TCount () => mUsed;

      public bool TIsEmpty () => mUsed == 0;
      public void TClear () {
         mQueue = new T[InitialCapacity];
         mHead = mTail = mUsed = 0;
      }
      T[] mQueue = new T[InitialCapacity];
      int mHead;
      int mTail;
      int mUsed;
      const int InitialCapacity = 4;
      void CheckEmpty () {
         if (mUsed == 0)
            throw new Exception ("Queue Empty");
      }
      void Resize () {
         int newSize = mQueue.Length == 0 ? InitialCapacity : 2 * mQueue.Length;
         T[] tmp = new T[newSize];
         // Copy in correct FIFO order
         for (int i = 0; i < mUsed; i++) {
            tmp[i] = mQueue[(mHead + i) % mQueue.Length];
         }
         mQueue = tmp;
         mHead = 0;
         mTail = mUsed;
      }
   }
}
