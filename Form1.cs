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
	public partial class FileInfoOverlay : Form
	{
		string _internalPath = string.Empty;
		Process _watchedProcess = null;
		Point _offset = Properties.Settings.Default.DisplayOffSetInPixels;

		const int WM_COMMAND = 0x111;
		const int MIN_ALL = 419;
		const int MIN_ALL_UNDO = 416;

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int X;
			public int Y;
			public int Width;
			public int Height;
		}

		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
		[DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true)]
		static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		public FileInfoOverlay()
		{
			Visible = false;
			InitializeComponent();
		}

		private void tmrPaintCheck_Tick(object sender, EventArgs e)
		{
			IntPtr hWnd = IntPtr.Zero; //FindWindow(null, "MainWindow");

			if (String.IsNullOrEmpty(_internalPath))
			{
				GetPathToExe();
			}

			_watchedProcess = Process.GetProcessesByName(
			   Path.GetFileNameWithoutExtension(_internalPath)
			   ).FirstOrDefault();

			if (_watchedProcess != null)
			{
				hWnd = _watchedProcess.MainWindowHandle;
				//string fullPath = process.Modules[0].FileName;
				//string ram = process.WorkingSet64.ToString();

				RECT rect;
				if (hWnd.ToInt32() == 0)
				{
					label1.Text = "";
					Visible = false;
				}
				else
				{
					Visible = true;
					GetWindowRect(hWnd, out rect);
					if (rect.X == -32000)
					{
						// the Window is minimized
						this.WindowState = FormWindowState.Minimized;
						label1.Text = "";
					}
					else
					{
						this.WindowState = FormWindowState.Normal;
						this.TopMost = true;
						this.Location = new Point(rect.X + _offset.X, rect.Y + _offset.Y);

						FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(_internalPath);
						label1.Text = _internalPath + " V. " + versionInfo.ProductVersion + " ram: " + _watchedProcess.WorkingSet64 / 1048576 + " mb";
					}
				}
			}
			else
			{
				Visible = false;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Visible = false;
			GetPathToExe();

			label1.ForeColor = Properties.Settings.Default.ForeGround;
			label1.BackColor = Properties.Settings.Default.BackGround;

		}

		private void GetPathToExe()
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
					try
					{
						_watchedProcess = Process.GetProcessesByName(
						Path.GetFileNameWithoutExtension(_internalPath)
						).FirstOrDefault();
					}
					catch (NullReferenceException)
					{
						_internalPath = string.Empty;
						return;
					}

					if (_watchedProcess != null)
					{
						_internalPath = _watchedProcess.MainModule.FileName;
					}
					else
					{
						_internalPath = string.Empty;
						//MessageBox.Show("File not found : " + _internalPath);
						//Application.Exit();
					}
				}
			}
		}

		private void btnKill_Click(object sender, EventArgs e)
		{
			if (_watchedProcess != null)
			{
				Visible = false;
				_watchedProcess.Kill();
				//tmrPaintCheck.Stop();
				//Environment.Exit(0);
			}
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			IntPtr lHwnd = FindWindow("Shell_TrayWnd", null);
			SendMessage(lHwnd, WM_COMMAND, (IntPtr)MIN_ALL, IntPtr.Zero);
		}
	}
}
