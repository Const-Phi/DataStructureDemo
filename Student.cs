using System;
using System.Collections.Generic;

namespace DataStructureDemo
{
    class Student
    {
        public string LastName { get; protected set; }

        public string FirstName { get; protected set; }

        public string MiddleName { get; protected set; }

        public string PhoneNumber { get; protected set; }

        public double Height  { get; protected set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }

        public DateTime BirthDate { get; protected set; }

        public Student(string lastName, string firstName, string middleName, DateTime birthDate)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            BirthDate = birthDate;
        }

        public override string ToString() => $"{LastName} {FirstName} {MiddleName} ({BirthDate.Year})";

        public class LastNameComparator : IComparer<Student>
        {
            public int Compare(Student x, Student y) => 
                x.LastName.CompareTo(y.LastName);
        }

        public class PhoneNumberComparator : IComparer<Student>
        {
            public int Compare(Student x, Student y) =>
                x.PhoneNumber.CompareTo(y.PhoneNumber);
        }

        public class HeightComparator : IComparer<Student>
        {
            public int Compare(Student x, Student y) =>
                x.Height.CompareTo(y.Height);
        }

        public class AgeComparator : IComparer<Student>
        {
            public int Compare(Student x, Student y) =>
                x.Age.CompareTo(y.Age);
        }
    }
}
