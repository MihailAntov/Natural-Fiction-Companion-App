

using NFCombat2.Common.Enums;
using static NFCombat2.Common.AppConstants.Messages;
using NFCombat2.Contracts;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;

namespace NFCombat2.Services
{
    public class LogService : ILogService
    {
        private readonly IProfileService _profileService;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();
        

        public LogService(IProfileService profileService)
        {
            _profileService = profileService;
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

        public async void Log(MessageType messageType, params string[] args)
        {
            Language language = _profileService.CurrentPlayer().Language;
            string structure = GetStructure(messageType, language);
            Messages.Add(String.Format($"  {structure}", args));




        }

        
    }
}
