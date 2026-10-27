class StudentInfo {
   public string FirstName { get; set; }
   public string LastName { get; set; }

   protected StudentInfo (string firstName, string lastName) {
      FirstName = firstName; LastName = lastName;
   }
   public void SetInfo (string firstname, string lastname) {
      FirstName = firstname;
      LastName = lastname;
   }
}

class Student (string firstname, string lastname, float gpa) : StudentInfo (firstname, lastname) {
   public float Gpa { get; set; } = gpa;
   public void SetGpa (float gpa) => Gpa = gpa;
}

class Teacher (string firstname, string lastname, string dept) : StudentInfo (firstname, lastname) {
   public string Dept { get; set; } = dept;
   public void SetDept (string dept) => Dept = dept;
}