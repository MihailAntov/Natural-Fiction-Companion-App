﻿using NFCombat2.Models.Fights;
using NFCombat2.Services.Contracts;
using System.Collections.ObjectModel;
using NFCombat2.Models.Contracts;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NFCombat2.ViewModels
{
    public class FightPageViewModel : INotifyPropertyChanged
    {

        private Fight fight;
        private IFightService _fightService;
        private IOptionsService _optionsService;

        public event PropertyChangedEventHandler PropertyChanged;

        public Command GetEpisodeCommand { get; }
        private string testLabel;
        public string TestLabel
        {
            get { return testLabel; }
            set
            {
                if(testLabel != value)
                {
                    testLabel = value;
                    OnPropertyChanged(nameof(TestLabel));
                }
            }
        }
        public string EpisodeNumber { get; set; }
        

        public ObservableCollection<Enemy> Enemies { get; set; } = new ObservableCollection<Enemy>();
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<IAction> Options { get; set; } = new ObservableCollection<IAction>();
        public OptionPickerViewModel OptionPickerViewModel { get; set; } 

        

        public FightPageViewModel(IFightService fightService, IOptionsService optionsService, OptionPickerViewModel opctionPickerViewModel)
        {
                _fightService = fightService;
                _optionsService = optionsService;
            OptionPickerViewModel = opctionPickerViewModel;
            GetEpisodeCommand = new Command(GetEpisode);
        }
        public async void GetEpisode()
        {
            int.TryParse(EpisodeNumber, out int episode);
            
            fight = await _fightService.GetFightByEpisodeNumber(episode);
            TestLabel = fight.GetType().Name;

            Enemies.Clear();
            foreach (var enemy in fight.Enemies)
            {
                Enemies.Add(enemy);
            }
            OptionPickerViewModel.Categories = new ObservableCollection<string>(_optionsService.GetCategories(fight));
        }

        public void IncreaseHealth(object sender, EventArgs e)
        {
            fight.Player.Health++;
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}