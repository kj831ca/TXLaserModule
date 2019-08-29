using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TXLaserModule
{
	public class TXLaserModuleAPI
	{
		private List<TXLaserController> controllerList;

		private static TXLaserModuleAPI _instance;

		private XDocument _doc;

		public List<TXLaserController> GetControllerList
		{
			get
			{
				return this.controllerList;
			}
		}

		private TXLaserModuleAPI()
		{
			this.init();
		}

		private void FillInController(string xmlFileName)
		{
			try
			{
				this._doc = XDocument.Load(xmlFileName);
			}
			catch
			{
				MessageBox.Show(string.Concat("Failed to load XML file: ", xmlFileName));
			}
			if (this._doc == null)
			{
				throw new Exception(string.Concat("Failed to open XML file: ", xmlFileName));
			}
			IEnumerable<XElement> controllerNode = 
				from xml in this._doc.Descendants("TXLaserModule").Elements<XElement>("TXLaserController")
				select xml;
			if (controllerNode != null)
			{
				foreach (XElement element in controllerNode)
				{
					string name = element.Attribute("name").Value;
					string com_port = element.Attribute("comport").Value;
					int baudrate = int.Parse(element.Attribute("baudrate").Value);
					TXLaserController controller = new TXLaserController(com_port, baudrate);
					this.controllerList.Add(controller);
				}
			}
		}

		private void init()
		{
			this.controllerList = new List<TXLaserController>();
			string pathName = AppDomain.CurrentDomain.BaseDirectory;
			string xmlFileName = string.Concat(Path.GetFullPath(Path.Combine(pathName, "..\\")), "Config\\TXLaserConfig.xml");
			this.FillInController(xmlFileName);
		}

		public static TXLaserModuleAPI instance()
		{
			if (TXLaserModuleAPI._instance == null)
			{
				TXLaserModuleAPI._instance = new TXLaserModuleAPI();
			}
			return TXLaserModuleAPI._instance;
		}
	}
}