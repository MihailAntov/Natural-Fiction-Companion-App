using NFCombat2.Common.AppConstants;
using NFCombat2.Common.Enums;
using NFCombat2.Contracts;
using NFCombat2.Models.Fights;
using static NFCombat2.Common.AppConstants.ItemNames;
using static NFCombat2.Common.AppConstants.Labels;
using static NFCombat2.Common.AppConstants.ModeNames;
using static NFCombat2.Common.AppConstants.FightResults;
using static NFCombat2.Common.AppConstants.Options;
using static NFCombat2.Common.AppConstants.EnemyNames;
using static NFCombat2.Common.AppConstants.PartNames;
using static NFCombat2.Common.AppConstants.CraftResults;
using NFCombat2.Models.Contracts;

namespace NFCombat2.Services
{
    public class NameService : INameService
    {
        public NameService()
        {
            
        }
        public string ItemName(ItemType type)
        {
            try
            {
                return EnglishItems[type];
            }
            catch
            {
                return "not found";
            }
        }

        public string ItemDescription(ItemType type)
        {
            try
            {
                return EnglishItems[type];
            }
            catch
            {
                return "not found";
            }
        }

        public string Label(LabelType type)
        {
            try
            {
                return EnglishLabels[type];
            }
            catch
            {
                return "not found";
            }
        }

        public string ProgramName(ProgramType type)
        {
            throw new NotImplementedException();
        }

        public string ModeName(ItemMode mode)
        {
            return EnglishModes[mode];
        }

        public string FightResultMessage(Fight fight)
        {
            
            return EnglishFightResults[(fight.Type,fight.Result)];
            
        }

        public string Option(OptionType option, CheckType checkType = CheckType.None)
        {
            return EnglishOptions[(option, checkType)];
        }

        public string InfoMessage(Fight fight)
        {
            if(fight is SkillCheckFight skillCheck)
            {
                if (skillCheck.CountWins)
                {
                    return $"You won {skillCheck.WonRounds} rounds.";
                }
            }
            return string.Empty;
        }

        public string EnemyName(EnemyType enemyType)
        {
            try
            {
                return EnglishEnemies[enemyType];

            }
            catch
            {
                return "Not Found";
            }
        }

        public void RetrieveFightNames(Fight fight)
        {
            if(fight is TentacleFight tentacleFight)
            {
                tentacleFight.TraumaTentacleName = EnglishEnemies[EnemyType.TraumaTentacle];
                tentacleFight.PathogensTentacleName = EnglishEnemies[EnemyType.PathogenTentacle];
                tentacleFight.IonizationTentacleName = EnglishEnemies[EnemyType.IonizationTentacle];
            }


            foreach(var enemy in fight.Enemies)
            {
                enemy.Name = EnglishEnemies[enemy.EnemyType];
                if(enemy.EnemyType == EnemyType.CommanderKabuto)
                {
                    enemy.Weapons[0].Name = EnglishItems[ItemType.KabutoMainHand];
                    enemy.Weapons[1].Name = EnglishItems[ItemType.KabutoOffHand];
                    
                }
            }
        }

        public string PartCategoryName(PartCategoryType category)
        {
            try
            {
                return EnglishPartCategories[category];

            }
            catch
            {
                return "Not Found";
            }
        }

        public string PartName(PartType partType)
        {
            try
            {
                return EnglishParts[partType];

            }
            catch
            {
                return "Not Found";
            }
        }

        public string CraftResultMessage(CraftResult result, IAddable item = null)
        {
            try
            {
                string format = EnglishCraftResults[result];
                if(item != null)
                {
                    string name = ItemName(item.ItemType);
                    return string.Format(format, name);
                }
                return EnglishCraftResults[result];

            }
            catch
            {
                return "Not Found";
            }
        }
    }
}
