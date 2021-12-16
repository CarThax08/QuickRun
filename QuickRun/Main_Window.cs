﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace QuickRun
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Version.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
			Trayicon.BalloonTipIcon = ToolTipIcon.Info;
			Trayicon.BalloonTipText = "Welome to quick run";
			Trayicon.BalloonTipTitle = "QuickRun " + Assembly.GetEntryAssembly().GetName().Version.ToString(); ;
			Trayicon.ShowBalloonTip(500);
		}

		private void Exit_onclick(object sender, EventArgs e)
		{
			Exit_Warning f2 = new Exit_Warning();
			f2.ShowDialog();
		}

		private void Run_onclick(object sender, EventArgs e)
		{
			string strCmdText;
			strCmdText = Args.Text;
			if (strCmdText == "Enter Arguments")
			{
				strCmdText = "";
			}
			try
			{
				System.Diagnostics.Process.Start(Command.Text, strCmdText);
				this.WindowState = FormWindowState.Minimized;
				Command.Text = "Enter Command";
				Args.Text = "Enter Arguments (Optional)";
				this.Hide();
			}
			catch (Exception)
			{
				Error f3 = new Error();
				f3.ShowDialog();
			}

		}
		private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Return)

			{

				string strCmdText;
				strCmdText = Args.Text;
				if (strCmdText == "Enter Arguments (Optional)")
				{
					strCmdText = "";
				}
				try
				{
					System.Diagnostics.Process.Start(Command.Text, strCmdText);
					this.WindowState = FormWindowState.Minimized;
					Command.Text = "Enter Command";
					Args.Text = "Enter Arguments (Optional)";
					this.Hide();
				}
				catch (Exception)
				{
					Error f3 = new Error();
					f3.ShowDialog();
				}
				this.WindowState = FormWindowState.Minimized;
				this.Hide();
			}
		}

		private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void HideButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			this.Hide();
		}

		private void cmd_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("cmd", "");
		}
		private void explorer_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("explorer", "");
		}

		private void about_Click(object sender, EventArgs e)
		{
			Info info = new Info();
			info.ShowDialog();
		}
	}
}
