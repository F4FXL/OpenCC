using System;
using Gtk;
using System.Threading;

namespace OpenCC
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			bool notRunning;

			//Use a global Mutex to determine if the program is already running
			using (Mutex mutex = new Mutex(true, "OpenCCMutexAlreadyRunning", out notRunning))
			{
				if(notRunning)//if this was set to true this means program was not runnning! We can start !
				{
					Application.Init();
					MainWindow win = new MainWindow();
					win.Show();
					Application.Run();
				}
			}
		}
	}
}
