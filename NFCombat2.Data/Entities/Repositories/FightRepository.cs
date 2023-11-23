using AutoMapper;
using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Models.Fights;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCombat2.Data.Entities.Repositories
{
    public class FightRepository
    {
        string _dbPath;
        private IMapper _mapper;
        public bool Seeded { get; set; } = false;
   

        protected SQLiteAsyncConnection connection = null!;
        public string StatusMessage { get; set; } = string.Empty;

        public FightRepository(string dbPath, IMapper mapper)
        {
            _dbPath = dbPath;
            _mapper = mapper;
            Init();
            
        }
        private async void Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<FightEntity>();
            await connection.CreateTableAsync<EnemyEntity>();
            if(await connection.Table<FightEntity>().CountAsync() > 0)
            {
                Seeded = true;
            }

        }

        public async Task InsertFight(FightEntity fight)
        {
            Init();
            await connection.InsertAsync(fight);
        }

        public async Task InsertRange<T>(IEnumerable<T> items)
        {
            Init();
            await connection.InsertAllAsync(items);
        }

        private async Task<int> DeleteAllFights()
        {
            return await connection.DropTableAsync<FightEntity>();
        }
        private async Task<int> DeleteAllEnemies()
        {
            return await connection.DropTableAsync<EnemyEntity>();
        }

        public async Task<int> DeleteAll()
        {
            Init();
            int result = 0;
            result += await DeleteAllFights();
            result += await DeleteAllEnemies();
            return result;
        }

        public async Task Update<T>(T item)
        {
            Init();
            await connection.UpdateAsync(item);
        }

        public async Task<Fight> GetFight(int id)
        {
            Init();
            var entity = await connection.GetAsync<FightEntity>(id);
            var enemies = await GetEnemiesByFightId(entity.Id);
            Fight result = null!;
            switch (entity.FightType)
            {
                case FightType.Regular:
                    result = new Fight(enemies);
                    break;
                case FightType.Escape:
                    result = new EscapeFight(enemies);
                    break;
                case FightType.Chase:
                    result = new ChaseFight(enemies);
                    break;
                case FightType.Constrained:
                    result = new ConstrainedFight(enemies);
                    break;
                case FightType.Timed:
                    result = new TimedFight(enemies);
                    break;
                case FightType.SkillCheck:
                    result = new SkillCheckFight(enemies);
                    break;
            }
            return result;
        }



        public async Task<IList<Enemy>> GetEnemiesByFightId(int fightId)
        {
            Init();
            var entities = await connection.Table<EnemyEntity>()
                .Where(e => e.FightId == fightId)
                .ToListAsync();

            var result = new List<Enemy>();

            foreach(var entity in entities)
            {
                result.Add(_mapper.Map<Enemy>(entity));
            }
            return result; 
        }
    }
}
