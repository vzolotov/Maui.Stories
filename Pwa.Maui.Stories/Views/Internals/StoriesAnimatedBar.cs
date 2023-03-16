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
        private object _locker = new object();
        private double _interval = 0;

        public bool Started { get; private set; } = false;
        public bool Paused { get; private set; } = false;
        public event EventHandler Completed;

        public StoriesAnimatedBar()
        {
        }

        [AutoBindable] bool _isComplete;
        [AutoBindable] double _durationSeconds;

        public static readonly BindableProperty IsWorkedProperty = BindableProperty.Create(
                                                                    nameof(IsWorked),
                                                                    typeof(bool),
                                                                    typeof(StoriesAnimatedBar),
                                                                    defaultBindingMode: BindingMode.TwoWay,
                                                                    defaultValue: false,
                                                                    propertyChanged: OnIsWorkedChanging);

        public bool IsWorked
        {
            get => (bool)GetValue(IsWorkedProperty);
            set => SetValue(IsWorkedProperty, value);
        }

        void Start()
        {
            _interval = Maximum / ((DurationSeconds * 1000) / StepMilliseconds);
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
            lock(_locker)
            {
                if(Progress >= Maximum && !IsComplete)
                {
                    IsWorked = false;
                    IsComplete = true;
                    Completed?.Invoke(this, EventArgs.Empty);
                }

                Progress += _interval;
            }
        }


        public void Pause()
        {
            _dispatcherTimer.Tick -= DispatcherTimerOnTick;
            _dispatcherTimer?.Stop();
            Started = false;
            Paused = true;
        }

        public void Stop()
        {
            _dispatcherTimer.Tick -= DispatcherTimerOnTick;
            _dispatcherTimer.Stop();
            Started = false;
            Paused = false;
        }

        static void OnIsWorkedChanging(Microsoft.Maui.Controls.BindableObject bindable, object oldValue, object newValue)
        {
            if(bindable is StoriesAnimatedBar bar)
            {
                if(bar.IsWorked)
                {
                    bar.Started = false;
                    if(!bar.Paused)
                    {
                        bar.Progress = 0;
                    }
                    bar.Paused = false;
                    bar.IsComplete = false;
                    if(!bar.Started)
                        bar.Start();
                }
                else
                {
                    bar.Stop();
                }
            }
        }
    }
}