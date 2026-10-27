class SchoolInfo {
   public string FirstName { get; init; }
   public string LastName { get; init; }
   protected SchoolInfo (string firstName, string lastName) {
      FirstName = firstName; LastName = lastName;
   }
}

class Students (string firstname, string lastname, float gpa) : SchoolInfo (firstname, lastname) {
   public float Gpa { get; init; } = gpa;
}

class Teachers (string firstname, string lastname, string dept) : SchoolInfo (firstname, lastname) {
   public string Dept { get; init; } = dept;
}