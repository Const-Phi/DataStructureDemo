using System;
using System.Collections.Generic;

namespace DataStructureDemo
{
    class Program
    {
        static void PrintTestPage(IPrintable printer)
        {
            printer.Print("It's just a test page...");
            printer.Print("Hello world!");
            printer.Print(new byte[] { 42, 12, 65, 7 });

            if (printer is ColorPrinter)
                printer.Print("I'm a ColorPrinter!");

            var mfu = printer as MultyFunctionalUnit;
            if (mfu != null)
            {
                var data = mfu.Scan();
                mfu.Print(data);
            }

            printer.Print(Environment.NewLine);
        }

        static void TestDisposingEntity()
        {
            using (var cp = new ColorPrinter(ConsoleColor.Red))
            {
                cp.Print("Created!");
                cp.Print("Do smth...");
            }
        }

        static void Main()
        {
            //TestDisposingEntity();

            //GC.Collect();

            //var myPrinter = new MultyFunctionalUnit();
            //PrintTestPage(myPrinter);

            //var myColorPrinter = new ColorPrinter(ConsoleColor.Green);
            //PrintTestPage(myColorPrinter);


            //var point = new Point(3, 45, -4, 89, 6);
            //var str = Convert.ToString(point);
            //Console.WriteLine(str);

            //var anotherPoint = new Point(point);

            //var p2 = new Point(2, 4, 6, -89, 3);

            //var clonePoint1 = point.Clone() as Point;
            //var clonePoint2 = (Point)point.Clone();


            //Console.WriteLine(point.Equals(anotherPoint));
            //Console.WriteLine(point.Equals(p2));

            //foreach (var coordinate in point)
            //    Console.WriteLine(coordinate);

            var students = new List<Student>()
            {
                new Student("Пушкин", "Александр", "Сергеевич", new DateTime(1799, 6, 6)),
                new Student("Бродский", "Иосиф", "Александрович", new DateTime(1940, 5, 24)),
                new Student("Высоцкий", "Владимир", "Семёнович", new DateTime(1938, 1, 25)),
                new Student("Цветаева", "Марина", "Ивановна", new DateTime(1892, 11, 8))
            };

            PrintStudentList(students, "\tbefore sorting:");
            students.Sort(new Student.LastNameComparator());
            PrintStudentList(students, "\tsorting by lastName:");
            students.Sort(new Student.AgeComparator());
            PrintStudentList(students, "\tsorting by age:");

            // demo of implicit and explicit type casting
            ComplexNumber z = Math.PI;
            double value = (double) z;

            MyStrangeNumber a = 5, b = 10; 
            var c = a + b;
            

        }

        private static void PrintStudentList(List<Student> students, String message)
        {
            Console.WriteLine(message);
            foreach (var student in students)
                Console.WriteLine(student);
            Console.WriteLine();
        }
    }
}
