using DawnOfHistoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Migrations
{
    public static class Iteration1Seeder
    {
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureCreated();

            //If there are no pre-existing Civilization entries, seed them now
            if(!context.Civs.Any())
            {
                foreach(Civ civ in GetSeedCivilizations())
                {
                    context.Civs.Add(civ);
                }
            }

            //If there are no pre-existing Advancement entries, seed them now
            if (!context.Civs.Any())
            {
                foreach (Advancement advancement in GetSeedAdvancements())
                {
                    context.Advancements.Add(advancement);
                }
            }
            
            //If there are no pre-existing Ability entries, seed them now
            if (!context.Abilities.Any())
            {
                foreach (Ability ability in GetSeedAbilities())
                {
                    context.Abilities.Add(ability);
                }
            }

            context.SaveChanges();
        }

        //Data for the Civilization reference table
        public static Civ[] GetSeedCivilizations()
        {
            Civ[] SeedCivs = {
                new Civ { Id = 1,  Name = "Minoa",    AstStone = 5, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 14, AstLateIron = 16 },
                new Civ { Id = 2,  Name = "Saba",     AstStone = 5, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 14, AstLateIron = 16 },
                new Civ { Id = 3,  Name = "Celts",    AstStone = 5, AstEarlyBronze = 7, AstLateBronze = 11, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 4,  Name = "Assyria",  AstStone = 4, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 5,  Name = "Rome",     AstStone = 4, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 6,  Name = "Babylon",  AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 7,  Name = "Carthage", AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 8,  Name = "Hellas",   AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 9,  Name = "Maurya",   AstStone = 4, AstEarlyBronze = 8, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 10, Name = "Dravidia", AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 11, Name = "Kushan",   AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 12, Name = "Nubia",    AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 13, Name = "Persia",   AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 14, Name = "Hatti",    AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 15, Name = "Iberia",   AstStone = 4, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 13, AstLateIron = 16 },
                new Civ { Id = 16, Name = "Indus",    AstStone = 3, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 12, AstLateIron = 16 },
                new Civ { Id = 17, Name = "Parthia",  AstStone = 3, AstEarlyBronze = 7, AstLateBronze = 10, AstEarlyIron = 12, AstLateIron = 16 },
                new Civ { Id = 18, Name = "Egypt",    AstStone = 3, AstEarlyBronze = 6, AstLateBronze = 9,  AstEarlyIron = 12, AstLateIron = 16 }
            };

            return SeedCivs;
        }

        //Data for the Advancement reference table
        public static Advancement[] GetSeedAdvancements()
        {
            //TODO: reformat this so that it's not nearly as wide
            
            Advancement[] SeedAdvancments = {
                /* Note: the IDs for Advancements correspond to the numbering in the Dawn of History
                 * rulebook, which starts at 2. For example, the Advancement Architecture, which has
                 * ID 5, corresponds to rule 30.5, which specifies the effects of the Architecture
                 * advancement
                 */
                new Advancement { Id = 2,  Name = "Advanced Military",   BaseCost = 260, Points = 3, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  0, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 3,  Name = "Agriculture",         BaseCost = 120, Points = 2, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 13,   CreditAdvancementValue = 20 },
                new Advancement { Id = 4,  Name = "Anatomy",             BaseCost = 270, Points = 3, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  0, CreditCraft =  5, CreditReligion =  0, CreditScience = 10, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 5,  Name = "Architecture",        BaseCost = 140, Points = 2, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  0, CreditCraft =  0, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 31,   CreditAdvancementValue = 20 },
                new Advancement { Id = 6,  Name = "Astronavigation",     BaseCost = 80,  Points = 1, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience = 10, CreditAdvancementId = 7,    CreditAdvancementValue = 10 },
                new Advancement { Id = 7,  Name = "Calendar",            BaseCost = 180, Points = 2, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  5, CreditCraft =  0, CreditReligion =  0, CreditScience = 10, CreditAdvancementId = 43,   CreditAdvancementValue = 20 },
                new Advancement { Id = 8,  Name = "Cartography",         BaseCost = 160, Points = 2, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  5, CreditCivic =  0, CreditCraft =  0, CreditReligion =  0, CreditScience = 10, CreditAdvancementId = 24,   CreditAdvancementValue = 20 },
                new Advancement { Id = 9,  Name = "Cloth Making",        BaseCost = 50,  Points = 1, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 38,   CreditAdvancementValue = 10 },
                new Advancement { Id = 10, Name = "Coinage",             BaseCost = 90,  Points = 1, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  5, CreditCraft =  0, CreditReligion =  0, CreditScience = 10, CreditAdvancementId = 50,   CreditAdvancementValue = 10 },
                new Advancement { Id = 11, Name = "Cultural Ascendancy", BaseCost = 280, Points = 3, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 12, Name = "Deism",               BaseCost = 80,  Points = 1, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft =  5, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = 20,   CreditAdvancementValue = 10 },
                new Advancement { Id = 13, Name = "Democracy",           BaseCost = 220, Points = 3, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  5, CreditCivic = 10, CreditCraft =  0, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 14, Name = "Diaspora",            BaseCost = 270, Points = 3, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft =  0, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 15, Name = "Diplomacy",           BaseCost = 180, Points = 2, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  5, CreditCraft =  0, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 42,   CreditAdvancementValue = 20 },
                new Advancement { Id = 16, Name = "Drama and Poetry",    BaseCost = 80,  Points = 1, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 44,   CreditAdvancementValue = 10 },
                new Advancement { Id = 17, Name = "Empiricism",          BaseCost = 60,  Points = 1, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  5, CreditCivic =  5, CreditCraft =  5, CreditReligion =  5, CreditScience = 10, CreditAdvancementId = 28,   CreditAdvancementValue = 10 },
                new Advancement { Id = 18, Name = "Engineering",         BaseCost = 160, Points = 2, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  0, CreditCraft =  5, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 45,   CreditAdvancementValue = 20 },
                new Advancement { Id = 19, Name = "Enlightenment",       BaseCost = 160, Points = 2, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft =  5, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = 33,   CreditAdvancementValue = 20 },
                new Advancement { Id = 20, Name = "Fundamentalism",      BaseCost = 150, Points = 2, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft =  0, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = 33,   CreditAdvancementValue = 20 },
                new Advancement { Id = 21, Name = "Iron Working",        BaseCost = 200, Points = 3, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 2,    CreditAdvancementValue = 10 },
                new Advancement { Id = 22, Name = "Irrigation",          BaseCost = 200, Points = 3, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 23, Name = "Law",                 BaseCost = 170, Points = 2, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 11,   CreditAdvancementValue = 20 },
                new Advancement { Id = 24, Name = "Library",             BaseCost = 220, Points = 3, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  5, CreditCivic =  0, CreditCraft =  0, CreditReligion =  0, CreditScience = 10, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 25, Name = "Literacy",            BaseCost = 110, Points = 2, IsArt = true,  IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic = 10, CreditCraft =  5, CreditReligion =  5, CreditScience =  5, CreditAdvancementId = 27,   CreditAdvancementValue = 20 },
                new Advancement { Id = 26, Name = "Masonry",             BaseCost = 60,  Points = 1, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 18,   CreditAdvancementValue = 10 },
                new Advancement { Id = 27, Name = "Mathematics",         BaseCost = 240, Points = 3, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt = 10, CreditCivic = 10, CreditCraft = 10, CreditReligion = 10, CreditScience = 10, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 28, Name = "Medicine",            BaseCost = 140, Points = 2, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  0, CreditCraft =  5, CreditReligion =  0, CreditScience = 10, CreditAdvancementId = 4,    CreditAdvancementValue = 20 },
                new Advancement { Id = 29, Name = "Metalworking",        BaseCost = 90,  Points = 1, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 30,   CreditAdvancementValue = 10 },
                new Advancement { Id = 30, Name = "Military",            BaseCost = 170, Points = 2, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  5, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 2,    CreditAdvancementValue = 20 },
                new Advancement { Id = 31, Name = "Mining",              BaseCost = 230, Points = 3, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 32, Name = "Monarchy",            BaseCost = 60,  Points = 1, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 23,   CreditAdvancementValue = 10 },
                new Advancement { Id = 33, Name = "Monotheism",          BaseCost = 240, Points = 3, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  5, CreditCraft =  0, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 34, Name = "Monument",            BaseCost = 180, Points = 2, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft =  5, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 53,   CreditAdvancementValue = 20 },
                new Advancement { Id = 35, Name = "Music",               BaseCost = 80,  Points = 1, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 19,   CreditAdvancementValue = 10 },
                new Advancement { Id = 36, Name = "Mysticism",           BaseCost = 50,  Points = 1, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 34,   CreditAdvancementValue = 10 },
                new Advancement { Id = 37, Name = "Mythology",           BaseCost = 60,  Points = 1, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft =  0, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = 25,   CreditAdvancementValue = 10 },
                new Advancement { Id = 38, Name = "Naval Warfare",       BaseCost = 160, Points = 2, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  5, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 14,   CreditAdvancementValue = 20 },
                new Advancement { Id = 39, Name = "Philosophy",          BaseCost = 240, Points = 3, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = true,  CreditArt =  0, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience =  5, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 40, Name = "Politics",            BaseCost = 230, Points = 3, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  0, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 41, Name = "Pottery",             BaseCost = 60,  Points = 1, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 3,    CreditAdvancementValue = 10 },
                new Advancement { Id = 42, Name = "Provincial Empire",   BaseCost = 260, Points = 3, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  5, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 43, Name = "Public Works",        BaseCost = 230, Points = 3, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  5, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 44, Name = "Rhetoric",            BaseCost = 130, Points = 2, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  5, CreditCraft =  0, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 40,   CreditAdvancementValue = 20 },
                new Advancement { Id = 45, Name = "Roadbuilding",        BaseCost = 220, Points = 3, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 46, Name = "Sculpture",           BaseCost = 50,  Points = 1, IsArt = true,  IsCivic = false, IsCraft = false, IsReligion = false, IsScience = false, CreditArt = 10, CreditCivic =  5, CreditCraft =  0, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = 5,    CreditAdvancementValue = 10 },
                new Advancement { Id = 47, Name = "Theocracy",           BaseCost = 80,  Points = 1, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  5, CreditCraft =  0, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 51,   CreditAdvancementValue = 10 },
                new Advancement { Id = 48, Name = "Theology",            BaseCost = 250, Points = 3, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft =  0, CreditReligion = 10, CreditScience =  5, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 49, Name = "Trade Empire",        BaseCost = 260, Points = 3, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  5, CreditCraft = 10, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 50, Name = "Trade Routes",        BaseCost = 180, Points = 2, IsArt = false, IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic =  0, CreditCraft = 10, CreditReligion =  5, CreditScience =  0, CreditAdvancementId = 49,   CreditAdvancementValue = 20 },
                new Advancement { Id = 51, Name = "Universal Doctrine",  BaseCost = 160, Points = 2, IsArt = false, IsCivic = false, IsCraft = false, IsReligion = true,  IsScience = false, CreditArt =  0, CreditCivic =  5, CreditCraft =  0, CreditReligion = 10, CreditScience =  0, CreditAdvancementId = 48,   CreditAdvancementValue = 20 },
                new Advancement { Id = 52, Name = "Urbanism",            BaseCost = 50,  Points = 1, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = false, CreditArt =  0, CreditCivic = 10, CreditCraft =  0, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 15,   CreditAdvancementValue = 10 },
                new Advancement { Id = 53, Name = "Wonder of the World", BaseCost = 280, Points = 3, IsArt = true,  IsCivic = false, IsCraft = true,  IsReligion = false, IsScience = false, CreditArt =  5, CreditCivic =  0, CreditCraft =  5, CreditReligion =  0, CreditScience =  0, CreditAdvancementId = null, CreditAdvancementValue = null },
                new Advancement { Id = 54, Name = "Written Record",      BaseCost = 60,  Points = 1, IsArt = false, IsCivic = true,  IsCraft = false, IsReligion = false, IsScience = true,  CreditArt =  0, CreditCivic =  5, CreditCraft =  0, CreditReligion =  0, CreditScience =  5, CreditAdvancementId = 8,    CreditAdvancementValue = 10 }
            };

            return SeedAdvancments;
        }

        //Data for the Ability reference table
        public static Ability[] GetSeedAbilities()
        {
            Ability[] SeedAbilities = {
                new Ability { Id = 1,   AdvancementId = 2,  RulesText = "The player with this advancement may use population counters from areas adjacent by land as casualties in conflicts. At least one population counter must remain in the areas used (18.2.4)." },
                new Ability { Id = 2,   AdvancementId = 2,  RulesText = "This advancement reduces the first faction in Civil War by five unit points, taken from the beneficiaries selection of 20 unit points. (29.4.1.8)." },
                new Ability { Id = 3,   AdvancementId = 2,  RulesText = "One additional city is retained in the Civil Disorder (29.7.2.2) calamity." },
                new Ability { Id = 4,   AdvancementId = 2,  RulesText = "Five fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.4)." },
                new Ability { Id = 5,   AdvancementId = 2,  RulesText = "The cost of a Minor Uprising is reduced by 5 (29.8.3.2)." },
                new Ability { Id = 6,   AdvancementId = 2,  RulesText = "The Cultural Ascendancy (30.11) advancement held by other players is neutralized. You may initiate conflicts with them." },
                new Ability { Id = 7,   AdvancementId = 3,  RulesText = "This advancement increases the population limit by one in areas that the holder alone occupies (20.1.3)." },
                new Ability { Id = 8,   AdvancementId = 3,  RulesText = "The ability of this card is suppressed when the player is the Primary Victim of Famine (29.3.1.4)." },
                new Ability { Id = 9,   AdvancementId = 4,  RulesText = "When purchased, this advancement allows the player to immediately acquire up to two additional science advancements valued under 100 points. Cards with dual groups (colors) are eligible. The player may not acquire advancements that they already have." },
                new Ability { Id = 10,  AdvancementId = 4,  RulesText = "This advancement causes eight fewer unit points to be lost as the Primary Victim of Epidemic, and five fewer points for a Secondary Victim (29.6.2.4)." },
                new Ability { Id = 11,  AdvancementId = 5,  RulesText = "Once each turn, up to half of the population cost of building a city can be paid with treasury counters (19.1.3)." },
                new Ability { Id = 12,  AdvancementId = 6,  RulesText = "The player's ships can enter dark blue open sea areas (17.2.3)." },
                new Ability { Id = 13,  AdvancementId = 6,  RulesText = "Players with this advancement may retain two ships of their choice for the Tempest calamity (29.3.3.4)." },
                new Ability { Id = 14,  AdvancementId = 7,  RulesText = "Five fewer unit points are lost by a Secondary Victim of Famine (29.3.1.3)." },
                new Ability { Id = 15,  AdvancementId = 8,  RulesText = "This advancement allows the player to purchase one trade card from the seventh stack for 14 treasury counters each turn (22.2.4)." },
                new Ability { Id = 16,  AdvancementId = 8,  RulesText = "Players with this advancement may retain two ships of their choice for the Tempest calamity (29.3.3.5)." },
                new Ability { Id = 17,  AdvancementId = 8,  RulesText = "One additional city is replaced due to Piracy (29.9.2.4)." },
                new Ability { Id = 18,  AdvancementId = 9,  RulesText = "Increases the players ship movement by one area (17.2.2)." },
                new Ability { Id = 19,  AdvancementId = 10, RulesText = "Players with this advancement may increase or decrease their tax rate by one (13.2.2)." },
                new Ability { Id = 20,  AdvancementId = 10, RulesText = "Five additional face value commodity card points must be returned to the trade card stacks due to Corruption (29.7.1.2)." },
                new Ability { Id = 21,  AdvancementId = 11, RulesText = "Your cities, ships and population counters can only be attacked by other players having either the Cultural Ascendancy or Advanced Military (17.4.2) advancements. (Barbarian/Pirate exempt)" },
                new Ability { Id = 22,  AdvancementId = 11, RulesText = "Players with the Politics (25.5) advancement may not use its special ability on players with this advancement." },
                new Ability { Id = 23,  AdvancementId = 11, RulesText = "The players cities require one additional population marker for support (21.1.1)." },
                new Ability { Id = 24,  AdvancementId = 12, RulesText = "One fewer city is reduced by the Superstition (29.3.2.2) calamity." },
                new Ability { Id = 25,  AdvancementId = 13, RulesText = "This advancement suppresses tax revolts (13.3), they do not occur to players with this advancement." },
                new Ability { Id = 26,  AdvancementId = 13, RulesText = "The first faction is increased by ten unit points for the Civil War (29.4.1.3) calamity." },
                new Ability { Id = 27,  AdvancementId = 13, RulesText = "One fewer city is reduced by the Civil Disorder (29.7.2.2) calamity." },
                new Ability { Id = 28,  AdvancementId = 13, RulesText = "Ten fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.5)." },
                new Ability { Id = 29,  AdvancementId = 14, RulesText = "The Coastal Migration calamity (29.6.3.3) has no effect on players with this advancement." },
                new Ability { Id = 30,  AdvancementId = 14, RulesText = "Players with the Diaspora (30.14) advancement may either place a city, or completely populate an empty area on the map adjacent to an area they alone occupy. Areas separated by water borders are not considered adjacent for this ability." },
                new Ability { Id = 31,  AdvancementId = 14, RulesText = "Players with this advancement must hold one fewer trade card between turns (27.2.2)." },
                new Ability { Id = 32,  AdvancementId = 15, RulesText = "Your cities can only be attacked by other players having either the Diplomacy or Military (17.4.1) advancements. (Barbarian/Pirate exempt.)" },
                new Ability { Id = 33,  AdvancementId = 15, RulesText = "One additional city is captured or destroyed by the Treachery calamity(29.2.2.3)." },
                new Ability { Id = 34,  AdvancementId = 16, RulesText = "The first faction is increased by five unit points for the Civil War calamity(29.4.1.3)." },
                new Ability { Id = 35,  AdvancementId = 16, RulesText = "One fewer city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 36,  AdvancementId = 17, RulesText = "Players with this advancement are not affected by the Squandered Wealth calamity (29.2.3.3)." },
                new Ability { Id = 37,  AdvancementId = 18, RulesText = "For conflicts, this advancement increases the value of the players cities by one. Attacking players must add an additional population counter, and one additional population counter is added when the city is replaced for conflict resolution (18.3.5)." },
                new Ability { Id = 38,  AdvancementId = 18, RulesText = "Players with this advancement require one less population counter when attacking cities of players without this advancement. The defending cities are replaced with one fewer population counter (18.3.5)." },
                new Ability { Id = 39,  AdvancementId = 18, RulesText = "Primary and Secondary Victims with the Urbanism (30.50) advancement not also having this advancement must remove an additional four unit points from areas adjacent to the affected area for both the Volcanic Eruption and Earthquake calamities (29.2.1.1)." },
                new Ability { Id = 40,  AdvancementId = 18, RulesText = "A city is reduced rather than destroyed by the Earthquake calamity (29.2.1.4) when the primary victim. Immune to the secondary effects of the Earthquake calamity." },
                new Ability { Id = 41,  AdvancementId = 18, RulesText = "Players with this advancement lose 3 fewer treasury counters to stock due to the Tempest calamity (29.3.3.7)." },
                new Ability { Id = 42,  AdvancementId = 18, RulesText = "A city is reduced rather than destroyed by the City in Flames calamity (29.4.3.2)." },
                new Ability { Id = 43,  AdvancementId = 18, RulesText = "A primary or Secondary Victim with this advancement removes a maximum of seven unit points from a flood plain due to the Flood Calamity (29.5.1.4). When the Primary Victim has this advancement and has no units on a flood plain, one of their coastal cities is reduced instead of eliminated." },
                new Ability { Id = 44,  AdvancementId = 18, RulesText = "Two fewer cities are reduced by the Cyclone calamity (29.6.1.7)." },
                new Ability { Id = 45,  AdvancementId = 19, RulesText = "One fewer city is reduced by the Superstition calamity (29.3.2.2)." },
                new Ability { Id = 46,  AdvancementId = 19, RulesText = "Five fewer population can be counted for city support during the Slave Revolt calamity (29.4.2.3)." },
                new Ability { Id = 47,  AdvancementId = 20, RulesText = "In the Special Abilities Phase (25.3), players with this advancement may destroy all units in one area adjacent by land. Players with the Fundamentalism or Philosophy advancement and the Barbarian/Pirate are exempt." },
                new Ability { Id = 48,  AdvancementId = 20, RulesText = "Players with this advancement have their Chronological Advancement Chart (C.A.C.) marker moved back (left) one additional space due to the Regression calamity (29.9.1.2)." },
                new Ability { Id = 49,  AdvancementId = 21, RulesText = "In conflicts, players without the Iron Working advancement must remove population counters first (18.2.3)." },
                new Ability { Id = 50,  AdvancementId = 22, RulesText = "This advancement increases the population limit by one in areas that the holder alone occupies (20.1.3)." },
                new Ability { Id = 51,  AdvancementId = 22, RulesText = "Players with this advancement are immune to the effects of Famine (29.3.1.4)." },
                new Ability { Id = 52,  AdvancementId = 23, RulesText = "When the Primary Victim has this advancement the city is not reduced due to the City Riots calamity (29.5.3.4)" },
                new Ability { Id = 53,  AdvancementId = 23, RulesText = "Five fewer commodity card points must be returned due to the Corruption calamity (29.7.1.3)." },
                new Ability { Id = 54,  AdvancementId = 23, RulesText = "One fewer city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 55,  AdvancementId = 23, RulesText = "This advancement causes 5 fewer face value points of trade cards to be removed for the Banditry calamity (29.9.3.3)." },
                new Ability { Id = 56,  AdvancementId = 24, RulesText = "It discounts the cost of any one Advancement by forty points, provided that the card is purchased simultaneously with Library." },
                new Ability { Id = 57,  AdvancementId = 24, RulesText = "The player's Chronological Advancement Chart (C.A.C.) marker is moved back (left) one fewer space by the Regression calamity (29.9.1.3)." },
                new Ability { Id = 58,  AdvancementId = 26, RulesText = "Players with this advancement lose 2 fewer treasury counters to stock due to the Tempest calamity (29.3.3.6)." },
                new Ability { Id = 59,  AdvancementId = 26, RulesText = "A city is reduced rather than destroyed by the City in Flames calamity (29.4.3.2)." },
                new Ability { Id = 60,  AdvancementId = 26, RulesText = "One fewer city is reduced by the Cyclone calamity (29.6.1.6)." },
                new Ability { Id = 61,  AdvancementId = 28, RulesText = "Eight fewer unit points are lost by a Primary Victim and five fewer unit points are lost by a Secondary Victim of Epidemic (29.6.2.4)." },
                new Ability { Id = 62,  AdvancementId = 29, RulesText = "In conflicts, players with this advancement remove their first population counter after all other players without the Metalworking advancement have removed theirs (18.2.3)." },
                new Ability { Id = 63,  AdvancementId = 30, RulesText = "Players with this advancement construct and maintain ships (16.1.1) after all players without the Military advancement." },
                new Ability { Id = 64,  AdvancementId = 30, RulesText = "Players with this advancement move (17.2.1), after all players without the Military advancement." },
                new Ability { Id = 65,  AdvancementId = 30, RulesText = "You may attack the cities of players with the Diplomacy advancement (17.4.1)." },
                new Ability { Id = 66,  AdvancementId = 30, RulesText = "The first faction is reduced by five unit points in the Civil War calamity (29.4.1.6)." },
                new Ability { Id = 67,  AdvancementId = 30, RulesText = "One fewer city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 68,  AdvancementId = 30, RulesText = "Five fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.4)." },
                new Ability { Id = 69,  AdvancementId = 30, RulesText = "The cost of a Minor Uprising is reduced by 5 (29.8.3.2)." },
                new Ability { Id = 70,  AdvancementId = 31, RulesText = "Players with this advancement may purchase one trade card from the eighth trade card stack for 16 treasury counters (22.5.5)." },
                new Ability { Id = 71,  AdvancementId = 31, RulesText = "Five fewer population counters can counted for city support during the Slave Revolt calamity (29.4.2.2)." },
                new Ability { Id = 72,  AdvancementId = 31, RulesText = "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 73,  AdvancementId = 31, RulesText = "Treasury counters are worth two points when purchasing civilization advances (26.4.2)." },
                new Ability { Id = 74,  AdvancementId = 32, RulesText = "Players with this advancement may increase the tax rate on their cities by one (13.2.1)." },
                new Ability { Id = 75,  AdvancementId = 32, RulesText = "Five fewer barbarian population counters are used for the Barbarian Hordes calamity when the player that drew the calamity has this advancement (29.5.2.2)." },
                new Ability { Id = 76,  AdvancementId = 32, RulesText = "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 77,  AdvancementId = 32, RulesText = "Five additional unit points are annexed due to Tyranny (29.8.1.6)." },
                new Ability { Id = 78,  AdvancementId = 33, RulesText = "Players may replace all units belonging to a single player in one area adjacent by land with their own stock counters. Monotheism or Theology advancements acquired by the subjected player negate this conversion. Pirate cities and barbarian counters may not be converted." },
                new Ability { Id = 79,  AdvancementId = 33, RulesText = "One additional city is reduced by the Iconoclasm and Heresy calamity (29.8.2.5)." },
                new Ability { Id = 80,  AdvancementId = 34, RulesText = "Upon purchase, the player acquires ten points of credit counters in any combination of colors. These credits are permanent but cannot be used the same turn that the Monument advancement is acquired." },
                new Ability { Id = 81,  AdvancementId = 35, RulesText = "The first faction is increased by five unit points for the Civil War calamity(29.4.1.3)." },
                new Ability { Id = 82,  AdvancementId = 35, RulesText = "One fewer city is reduced by the Civil Disorder calamity (29.7.2.2)." },
                new Ability { Id = 83,  AdvancementId = 36, RulesText = "One fewer city is reduced by the Superstition calamity (29.3.2.2)." },
                new Ability { Id = 84,  AdvancementId = 37, RulesText = "Five more population can be counted for city support during the Slave Revolt calamity (29.4.2.3)." },
                new Ability { Id = 85,  AdvancementId = 38, RulesText = "Players ships may carry one additional population counter (17.5.2)." },
                new Ability { Id = 86,  AdvancementId = 38, RulesText = "Players with this advancement may use ships instead of population as casualties in conflicts (18.2.5)." },
                new Ability { Id = 87,  AdvancementId = 38, RulesText = "The first faction is reduced by five unit points in the Civil War calamity (29.4.1.6)." },
                new Ability { Id = 88,  AdvancementId = 38, RulesText = "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 89,  AdvancementId = 38, RulesText = "One fewer city is replaced due to Piracy (29.9.2.4)." },
                new Ability { Id = 90,  AdvancementId = 39, RulesText = "The first faction in the Civil War calamity is reduced by fifteen unit points (29.4.1.3)." },
                new Ability { Id = 91,  AdvancementId = 39, RulesText = "One less city is reduced by the Iconoclasm and Heresy calamity (29.8.2.3)." },
                new Ability { Id = 92,  AdvancementId = 39, RulesText = "Players with the Fundamentalism advancement may not use their special ability on players with this advancement (25.3)." },
                new Ability { Id = 93,  AdvancementId = 40, RulesText = "Players with this advancement may either replace from treasury all units in one adjacent area belonging to one player without the Politics or Cultural Ascendancy advancements, or they may convert five treasury counters from stock to treasury. Pirate cities and barbarian counters may not be annexed with this ability." },
                new Ability { Id = 94,  AdvancementId = 40, RulesText = "Five barbarian population counters are added to the total for the Barbarian Hordes calamity when the player that drew the calamity has this advancement (29.5.2.2)." },
                new Ability { Id = 95,  AdvancementId = 41, RulesText = "Five fewer unit points are lost by the Famine calamity (29.3.1.2)." },
                new Ability { Id = 96,  AdvancementId = 42, RulesText = "Five barbarian population counters are added to the total for the Barbarian Hordes calamity when the player that drew the calamity has this advancement (29.5.2.2)." },
                new Ability { Id = 97,  AdvancementId = 42, RulesText = "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 98,  AdvancementId = 42, RulesText = "Five additional unit points are annexed due to Tyranny (29.8.1.5)." },
                new Ability { Id = 99,  AdvancementId = 42, RulesText = "Players with this advancement may take one commodity card with a face value of two or more (opponent's choice) from up to five players that they have units adjacent to. Players with the Provincial Empire or Public Works advancement are exempt from this special ability." },
                new Ability { Id = 100, AdvancementId = 43, RulesText = "Players with this advancement must spend one additional population counter to construct cities (19.4)." },
                new Ability { Id = 101, AdvancementId = 43, RulesText = "The player's city areas may also have one population counter in them (20.1)." },
                new Ability { Id = 102, AdvancementId = 43, RulesText = "Players with the Provincial Empire advancement may not use their special ability on players with the Public Works advancement (25.6)." },
                new Ability { Id = 103, AdvancementId = 44, RulesText = "Players with this advancement may buy one trade card from the third trade card stack for six treasury counters each turn (22.5.3)." },
                new Ability { Id = 104, AdvancementId = 45, RulesText = "This advancement allows the players population counters to move two areas instead of one so long as the first area has no units from any other player (17.3.1)." },
                new Ability { Id = 105, AdvancementId = 45, RulesText = "Five additional unit points are lost by the Epidemic calamity (29.6.2.4)." },
                new Ability { Id = 106, AdvancementId = 45, RulesText = "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 107, AdvancementId = 46, RulesText = "Five fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.4)." },
                new Ability { Id = 108, AdvancementId = 47, RulesText = "Five fewer population counters can counted for city support during the Slave Revolt calamity (29.4.2.2)." },
                new Ability { Id = 109, AdvancementId = 47, RulesText = "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                new Ability { Id = 110, AdvancementId = 47, RulesText = "Five additional unit points are annexed due to Tyranny (29.8.1.6)." },
                new Ability { Id = 111, AdvancementId = 47, RulesText = "Players with this advancement may return one commodity card for each city instead of reducing them due to the Iconoclasm and Heresy calamity(29.8.2.2)." },
                new Ability { Id = 112, AdvancementId = 48, RulesText = "Three fewer cities are reduced due to Iconoclasm and Heresy (29.8.2.4)." },
                new Ability { Id = 113, AdvancementId = 48, RulesText = "This advancement causes 5 fewer face value points of trade cards to be removed for the Banditry calamity (29.9.3.3)." },
                new Ability { Id = 114, AdvancementId = 48, RulesText = "Players with the Monotheism advancement may not use their special ability on you (25.4)." },
                new Ability { Id = 115, AdvancementId = 49, RulesText = "Players with this advancement may ask up to three players, (one at a time in succession) without the Trade Empire or Wonder of the World advancements, for a single named commodity card. If the player has that card, they must surrender it. Only one trade card may be obtained with this ability each turn." },
                new Ability { Id = 116, AdvancementId = 49, RulesText = "One additional city is reduced by the Cyclone calamity (29.6.1.6)." },
                new Ability { Id = 117, AdvancementId = 49, RulesText = "Five additional unit points are lost by the Epidemic calamity (29.6.2.4)." },
                new Ability { Id = 118, AdvancementId = 50, RulesText = "When returning excess commodity cards (27.1), players with this advancement may convert two population stock to treasury for the face value of each trade card returned." },
                new Ability { Id = 119, AdvancementId = 50, RulesText = "Players with this advancement may increase the number of trade cards they can hold between turns by one (27.2.1)." },
                new Ability { Id = 120, AdvancementId = 51, RulesText = "Players with this advancement may replace from their stock up to five barbarian/pirate population counters in one adjacent area, or one barbarian/pirate city." },
                new Ability { Id = 121, AdvancementId = 51, RulesText = "Players with the this advancement reduce the affect of the Squandered Wealth calamity to five treasury counters returned to stock (29.2.3.3)." },
                new Ability { Id = 122, AdvancementId = 51, RulesText = "One more city is reduced by the Superstition calamity (29.3.2.3)." },
                new Ability { Id = 123, AdvancementId = 52, RulesText = "Players with this advancement may use up to four counters from adjacent areas to build a city in an area without a city site (19.5)." },
                new Ability { Id = 124, AdvancementId = 52, RulesText = "Primary and Secondary Victims with this advancement not also having Engineering (30.18) must remove an additional four unit points from areas adjacent to the affected area for both the Volcanic Eruption and Earthquake calamities (29.2.1.1)." },
                new Ability { Id = 125, AdvancementId = 53, RulesText = "When purchased, the player immediately acquires twenty points of credit counters in any combination of colors. They can not be used the same turn this advancement is purchased." },
                new Ability { Id = 126, AdvancementId = 53, RulesText = "Players with the Trade Empire advancement may not use their special ability on you (25.7)." },
                new Ability { Id = 127, AdvancementId = 54, RulesText = "Players that purchase this advancement immediately acquire five points of credit counters of any one color. They can not be used the same turn this advancement is purchased." }
            };

            return SeedAbilities;
        }
    }
}
