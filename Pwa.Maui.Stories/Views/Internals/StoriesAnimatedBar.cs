using System;
using System.Diagnostics;
using Microsoft.Maui;
using Maui.BindableProperty.Generator.Core;

namespace Pwa.Maui.Stories.Views.Internals
{
    public partial class StoriesAnimatedBar : ProgressBar
    {
        private const int StepMilliseconds = 150;
        private const double Maximum = 1; //Progress <= 1
        private double _stepValue;
        private IDispatcherTimer? _dispatcherTimer;
        public bool Started { get; private set; } = false;
        public bool Paused { get; private set; } = false;
        public event EventHandler Completed;

        public StoriesAnimatedBar()
        {
        }

        [AutoBindable] bool _isComplete;
        [AutoBindable(OnChanged = nameof(OnIsWorkedChanging))] bool _isWorked;
        [AutoBindable] double _durationSeconds;

        void Start()
        {
            if(IsComplete || !Started)
            {
                _dispatcherTimer = Dispatcher.CreateTimer();
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(StepMilliseconds);
                _dispatcherTimer.Tick += DispatcherTimerOnTick;
            }

            Started = true;
            Paused = false;
            _dispatcherTimer?.Start();
        }
        private void DispatcherTimerOnTick(object? sender, EventArgs e)
        {
            if(Progress >= Maximum)
            {
                Stop();
                IsComplete = true;
                Completed?.Invoke(this, EventArgs.Empty);
            }
            //it would be nice to put it in MaxSecondsProperty setter,
            //but the order of calling avalonia properties is not defined
            var interval = (DurationSeconds * 1000) / StepMilliseconds;
            Progress += Maximum / interval;
            Debug.WriteLine(Progress);
        }


        public void Pause()
        {
            _dispatcherTimer?.Stop();
            Started = false;
            Paused = true;
        }

        public void Stop()
        {
            _dispatcherTimer?.Stop();
            _dispatcherTimer.Tick -= DispatcherTimerOnTick;
            Started = false;
            Paused = false;
        }

        void OnIsWorkedChanging(bool value)
        {
            if(IsWorked)
            {
                this.Started = false;
                this.Paused = false;
                this.IsComplete = false;
                this.Progress = 0;
                if(!Started)
                    Start();
            }
            else
            {
                Stop();
            }
        }
    }
}