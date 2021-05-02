using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace theme_tool.UserControl
{
	public class ErrorMessageBox : Form
	{
		private IContainer components;

		private RichTextBox richTextBox1;

		private Button close_button;

		private Panel white_panel;

		private PictureBox pictureBoxIcon;

		public ErrorMessageBox()
		{
			InitializeComponent();
			Bitmap image = new Bitmap(pictureBoxIcon.Width, pictureBoxIcon.Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics.DrawIcon(SystemIcons.Error, 0, 0);
			graphics.Dispose();
			pictureBoxIcon.Image = image;
		}

		private void ok_button_Click(object sender, EventArgs e)
		{
			Hide();
		}

		public void SetMessage(string msg)
		{
			richTextBox1.Text = msg;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(theme_tool.UserControl.ErrorMessageBox));
			richTextBox1 = new System.Windows.Forms.RichTextBox();
			close_button = new System.Windows.Forms.Button();
			white_panel = new System.Windows.Forms.Panel();
			pictureBoxIcon = new System.Windows.Forms.PictureBox();
			white_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxIcon).BeginInit();
			SuspendLayout();
			richTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			richTextBox1.Location = new System.Drawing.Point(72, 22);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.ReadOnly = true;
			richTextBox1.Size = new System.Drawing.Size(411, 179);
			richTextBox1.TabIndex = 0;
			richTextBox1.Text = resources.GetString("richTextBox1.Text");
			close_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			close_button.Location = new System.Drawing.Point(409, 241);
			close_button.Name = "close_button";
			close_button.Size = new System.Drawing.Size(75, 23);
			close_button.TabIndex = 1;
			close_button.Text = "Close";
			close_button.UseVisualStyleBackColor = true;
			close_button.Click += new System.EventHandler(ok_button_Click);
			white_panel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			white_panel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			white_panel.Controls.Add(pictureBoxIcon);
			white_panel.Controls.Add(richTextBox1);
			white_panel.Location = new System.Drawing.Point(1, 1);
			white_panel.Name = "white_panel";
			white_panel.Size = new System.Drawing.Size(497, 224);
			white_panel.TabIndex = 3;
			pictureBoxIcon.Location = new System.Drawing.Point(22, 43);
			pictureBoxIcon.Name = "pictureBoxIcon";
			pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
			pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBoxIcon.TabIndex = 1;
			pictureBoxIcon.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(496, 276);
			base.Controls.Add(close_button);
			base.Controls.Add(white_panel);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(300, 190);
			base.Name = "ErrorMessageBox";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			Text = "Export Result Error";
			white_panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBoxIcon).EndInit();
			ResumeLayout(false);
		}
	}
}
