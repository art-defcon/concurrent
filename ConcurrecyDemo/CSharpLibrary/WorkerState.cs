namespace CSharpLibrary
{
    public class WorkerState
    {
        public WorkerState(string status, int count, long countPerSec, bool running)
        {
            Status = status;
            Count = count;
            CountPerSec = countPerSec;
            Running = running;
        }
        public string Status { get; private set; }
        public int Count { get; private set; }
        public long CountPerSec { get; private set; }
        public bool Running { get; private set; }
    }
}