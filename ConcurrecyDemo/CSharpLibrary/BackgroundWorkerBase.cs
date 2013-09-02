using System;
using System.Threading;

namespace CSharpLibrary
{
    /// <summary>
    /// Background worker implmentation
    /// </summary>
    public abstract class BackgroundWorkerBase
    {
        private Thread _thread;

        /// <summary>
        /// Start the thread running DoWork
        /// </summary>
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
                // Must always rethrow ThreadAbortExceptions
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