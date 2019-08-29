using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TXLaserModule
{
	public class TXLaserView : UserControl
	{
		private IContainer components = null;

		public Button btn_LaserOff;

		public Button btn_LEDOn;

		public Button btn_LEDOff;

		public Button btn_LaserOn;

		public Button btn_AllOff;

		public Button btn_Boost0;

		public Button btn_Boost250;

		public Button btn_Boost500;

		public Button btn_Boost750;

		public Button btn_Boost1000;

		public Button btn_ResetLaser;

		public TXLaserView()
		{
			this.InitializeComponent();
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
			this.btn_LaserOn = new Button();
			this.btn_LaserOff = new Button();
			this.btn_LEDOn = new Button();
			this.btn_LEDOff = new Button();
			this.btn_AllOff = new Button();
			this.btn_Boost0 = new Button();
			this.btn_Boost250 = new Button();
			this.btn_Boost500 = new Button();
			this.btn_Boost750 = new Button();
			this.btn_Boost1000 = new Button();
			this.btn_ResetLaser = new Button();
			base.SuspendLayout();
			this.btn_LaserOn.Location = new Point(143, 155);
			this.btn_LaserOn.Name = "btn_LaserOn";
			this.btn_LaserOn.Size = new System.Drawing.Size(75, 23);
			this.btn_LaserOn.TabIndex = 0;
			this.btn_LaserOn.Text = "Laser On";
			this.btn_LaserOn.UseVisualStyleBackColor = true;
			this.btn_LaserOff.Location = new Point(0x110, 155);
			this.btn_LaserOff.Name = "btn_LaserOff";
			this.btn_LaserOff.Size = new System.Drawing.Size(75, 23);
			this.btn_LaserOff.TabIndex = 1;
			this.btn_LaserOff.Text = "Laser Off";
			this.btn_LaserOff.UseVisualStyleBackColor = true;
			this.btn_LEDOn.Location = new Point(143, 201);
			this.btn_LEDOn.Name = "btn_LEDOn";
			this.btn_LEDOn.Size = new System.Drawing.Size(75, 23);
			this.btn_LEDOn.TabIndex = 2;
			this.btn_LEDOn.Text = "LED On";
			this.btn_LEDOn.UseVisualStyleBackColor = true;
			this.btn_LEDOff.Location = new Point(0x110, 201);
			this.btn_LEDOff.Name = "btn_LEDOff";
			this.btn_LEDOff.Size = new System.Drawing.Size(75, 23);
			this.btn_LEDOff.TabIndex = 3;
			this.btn_LEDOff.Text = "LED Off";
			this.btn_LEDOff.UseVisualStyleBackColor = true;
			this.btn_AllOff.Location = new Point(205, 253);
			this.btn_AllOff.Name = "btn_AllOff";
			this.btn_AllOff.Size = new System.Drawing.Size(75, 23);
			this.btn_AllOff.TabIndex = 4;
			this.btn_AllOff.Text = "All Off";
			this.btn_AllOff.UseVisualStyleBackColor = true;
			this.btn_Boost0.Location = new Point(48, 56);
			this.btn_Boost0.Name = "btn_Boost0";
			this.btn_Boost0.Size = new System.Drawing.Size(75, 23);
			this.btn_Boost0.TabIndex = 5;
			this.btn_Boost0.Text = "Boost 0";
			this.btn_Boost0.UseVisualStyleBackColor = true;
			this.btn_Boost250.Location = new Point(129, 56);
			this.btn_Boost250.Name = "btn_Boost250";
			this.btn_Boost250.Size = new System.Drawing.Size(75, 23);
			this.btn_Boost250.TabIndex = 6;
			this.btn_Boost250.Text = "Boost 250";
			this.btn_Boost250.UseVisualStyleBackColor = true;
			this.btn_Boost500.Location = new Point(210, 56);
			this.btn_Boost500.Name = "btn_Boost500";
			this.btn_Boost500.Size = new System.Drawing.Size(75, 23);
			this.btn_Boost500.TabIndex = 7;
			this.btn_Boost500.Text = "Boost 500";
			this.btn_Boost500.UseVisualStyleBackColor = true;
			this.btn_Boost750.Location = new Point(0x123, 56);
			this.btn_Boost750.Name = "btn_Boost750";
			this.btn_Boost750.Size = new System.Drawing.Size(75, 23);
			this.btn_Boost750.TabIndex = 8;
			this.btn_Boost750.Text = "Boost 750";
			this.btn_Boost750.UseVisualStyleBackColor = true;
			this.btn_Boost1000.Location = new Point(0x174, 56);
			this.btn_Boost1000.Name = "btn_Boost1000";
			this.btn_Boost1000.Size = new System.Drawing.Size(75, 23);
			this.btn_Boost1000.TabIndex = 9;
			this.btn_Boost1000.Text = "Boost 1000";
			this.btn_Boost1000.UseVisualStyleBackColor = true;
			this.btn_ResetLaser.Location = new Point(210, 109);
			this.btn_ResetLaser.Name = "btn_ResetLaser";
			this.btn_ResetLaser.Size = new System.Drawing.Size(75, 23);
			this.btn_ResetLaser.TabIndex = 10;
			this.btn_ResetLaser.Text = "Reset Laser";
			this.btn_ResetLaser.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.btn_ResetLaser);
			base.Controls.Add(this.btn_Boost1000);
			base.Controls.Add(this.btn_Boost750);
			base.Controls.Add(this.btn_Boost500);
			base.Controls.Add(this.btn_Boost250);
			base.Controls.Add(this.btn_Boost0);
			base.Controls.Add(this.btn_AllOff);
			base.Controls.Add(this.btn_LEDOff);
			base.Controls.Add(this.btn_LEDOn);
			base.Controls.Add(this.btn_LaserOff);
			base.Controls.Add(this.btn_LaserOn);
			base.Name = "TXLaserView";
			base.Size = new System.Drawing.Size(0x1f6, 0x165);
			base.ResumeLayout(false);
		}
	}
}