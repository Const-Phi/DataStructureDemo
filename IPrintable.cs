namespace DataStructureDemo
{
    /// <summary>
    /// Интерфейс, описывающий требования к печатному устройству.
    /// </summary>
    interface IPrintable
    {
        /// <summary>
        /// Метод, отправляющий на печать массив байт.
        /// </summary>
        /// <param name="data">Данные, представленные в виде массива байт.</param>
        void Print(byte[] data);

        /// <summary>
        /// Метод, отправляющий на печать текст.
        /// </summary>
        /// <param name="message">Текст, который будет напечатан.</param>
        void Print(string message);
    }
}
