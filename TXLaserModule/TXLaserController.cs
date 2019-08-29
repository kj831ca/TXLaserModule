using BaseModule;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace TXLaserModule
{
	public class TXLaserController
	{
		private SerialPort _serialPort;

		private TXLaserViewFeeder _txLaserViewFeeder;

		private readonly static byte ALL_OFF;

		private readonly static byte LASER_ON;

		private readonly static byte LAMP_LED;

		private readonly static byte PINHOLE_LED;

		public IGUIView GetGUIView
		{
			get
			{
				return this._txLaserViewFeeder;
			}
		}

		public UserControl View
		{
			get
			{
				return this._txLaserViewFeeder.View;
			}
		}

		static TXLaserController()
		{
			TXLaserController.ALL_OFF = 0;
			TXLaserController.LASER_ON = 64;
			TXLaserController.LAMP_LED = 3;
			TXLaserController.PINHOLE_LED = 4;
		}

		public TXLaserController(string comPort, int baudRate)
		{
			try
			{
				this.init(comPort, baudRate);
				this._txLaserViewFeeder = new TXLaserViewFeeder(this);
			}
			catch
			{
				MessageBox.Show(string.Concat("Error Initializing TXLaserModule; Check ", comPort.ToString(), "."));
			}
		}

		public bool AllOff()
		{
			bool flag;
			flag = (this._serialPort.IsOpen ? this.TotalSend(TXLaserController.ALL_OFF) : false);
			return flag;
		}

		public void BoostTo0()
		{
			this.SetLaserMode(TXLaserController.LaserMode.Normal, TXLaserController.LaserBoostLength.Ignored, TXLaserController.FiringFrequency.BoostFire);
		}

		public void BoostTo1000()
		{
			this.SetLaserMode(TXLaserController.LaserMode.Boost, TXLaserController.LaserBoostLength.B1000, TXLaserController.FiringFrequency.BoostFire);
		}

		public void BoostTo250()
		{
			this.SetLaserMode(TXLaserController.LaserMode.Boost, TXLaserController.LaserBoostLength.B250, TXLaserController.FiringFrequency.BoostFire);
		}

		public void BoostTo500()
		{
			this.SetLaserMode(TXLaserController.LaserMode.Boost, TXLaserController.LaserBoostLength.B500, TXLaserController.FiringFrequency.BoostFire);
		}

		public void BoostTo750()
		{
			this.SetLaserMode(TXLaserController.LaserMode.Boost, TXLaserController.LaserBoostLength.B750, TXLaserController.FiringFrequency.BoostFire);
		}

		public void Connect()
		{
			if (!this._serialPort.IsOpen)
			{
				this._serialPort.Open();
			}
		}

		public void Disconnect()
		{
			if (this._serialPort.IsOpen)
			{
				this._serialPort.Close();
			}
		}

		~TXLaserController()
		{
			this.Disconnect();
		}

		private void init(string comPort, int baudRate)
		{
			this._serialPort = new SerialPort()
			{
				PortName = comPort,
				BaudRate = baudRate,
				DataBits = 8,
				StopBits = StopBits.One,
				DtrEnable = true,
				Parity = Parity.None,
				Handshake = Handshake.None,
				ReadTimeout = 0x5dc,
				WriteTimeout = 0x1f4
			};
		}

		public bool LaserOff()
		{
			bool flag;
			bool? nullable = null;
			bool? nullable1 = nullable;
			nullable = null;
			flag = (!this.SetOutputStates(new bool?(false), nullable1, nullable) ? false : true);
			return flag;
		}

		public bool LaserOn()
		{
			bool flag;
			bool? nullable = null;
			bool? nullable1 = nullable;
			nullable = null;
			flag = (!this.SetOutputStates(new bool?(true), nullable1, nullable) ? false : true);
			return flag;
		}

		public bool LEDOff()
		{
			bool flag;
			bool? nullable = null;
			bool? nullable1 = nullable;
			nullable = null;
			flag = (!this.SetOutputStates(nullable1, new bool?(false), nullable) ? false : true);
			return flag;
		}

		public bool LEDOn()
		{
			bool flag;
			bool? nullable = null;
			bool? nullable1 = nullable;
			nullable = null;
			flag = (!this.SetOutputStates(nullable1, new bool?(true), nullable) ? false : true);
			return flag;
		}

		public void ResetAndDisconnectLaserBoard()
		{
			if (this._serialPort.IsOpen)
			{
				try
				{
					this.SetLaserMode(TXLaserController.LaserMode.Reset, TXLaserController.LaserBoostLength.Ignored, TXLaserController.FiringFrequency.CameraFire);
				}
				catch (Exception exception)
				{
					return;
				}
				this.Disconnect();
			}
		}

		public void ResetLaser()
		{
			if (this._serialPort.IsOpen)
			{
				try
				{
					this.SetLaserMode(TXLaserController.LaserMode.Reset, TXLaserController.LaserBoostLength.Ignored, TXLaserController.FiringFrequency.CameraFire);
				}
				catch (Exception exception)
				{
				}
			}
		}

		private bool SendCommand(byte command)
		{
			bool flag;
			if (this._serialPort.IsOpen)
			{
				byte[] buffer = new byte[] { command };
				this._serialPort.Write(buffer, 0, (int)buffer.Length);
				byte[] response = new byte[1];
				this._serialPort.Read(response, 0, 1);
				flag = ((response == null ? true : response[0] != command) ? false : true);
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		public void SetLaserMode(TXLaserController.LaserMode mode, TXLaserController.LaserBoostLength boostLen , TXLaserController.FiringFrequency frequency = 0)
		{
			if ((mode != TXLaserController.LaserMode.Boost ? false : boostLen == TXLaserController.LaserBoostLength.Ignored))
			{
				throw new Exception("Illegal call to SetLaserMode()");
			}
			byte cmdNibble = (byte)(((byte)mode & 3) << 2 | (byte)boostLen & 3);
			byte cmdLowerNibble = (byte)frequency;
			byte[] data = new byte[] { (byte)(cmdNibble << 4 | cmdLowerNibble) };
			try
			{
				if (!this.TotalSend(data[0]))
				{
					this.TotalSend(data[0]);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.ToString());
			}
		}

		public bool SetOutputStates(bool? LaserState = null, bool? PHLedState = null, bool? FrontLEDState = null)
		{
			bool flag;
			byte boardState = 0;
			if (this._serialPort.IsOpen)
			{
				if (LaserState.HasValue)
				{
					boardState = (!LaserState.Value ? (byte)(boardState & (byte)(~TXLaserController.LASER_ON)) : (byte)(boardState | TXLaserController.LASER_ON));
				}
				if (PHLedState.HasValue)
				{
					boardState = (!PHLedState.Value ? (byte)(boardState & (byte)(~TXLaserController.PINHOLE_LED)) : (byte)(boardState | TXLaserController.PINHOLE_LED));
				}
				if (FrontLEDState.HasValue)
				{
					boardState = (!FrontLEDState.Value ? (byte)(boardState & (byte)(~TXLaserController.LAMP_LED)) : (byte)(boardState | TXLaserController.LAMP_LED));
				}
				flag = this.TotalSend(boardState);
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		private bool TotalSend(byte command)
		{
			bool flag;
			int count = 0;
			int i = 0;
			while (true)
			{
				if (i > 9)
				{
					if (count != 10)
					{
						flag = false;
						break;
					}
					else
					{
						count = 0;
						flag = true;
						break;
					}
				}
				else if (!this.SendCommand(command))
				{
					flag = false;
					break;
				}
				else
				{
					count++;
					i++;
				}
			}
			return flag;
		}

		public enum FiringFrequency
		{
			CameraFire,
			BoostFire
		}

		public enum LaserBoostLength
		{
			B250,
			B500,
			B750,
			B1000,
			Ignored
		}

		public enum LaserMode
		{
			Reset,
			Normal,
			VoltageMeasurement,
			Boost
		}
	}
}