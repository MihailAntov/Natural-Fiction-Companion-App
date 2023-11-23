using AutoMapper;
using NFCombat2.Contracts;
using NFCombat2.Data.Entities.Repositories;
using NFCombat2.Data.Extensions;

namespace NFCombat2.Services
{
    public class SeederService : ISeederService
    {
        private FightRepository _fightRepository;
        private ItemRepository _itemRepository;
        public SeederService(FightRepository fightRepository, ItemRepository itemRepository)
        {
            _fightRepository = fightRepository;
            _itemRepository = itemRepository;
        }
        public void SeedFights()
        {
            ItemRepositorySeeder.SeedRepository(_itemRepository);
        }

        public void SeedItems()
        {
            FightRepositorySeeder.SeedRepository(_fightRepository);
        }
    }
}
