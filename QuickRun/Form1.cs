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
			this.WindowState = FormWindowState.Minimized;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Version.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
			Trayicon.BalloonTipIcon = ToolTipIcon.Info;
			Trayicon.BalloonTipText = "QuickRun is now running in the background";
			Trayicon.BalloonTipTitle = "Welcome Message";
			Trayicon.ShowBalloonTip(500);
			this.Hide();
		}

		private void Exit_onclick(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Run_onclick(object sender, EventArgs e)
		{
			string strCmdText;
			strCmdText = Args.Text;
			if (strCmdText == "Enter Arguments")
			{
				strCmdText = "";
			}
			System.Diagnostics.Process.Start(Command.Text, strCmdText);
			this.WindowState = FormWindowState.Minimized;
			this.Hide();
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
				System.Diagnostics.Process.Start(Command.Text, strCmdText);
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

		private void Version_Click(object sender, EventArgs e)
		{

		}
	}
}