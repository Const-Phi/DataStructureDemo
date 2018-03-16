using System;

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


            var point = new Point(3, 45, -4, 89, 6);
            var str = Convert.ToString(point);
            Console.WriteLine(str);

            var anotherPoint = new Point(point);

            var p2 = new Point(2, 4, 6, -89, 3);

            var clonePoint1 = point.Clone() as Point;
            var clonePoint2 = (Point)point.Clone();


            Console.WriteLine(point.Equals(anotherPoint));
            Console.WriteLine(point.Equals(p2));

            //foreach (var coordinate in point)
            //    Console.WriteLine(coordinate);
        }
    }
}
