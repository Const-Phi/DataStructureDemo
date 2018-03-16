using System;

namespace DataStructureDemo
{
    class ColorPrinter : IPrintable, IDisposable
    {
        private ConsoleColor color;

        public ColorPrinter(ConsoleColor color)
        {
            this.color = color;
        }

        private void StaffPrint(string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        public void Print(string message) =>
            StaffPrint(message);

        public void Print(byte[] data) =>
            StaffPrint(string.Join(" ", Array.ConvertAll(data, item => $"0x{item:X}")));

        public void Dispose()
        {
            Print("Disposed!");
        }

        ~ColorPrinter()
        {
            Print("Finilized!");
        }
    }
}
