using System;
using System.Threading;

namespace CSharpLibrary
{
    public abstract class BackgroundWorkerBase
    {
        private Thread _thread;

        public void Run()
        {
            try
            {
                Stopping = false;
                Threadhelper.DisplayTimerProperties();
                _thread = new Thread(DoWork);
                _thread.Start();
            }
            catch (ThreadAbortException t)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        internal bool Stopping { get; set; }

        public void RequestStop()
        {
            Stopping = true;
        }

        public abstract void DoWork();
    }
}