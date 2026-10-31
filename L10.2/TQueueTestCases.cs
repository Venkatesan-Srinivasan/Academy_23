using System;
using System.Collections.Generic;
using System.Text;

namespace L10._2 {

   #region class TQueueTest --------------------------------------------------------------------------
   /// <summary>Tests the TQueue class</summary>
   class TQueueTest {

      #region Methods --------------------------------------------------
      /// <summary>Test basic queue operations</summary>
      public static void TestBasicQueue () {
         TQueue1<int> q = new ();
         q.Enqueue (10);
         q.Enqueue (20);
         q.Enqueue (30);
         bool passed = q.Dequeue () == 10 &&
                       q.Dequeue () == 20 &&
                       q.Dequeue () == 30 &&
                       q.IsEmpty;
         PrintResult ("Basic Queue", passed);
      }

      /// <summary>Test clearing the queue</summary>
      public static void TestClear () {
         TQueue1<int> q = new ();
         q.Enqueue (10);
         q.Enqueue (20);
         q.Clear ();
         bool passed = q.Count == 0 && q.IsEmpty;
         PrintResult ("Clear", passed);
      }

      /// <summary>Test circular queue behavior</summary>
      public static void TestCircularQueue () {
         TQueue1<int> q = new ();
         q.Enqueue (10);
         q.Enqueue (20);
         q.Enqueue (30);
         q.Enqueue (40);
         q.Dequeue ();
         q.Dequeue ();
         q.Enqueue (50);
         q.Enqueue (60);
         bool passed = q.Dequeue () == 30 &&
                       q.Dequeue () == 40 &&
                       q.Dequeue () == 50 &&
                       q.Dequeue () == 60 &&
                       q.IsEmpty;
         PrintResult ("Circular Queue", passed);
      }

      /// <summary>Test operations on an empty queue</summary>
      public static void TestEmptyQueue () {
         TQueue1<int> q = new ();
         bool dequeuePassed = false;
         bool peekPassed = false;
         try {
            q.Dequeue ();
         } catch (Exception e) {
            dequeuePassed = e.Message == "Queue empty";
         }
         try {
            q.Peek();
         } catch (Exception e) {
            peekPassed = e.Message == "Queue empty";
         }
         PrintResult ("Empty Queue", dequeuePassed && peekPassed);
      }

      /// <summary>Test peek and count</summary>
      public static void TestPeek () {
         TQueue1<int> q = new ();
         q.Enqueue (100);
         q.Enqueue (200);
         bool passed = q.Peek() == 100 &&
                       q.Count == 2;
         PrintResult ("Peek and Count", passed);
      }

      /// <summary>Test automatic queue resizing</summary>
      public static void TestResize () {
         TQueue1<int> q = new ();
         for (int i = 1; i <= 10; i++)
            q.Enqueue (i);
         bool passed = q.Count == 10;
         for (int i = 1; i <= 10; i++)
            if (q.Dequeue () != i)
               passed = false;
         passed = passed && q.IsEmpty;
         PrintResult ("Resize", passed);
      }

      /// <summary>Test resizing while the head has wrapped around</summary>
      public static void ResizeWhileWrappedMaintainsQueueOrder () {
         TQueue1<int> q = new ();
         for (int i = 1; i <= 4; i++) q.Enqueue (i);   // Fill the initial capacity
         q.Dequeue ();
         q.Dequeue ();                                  // mHead is now 2
         for (int i = 5; i <= 10; i++) q.Enqueue (i);   // Wraps, then resizes while full
         for (int i = 3; i <= 10; i++)Console.WriteLine (i == q.Dequeue ()) ;
         PrintResult ("resize while wrapped", q.IsEmpty);
      }


      #endregion

      #region Implementation -------------------------------------------
      /// <summary>Print the test result</summary>
      static void PrintResult (string test, bool passed) =>
         Console.WriteLine ($"{test}: {(passed ? "PASSED" : "FAILED")}");
      #endregion
   }
   #endregion
}