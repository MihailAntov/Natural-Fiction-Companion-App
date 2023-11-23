

using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Repositories;

namespace NFCombat2.Data.Extensions
{
    public class FightRepositorySeeder
    {
        public static async void SeedRepository(FightRepository repository)
        {
            await repository.DeleteAll();
            
            var fights = new List<FightEntity>()
            {
                new FightEntity()
                {

                },
            };


            await repository.InsertRange(fights);
        }
    }
}
