using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace daVinci.Resources
{
    public class Win32Helper
    {
        #region GetWindowRect Helper

        private static double? getDpiYScale = null;
        private static double? getDpiXScale = null;

        public static double GetDpiXScale
        {
            get
            {
                if (!getDpiXScale.HasValue)
                {
                    var g = System.Drawing.Graphics.FromHwnd(IntPtr.Zero);
                    IntPtr desktop = g.GetHdc();
                    //   LOGPIXELSY = 90   
                    int Ydpi = Win32Helper.GetDeviceCaps(desktop, 90);

                    getDpiXScale = Ydpi / 96.0;
                    getDpiYScale = Ydpi / 96.0;

                    g.Dispose();
                }

                return getDpiXScale.Value;
            }
        }

        public static double GetDpiYScale
        {
            get
            {
                return GetDpiXScale;
            }
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        public static System.Windows.Rect GetParentWindowSize(object wrapper, IntPtr parentHwnd)
        {
            RECT rct;

            if (GetWindowRect(new HandleRef(wrapper, parentHwnd), out rct))
            {
                return new System.Windows.Rect(rct.Left, rct.Top, rct.Right - rct.Left, rct.Bottom - rct.Top);
            }

            return System.Windows.Rect.Empty;
        }


        private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hwnd, ref placement);
            return placement;
        }

        public static bool IsMaximized(IntPtr hwnd)
        {
            try
            {
                if (GetPlacement(hwnd).showCmd == ShowWindowCommands.Maximized)
                    return true;
            }
            catch
            {
            }
            return false;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public ShowWindowCommands showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        private enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            Minimized = 2,
            Maximized = 3,
        }
        #endregion
    }
}
