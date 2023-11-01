

using NFCombat2.Common.Enums;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace NFCombat2.Services.Contracts
{
    public interface ILogService : INotifyCollectionChanged
    {
        void Log(MessageType messageType, params string[] args);
        public ObservableCollection<string> Messages { get; }
        
    }
}
