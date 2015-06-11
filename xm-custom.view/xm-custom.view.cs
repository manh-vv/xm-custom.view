using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace xmcustom.view
{
	public class App : Application
	{
		MyPage contentPage;

		public App ()
		{

			// The root page of your application
			MainPage = this.contentPage = new MyPage ();

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

