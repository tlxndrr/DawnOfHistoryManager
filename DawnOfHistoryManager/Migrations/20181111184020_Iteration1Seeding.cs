using Microsoft.EntityFrameworkCore.Migrations;

namespace DawnOfHistoryManager.Migrations
{
    public partial class Iteration1Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Advancements",
                columns: new[] { "Id", "BaseCost", "CreditAdvancementId", "CreditAdvancementValue", "CreditArt", "CreditCivic", "CreditCraft", "CreditReligion", "CreditScience", "IsArt", "IsCivic", "IsCraft", "IsReligion", "IsScience", "Name", "Points" },
                values: new object[,]
                {
                    { 2, 260, null, null, 0, 10, 0, 0, 5, false, true, false, false, false, "Advanced Military", 3 },
                    { 31, 230, null, null, 0, 0, 10, 0, 5, false, false, true, false, false, "Mining", 3 },
                    { 32, 60, 23, 10, 0, 10, 0, 5, 0, false, true, false, false, false, "Monarchy", 1 },
                    { 33, 240, null, null, 0, 5, 0, 10, 0, false, false, false, true, false, "Monotheism", 3 },
                    { 34, 180, 53, 20, 0, 0, 5, 5, 0, false, false, true, true, false, "Monument", 2 },
                    { 35, 80, 19, 10, 10, 0, 0, 5, 0, true, false, false, false, false, "Music", 1 },
                    { 36, 50, 34, 10, 5, 0, 0, 5, 0, true, false, false, true, false, "Mysticism", 1 },
                    { 38, 160, 14, 20, 0, 10, 5, 0, 0, false, true, false, false, false, "Naval Warfare", 2 },
                    { 39, 240, null, null, 0, 0, 0, 5, 5, false, false, false, true, true, "Philosophy", 3 },
                    { 40, 230, null, null, 10, 0, 0, 5, 0, true, false, false, false, false, "Politics", 3 },
                    { 41, 60, 3, 10, 5, 0, 10, 0, 0, false, false, true, false, false, "Pottery", 1 },
                    { 42, 260, null, null, 0, 10, 5, 0, 0, false, true, false, false, false, "Provincial Empire", 3 },
                    { 43, 230, null, null, 0, 10, 5, 0, 0, false, true, false, false, false, "Public Works", 3 },
                    { 44, 130, 40, 20, 10, 5, 0, 0, 0, false, true, false, false, false, "Rhetoric", 2 },
                    { 45, 220, null, null, 0, 0, 10, 0, 5, false, false, true, false, false, "Roadbuilding", 3 },
                    { 46, 50, 5, 10, 10, 5, 0, 0, 0, true, false, false, false, false, "Sculpture", 1 },
                    { 47, 80, 51, 10, 0, 5, 0, 5, 0, false, true, false, true, false, "Theocracy", 1 },
                    { 48, 250, null, null, 0, 0, 0, 10, 5, false, false, false, true, false, "Theology", 3 },
                    { 49, 260, null, null, 0, 5, 10, 0, 0, false, false, true, false, false, "Trade Empire", 3 },
                    { 50, 180, 49, 20, 0, 0, 10, 5, 0, false, false, true, false, false, "Trade Routes", 2 },
                    { 51, 160, 48, 20, 0, 5, 0, 10, 0, false, false, false, true, false, "Universal Doctrine", 2 },
                    { 52, 50, 15, 10, 0, 10, 0, 0, 5, false, true, false, false, false, "Urbanism", 1 },
                    { 53, 280, null, null, 5, 0, 5, 0, 0, true, false, true, false, false, "Wonder of the World", 3 },
                    { 54, 60, 8, 10, 0, 5, 0, 0, 5, false, true, false, false, true, "Written Record", 1 },
                    { 30, 170, 2, 20, 0, 10, 5, 0, 0, false, true, false, false, false, "Military", 2 },
                    { 29, 90, 30, 10, 0, 0, 10, 0, 5, false, false, true, false, false, "Metalworking", 1 },
                    { 37, 60, 25, 10, 5, 0, 0, 10, 0, false, false, false, true, false, "Mythology", 1 },
                    { 27, 240, null, null, 10, 10, 10, 10, 10, true, false, false, false, true, "Mathematics", 3 },
                    { 3, 120, 13, 20, 0, 0, 10, 0, 5, false, false, true, false, false, "Agriculture", 2 },
                    { 4, 270, null, null, 0, 0, 5, 0, 10, false, false, false, false, true, "Anatomy", 3 },
                    { 5, 140, 31, 20, 10, 0, 0, 0, 5, true, false, false, false, false, "Architecture", 2 },
                    { 6, 80, 7, 10, 0, 0, 0, 5, 10, false, false, false, false, true, "Astronavigation", 1 },
                    { 28, 140, 4, 20, 0, 0, 5, 0, 10, false, false, false, false, true, "Medicine", 2 },
                    { 8, 160, 24, 20, 5, 0, 0, 0, 10, false, false, false, false, true, "Cartography", 2 },
                    { 9, 50, 38, 10, 5, 0, 10, 0, 0, false, false, true, false, false, "Cloth Making", 1 },
                    { 10, 90, 50, 10, 0, 5, 0, 0, 10, false, false, false, false, true, "Coinage", 1 },
                    { 11, 280, null, null, 10, 0, 0, 5, 0, true, false, false, false, false, "Cultural Ascendancy", 3 },
                    { 12, 80, 20, 10, 0, 0, 5, 10, 0, false, false, false, true, false, "Deism", 1 },
                    { 13, 220, null, null, 5, 10, 0, 0, 0, false, true, false, false, false, "Democracy", 3 },
                    { 14, 270, null, null, 5, 0, 0, 10, 0, false, false, false, true, false, "Diaspora", 3 },
                    { 7, 180, 43, 20, 0, 5, 0, 0, 10, false, false, false, false, true, "Calendar", 2 },
                    { 16, 80, 44, 10, 10, 0, 0, 5, 0, true, false, false, false, false, "Drama and Poetry", 1 },
                    { 15, 180, 42, 20, 10, 5, 0, 0, 0, true, false, false, false, false, "Diplomacy", 2 },
                    { 26, 60, 18, 10, 0, 0, 10, 0, 5, false, false, true, false, false, "Masonry", 1 },
                    { 25, 110, 27, 20, 10, 10, 5, 5, 5, true, true, false, false, false, "Literacy", 2 },
                    { 23, 170, 11, 20, 0, 10, 0, 5, 0, false, true, false, false, false, "Law", 2 },
                    { 22, 200, null, null, 0, 0, 10, 0, 5, false, false, true, false, false, "Irrigation", 3 },
                    { 24, 220, null, null, 5, 0, 0, 0, 10, false, false, false, false, true, "Library", 3 },
                    { 20, 150, 33, 20, 5, 0, 0, 10, 0, false, false, false, true, false, "Fundamentalism", 2 },
                    { 19, 160, 33, 20, 0, 0, 5, 10, 0, false, false, false, true, false, "Enlightenment", 2 },
                    { 18, 160, 45, 20, 0, 0, 5, 0, 5, false, false, true, false, true, "Engineering", 2 },
                    { 17, 60, 28, 10, 5, 5, 5, 5, 10, false, false, false, false, true, "Empiricism", 1 },
                    { 21, 200, 2, 10, 0, 0, 10, 0, 5, false, false, true, false, false, "Iron Working", 3 }
                });

            migrationBuilder.InsertData(
                table: "Civs",
                columns: new[] { "Id", "AstEarlyBronze", "AstEarlyIron", "AstLateBronze", "AstLateIron", "AstStone", "Name" },
                values: new object[,]
                {
                    { 16, 7, 12, 10, 16, 3, "Indus" },
                    { 10, 7, 13, 10, 16, 4, "Dravidia" },
                    { 15, 7, 13, 10, 16, 4, "Iberia" },
                    { 14, 7, 13, 10, 16, 4, "Hatti" },
                    { 13, 7, 13, 10, 16, 4, "Persia" },
                    { 12, 7, 13, 10, 16, 4, "Nubia" },
                    { 11, 7, 13, 10, 16, 4, "Kushan" },
                    { 9, 8, 13, 10, 16, 4, "Maurya" },
                    { 3, 7, 13, 11, 16, 5, "Celts" },
                    { 7, 7, 13, 10, 16, 4, "Carthage" },
                    { 6, 7, 13, 10, 16, 4, "Babylon" },
                    { 5, 8, 13, 11, 16, 4, "Rome" },
                    { 4, 8, 13, 11, 16, 4, "Assyria" },
                    { 2, 8, 14, 11, 16, 5, "Saba" },
                    { 1, 8, 14, 11, 16, 5, "Minoa" },
                    { 17, 7, 12, 10, 16, 3, "Parthia" },
                    { 8, 7, 13, 10, 16, 4, "Hellas" },
                    { 18, 6, 12, 9, 16, 3, "Egypt" }
                });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "AdvancementId", "RulesText" },
                values: new object[,]
                {
                    { 1, 2, "The player with this advancement may use population counters from areas adjacent by land as casualties in conflicts. At least one population counter must remain in the areas used (18.2.4)." },
                    { 93, 40, "Players with this advancement may either replace from treasury all units in one adjacent area belonging to one player without the Politics or Cultural Ascendancy advancements, or they may convert five treasury counters from stock to treasury. Pirate cities and barbarian counters may not be annexed with this ability." },
                    { 92, 39, "Players with the Fundamentalism advancement may not use their special ability on players with this advancement (25.3)." },
                    { 91, 39, "One less city is reduced by the Iconoclasm and Heresy calamity (29.8.2.3)." },
                    { 90, 39, "The first faction in the Civil War calamity is reduced by fifteen unit points (29.4.1.3)." },
                    { 89, 38, "One fewer city is replaced due to Piracy (29.9.2.4)." },
                    { 88, 38, "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 87, 38, "The first faction is reduced by five unit points in the Civil War calamity (29.4.1.6)." },
                    { 86, 38, "Players with this advancement may use ships instead of population as casualties in conflicts (18.2.5)." },
                    { 85, 38, "Players ships may carry one additional population counter (17.5.2)." },
                    { 84, 37, "Five more population can be counted for city support during the Slave Revolt calamity (29.4.2.3)." },
                    { 83, 36, "One fewer city is reduced by the Superstition calamity (29.3.2.2)." },
                    { 82, 35, "One fewer city is reduced by the Civil Disorder calamity (29.7.2.2)." },
                    { 81, 35, "The first faction is increased by five unit points for the Civil War calamity(29.4.1.3)." },
                    { 94, 40, "Five barbarian population counters are added to the total for the Barbarian Hordes calamity when the player that drew the calamity has this advancement (29.5.2.2)." },
                    { 80, 34, "Upon purchase, the player acquires ten points of credit counters in any combination of colors. These credits are permanent but cannot be used the same turn that the Monument advancement is acquired." },
                    { 78, 33, "Players may replace all units belonging to a single player in one area adjacent by land with their own stock counters. Monotheism or Theology advancements acquired by the subjected player negate this conversion. Pirate cities and barbarian counters may not be converted." },
                    { 77, 32, "Five additional unit points are annexed due to Tyranny (29.8.1.6)." },
                    { 76, 32, "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 75, 32, "Five fewer barbarian population counters are used for the Barbarian Hordes calamity when the player that drew the calamity has this advancement (29.5.2.2)." },
                    { 74, 32, "Players with this advancement may increase the tax rate on their cities by one (13.2.1)." },
                    { 73, 31, "Treasury counters are worth two points when purchasing civilization advances (26.4.2)." },
                    { 72, 31, "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 71, 31, "Five fewer population counters can counted for city support during the Slave Revolt calamity (29.4.2.2)." },
                    { 70, 31, "Players with this advancement may purchase one trade card from the eighth trade card stack for 16 treasury counters (22.5.5)." },
                    { 69, 30, "The cost of a Minor Uprising is reduced by 5 (29.8.3.2)." },
                    { 68, 30, "Five fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.4)." },
                    { 67, 30, "One fewer city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 66, 30, "The first faction is reduced by five unit points in the Civil War calamity (29.4.1.6)." },
                    { 79, 33, "One additional city is reduced by the Iconoclasm and Heresy calamity (29.8.2.5)." },
                    { 65, 30, "You may attack the cities of players with the Diplomacy advancement (17.4.1)." },
                    { 95, 41, "Five fewer unit points are lost by the Famine calamity (29.3.1.2)." },
                    { 97, 42, "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 125, 53, "When purchased, the player immediately acquires twenty points of credit counters in any combination of colors. They can not be used the same turn this advancement is purchased." },
                    { 124, 52, "Primary and Secondary Victims with this advancement not also having Engineering (30.18) must remove an additional four unit points from areas adjacent to the affected area for both the Volcanic Eruption and Earthquake calamities (29.2.1.1)." },
                    { 123, 52, "Players with this advancement may use up to four counters from adjacent areas to build a city in an area without a city site (19.5)." },
                    { 122, 51, "One more city is reduced by the Superstition calamity (29.3.2.3)." },
                    { 121, 51, "Players with the this advancement reduce the affect of the Squandered Wealth calamity to five treasury counters returned to stock (29.2.3.3)." },
                    { 120, 51, "Players with this advancement may replace from their stock up to five barbarian/pirate population counters in one adjacent area, or one barbarian/pirate city." },
                    { 119, 50, "Players with this advancement may increase the number of trade cards they can hold between turns by one (27.2.1)." },
                    { 118, 50, "When returning excess commodity cards (27.1), players with this advancement may convert two population stock to treasury for the face value of each trade card returned." },
                    { 117, 49, "Five additional unit points are lost by the Epidemic calamity (29.6.2.4)." },
                    { 116, 49, "One additional city is reduced by the Cyclone calamity (29.6.1.6)." },
                    { 115, 49, "Players with this advancement may ask up to three players, (one at a time in succession) without the Trade Empire or Wonder of the World advancements, for a single named commodity card. If the player has that card, they must surrender it. Only one trade card may be obtained with this ability each turn." },
                    { 114, 48, "Players with the Monotheism advancement may not use their special ability on you (25.4)." },
                    { 113, 48, "This advancement causes 5 fewer face value points of trade cards to be removed for the Banditry calamity (29.9.3.3)." },
                    { 96, 42, "Five barbarian population counters are added to the total for the Barbarian Hordes calamity when the player that drew the calamity has this advancement (29.5.2.2)." },
                    { 112, 48, "Three fewer cities are reduced due to Iconoclasm and Heresy (29.8.2.4)." },
                    { 110, 47, "Five additional unit points are annexed due to Tyranny (29.8.1.6)." },
                    { 109, 47, "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 108, 47, "Five fewer population counters can counted for city support during the Slave Revolt calamity (29.4.2.2)." },
                    { 107, 46, "Five fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.4)." },
                    { 106, 45, "One additional city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 105, 45, "Five additional unit points are lost by the Epidemic calamity (29.6.2.4)." },
                    { 104, 45, "This advancement allows the players population counters to move two areas instead of one so long as the first area has no units from any other player (17.3.1)." },
                    { 103, 44, "Players with this advancement may buy one trade card from the third trade card stack for six treasury counters each turn (22.5.3)." },
                    { 102, 43, "Players with the Provincial Empire advancement may not use their special ability on players with the Public Works advancement (25.6)." },
                    { 101, 43, "The player's city areas may also have one population counter in them (20.1)." },
                    { 100, 43, "Players with this advancement must spend one additional population counter to construct cities (19.4)." },
                    { 99, 42, "Players with this advancement may take one commodity card with a face value of two or more (opponent's choice) from up to five players that they have units adjacent to. Players with the Provincial Empire or Public Works advancement are exempt from this special ability." },
                    { 98, 42, "Five additional unit points are annexed due to Tyranny (29.8.1.5)." },
                    { 111, 47, "Players with this advancement may return one commodity card for each city instead of reducing them due to the Iconoclasm and Heresy calamity(29.8.2.2)." },
                    { 126, 53, "Players with the Trade Empire advancement may not use their special ability on you (25.7)." },
                    { 64, 30, "Players with this advancement move (17.2.1), after all players without the Military advancement." },
                    { 62, 29, "In conflicts, players with this advancement remove their first population counter after all other players without the Metalworking advancement have removed theirs (18.2.3)." },
                    { 29, 14, "The Coastal Migration calamity (29.6.3.3) has no effect on players with this advancement." },
                    { 28, 13, "Ten fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.5)." },
                    { 27, 13, "One fewer city is reduced by the Civil Disorder (29.7.2.2) calamity." },
                    { 26, 13, "The first faction is increased by ten unit points for the Civil War (29.4.1.3) calamity." },
                    { 25, 13, "This advancement suppresses tax revolts (13.3), they do not occur to players with this advancement." },
                    { 24, 12, "One fewer city is reduced by the Superstition (29.3.2.2) calamity." },
                    { 23, 11, "The players cities require one additional population marker for support (21.1.1)." },
                    { 22, 11, "Players with the Politics (25.5) advancement may not use its special ability on players with this advancement." },
                    { 21, 11, "Your cities, ships and population counters can only be attacked by other players having either the Cultural Ascendancy or Advanced Military (17.4.2) advancements. (Barbarian/Pirate exempt)" },
                    { 20, 10, "Five additional face value commodity card points must be returned to the trade card stacks due to Corruption (29.7.1.2)." },
                    { 19, 10, "Players with this advancement may increase or decrease their tax rate by one (13.2.2)." },
                    { 18, 9, "Increases the players ship movement by one area (17.2.2)." },
                    { 17, 8, "One additional city is replaced due to Piracy (29.9.2.4)." },
                    { 30, 14, "Players with the Diaspora (30.14) advancement may either place a city, or completely populate an empty area on the map adjacent to an area they alone occupy. Areas separated by water borders are not considered adjacent for this ability." },
                    { 16, 8, "Players with this advancement may retain two ships of their choice for the Tempest calamity (29.3.3.5)." },
                    { 14, 7, "Five fewer unit points are lost by a Secondary Victim of Famine (29.3.1.3)." },
                    { 13, 6, "Players with this advancement may retain two ships of their choice for the Tempest calamity (29.3.3.4)." },
                    { 12, 6, "The player's ships can enter dark blue open sea areas (17.2.3)." },
                    { 11, 5, "Once each turn, up to half of the population cost of building a city can be paid with treasury counters (19.1.3)." },
                    { 10, 4, "This advancement causes eight fewer unit points to be lost as the Primary Victim of Epidemic, and five fewer points for a Secondary Victim (29.6.2.4)." },
                    { 9, 4, "When purchased, this advancement allows the player to immediately acquire up to two additional science advancements valued under 100 points. Cards with dual groups (colors) are eligible. The player may not acquire advancements that they already have." },
                    { 8, 3, "The ability of this card is suppressed when the player is the Primary Victim of Famine (29.3.1.4)." },
                    { 7, 3, "This advancement increases the population limit by one in areas that the holder alone occupies (20.1.3)." },
                    { 6, 2, "The Cultural Ascendancy (30.11) advancement held by other players is neutralized. You may initiate conflicts with them." },
                    { 5, 2, "The cost of a Minor Uprising is reduced by 5 (29.8.3.2)." },
                    { 4, 2, "Five fewer unit points are lost to the beneficiary in the Tyranny calamity (29.8.1.4)." },
                    { 3, 2, "One additional city is retained in the Civil Disorder (29.7.2.2) calamity." },
                    { 2, 2, "This advancement reduces the first faction in Civil War by five unit points, taken from the beneficiaries selection of 20 unit points. (29.4.1.8)." },
                    { 15, 8, "This advancement allows the player to purchase one trade card from the seventh stack for 14 treasury counters each turn (22.2.4)." },
                    { 63, 30, "Players with this advancement construct and maintain ships (16.1.1) after all players without the Military advancement." },
                    { 31, 14, "Players with this advancement must hold one fewer trade card between turns (27.2.2)." },
                    { 33, 15, "One additional city is captured or destroyed by the Treachery calamity(29.2.2.3)." },
                    { 61, 28, "Eight fewer unit points are lost by a Primary Victim and five fewer unit points are lost by a Secondary Victim of Epidemic (29.6.2.4)." },
                    { 60, 26, "One fewer city is reduced by the Cyclone calamity (29.6.1.6)." },
                    { 59, 26, "A city is reduced rather than destroyed by the City in Flames calamity (29.4.3.2)." },
                    { 58, 26, "Players with this advancement lose 2 fewer treasury counters to stock due to the Tempest calamity (29.3.3.6)." },
                    { 57, 24, "The player's Chronological Advancement Chart (C.A.C.) marker is moved back (left) one fewer space by the Regression calamity (29.9.1.3)." },
                    { 56, 24, "It discounts the cost of any one Advancement by forty points, provided that the card is purchased simultaneously with Library." },
                    { 55, 23, "This advancement causes 5 fewer face value points of trade cards to be removed for the Banditry calamity (29.9.3.3)." },
                    { 54, 23, "One fewer city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 53, 23, "Five fewer commodity card points must be returned due to the Corruption calamity (29.7.1.3)." },
                    { 52, 23, "When the Primary Victim has this advancement the city is not reduced due to the City Riots calamity (29.5.3.4)" },
                    { 51, 22, "Players with this advancement are immune to the effects of Famine (29.3.1.4)." },
                    { 50, 22, "This advancement increases the population limit by one in areas that the holder alone occupies (20.1.3)." },
                    { 49, 21, "In conflicts, players without the Iron Working advancement must remove population counters first (18.2.3)." },
                    { 32, 15, "Your cities can only be attacked by other players having either the Diplomacy or Military (17.4.1) advancements. (Barbarian/Pirate exempt.)" },
                    { 48, 20, "Players with this advancement have their Chronological Advancement Chart (C.A.C.) marker moved back (left) one additional space due to the Regression calamity (29.9.1.2)." },
                    { 46, 19, "Five fewer population can be counted for city support during the Slave Revolt calamity (29.4.2.3)." },
                    { 45, 19, "One fewer city is reduced by the Superstition calamity (29.3.2.2)." },
                    { 44, 18, "Two fewer cities are reduced by the Cyclone calamity (29.6.1.7)." },
                    { 43, 18, "A primary or Secondary Victim with this advancement removes a maximum of seven unit points from a flood plain due to the Flood Calamity (29.5.1.4). When the Primary Victim has this advancement and has no units on a flood plain, one of their coastal cities is reduced instead of eliminated." },
                    { 42, 18, "A city is reduced rather than destroyed by the City in Flames calamity (29.4.3.2)." },
                    { 41, 18, "Players with this advancement lose 3 fewer treasury counters to stock due to the Tempest calamity (29.3.3.7)." },
                    { 40, 18, "A city is reduced rather than destroyed by the Earthquake calamity (29.2.1.4) when the primary victim. Immune to the secondary effects of the Earthquake calamity." },
                    { 39, 18, "Primary and Secondary Victims with the Urbanism (30.50) advancement not also having this advancement must remove an additional four unit points from areas adjacent to the affected area for both the Volcanic Eruption and Earthquake calamities (29.2.1.1)." },
                    { 38, 18, "Players with this advancement require one less population counter when attacking cities of players without this advancement. The defending cities are replaced with one fewer population counter (18.3.5)." },
                    { 37, 18, "For conflicts, this advancement increases the value of the players cities by one. Attacking players must add an additional population counter, and one additional population counter is added when the city is replaced for conflict resolution (18.3.5)." },
                    { 36, 17, "Players with this advancement are not affected by the Squandered Wealth calamity (29.2.3.3)." },
                    { 35, 16, "One fewer city is reduced by the Civil Disorder calamity (29.7.2.3)." },
                    { 34, 16, "The first faction is increased by five unit points for the Civil War calamity(29.4.1.3)." },
                    { 47, 20, "In the Special Abilities Phase (25.3), players with this advancement may destroy all units in one area adjacent by land. Players with the Fundamentalism or Philosophy advancement and the Barbarian/Pirate are exempt." },
                    { 127, 54, "Players that purchase this advancement immediately acquire five points of credit counters of any one color. They can not be used the same turn this advancement is purchased." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Abilities",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Civs",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Advancements",
                keyColumn: "Id",
                keyValue: 54);
        }
    }
}
