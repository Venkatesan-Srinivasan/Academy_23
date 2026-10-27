namespace P01;

using System.Diagnostics;
class Program {
   static void Main (string[] args) {
      //base and derived class
      Console.WriteLine ("Hello, World!");
      Student s1 = new ("Adithya", "CSE", 9.4f);
      Console.WriteLine ($"{s1.FirstName}, {s1.LastName}, {s1.Gpa}");
      Student s2 = new ("Arun", "Civil", 9.44f);
      Console.WriteLine ($"{s2.FirstName}, {s2.LastName}, {s2.Gpa}");
      Teacher t1 = new ("Kalai", "ME", "Tech");
      Console.WriteLine ($"{t1.FirstName}, {t1.LastName}, {t1.Dept}");
      Teacher t2 = new ("Vani", "Mtech", "IT");
      Console.WriteLine ($"{t2.FirstName}, {t2.LastName}, {t2.Dept}");

      //upcasting- base-->derived
      //UPCASTING
      SchoolInfo sc1 = new Students ("Akshay", "EEE", 8.5f);
      //Console.WriteLine($"{sc1.FirstName}, {sc1.LastName}, {sc1.Gpa}");
      //base class only knows its im[plemntation and its implemntation to derived, so gpa shws CTE
      SchoolInfo tc1 = new Teachers ("Geethu", "Deep", "ECE");
      Console.WriteLine ($"{tc1.FirstName} {tc1.LastName}");
      //the derived class still get access to base clas methods

      //DOWNCASTING
      Students st1 = (Students)sc1;
      Console.WriteLine (st1.FirstName);
      Console.WriteLine (st1.Gpa);

      Teachers ts1 = (Teachers)tc1;
      Console.WriteLine (ts1.FirstName);
      Console.WriteLine (ts1.Dept);
      /*
      Teachers ts2 = (Teachers)sc1;
      Console.WriteLine (ts2.Dept);
      */
      //Unhandled exception. System.InvalidCastException: Unable to cast object of type 'Students' to type 'Teachers'.

      //NO UPCASTING
      //SchoolInfo sc1 = new("Akshay", "EEE");

      //DOWNCASTING
      /*
      Students st1 = (Students)sc1;
      Console.WriteLine(st1.FirstName);
      Console.WriteLine(st1.LastName);
      */
      //Unhandled exception. System.InvalidCastException: Unable to cast object of type 'SchoolInfo' to type 'Students'.

      //Virtual and Method Overriding --Polymorphism:
      Arithmetic ar = new Arithmetic ();
      Console.WriteLine (ar.Operation (2, 4));
      Arithmetic ae1 = new SubArithmetic ();
      Console.WriteLine (ae1.Operation (5, 10));
      Arithmetic ae2 = new DiffArithmetic ();
      Console.WriteLine (ae2.Operation (15, 10));
      Arithmetic ae3 = new MulArithmetic ();
      Console.WriteLine (ae3.Operation (15, 10));
      //Abstact Modifiers
      /*
      Arithmetics ars = new Arithmetics();        not valid for abstract
      Console.WriteLine(ars.Operations(2, 4));
      */

      Arithmetics aes1 = new SubArithmetics ();
      Console.WriteLine (aes1.Operations (5, 10));
      Arithmetics aes2 = new DiffArithmetics ();
      Console.WriteLine (aes2.Operations (15, 10));
      Arithmetics aes3 = new MulArithmetics ();
      Console.WriteLine (aes3.Operations (15, 10));
      /*
            //Interface
            IPayment ip1 = new Teach ();
            Console.WriteLine (ip1.Payments ());
            //the method doesnot now the identity of objects but knows only the behaviour.

            School se1 = new Studet ();
            School te1 = new Teach ();
            Process (se1);
            Process (te1);
            void Process (School sl) {
               if (sl is Studet s) {
                  s.Request ();
               } else if (sl is Teach t) {
                  t.Approve ();
               }
            }
            IPayment ip1 = new Teach ();
            StartPayment (ip1);
            IPayment ip2 = new Infra ();
            StartPayment (ip2);
            IPayment ip3 = new Electrician ();
            StartPayment (ip3);
            void StartPayment (IPayment staff) => staff.Payments ();
         }
         interface IPayment {
            void Payments ();
         }
      */
   }
}