using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;

namespace NFCombat2.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly SettingsRepository _settingsRepository;
        public SettingsService(SettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
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
            Language = await _settingsRepository.GetLanguage();
        }

        public async Task SetLanguage(Language language)
        {
            await _settingsRepository.SetLanguage(language);
            Language = language;
        }

        public async Task<int> GetCurrentPlayerId()
        {
            return await _settingsRepository.GetCurrentPlayerId();
        }

        public async Task SetCurrentPlayerId(int id)
        {
            await _settingsRepository.SetCurrentPlayerId(id);
        }
    }
}
