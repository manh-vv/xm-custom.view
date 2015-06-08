using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace xmcustom.view
{
	public class App : Application
	{
		private readonly ContentPage contentPage;
		private readonly StackLayout _layout;
		private readonly PopupLayout pl;
		private readonly Button btn;
		private readonly ListView lv;
		private readonly View myPopupContent;

		public App ()
		{
			// The root page of your application
			MainPage = this.contentPage = new ContentPage {
				Content = this.pl = createPopup()
			};

            this.pl.Content = this._layout = createLayout();
			this._layout.Children.Add (this.btn = createButton ());

            this.lv = createListView();
			this.myPopupContent = createMyPopupContent ();
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

        private PopupLayout createPopup()
        {
            PopupLayout popup = new PopupLayout()
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
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 4,
				BackgroundColor = Color.White.WithLuminosity(0.6),

				Children =  {
					new Label{
						Text = "My popup",
					},
				},
			};

			Button button = new Button {
				Text = "OK",
				BackgroundColor = Color.White.WithSaturation(0.6),
			};

			button.Clicked += (sender, e) => pl.DismissPopup ();

			stackLayout.Children.Add (button);



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
				pl.ShowPopup(this.lv);
				this.btn.IsEnabled = false;
			};

			return button;
		}

		ListView createListView ()
		{
			ListView listView = new ListView {
				BackgroundColor = Color.Lime.WithSaturation(0.2),
				WidthRequest = 100,
				ItemTemplate = new DataTemplate(typeof (TextCell)),
			};

			List<string> listItem = new List<string> (12);
			for (int i = 0; i < listItem.Capacity; i++) {
				listItem.Add ((i + 1).ToString ().PadLeft (2, '0'));
			}

			listView.ItemsSource = listItem;

			listView.ItemTapped += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("Item is tapped");
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

