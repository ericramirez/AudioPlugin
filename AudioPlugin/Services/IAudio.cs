using System;

namespace AudioPlugin
{
	public interface IAudio
	{
		void Play (string resource);
		void Stop ();
	}
}

