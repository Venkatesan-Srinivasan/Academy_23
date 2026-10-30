using System;
using System.Collections.Generic;
using System.Text;

namespace P01._2;

public class Class2 {

}
public class Vehicle {
   // Properties;
   public string? type { get; set; }
   public double mileage { get; set; }
   public bool isRunning { get; set; }
   public virtual void Start () {
      isRunning = true;
      Console.WriteLine ("Vehicle started.");
   }

   public void Stop () {
      isRunning = false;
      Console.WriteLine ("Vehicle stopped.");
   }
}
public class Car : Vehicle {
   public string? brand { get; set; }
   public void GetInfo () {
      Console.WriteLine ($"This {type} brand is {brand}");
   }
   // Method Overriding
   public override void Start () {
      isRunning = false;
   }
}

public class Jeep : Car {
   //public override void Start () {
   //   Console.WriteLine ("This is a Jeep");
   //}
}

