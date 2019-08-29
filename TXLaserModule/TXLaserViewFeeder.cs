using BaseModule;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TXLaserModule
{
	public class TXLaserViewFeeder : IGUIView
	{
		private TXLaserController _txLaserController;

		private TXLaserView _txLaserView;

		public int SecurityLevel
		{
			get;
			set;
		}

		public UserControl View
		{
			get
			{
				return this._txLaserView;
			}
		}

		public TXLaserViewFeeder(TXLaserController controller)
		{
			this._txLaserController = controller;
			this._txLaserView = new TXLaserView();
			this.init();
			this.subscribeToView();
			this.SetButtonState(false);
		}

		UserControl BaseModule.IGUIView.View()
		{
			return this._txLaserView;
		}

		private void Btn_AllOff_Click(object sender, EventArgs e)
		{
			if (!this._txLaserController.AllOff())
			{
				MessageBox.Show("All Off Fail");
			}
		}

		private void Btn_Boost0_Click(object sender, EventArgs e)
		{
			this._txLaserController.BoostTo0();
		}

		private void Btn_Boost1000_Click(object sender, EventArgs e)
		{
			this._txLaserController.BoostTo1000();
		}

		private void Btn_Boost250_Click(object sender, EventArgs e)
		{
			this._txLaserController.BoostTo250();
		}

		private void Btn_Boost500_Click(object sender, EventArgs e)
		{
			this._txLaserController.BoostTo500();
		}

		private void Btn_Boost750_Click(object sender, EventArgs e)
		{
			this._txLaserController.BoostTo750();
		}

		private void Btn_LaserOff_Click(object sender, EventArgs e)
		{
			if (!this._txLaserController.LaserOff())
			{
				MessageBox.Show("Laser Off Fail");
			}
		}

		private void Btn_LaserOn_Click(object sender, EventArgs e)
		{
			if (!this._txLaserController.LaserOn())
			{
				MessageBox.Show("Laser On Fail");
			}
		}

		private void Btn_LEDOff_Click(object sender, EventArgs e)
		{
			if (!this._txLaserController.LEDOff())
			{
				MessageBox.Show("LED Off Fail");
			}
		}

		private void Btn_LEDOn_Click(object sender, EventArgs e)
		{
			if (!this._txLaserController.LEDOn())
			{
				MessageBox.Show("LED On Fail");
			}
		}

		private void Btn_ResetLaser_Click(object sender, EventArgs e)
		{
			this._txLaserController.ResetLaser();
		}

		private void buttonState(Button button, bool state)
		{
			if (!button.InvokeRequired)
			{
				button.Enabled = state;
			}
			else
			{
				this._txLaserView.Invoke(new TXLaserViewFeeder.ButtonState(this.buttonState), new object[] { button, state });
			}
		}

		public void CloseView()
		{
		}

		private void init()
		{
		}

		public void Refresh()
		{
		}

		private void SetButtonState(bool state)
		{
		}

		private void subscribeToView()
		{
			this._txLaserView.btn_LaserOn.Click += new EventHandler(this.Btn_LaserOn_Click);
			this._txLaserView.btn_LaserOff.Click += new EventHandler(this.Btn_LaserOff_Click);
			this._txLaserView.btn_LEDOn.Click += new EventHandler(this.Btn_LEDOn_Click);
			this._txLaserView.btn_LEDOff.Click += new EventHandler(this.Btn_LEDOff_Click);
			this._txLaserView.btn_AllOff.Click += new EventHandler(this.Btn_AllOff_Click);
			this._txLaserView.btn_Boost0.Click += new EventHandler(this.Btn_Boost0_Click);
			this._txLaserView.btn_Boost250.Click += new EventHandler(this.Btn_Boost250_Click);
			this._txLaserView.btn_Boost500.Click += new EventHandler(this.Btn_Boost500_Click);
			this._txLaserView.btn_Boost750.Click += new EventHandler(this.Btn_Boost750_Click);
			this._txLaserView.btn_Boost1000.Click += new EventHandler(this.Btn_Boost1000_Click);
			this._txLaserView.btn_ResetLaser.Click += new EventHandler(this.Btn_ResetLaser_Click);
		}

		private delegate void ButtonState(Button button, bool state);
	}
}