using System;
using System.Threading;

namespace CSharpLibrary
{
    public class CalculateEngine : BackgroundWorkerBase
    {
        private volatile int _count = 0;
        private long _cps = 0;
        private long _lastUpdate = DateTime.Now.Ticks;
        private readonly Random _random = new Random(1337);
        private readonly Object _lockObject = new object();

        public WorkerState WorkerState
        {
            get
            {
                lock (_lockObject)
                {
                    return new WorkerState(String.Format("worker thread: working count {0}, {1}/s", _count, _cps),
                                           _count, _cps, !Stopping);
                }
            }
        }

        // This method will be called when the thread is started.
        public override void DoWork()
        {
            const long countSize = 1;
            while (!Stopping)
            {
                lock (_lockObject)
                {
                    if (_count++%countSize == 0)
                    {
                        // http://msdn.microsoft.com/en-us/library/system.datetime.ticks.aspx
                        long now = DateTime.Now.Ticks;
                        long ts = now - _lastUpdate;
                        //long cps;
                        if (ts == 0)
                            _cps = 0;
                        else
                            _cps = (countSize*10000000)/ts;
                        _lastUpdate = now;
                        Thread.Sleep(_random.Next(1, 100));
                    }
                }
            }
        }
    }
}