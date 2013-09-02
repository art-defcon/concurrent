using System;
using System.Timers;
using System.Windows;
using CSharpLibrary;

namespace ConcurrentClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculateEngine _backgroundWorker;
        private Timer _timer;
        public CurrentStateModel _state;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            _state = new CurrentStateModel();
            Running.DataContext = _state;
            Count.DataContext = _state;
            CountPerSec.DataContext = _state;

            _backgroundWorker = new CalculateEngine();
            _backgroundWorker.Run();

            _timer = new Timer(100);
            _timer.Elapsed += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            var workerState = _backgroundWorker.WorkerState;
            _state.Running = workerState.Running;
            _state.Count = workerState.Count;
            _state.CountPerSec = workerState.CountPerSec;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _backgroundWorker.RequestStop();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (_backgroundWorker.WorkerState.Running)
                _backgroundWorker.RequestStop();
            else
                _backgroundWorker.Run();    
        }
    }
}
