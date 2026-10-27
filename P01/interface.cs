abstract class School {
   internal abstract void Details ();
}

class Teach : School, IPayment {
   internal override void Details () => Console.WriteLine ("Teachers Info");
   public void Approve () => Console.WriteLine ("Teacher Approved");
   public void Payments () => Console.WriteLine ("Teachers Payment");
}

class Studet : School {
   public void Request () => Console.WriteLine ("Student Request");
   internal override void Details () => Console.WriteLine ("Students Info");
}

abstract class ServiceProvider {
   internal abstract void Description ();
}

class Infra : ServiceProvider, IPayment {
   internal override void Description () => Console.WriteLine ("Infra Info");
   public void Payments () => Console.WriteLine ("Infra Payment");

}

class Electrician : ServiceProvider, IPayment {
   internal override void Description () => Console.WriteLine ("Electrician Info");
   public void Payments () => Console.WriteLine ("Electrician Payment");
}