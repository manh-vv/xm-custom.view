using System;
using Xamarin.Forms;

namespace xmcustom.view
{
	public class MyViewCell : ViewCell
	{
		public MyViewCell ()
		{
			Label firstLabel = new Label { 
				HorizontalOptions = LayoutOptions.StartAndExpand,
				HeightRequest = UIConst.DEFAULT_HEIGHT,
				WidthRequest = 150,
				TextColor = Color.Blue,
				BackgroundColor = Color.Olive,
			};

			firstLabel.SetBinding (Label.TextProperty, new Binding ("lbl1"));

			Label secondLabel = new Label { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = UIConst.DEFAULT_HEIGHT,
				TextColor = Color.Blue,
				BackgroundColor = Color.Pink
			};

			secondLabel.SetBinding (Label.TextProperty, new Binding ("lbl2"));

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Children = {
					firstLabel,
					secondLabel
				}
			};
		}
	}
}

