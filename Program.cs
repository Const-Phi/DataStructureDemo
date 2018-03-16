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

        static void Main()
        {
            var myPrinter = new MultyFunctionalUnit();
            PrintTestPage(myPrinter);

            var myColorPrinter = new ColorPrinter(ConsoleColor.Green);
            PrintTestPage(myColorPrinter);
        }
    }
}
