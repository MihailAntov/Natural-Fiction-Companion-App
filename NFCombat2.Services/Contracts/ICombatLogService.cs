

namespace NFCombat2.Services.Contracts
{
    public interface ICombatLogService
    {
        ICollection<string> Messages { get; set; }
        void AddMessage(string message);
    }
}
