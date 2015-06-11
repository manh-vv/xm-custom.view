using System;

using Xamarin.Forms;

namespace xmcustom.view
{
	public class MyPage : ContentPage
	{
		public MyPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" },
					new MyView{
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand
					}
				}
			};
		}
	}
}


