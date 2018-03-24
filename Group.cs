using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureDemo
{
    class Group
    {
        Student[] students;

        int numberOFStudents = 0;

        public Group(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), size, "Size must be greater then zero.");

            students = new Student[size];
        }

        protected Student Find(string lastName)
        {
            foreach (var student in students)
                if (student.LastName.Equals(lastName))
                    return student;
            throw new StudentNotFoundException(lastName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public Student this[string lastName]
        {
            get
            {
                return Find(lastName);
            }
        }

        class StudentNotFoundException : Exception
        {
            public StudentNotFoundException()
                : base()
            { }

            public StudentNotFoundException(string lastName)
                : base($"Student with last name \'{lastName}\' not found.")
            { }
        }
    }
}
