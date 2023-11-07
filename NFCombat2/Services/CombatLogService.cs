

using NFCombat2.Contracts;

namespace NFCombat2.Services
{
    public class CombatLogService : ICombatLogService
    {
        public CombatLogService()
        {
                
        }
        public ICollection<string> Messages { get; set; } = new List<string>();

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }
    }
}
