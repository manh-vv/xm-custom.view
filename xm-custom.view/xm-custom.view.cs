using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace xmcustom.view
{
	public class App : Application
	{
		private readonly ContentPage contentPage;
		private readonly StackLayout _layout;
		private readonly MyPopupLayout pl;
		private readonly Button btn;
		private readonly ListView lv;
		private readonly View myPopupContent;

		public App ()
		{

			this.pl = createPopup ();
			this.lv = createListView();
			this.btn = createButton ();
			this._layout = createLayout();
			this.myPopupContent = createMyPopupContent ();

			// The root page of your application
			MainPage = this.contentPage = new ContentPage {
				//Content = this.pl = createPopup(),
				Content = this.myPopupContent,
			};




            // this.pl.Content = this._layout = createLayout();


			//this._layout.Children.Add (this.btn = createButton ());
			// this._layout.Children.Add (this.myPopupContent = createMyPopupContent ());
		}

        private StackLayout createLayout()
        {
            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Gray,
            };

            return stackLayout;
        }

        private MyPopupLayout createPopup()
        {
            MyPopupLayout popup = new MyPopupLayout()
            {
                BackgroundColor = Color.Pink.WithLuminosity(0.4),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            return popup;
        }

		View createMyPopupContent ()
		{
			StackLayout stackLayout = new StackLayout {
				Orientation = StackOrientation.Vertical,
				WidthRequest = 320,
				HeightRequest = 240,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 4,
				BackgroundColor = Color.White.WithLuminosity(0.6),

				Children =  {
					new Label{
						Text = "My popup",
					},
				},
			};

			StackLayout horizontalStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.White.WithLuminosity(0.2),
				//VerticalOptions = LayoutOptions.EndAndExpand,
			};

			Entry entry = new Entry {
				HeightRequest = 38,
				WidthRequest = 120,
				BackgroundColor = Color.Pink,
				Text = "HELLO",
			};
			this.pl.Content = entry;

			Button button = new Button {
				HeightRequest = 38,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "OK",
				BackgroundColor = Color.White.WithSaturation(0.6),
			};

			button.Clicked += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("---- Button OK click show popup");
				pl.ShowPopup (lv, entry, MyPopupLayout.PopupLocation.Bottom, 0, 0);
			};

			horizontalStack.Children.Add (button);
			horizontalStack.Children.Add (entry);

			stackLayout.Children.Add (horizontalStack);

			return stackLayout;
		}

		Button createButton ()
		{
			Button button = new Button {
				BackgroundColor = Color.Blue,
				HeightRequest = 48,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Text = "Show popup"
			};

			button.Clicked += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("---- Button click show popup");
				pl.ShowPopup(this.lv);
			};

			return button;
		}

		ListView createListView ()
		{
			ListView listView = new ListView {
				BackgroundColor = Color.Lime.WithSaturation(0.2),
				WidthRequest = 100,
				HeightRequest = 200,
				VerticalOptions = LayoutOptions.StartAndExpand,
			};

			List<string> listItem = new List<string> (12);
			for (int i = 0; i < listItem.Capacity; i++) {
				listItem.Add ((i + 1).ToString ().PadLeft (2, '0'));
			}

			listView.ItemsSource = listItem;

			listView.ItemTapped += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("---- Item is tapped");
				this.pl.DismissPopup();
				this.btn.IsEnabled = true;
			};

			return listView;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

