using System;
using Xamarin.Forms;

namespace xmcustom.view
{
	public class UIConst
	{

		public static double DEFAULT_HEIGHT = Device.OnPlatform<double>(60, 40, 40);

		public static Color C_BG_CONTROL = Color.White;
		public static Color C_LIGHT_GRAY = Color.FromHex("#DDDDDD");

		public UIConst () {}
	}
}

