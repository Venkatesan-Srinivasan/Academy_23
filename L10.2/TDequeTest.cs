namespace L10._2 {

   class TDequeTest {
      public static void TestBasicDeque () {
         TDeque<int> dk = new ();
         dk.EnqueueFront (2);
         dk.EnqueueFront (1);
         dk.EnqueueRear (3);
         dk.EnqueueRear (4);
         dk.EnqueueFront (6);
         dk.EnqueueFront (5);
         dk.EnqueueRear (7);
         dk.EnqueueRear (8);
         dk.DequeueFront ();
         dk.EnqueueFront (5);
         dk.DequeueRear ();
         dk.EnqueueRear (8);
         dk.DequeueRear ();
         dk.DequeueRear ();
         dk.DequeueFront ();
         dk.DequeueFront ();

         bool passed = dk.DequeueFront () == 1 &&
                       dk.DequeueRear () == 4 &&
                       dk.DequeueFront () == 2 &&
                       dk.DequeueRear () == 3;
         Console.WriteLine ($"Basic Queue: {passed}");
      }
      public static void TestEmpty () {
         TDeque<int> dk = new ();
         dk.EnqueueFront (10);
         dk.DequeueFront ();
         dk.EnqueueRear (20);
         dk.DequeueRear ();
         dk.EnqueueFront (30);
         dk.EnqueueRear (40);
         dk.DequeueFront ();
         dk.DequeueRear ();
         bool passed = dk.IsEmpty;
         Console.WriteLine ($"Empty Queue: {passed}");
      }
      public static void TestPeek () {
         TDeque<int> dk = new ();
         dk.EnqueueFront (10);
         dk.EnqueueRear (20);
         dk.EnqueueFront (30);
         dk.EnqueueRear (40);
         dk.DequeueFront ();
         dk.DequeueRear ();
         bool passed = dk.PeekRear () == 20 &&
                       dk.PeekFront () == 10;
         Console.WriteLine ($"Peek Queue: {passed}");
      }
      public static void TestResize () {
         TDeque<char> dk = new ();
         for (int i = 0; i < 5; i++)
            dk.EnqueueRear ((char)('A' + i));
         for (int i = 5; i < 10; i++)
            dk.EnqueueFront ((char)('A' + i));
         bool passed = dk.Count == 10;
         for (int i = 9; i >= 5; i--)
            if (dk.DequeueFront () != (char)('A' + i)) passed = false;
         for (int i = 0; i < 5; i++)
            if (dk.DequeueFront () != (char)('A' + i)) passed = false;


         passed = passed && dk.IsEmpty;
         Console.WriteLine ($"Resize: {passed}");
      }
      public static void ResizeWhileWrappedMaintainsQueueOrder () {
         TDeque<int> dk = new ();
         for (int i = 1; i <= 4; i++) dk.EnqueueRear (i);   // Fill the initial capacity
         dk.DequeueFront ();
         dk.DequeueFront ();                                  // mHead is now 2
         for (int i = 5; i <= 10; i++) dk.EnqueueFront (i);   // Wraps, then resizes while full
         for (int i = 3; i <= 10; i++) dk.DequeueRear ();
         bool passed = dk.IsEmpty;
         Console.WriteLine ($"Resize while wrapped:: {passed}");
      }
   }
}