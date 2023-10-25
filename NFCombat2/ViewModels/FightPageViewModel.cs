

//namespace NFCombat2.ViewModels
//{
//    public class FightPageViewModel
//    {
//        public async void GetEpisode(object sender, EventArgs e)
//        {
//            int result = int.Parse(await DisplayPromptAsync("Enter episode number", null, "Enter", "Cancel", null, maxLength: 3, keyboard: Keyboard.Numeric));
//            _fightService = this.Handler.MauiContext.Services.GetRequiredService<IFightService>();
//            fight = await _fightService.GetFightByEpisodeNumber(result);
//            TestLabel.Text = fight.GetType().Name;
//            //this.ShowHpBtn.IsVisible = true;
//            //this.IncreaseHpBtn.IsVisible = true;
//            //this.ChooseStandardActionBtn.IsVisible = true;
//            Enemies.Clear();
//            foreach (var enemy in fight.Enemies)
//            {
//                Enemies.Add(enemy);
//            }
//            //OnPropertyChanged(nameof(Enemies));
//        }

//        public void IncreaseHealth(object sender, EventArgs e)
//        {
//            fight.Player.Health++;
//        }

//        public async void ShowHealth(object sender, EventArgs e)
//        {
//            await DisplayAlert("Health", $"{fight.Player.Health}", "Okay");
//        }
//    }
//}
