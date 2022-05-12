using PomodoroPlatzi.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PomodoroPlatzi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageFlyout : ContentPage
    {
        public ListView ListView;

        public MenuPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }
    }
}