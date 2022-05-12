using Newtonsoft.Json;
using PomodoroPlatzi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PomodoroPlatzi.ViewModels
{
    public class HistoryViewModel : NotificationObject
    {
        public ObservableCollection<Pomodoro> Pomodoros { get; set; }

        public HistoryViewModel()
        {
            Pomodoros = new ObservableCollection<Pomodoro>();

            LoadPomodoros();
        }

        private void LoadPomodoros()
        {
            if (Application.Current.Properties.ContainsKey(Literales.PomodoroHistory))
            {
                var json = Application.Current.Properties[Literales.PomodoroHistory].ToString();
                var history = JsonConvert.DeserializeObject<List<Pomodoro>>(json);

                Pomodoros = new ObservableCollection<Pomodoro>(history.ToList());
            }
        }
    }
}
