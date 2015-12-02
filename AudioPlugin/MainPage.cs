using System;
using Xamarin.Forms;

namespace AudioPlugin
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			var play = new Button {
				Text ="Go play me",
				BackgroundColor = Color.Blue

			};

			play.Clicked += (object sender, EventArgs e) => {
				DependencyService.Get<IAudio>().Play("http://users.skynet.be/fa046054/home/P22/track39.mp3");
			};

			Content = play;
		}
	}
}

