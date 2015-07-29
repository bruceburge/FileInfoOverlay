using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInfoOverlay
{
	public partial class Form1 : Form
	{
		//string windowTitle = Properties.Settings.Default.AppTitle;
		string appName = Properties.Settings.Default.AppName;

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int X;
			public int Y;
			public int Width;
			public int Height;
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		public Form1()
		{

			InitializeComponent();
		}

		private void tmrPaintCheck_Tick(object sender, EventArgs e)
		{
			IntPtr hWnd = IntPtr.Zero; //FindWindow(null, "MainWindow");

			var process = Process.GetProcessesByName(appName.Replace(".exe", "")).FirstOrDefault();
			if (process != null)
			{
				hWnd = process.MainWindowHandle;
				string fullPath = process.Modules[0].FileName;
				//string ram = process.WorkingSet64.ToString();
		
				RECT rect;
				if (hWnd.ToInt32() == 0)
				{
					label1.Text = "";
				}
				else
				{
					GetWindowRect(hWnd, out rect);
					if (rect.X == -32000)
					{
						// the game is minimized
						this.WindowState = FormWindowState.Minimized;
						label1.Text = "";
					}
					else
					{
						this.WindowState = FormWindowState.Normal;
						this.Location = new Point(rect.X + 10, rect.Y + 10);

						FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(appName);
						label1.Text = fullPath + " V. " + versionInfo.ProductVersion;
					}
				}
			}
		}
	}
}
