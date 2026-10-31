namespace L10._2;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Hello, World!");
      //TQueueTest<int> TQueuetest = new();
      TQueueTest.TestBasicQueue ();
      TQueueTest.TestCircularQueue ();
      TQueueTest.TestEmptyQueue ();
      TQueueTest.TestPeek ();
      //TQueueTest.TestClear ();

      TQueueTest.TestResize ();

      TQueueTest.ResizeWhileWrappedMaintainsQueueOrder ();

      /*
      q.Enqueue ()
      q.TEnqueue (1);
      q.TEnqueue (2);
      q.TEnqueue (3);
      q.TEnqueue (4);
      q.TEnqueue (5);
      q.TEnqueue (6);
      Console.WriteLine (q.TCount ());
      Console.WriteLine (q.TDequeue ());
      //Console.WriteLine (q.TCount ());
      //q.TClear ();
      Console.WriteLine (q.TIsEmpty ());
      Console.WriteLine (q.TDequeue ());
      Console.WriteLine (q.TDequeue ());
      Console.WriteLine (q.TDequeue ());
      Console.WriteLine (q.TDequeue ());
      Console.WriteLine (q.TDequeue ());
      bool passed = true;
      // STEP 1: Enqueue 100,000 elements
      for (int i = 1; i <= 100000; i++) {
         q.TEnqueue (i);
      }
      Console.WriteLine ("After Enqueue:");
      Console.WriteLine (q.TCount ());   // 100000
      Console.WriteLine (q.TPeek ());    // 1

      // STEP 2: Dequeue first 50,000 and verify FIFO
      for (int i = 1; i <= 50000; i++) {
         int value = q.TDequeue ();
         if (value != i) {
            Console.WriteLine ("FIFO failed at: " + i);
            passed = false;
            break;
         }
      }
      Console.WriteLine ("After 50,000 Dequeues:");
      Console.WriteLine (q.TCount ());   // 50000
      Console.WriteLine (q.TPeek ());    // 50001

      // STEP 3: Add another 50,000
      for (int i = 100001; i <= 150000; i++) {
         q.TEnqueue (i);
      }
      Console.WriteLine ("After adding more:");
      Console.WriteLine (q.TCount ());   // 100000
      Console.WriteLine (q.TPeek ());    // 50001

      // STEP 4: Verify everything remaining
      for (int i = 50001; i <= 150000; i++) {
         int value = q.TDequeue ();

         if (value != i) {
            Console.WriteLine ("FIFO failed at: " + i);
            passed = false;
            break;
         }
      }

      // STEP 5: Check completely empty
      Console.WriteLine ("Final:");
      Console.WriteLine (q.TCount ());       // 0
      Console.WriteLine (q.TIsEmpty ());     // True

      // STEP 6: Reuse after huge operation
      q.TEnqueue (999);
      q.TEnqueue (888);
      q.TEnqueue (777);
      Console.WriteLine ("Reuse:");
      Console.WriteLine (q.TPeek ());        // 999
      Console.WriteLine (q.TCount ());       // 3
      Console.WriteLine (q.TDequeue ());     // 999
      Console.WriteLine (q.TDequeue ());     // 888
      Console.WriteLine (q.TDequeue ());     // 777
      Console.WriteLine (q.TIsEmpty ());     // True

      // Overall result
      if (passed)
         Console.WriteLine ("TEST PASSED");
      else
         Console.WriteLine ("TEST FAILED");
      */
   }
}
