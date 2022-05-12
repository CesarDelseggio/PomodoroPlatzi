using PomodoroPlatzi.Models;
using PomodoroPlatzi.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PomodoroPlatzi.ViewModels
{
    public class MenuPageFlyoutViewModel : NotificationObject
    {
        public ObservableCollection<MenuPageFlyoutMenuItem> MenuItems { get; set; }

        public MenuPageFlyoutViewModel()
        {
            MenuItems = new ObservableCollection<MenuPageFlyoutMenuItem>(new[]
            {
                    new MenuPageFlyoutMenuItem { Id = 0, Title = "Pomodoro", TargetType = typeof(PomodoroPage) },
                    new MenuPageFlyoutMenuItem { Id = 1, Title = "Historico", TargetType = typeof(HistoryPage) },
                    new MenuPageFlyoutMenuItem { Id = 2, Title = "Configuración",TargetType = typeof(ConfigurationPage) }
                });
        }
    }
}
