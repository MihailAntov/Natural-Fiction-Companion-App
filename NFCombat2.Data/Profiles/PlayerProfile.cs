

using AutoMapper;
using NFCombat2.Data.Entities.Combat;
using NFCombat2.Data.Entities.Items;
using NFCombat2.Models.Items.Parts;
using NFCombat2.Models.Player;

namespace NFCombat2.Data.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<PlayerEntity, Player>();
            CreateMap<Player, PlayerEntity>();
            CreateMap<PartBag, PartBagEntity>();
        }

    }
}
