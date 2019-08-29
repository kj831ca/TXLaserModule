using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TXLaserModule
{
	public class TXLaserStartForm : Form
	{
		private TXLaserModuleAPI _txLaserModuleAPI;

		private TXLaserController _txLaserController;

		private IContainer components = null;

		private Panel panel1;

		public TXLaserStartForm()
		{
			this.InitializeComponent();
			this._txLaserModuleAPI = TXLaserModuleAPI.instance();
			this._txLaserController = this._txLaserModuleAPI.GetControllerList[0];
			this._txLaserController.Connect();
			this.panel1.Controls.Add(this._txLaserController.View);
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.panel1 = new Panel();
			base.SuspendLayout();
			this.panel1.Location = new Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(0x18e, 0x1aa);
			this.panel1.TabIndex = 0;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(0x1a6, 0x1c2);
			base.Controls.Add(this.panel1);
			base.Name = "TXLaserStartForm";
			this.Text = "Form1";
			base.ResumeLayout(false);
		}
	}
}