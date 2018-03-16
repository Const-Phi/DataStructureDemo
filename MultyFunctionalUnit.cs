using System;

namespace DataStructureDemo
{
    class MultyFunctionalUnit : IPrintable, IScannable
    {
        public void Print(string message) => Console.WriteLine(message);

        public void Print(byte[] data)
        {
            foreach (var item in data)
                Console.Write($"0x{item:X} ");
            Console.WriteLine();
        }

        public byte[] Scan() => new byte[] { 42 };
    }
}
