using System;
using Xamarin.Forms;
using AudioPlugin.Droid;
using Android.Media;

[assembly: Dependency (typeof (AudioService_Android))]
namespace AudioPlugin.Droid
{
	public class AudioService_Android : IAudio
	{
		private MediaPlayer _mediaPlayer;
		private bool playing = false;

		public AudioService_Android () {
		}

		public void Play(string path)
		{
			path = path.Trim ();
			Uri source;
			if (Uri.TryCreate (path, UriKind.Absolute, out source)
			    && (source.Scheme == Uri.UriSchemeHttp || source.Scheme == Uri.UriSchemeHttps)) {
				var androidUri = Android.Net.Uri.Parse (source.ToString());
				Play (androidUri);
			}

		}

		private void Play (global::Android.Net.Uri source)
		{

			if (_mediaPlayer == null) {
				_mediaPlayer = new MediaPlayer ();
			} else if (!playing){
				
				 playing = true;
				_mediaPlayer.SetAudioStreamType (Android.Media.Stream.Music);
				_mediaPlayer.Prepared += (object sender, EventArgs e) => _mediaPlayer.Start ();
				_mediaPlayer.Completion += (object sender, EventArgs e) => {
					_mediaPlayer.Stop ();
					//_mediaPlayer.Reset ();
					//_mediaPlayer.Release ();
				};
				_mediaPlayer.SetDataSource(Android.App.Application.Context, source); 
				_mediaPlayer.Prepare ();

			}

			
		}

		public void Stop()
		{
			if (playing)
				_mediaPlayer.Stop ();	
		}
	}
}

