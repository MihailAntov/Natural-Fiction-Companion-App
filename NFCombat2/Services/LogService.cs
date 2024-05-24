

using NFCombat2.Common.Enums;
using static NFCombat2.Common.AppConstants.Messages;
using NFCombat2.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using NFCombat2.Models.Player;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Services
{
    public class LogService : ILogService
    {
        private readonly IPlayerService _playerService;
        private readonly ISettingsService _settingsService;
       
        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();
        

        public LogService(IPlayerService playerService, ISettingsService settingsService)
        {
            _playerService = playerService;
            _settingsService = settingsService;
            
        }

        private string GetStructure(MessageType type, Language language)
        {
            switch (language)
            {
                case Language.Bulgarian:
                    return BulgarianMessages[type];
                case Language.English:
                default:
                    return EnglishMessages[type];

            }
        }

        public async Task Log(MessageType messageType, params string[] args)
        {
            Language language = _settingsService.Language;
            string structure = GetStructure(messageType, language);
            Messages.Add(String.Format($"  {structure}", args));
        }

        public Task<string> GetResolutionMessage(ICombatResolution resolution)
        {
            Language language = _settingsService.Language;
            string structure = GetStructure(resolution.MessageType, language);
            return Task.FromResult(String.Format($"  {structure}", resolution.MessageArgs));


        }
    }
}
