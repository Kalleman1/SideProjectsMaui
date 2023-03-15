using MonkeyFinder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyFinder.Services;
using System.Diagnostics;

namespace MonkeyFinder.ViewModels
{
    public class MonkeysViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; } = new();
        public Command GetMonkeysCommand { get; }
        MonkeyService monkeyService; 

        public MonkeysViewModel(MonkeyService monkeyService) 
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync()); 
        }

        async Task GetMonkeysAsync()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;

                var monkeys = await monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)
                {
                    monkeys.Clear();
                }

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey); 


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Application.Current.MainPage.DisplayAlert("ERRORRRRR", ex.Message, "Ok"); 
            }
            finally { IsBusy = false; }
        }
    }
}
