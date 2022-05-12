using Newtonsoft.Json;
using PomodoroPlatzi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace PomodoroPlatzi.ViewModels
{
    public class PomodoroViewModel : NotificationObject
    {
        protected Timer timer { get; set; }

        public Command StartOrPauseCommand { get; set; }

        public PomodoroViewModel()
        {
            StartOrPauseCommand = new Command(StartOrPauseCommandExecute);
            LoadConfigurations();

            IsRunning = true;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void LoadConfigurations()
        {
            if (Application.Current.Properties.ContainsKey(Literales.PomodoroDuration))
            {
                PomodoroDuration = (int) Application.Current.Properties[Literales.PomodoroDuration];
            }

            if (Application.Current.Properties.ContainsKey(Literales.PomodoroBreakDuration))
            {
                PomodoroBreakDuration = (int)Application.Current.Properties[Literales.PomodoroBreakDuration];
            }

            Duration = PomodoroDuration;
        }

        private void StartOrPauseCommandExecute()
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Elapse = Elapse.Add(TimeSpan.FromSeconds(1));

            if (IsRunning && (Elapse.TotalSeconds == PomodoroDuration * 60))
            {
                IsRunning = false;
                IsBreak = true;

                await SavePomodoro(new Pomodoro()
                {
                    Date = DateTime.Now,
                    Elapse = Elapse
                });

                Elapse = TimeSpan.Zero;
                Duration = PomodoroBreakDuration;
            }

            if (IsBreak && (Elapse.TotalSeconds == PomodoroBreakDuration * 60))
            {
                IsRunning = true;
                IsBreak = false;

                Elapse = TimeSpan.Zero;
                Duration = PomodoroDuration;
            }
        }

        private async Task SavePomodoro(Pomodoro pomodoro)
        {
            var pomodoroHistory = new List<Pomodoro>();
            string json;

            if (Application.Current.Properties.ContainsKey(Literales.PomodoroHistory))
            {
                json = Application.Current.Properties[Literales.PomodoroHistory].ToString();
                pomodoroHistory = JsonConvert.DeserializeObject<List<Pomodoro>>(json);
            }
            
            pomodoroHistory.Add(pomodoro);

            json = JsonConvert.SerializeObject(pomodoroHistory);
            Application.Current.Properties[Literales.PomodoroHistory] = json;

            await Application.Current.SavePropertiesAsync();
        }

        private TimeSpan elapse;

        public TimeSpan Elapse
        {
            get { return elapse; }
            set { 
                elapse = value;
                OnPropertyChanged();
            }
        }

        private int pomodoroDuration;

        public int PomodoroDuration
        {
            get { return pomodoroDuration; }
            set { 
                pomodoroDuration = value;
                OnPropertyChanged();
            }
        }

        private int pomodoroBreakDuration;

        public int PomodoroBreakDuration
        {
            get { return pomodoroBreakDuration; }
            set { 
                pomodoroBreakDuration = value;
                OnPropertyChanged();
            }
        }

        private int duration;

        public int Duration
        {
            get { return duration; }
            set { 
                duration = value * 60;
                OnPropertyChanged();
            }
        }


        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set { 
                isRunning = value;
                OnPropertyChanged();
            }
        }

        private bool isBreak;

        public bool IsBreak
        {
            get { return isBreak; }
            set { 
                isBreak = value;
                OnPropertyChanged();
            }
        }


    }
}
