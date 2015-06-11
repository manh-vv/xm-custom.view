using System;

using Xamarin.Forms;

namespace xmcustom.view
{
	public class MyView : ContentView
	{
		MyViewCell mvc;
		View _view;
		ListView _lv;
		public MyView ()
		{
			Content = new StackLayout {
				BackgroundColor = UIConst.C_BG_CONTROL,
				Children = {
					(_view = createLable()),
					(_lv = createListView())
				}
			};
		}

		View createLable ()
		{
			/*
			(new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = UIConst.DEFAULT_HEIGHT,
				Text = "My Label",
				TextColor = Color.Blue
			})
			*/
			mvc = new MyViewCell ();

			return mvc.View;
		}

		ListView createListView ()
		{
			ListView lv = new ListView { 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = UIConst.DEFAULT_HEIGHT,
				ItemTemplate = new DataTemplate(typeof (MyViewCell)),
			};

			// add data
			MyModel[] myModels = new MyModel[50];
			for (int i = 0; i < myModels.Length; i++) {
				myModels [i] = new MyModel ("lbl1 --- " + i, "lbl2 --- " + i);
			}

			lv.ItemsSource = myModels;

			lv.ItemTapped += (sender, e) => {
				MyModel model = (MyModel) e.Item;

				mvc.BindingContext = model;

				lv.SelectedItem = null;
			};

			return lv;
		}
	}
}


