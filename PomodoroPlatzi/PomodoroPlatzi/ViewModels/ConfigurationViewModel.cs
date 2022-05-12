using PomodoroPlatzi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace PomodoroPlatzi.ViewModels
{
    public class ConfigurationViewModel : NotificationObject
    {
        public Command SaveCommand { get; set; }

        public ConfigurationViewModel()
        {
            LoadPomodoroDurations();
            LoadBreakDurations();
            LoadPomodoroSaved();

            SaveCommand = new Command(OnSaveCommandExecute);
        }

        private void LoadPomodoroDurations()
        {
            PomodoroDurations = new ObservableCollection<int>();
            PomodoroDurations.Add(1);
            PomodoroDurations.Add(5);
            PomodoroDurations.Add(10);
            PomodoroDurations.Add(25);
        }

        private void LoadBreakDurations()
        {
            PomodoroBreakDurations = new ObservableCollection<int>();
            PomodoroBreakDurations.Add(1);
            PomodoroBreakDurations.Add(2);
            PomodoroBreakDurations.Add(3);
            PomodoroBreakDurations.Add(5);
        }

        private void LoadPomodoroSaved()
        {
            if (Application.Current.Properties.ContainsKey(Literales.PomodoroDuration))
            {
                PomodoroDurationSelect = (int)Application.Current.Properties[Literales.PomodoroDuration];
            }

            if (Application.Current.Properties.ContainsKey(Literales.PomodoroBreakDuration))
            {
                PomodoroBreakDurationSelect = (int)Application.Current.Properties[Literales.PomodoroBreakDuration];
            }

        }

        private async void OnSaveCommandExecute()
        {
            Application.Current.Properties[Literales.PomodoroDuration] = PomodoroDurationSelect;
            Application.Current.Properties[Literales.PomodoroBreakDuration] = PomodoroBreakDurationSelect;

            await Application.Current.SavePropertiesAsync();
        }

        public ObservableCollection<int> PomodoroDurations { get; set; }
        public ObservableCollection<int> PomodoroBreakDurations { get; set; }

        private int pomodoroDurationSelect;

        public int PomodoroDurationSelect
        {
            get { return pomodoroDurationSelect; }
            set { 
                pomodoroDurationSelect = value;
                OnPropertyChanged();
            }
        }

        private int pomodoroBreakDurationSelect;

        public int PomodoroBreakDurationSelect
        {
            get { return pomodoroBreakDurationSelect; }
            set { 
                pomodoroBreakDurationSelect = value; 
                OnPropertyChanged(); 
            }
        }


    }
}
