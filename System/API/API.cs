using System;

namespace ES_DOS.API
{
    /// <summary>
    /// ��������� � ����������� ����� API, ��������������� ��� ������� ������ � �����.
    /// </summary>
    public static class Api
    {
        /// <summary>
        /// ������������� ���� ������.
        /// </summary>
        /// <param name="color"></param>
        public static void SetFGColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// ������������� ���� ������� ����.
        /// </summary>
        /// <param name="color"></param>
        public static void SetBGColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
        /// <summary>
        /// ������������� ���� ������ �� ���������.
        /// </summary>
        public static void ResetFGColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /// <summary>
        /// ������������� ���� ������� ���� �� ���������.
        /// </summary>
        public static void ResetBGColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// ���������� ����� ����� �� ���������
        /// </summary>
        public static void ResetAll()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        /// <summary>
        /// ������ ������� ����� ���������, � ����������� ��
        /// ���������� ���� "int i".
        /// </summary>
        /// <param name="message"></param>
        /// <param name="i"></param>
        /// <exception cref="TypeNotSpecifed"></exception>
        public static void Message(string message, int i)
        {
            if (i == 1)
            {
                SetFGColor(ConsoleColor.Green);
                Console.WriteLine("[INFO]: " + message);
                ResetAll();
            }
            else if (i == 2)
            {
                SetFGColor(ConsoleColor.Yellow);
                Console.WriteLine("[WARN]: " + message);
                ResetAll();
            }
            else if (i == 3)
            {
                SetFGColor(ConsoleColor.Red);
                Console.WriteLine("[ERR]: " + message);
                ResetAll();
            }
            else if (i == 4)
            {
                SetFGColor(ConsoleColor.White);
                SetBGColor(ConsoleColor.Red);
                Console.WriteLine("[FATAL]: " + message);
                ResetAll();
            }
            else if (i > 4)
            {
                throw new Exception("The input type Message(string message, int i) has exceeded its maximum value.");
            }
        }
    }
}