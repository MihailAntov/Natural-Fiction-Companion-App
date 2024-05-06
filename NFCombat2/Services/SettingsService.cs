using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using Microsoft.Maui.Storage;

namespace NFCombat2.Services
{
    public class SettingsService : ISettingsService
    {
        //private readonly SettingsRepository _settingsRepository;
        public SettingsService()
        {
            //_settingsRepository = settingsRepository;
            if (!Preferences.Default.ContainsKey("language"))
            {
                Preferences.Default.Set("language", "Bulgarian");
            }

            if (!Preferences.Default.ContainsKey("playerId"))
            {
                Preferences.Default.Set("playerId", 0);
            }
            LoadLanguage();
        }
        //public Language Language { 
        //    get { return _settingsRepository.GetLanguage() } 
        //    set { Task.Run(async () =>await  _settingsRepository.SetLanguage(value)); } }

        //public int CurrentPlayerId
        //{
        //    get { return _settingsRepository.GetCurrentPlayerId() }
        //    set { Task.Run(async ()=>await _settingsRepository.SetCurrentPlayerId(value)); }
        //}
        public Language Language { get; private set; }


        private async void LoadLanguage()
        {
            var lang = Preferences.Default.Get("language","Bulgarian");
            if (Enum.TryParse(typeof(Language), lang, true, out var language))
            {
                Language = (Language)language;
            }
            //Language = await _settingsRepository.GetLanguage();
        }

        public async Task SetLanguage(Language language)
        {
            //await _settingsRepository.SetLanguage(language);
            Preferences.Default.Set("language",language.ToString());
            Language = language;
        }

        public async Task<int> GetCurrentPlayerId()
        {
            var pref = Preferences.Default.Get("playerId", 0);
            return (int)pref;
            //return await _settingsRepository.GetCurrentPlayerId();
        }

        public async Task SetCurrentPlayerId(int id)
        {
            Preferences.Default.Set("playerId", id);
            //await _settingsRepository.SetCurrentPlayerId(id);
        }
    }
}
