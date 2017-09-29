﻿using System;
using System.Runtime.InteropServices;

namespace SIClass
{
    public class SendGameInput
    {
        #region Imports

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern short VkKeyScan(char ch);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        #endregion

        public static uint Click()
        {
            INPUT structure = new INPUT();
            structure.mi.dx = 0;
            structure.mi.dy = 0;
            structure.mi.mouseData = 0;
            structure.mi.dwFlags = 2;
            INPUT input2 = structure;
            input2.mi.dwFlags = 4;
            INPUT[] pInputs = new INPUT[] { structure, input2 };
            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Z()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.Z);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.Z);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint Q()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.Q);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.Q);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint W()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.W);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.W);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint E()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.E);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.E);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint R()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.R);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.R);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint T()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.T);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.T);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static uint G()
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.G);
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = VkKeyScan((char)System.Windows.Forms.Keys.G);
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            return SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static void SendKeyAsInput(System.Windows.Forms.Keys key)
        {
            INPUT structure = new INPUT();
            structure.type = (int)InputType.INPUT_KEYBOARD;
            structure.ki.wVk = (short)key;
            structure.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            structure.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT input2 = new INPUT();
            input2.type = (int)InputType.INPUT_KEYBOARD;
            input2.ki.wVk = (short)key;
            input2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            input2.ki.dwExtraInfo = GetMessageExtraInfo();

            INPUT[] pInputs = new INPUT[] { structure, input2 };

            SendInput(2, pInputs, Marshal.SizeOf(structure));
        }

        public static void SendKeyAsInput(System.Windows.Forms.Keys key, int HoldTime)
        {
            INPUT INPUT1 = new INPUT();
            INPUT1.type = (int)InputType.INPUT_KEYBOARD;
            INPUT1.ki.wVk = (short)key;
            INPUT1.ki.dwFlags = (int)KEYEVENTF.KEYDOWN;
            INPUT1.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, new INPUT[] { INPUT1 }, Marshal.SizeOf(INPUT1));

            WaitForSingleObject((IntPtr)0xACEFDB, (uint)HoldTime);

            INPUT INPUT2 = new INPUT();
            INPUT2.type = (int)InputType.INPUT_KEYBOARD;
            INPUT2.ki.wVk = (short)key;
            INPUT2.mi.dwFlags = (int)KEYEVENTF.KEYUP;
            INPUT2.ki.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, new INPUT[] { INPUT2 }, Marshal.SizeOf(INPUT2));

        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public int type;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [Flags]
        public enum InputType
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2
        }

        [Flags]
        public enum MOUSEEVENTF
        {
            MOVE = 0x0001, /* mouse move */
            LEFTDOWN = 0x0002, /* left button down */
            LEFTUP = 0x0004, /* left button up */
            RIGHTDOWN = 0x0008, /* right button down */
            RIGHTUP = 0x0010, /* right button up */
            MIDDLEDOWN = 0x0020, /* middle button down */
            MIDDLEUP = 0x0040, /* middle button up */
            XDOWN = 0x0080, /* x button down */
            XUP = 0x0100, /* x button down */
            WHEEL = 0x0800, /* wheel button rolled */
            MOVE_NOCOALESCE = 0x2000, /* do not coalesce mouse moves */
            VIRTUALDESK = 0x4000, /* map to entire virtual desktop */
            ABSOLUTE = 0x8000 /* absolute move */
        }

        [Flags]
        public enum KEYEVENTF
        {
            KEYDOWN = 0,
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008,
        }
    }
}
