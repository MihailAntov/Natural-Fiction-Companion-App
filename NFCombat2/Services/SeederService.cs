using AutoMapper;
using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Data.Extensions;

namespace NFCombat2.Services
{
    public class SeederService : ISeederService
    {
        private FightRepository _fightRepository;
        private PlayerRepository _playerRepository;
        public SeederService(FightRepository fightRepository, PlayerRepository playerRepository)
        {
            _fightRepository = fightRepository;
            _playerRepository = playerRepository;
        }
        public void SeedFights()
        {
            FightRepositorySeeder.SeedRepository(_fightRepository);
        }

        public void SeedItems()
        {
            ItemRepositorySeeder.SeedRepository(_playerRepository);
        }
    }
}
