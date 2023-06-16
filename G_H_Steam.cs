using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        private const int VK_G = 0x47; // Код клавиши G
        private const int VK_H = 0x48; // Код клавиши H

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        static void Main(string[] args)
        {
            bool gKeyPressed = false;

            while (true)
            {
                // Проверяем состояние клавиши G
                short gKeyState = GetAsyncKeyState(VK_G);

                // Проверяем, нажата ли клавиша G
                if ((gKeyState & 0x8000) != 0)
                {
                    // Если клавиша G нажата и не была нажата ранее, устанавливаем флаг gKeyPressed в true
                    if (!gKeyPressed)
                    {
                        gKeyPressed = true;
                    }
                }
                else
                {
                    // Если клавиша G не нажата и флаг gKeyPressed установлен в true, нажимаем клавишу H
                    if (gKeyPressed)
                    {
                        keybd_event((byte)VK_H, 0, 0, 0);
                        keybd_event((byte)VK_H, 0, 0x2, 0);
                        gKeyPressed = false;
                    }
                }
            }
        }
    }
}
