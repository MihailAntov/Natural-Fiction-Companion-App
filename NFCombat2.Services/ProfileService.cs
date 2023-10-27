

using NFCombat2.Models.Player;
using NFCombat2.Services.Contracts;
using NFCombat2.Data;

namespace NFCombat2.Services
{
    public class ProfileService : IProfileService
    {
        private ProfileRepository repo;
        public ProfileService(ProfileRepository repository)
        {
            repo = repository;
        }

        public Player CurrentPlayer()
        {
            return repo.GetAllProfiles().Select(p=> new Player
            {
                Name = p.Name
            }).First();
        }

        public List<Player> GetAll()
        {
            return repo.GetAllProfiles()
                .Select(p => new Player()
                {
                    Name = p.Name,
                    MaxHealth = p.MaxHealth,
                    Health = p.Health
                }).ToList();
        }

        public void Save(string name)
        {
            repo.AddNewProfile(name);
        }
    }
}
