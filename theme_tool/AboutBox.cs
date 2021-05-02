using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using theme_tool.Properties;

namespace theme_tool
{
	internal class AboutBox : Form
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel;

		private PictureBox logoPictureBox;

		private Label labelCopyright;

		private Label labelCompanyName;

		private TextBox textBoxDescription;

		private Button okButton;

		private Label labelProductName;

		private Label labelVersion;

		public string AssemblyTitle
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (customAttributes.Length > 0)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
					if (assemblyTitleAttribute.Title != "")
					{
						return assemblyTitleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)customAttributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)customAttributes[0]).Company;
			}
		}

		public AboutBox()
		{
			InitializeComponent();
			Text = string.Format("About {0}", AssemblyTitle);
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = string.Format("  Version {0}", AssemblyVersion);
			labelCopyright.Text = AssemblyCopyright;
			labelCompanyName.Text = AssemblyCompany;
			textBoxDescription.Text = AssemblyDescription;
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
			tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			logoPictureBox = new System.Windows.Forms.PictureBox();
			labelProductName = new System.Windows.Forms.Label();
			labelVersion = new System.Windows.Forms.Label();
			labelCopyright = new System.Windows.Forms.Label();
			labelCompanyName = new System.Windows.Forms.Label();
			textBoxDescription = new System.Windows.Forms.TextBox();
			okButton = new System.Windows.Forms.Button();
			tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
			SuspendLayout();
			tableLayoutPanel.ColumnCount = 4;
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54f));
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16f));
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208f));
			tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
			tableLayoutPanel.Controls.Add(labelProductName, 2, 0);
			tableLayoutPanel.Controls.Add(labelVersion, 2, 1);
			tableLayoutPanel.Controls.Add(labelCopyright, 0, 4);
			tableLayoutPanel.Controls.Add(labelCompanyName, 0, 3);
			tableLayoutPanel.Controls.Add(textBoxDescription, 0, 5);
			tableLayoutPanel.Controls.Add(okButton, 0, 6);
			tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel.Location = new System.Drawing.Point(9, 8);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 7;
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80f));
			tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			tableLayoutPanel.Size = new System.Drawing.Size(476, 192);
			tableLayoutPanel.TabIndex = 0;
			logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			logoPictureBox.Image = theme_tool.Properties.Resources.CustomThemeEditer_48x48;
			logoPictureBox.Location = new System.Drawing.Point(3, 3);
			logoPictureBox.Name = "logoPictureBox";
			tableLayoutPanel.SetRowSpan(logoPictureBox, 2);
			logoPictureBox.Size = new System.Drawing.Size(48, 48);
			logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			logoPictureBox.TabIndex = 12;
			logoPictureBox.TabStop = false;
			tableLayoutPanel.SetColumnSpan(labelProductName, 2);
			labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			labelProductName.Font = new System.Drawing.Font("MS UI Gothic", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 128);
			labelProductName.Location = new System.Drawing.Point(76, 0);
			labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			labelProductName.MaximumSize = new System.Drawing.Size(0, 16);
			labelProductName.Name = "labelProductName";
			labelProductName.Size = new System.Drawing.Size(397, 16);
			labelProductName.TabIndex = 19;
			labelProductName.Text = "製品名";
			labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			tableLayoutPanel.SetColumnSpan(labelVersion, 2);
			labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			labelVersion.Location = new System.Drawing.Point(76, 25);
			labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			labelVersion.MaximumSize = new System.Drawing.Size(0, 16);
			labelVersion.Name = "labelVersion";
			labelVersion.Size = new System.Drawing.Size(397, 16);
			labelVersion.TabIndex = 0;
			labelVersion.Text = "バージョン";
			labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			tableLayoutPanel.SetColumnSpan(labelCopyright, 4);
			labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			labelCopyright.Font = new System.Drawing.Font("MS UI Gothic", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
			labelCopyright.Location = new System.Drawing.Point(6, 74);
			labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			labelCopyright.MaximumSize = new System.Drawing.Size(0, 16);
			labelCopyright.Name = "labelCopyright";
			labelCopyright.Size = new System.Drawing.Size(467, 12);
			labelCopyright.TabIndex = 21;
			labelCopyright.Text = "著作権";
			tableLayoutPanel.SetColumnSpan(labelCompanyName, 4);
			labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
			labelCompanyName.Font = new System.Drawing.Font("MS UI Gothic", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 128);
			labelCompanyName.Location = new System.Drawing.Point(6, 62);
			labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			labelCompanyName.MaximumSize = new System.Drawing.Size(0, 16);
			labelCompanyName.Name = "labelCompanyName";
			labelCompanyName.Size = new System.Drawing.Size(467, 12);
			labelCompanyName.TabIndex = 22;
			labelCompanyName.Text = "会社名";
			labelCompanyName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			tableLayoutPanel.SetColumnSpan(textBoxDescription, 4);
			textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			textBoxDescription.Location = new System.Drawing.Point(6, 89);
			textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			textBoxDescription.Multiline = true;
			textBoxDescription.Name = "textBoxDescription";
			textBoxDescription.ReadOnly = true;
			textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			textBoxDescription.Size = new System.Drawing.Size(467, 74);
			textBoxDescription.TabIndex = 23;
			textBoxDescription.TabStop = false;
			textBoxDescription.Text = "説明";
			okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
			tableLayoutPanel.SetColumnSpan(okButton, 4);
			okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			okButton.Location = new System.Drawing.Point(200, 169);
			okButton.Name = "okButton";
			okButton.Size = new System.Drawing.Size(75, 20);
			okButton.TabIndex = 24;
			okButton.Text = "Close";
			base.AcceptButton = okButton;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(494, 208);
			base.Controls.Add(tableLayoutPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AboutBox";
			base.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "AboutBox";
			tableLayoutPanel.ResumeLayout(false);
			tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
			ResumeLayout(false);
		}
	}
}
