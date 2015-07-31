using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
		string _internalPath = string.Empty;
		Point _offset = Properties.Settings.Default.DisplayOffSetInPixels;
		
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

			var process = Process.GetProcessesByName(
				Path.GetFileNameWithoutExtension(_internalPath)
				).FirstOrDefault();
			
			if (process != null)
			{
				hWnd = process.MainWindowHandle;
				//string fullPath = process.Modules[0].FileName;
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
						this.TopMost = true;
						this.Location = new Point(rect.X + _offset.X, rect.Y + _offset.Y);

						FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(_internalPath);
						label1.Text = _internalPath + " V. " + versionInfo.ProductVersion;
					}
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_internalPath = Properties.Settings.Default.AppName;
			 
			//if the provided file doesn't exist, see if it exist in the current directory 
			//this is to allow for full path, and local path names in config.
			if (!File.Exists(_internalPath))
			{
				string combinePath = Path.Combine(Environment.CurrentDirectory, _internalPath);
				if (File.Exists(combinePath))
				{
					_internalPath = combinePath;
				}
				else
				{
					MessageBox.Show("File not found : " + _internalPath);
					Application.Exit();
				}
			}

			label1.ForeColor = Properties.Settings.Default.ForeGround;
			label1.BackColor = Properties.Settings.Default.BackGround;

		}
	}
}
