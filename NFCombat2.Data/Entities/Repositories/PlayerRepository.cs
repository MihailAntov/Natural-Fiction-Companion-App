using NFCombat2.Common.Enums;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Data.Entities.Notes;
using NFCombat2.Data.Entities.Programs;
using NFCombat2.Data.Extensions;
using NFCombat2.Data.Helpers;
using NFCombat2.Models.Contracts;
using NFCombat2.Models.Factories;
using NFCombat2.Models.Items;
using NFCombat2.Models.Items.Equipments;
using NFCombat2.Models.Items.Parts;
using NFCombat2.Models.Items.Weapons;
using NFCombat2.Models.Notes;
using NFCombat2.Models.Player;
using NFCombat2.Models.Programs;
using SQLite;
using System;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;

namespace NFCombat2.Data.Entities.Repositories
{
    public class PlayerRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection connection = null!;
        //private IMapper _mapper;
        public string StatusMessage { get; set; } = string.Empty;
        public bool ShouldSeed { get; set; } = false;
        private async Task Init()
        {
            if (connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);

            //await connection.DropTableAsync<PlayerEntity>();
            //await connection.DropTableAsync<PlayersItemsEntity>();
            //await connection.DropTableAsync<PlayersEquipmentsEntity>();
            //await connection.DropTableAsync<PlayersWeaponsEntity>();
            //await connection.DropTableAsync<ItemEntity>();
            //await connection.DropTableAsync<ProgramEntity>();
            //await connection.DropTableAsync<PlayersProgramsEntity>();
            //await connection.DropTableAsync<PartBagEntity>();
            //await connection.DropTableAsync<NoteEntity>();
            //Uncomment above lines to reset item db

            await connection.CreateTableAsync<PlayerEntity>();
            await connection.CreateTableAsync<PlayersItemsEntity>();
            await connection.CreateTableAsync<PlayersEquipmentsEntity>();
            await connection.CreateTableAsync<PlayersWeaponsEntity>();
            await connection.CreateTableAsync<ItemEntity>();
            await connection.CreateTableAsync<ProgramEntity>();
            //await connection.CreateTableAsync<PlayersProgramsEntity>();
            await connection.CreateTableAsync<PartBagEntity>();
            await connection.CreateTableAsync<NoteEntity>();

            if(connection.Table<PlayerEntity>() != null)
            {
                
                if (await connection.Table<PlayerEntity>().CountAsync() == 0) 
                {
                    ItemRepositorySeeder.SeedRepository(this);
                }
            }

        }
        public PlayerRepository(string dbPath,  bool seed)
        {
            _dbPath = dbPath;
            ShouldSeed = seed;
            Init();
        }

        public async Task<Player?> AddNewProfile(Player player)
        {
            int result = 0;
            await Init();
            await Task.Run(async () =>
            {
                try
                {
                    

                    // basic validation to ensure a name was entered
                    if (string.IsNullOrEmpty(player.Name))
                        throw new Exception("Valid name required");
                    
                    
                    result = await connection.InsertAsync(new PlayerEntity { Name = player.Name, Class = player.Class });

                    StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, player.Name);
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", player.Name, ex.Message);
                }
            });

            return result == 1 ? player : null;
        }

        private async Task UpdateEntity(PlayerEntity player)
        {
            await Init();
            await connection.UpdateAsync(player);
        }

        private async Task UpdateItems(Player player)
        {
            var allItems = new List<Item>();
            allItems.AddRange(player.Items);
            allItems.AddRange(player.ExtraItems);

            var existingItems = await connection.Table<PlayersItemsEntity>()
                .Where(pi => pi.PlayerId == player.Id).ToListAsync();
            var removedItems = existingItems.Where(i=> !allItems.Select(item=> item.Id).Contains(i.ItemId)).ToList();
            foreach (var item in removedItems)
            {
                await connection.DeleteAsync(item);
            }

            
            foreach (var item in allItems)
            {
                PlayersItemsEntity playersItems = null!;
                try
                {
                    playersItems = await connection.GetAsync<PlayersItemsEntity>(ps => ps.PlayerId == player.Id && ps.ItemId == item.Id && ps.InExtraBag == item.InExtraBag);
                }
                catch
                {
                    await connection.InsertAsync(new PlayersItemsEntity() 
                    { 
                        PlayerId = player.Id,
                        ItemId = item.Id,
                        Quantity = item.Quantity,
                        InExtraBag = item.InExtraBag,
                    });
                    continue;
                }
                playersItems.Quantity = item.Quantity;
                playersItems.InExtraBag = item.InExtraBag;
                await connection.UpdateAsync(playersItems);
            }

           

            var existingrecords = await connection.Table<PlayersItemsEntity>().ToListAsync();
        }

        private async Task UpdateEquipments( Player player)
        {
            var oldEquipments = await connection.Table<PlayersEquipmentsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var equipment in oldEquipments)
            {
                await connection.DeleteAsync(equipment);
            }


            foreach (var equipment in player.Equipment)
            {
                AttachedTo attachedTo = AttachedTo.None;
                if(equipment is WeaponModification modification)
                {
                    attachedTo = modification.AttachedTo;
                }

                var newPlayersEquipmentsEntity = new PlayersEquipmentsEntity() 
                {
                    PlayerId = player.Id, 
                    EquipmentId = equipment.Id, 
                    IsConsumable = equipment.IsConsumable,
                    Quantity = equipment.Quantity
                };
                newPlayersEquipmentsEntity.AttachedTo = attachedTo;
                    

                await connection.InsertAsync(newPlayersEquipmentsEntity);
                continue;
                
            }
        }

        private async Task UpdateParts(Player player)
        {


            PartBagEntity bagEntity = await connection.FindAsync<PartBagEntity>(player.Id);
            if(bagEntity == null)
            {
                bagEntity = new PartBagEntity() {Id = player.Id };
                await connection.InsertAsync(bagEntity);
            }
            
            PartsMapper.SaveParts(player.PartsBag, bagEntity);
            await connection.UpdateAsync(bagEntity);
        }

        private async Task UpdatePrograms(Player player)
        {
            //Marker : Programs TODO : add string holding programIds
            //foreach(var program in player.Programs)
            //{
            //    PlayersProgramsEntity entity = await connection.Table<PlayersProgramsEntity>()
            //        .Where(pp => pp.PlayerId == player.Id && pp.ProgramId == program.Id)
            //        .FirstOrDefaultAsync();

            //    if(entity == null)
            //    {
            //        PlayersProgramsEntity newEntity = new PlayersProgramsEntity()
            //        {
            //            PlayerId = player.Id,
            //            ProgramId = program.Id
            //        };
            //        await connection.InsertAsync(newEntity);
            //    }

            //}

        }

        private async Task UpdateWeapons(Player player)
        {

            var oldWeapons = await connection.Table<PlayersWeaponsEntity>().Where(pw => pw.PlayerId == player.Id).ToListAsync();
            foreach (var weapon in oldWeapons)
            {
                await connection.DeleteAsync(weapon);
            }


            foreach (var weapon in player.Weapons)
            {
                if(weapon == null)
                {
                    continue;
                }
                PlayersWeaponsEntity playersItems = null!;
                
                playersItems = await connection.Table<PlayersWeaponsEntity>().FirstOrDefaultAsync(pi=> pi.ItemId == weapon.Id && pi.PlayerId == player.Id && pi.Hand == weapon.Hand);
                
                if(playersItems == null)
                {
                    
                    var newPlayersItems = new PlayersWeaponsEntity() { PlayerId = player.Id, ItemId = weapon.Id };
                    newPlayersItems.Quantity = weapon.Quantity;
                    newPlayersItems.Hand = weapon.Hand;
                    newPlayersItems.Durability = weapon.Durability;
                    await connection.InsertAsync(newPlayersItems);
                    var allPlayers = await connection.Table<PlayerEntity>().ToListAsync();
                    var allPlayersItems = await connection.Table<PlayersWeaponsEntity>().ToListAsync();
                    continue;
                }
                playersItems.Hand = weapon.Hand;
                playersItems.Durability = weapon.Durability;
                await connection.UpdateAsync(playersItems);
                    var allPlayersItems2 = await connection.Table<PlayersWeaponsEntity>().ToListAsync();
            }
        }

        public async Task UpdatePlayer(Player player)
        {
            await Init();
            //var entity = _mapper.Map<PlayerEntity>(player);
            var entity = new PlayerEntity()

            {
                Id = player.Id,
                Name = player.Name,
                Health = player.Health,
                BaseMaxHealth = player.BaseMaxHealth,
                Class = player.Class,
                MaxIonization = player.MaxIonization,
                MaxTrauma = player.MaxTrauma,
                MaxPathogens = player.MaxPathogens,
                Ionization = player.Ionization,
                Trauma = player.Trauma,
                Pathogens = player.Pathogens,
                Overload = player.Overload,
                MaxOverload = player.MaxOverload,
                Speed = player.Speed,
                Fuel = player.Fuel,
                

            };
            await UpdateItems(player);
            await UpdateEquipments(player);
            await UpdateWeapons(player);
            await UpdatePrograms(player);
            await UpdateParts(player);
            await UpdateEntity(entity);
        }

        private async Task RetrievePlayerData(Player player)
        {

            //items
            var playersItemsEntities = await connection.Table<PlayersItemsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var playersItemsEntity in playersItemsEntities)
            {
                var entity = await connection.GetAsync<ItemEntity>(playersItemsEntity.ItemId);
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                int itemId = entity.Id.Value;
                
                var item = (Item)ItemConverter(entity.Type,entity.Category, itemId);
                item.Quantity = playersItemsEntity.Quantity;
                item.InExtraBag = playersItemsEntity.InExtraBag;
                if (item.InExtraBag)
                {
                    player.ExtraItems.Add(item);
                    continue;
                }
                player.Items.Add(item);
                continue;
            }


            //weapons

            var playersWeaponsEntities = await connection.Table<PlayersWeaponsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var playersWeaponsEntity in playersWeaponsEntities)
            {

                var entity = await connection.GetAsync<ItemEntity>(playersWeaponsEntity.ItemId);
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                int itemId = entity.Id.Value;
                switch (playersWeaponsEntity.Hand)
                {
                    case Hand.MainHand:
                        player.MainHand = (Weapon)ItemConverter(entity.Type, entity.Category, itemId, playersWeaponsEntity.Hand, playersWeaponsEntity.Durability);
                        break;
                    case Hand.OffHand:
                        player.OffHand = (Weapon)ItemConverter(entity.Type, entity.Category, itemId, playersWeaponsEntity.Hand, playersWeaponsEntity.Durability);
                        break;
                }
                
            }


            //equipments
            var playersEquipmentsEntitites = await connection.Table<PlayersEquipmentsEntity>().Where(pi => pi.PlayerId == player.Id).ToListAsync();
            foreach (var playersEquipmentsEntity in playersEquipmentsEntitites)
            {
                var entity = await connection.GetAsync<ItemEntity>(playersEquipmentsEntity.EquipmentId);
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                int equipmentId = entity.Id.Value;
                
                var equipment = (Equipment)ItemConverter(entity.Type, entity.Category, equipmentId, playersEquipmentsEntity.AttachedTo);
                equipment.Quantity = playersEquipmentsEntity.Quantity;
                player.Equipment.Add(equipment);
            }

            

            foreach (Equipment equipment in player.Equipment)
            {
                if(equipment is WeaponModification modification)
                {
                    if(modification.AttachedTo == AttachedTo.MainHand)
                    {
                        modification.AttachToWeapon(player.MainHand);
                    }else if(modification.AttachedTo == AttachedTo.OffHand)
                    {
                        modification.AttachToWeapon(player.OffHand);
                    }
                }

                if(equipment is IModifyPlayer playerModification)
                {
                    playerModification.OnAdded(player);
                }
            }

            //parts
            
            var bagEntity = await connection.FindAsync<PartBagEntity>(player.Id);
            if(bagEntity != null)
            {
                PartsMapper.LoadParts(bagEntity, player.PartsBag);
            }

            //programs

            //var playersProgramsEntities = await connection.Table<PlayersProgramsEntity>()
            //    .Where(pp => pp.PlayerId == player.Id).ToListAsync();
            //var programIds = playersProgramsEntities.Select(pp=> pp.ProgramId).ToList();

            //var programs = await connection.Table<ProgramEntity>()
            //    .Where(p=> programIds.Contains(p.Id)).ToListAsync();
            //if (player.Class == PlayerClass.Hacker)
            //{
            //    List<Program> knownPrograms = GetKnownPrograms(player);
            //    player.Programs = knownPrograms;
            //}

        }

        public async Task<List<Player>> GetAllProfiles()
        {
            await Init();
            List<Player> players = new List<Player>();

            try
            {

                players = (await connection.Table<PlayerEntity>().ToListAsync())
                    //.Select(_mapper.Map<Player>)
                    .Select(pe=> new Player()
                    {
                        Id = pe.Id,
                        Name = pe.Name,
                        Health = pe.Health,
                        BaseMaxHealth = pe.BaseMaxHealth,
                        Class = pe.Class,
                        MaxIonization = pe.MaxIonization,
                        MaxTrauma = pe.MaxTrauma,
                        MaxPathogens = pe.MaxPathogens,
                        Ionization = pe.Ionization,
                        Trauma = pe.Trauma,
                        Pathogens = pe.Pathogens,
                        Overload = pe.Overload,
                        MaxOverload = pe.MaxOverload,
                        Speed = pe.Speed,
                        Fuel = pe.Fuel,
                        

                    }).ToList();
                foreach (var player in players)
                {
                    await RetrievePlayerData(player);
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            

            return players;
        }

        public async Task<Player?> GetPlayerById(int id)
        {
           await Init();
            try
            {
                var allPlayers = await connection.Table<PlayerEntity>().ToListAsync();
                Player? player = (await connection.Table<PlayerEntity>().ToListAsync())
                    //.Select(_mapper.Map<Player>)
                    .Select(pe => new Player()
                    {
                        Id = pe.Id,
                        Name = pe.Name,
                        Health = pe.Health,
                        BaseMaxHealth = pe.BaseMaxHealth,
                        Class = pe.Class,
                        MaxIonization = pe.MaxIonization,
                        MaxTrauma = pe.MaxTrauma,
                        MaxPathogens = pe.MaxPathogens,
                        Ionization = pe.Ionization,
                        Trauma = pe.Trauma,
                        Pathogens = pe.Pathogens,
                        Overload = pe.Overload,
                        MaxOverload = pe.MaxOverload,
                        Speed = pe.Speed,
                        Fuel = pe.Fuel,


                    })
                    .FirstOrDefault(p => p.Id == id);
                
                if (player != null)
                {
                    await RetrievePlayerData(player);
                }

                return player;
                
                
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                
            }
            return null;
        }

        public async Task InsertRange<ItemEntity>(IEnumerable<ItemEntity> items)
        {
            await Init();
            await connection.InsertAllAsync(items);
        }

        public async Task<int> DeleteAllItems()
        {
            await Init();
            int result = 0;
            result +=  await connection.DropTableAsync<ItemEntity>();
            await connection.CreateTableAsync<ItemEntity>();
            result += await connection.DropTableAsync<PlayersItemsEntity>();
            await connection.CreateTableAsync<PlayersItemsEntity>();
            return result;

        }
        public async Task<IAddable> GetItemById(int id)
        {
            await Init();
            var entity =  await connection.GetAsync<ItemEntity>(id);
            return ItemConverter(entity.Type, entity.Category, id);
        }

        public async Task<ICollection<IAddable>> GetItemsByCategory(ItemCategory category)
        {
            await Init();
            var entities = await connection.Table<ItemEntity>().Where(i=> i.Category == category && i.IsCraftOnly == false).ToListAsync();
            List<IAddable> items = new List<IAddable>();
            foreach (var entity in entities)
            {
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                var itemId = entity.Id.Value;
                var item = ItemConverter(entity.Type, entity.Category, itemId);
                //TODO quantity


                items.Add(item);
            }
            return items;

        }

        public async Task<ICollection<IAddable>> GetCraftableItems()
        {
            await Init();
            var entities = await connection.Table<ItemEntity>().Where(i=>i.IsCraftOnly).ToListAsync();
            //todo: replace iscraftonly with iscraftable to handle grenades and such
            List<IAddable> items = new List<IAddable>();
            foreach (var entity in entities)
            {
                if (!entity.Id.HasValue)
                {
                    throw new NullReferenceException();
                }
                var itemId = entity.Id.Value;
                var item = ItemConverter(entity.Type, entity.Category, itemId);
                item.Episode = entity.Episode;
                item.Formula = entity.Formula; 
                //TODO quantity


                items.Add(item);
            }
            return items;
        }

        public async Task<Note> AddNewNote(int playerId)
        {
            Note result = new Note();
            int status = 0;
            await Init();
            var entity = new NoteEntity() { PlayerID = playerId };
            await Task.Run(async () =>
            {
                try
                {
                    status = await connection.InsertAsync(entity);
                    StatusMessage = string.Format("{0} record(s) added (Title: {1})", result, entity.Id);
                    result.Id = entity.Id;

                    
                }
                catch (Exception ex)
                {
                    StatusMessage = string.Format("Failed to add {0}. Error: {1}", 0, ex.Message);
                    result = null;
                }
            });

            return result;
        }


        public async Task UpdateNote(Note note)
        {
            await Init();

            var entity = await connection.GetAsync<NoteEntity>(note.Id);
            entity.Text = note.Text;
            entity.Title = note.Title;
            await connection.UpdateAsync(entity);
        }

        public async Task DeleteNote(Note note)
        {

            await Init();
            await connection.DeleteAsync<NoteEntity>(note.Id);
        }


        public async Task<List<Note>> GetAllNotes(int playerId)
        {
            var noteEntities = await connection.Table<NoteEntity>()
                .Where(ne => ne.PlayerID == playerId)
                .ToListAsync();

            var notes = noteEntities.Select(ne => new Note()
            {
                Title = ne.Title,
                Text = ne.Text,
                Id = ne.Id
            }).ToList();

            return notes;

        }

        public async Task<Note> GetNote(int noteId)
        {
            var noteEntity = await connection.GetAsync<NoteEntity>(noteId);
            var note = new Note()
            {
                Id = noteEntity.Id,
                Title = noteEntity.Title,
                Text = noteEntity.Text
            };

            return note;
        }



        private IAddable ItemConverter(ItemType type, ItemCategory category, int itemId, params object[] args)
        {
            if(category == ItemCategory.Weapon)
            {
                return WeaponFactory.GetWeapon(type, itemId, args);
            }
            else
            {
                string typeName = type.ToString();
                string[] itemLocations = new string[] { "Equipments", "Items", "ActiveEquipments", "Weapons" };


                foreach (var itemLocation in itemLocations)
                {
                    string fullTypeName = $"NFCombat2.Models.Items.{itemLocation}.{typeName}, NFCombat2.Models";
                    Type? itemType = Type.GetType(fullTypeName);
                    if (itemType != null)
                    {
                        var item = (Item?)Activator.CreateInstance(itemType);
                        if (item == null)
                        {
                            throw new NullReferenceException();

                        }
                        item.Id = itemId;
                        item.ItemType = type;
                        
                        if(item is WeaponModification modification && args.Length > 0)
                        {
                            if (args[0] is AttachedTo attachedTo)
                            {
                                modification.AttachedTo = attachedTo;
                            }
                        }
                        
                        return item;
                    }
                }

                throw new InvalidCastException(typeName);
            }
            
            
        }




    }
}
