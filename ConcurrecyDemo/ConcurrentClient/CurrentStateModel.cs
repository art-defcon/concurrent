using System.ComponentModel;
using ConcurrentClient.Annotations;

namespace ConcurrentClient
{
    /// <summary>
    /// This class implements <see cref="INotifyPropertyChanged"/> to let the View subscribe to bound data
    /// </summary>
    public class CurrentStateModel : INotifyPropertyChanged
    {
        private bool _running;
        private long _cps;
        private long _count;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Running
        {
            get { return _running; }
            set
            {
                _running = value;
                OnPropertyChanged("Running");
            }
        }

        public long Count
        {
            get { return _count; }
            set
            {
                if(_count == value)
                    return;
                
                _count = value;
                OnPropertyChanged("Count");
            }
        }

        public long CountPerSec
        {
            get { return _cps; }
            set
            {
                if (_cps == value)
                    return;

                _cps = value;
                OnPropertyChanged("CountPerSec");
            }
        }
    }
}