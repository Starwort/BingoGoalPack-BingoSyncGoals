﻿using BingoGoalPackBingoSyncGoals.Icons;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BingoBoardCore.Common.Systems;
using BingoBoardCore.AnimationHelpers;
using System;

namespace BingoGoalPackBingoSyncGoals.Content {
    internal class RegisterGoals : ModSystem {
        static Item die => BingoBoardCore.BingoBoardCore.dieIcon;
        static Item disallow => BingoBoardCore.BingoBoardCore.disallowIcon;
        static readonly Item craft = new(ItemID.WorkBench);

        internal void registerGoals() {
            var kill = new Item(ItemID.CopperShortsword);
            var trash = new Item(ItemID.TrashCan);
            var sell = new Item(ItemID.DiscountCard);
            var swordOrSpear = IconAnimationSystem.registerRandAnimation(
                ItemSets.swords.Concat(ItemSets.spears).ToArray()
            );

            var tiles = IconAnimationSystem.registerRandAnimation(ItemSets.tiles);
            var accessories = IconAnimationSystem.registerRandAnimation(ItemSets.accessories);
            var evilBoss = IconAnimationSystem.registerCycleAnimation(ItemID.BrainofCthulhuTrophy, ItemID.EaterofWorldsTrophy);
            var questFish = IconAnimationSystem.registerRandAnimation(ItemSets.questFish);
            var platforms = IconAnimationSystem.registerRandAnimation(ItemSets.platforms);

            Func<BingoMode, int, bool> notLockout = (mode, _) => mode != BingoMode.Lockout;
            Func<BingoMode, int, bool> twoLockout = (mode, teams) => mode == BingoMode.Lockout && teams == 2;
            Func<BingoMode, int, bool> anyLockout = (mode, _) => mode == BingoMode.Lockout;

            #region Difficulty 0 goals
            register(
                "DownEoC",
                difficulty: 0,
                new Item(ItemID.EyeofCthulhuTrophy),
                new[] {"ME.5.1", "ME.5.2"}
            );
            register(
                "DownKS",
                difficulty: 0,
                new Item(ItemID.KingSlimeTrophy),
                new[] {"ME.3.1", "ME.3.2"}
            );
            register(
                "PutFoodOnPlate",
                difficulty: 0,
                new Item(ItemID.FoodPlatter)
            );
            register(
                "Get999OfTile",
                difficulty: 0,
                tiles,
                text: "999"
            );
            register(
                "FillPiggyBank",
                difficulty: 0,
                new Item(ItemID.PiggyBank)
            );
            register(
                "EatCookedFish",
                difficulty: 0,
                new Item(ItemID.CookedFish)
            );
            register(
                "Suffocate7s",
                difficulty: 0,
                ModContent.GetInstance<Suffocation>().Item,
                text: "7s"
            );
            register(
                "DieToThorns",
                difficulty: 0,
                ModContent.GetInstance<Thorns>().Item,
                modifier: die
            );
            #endregion

            #region Difficulty 1 goals
            register(
                "Get2Spears",
                difficulty: 1,
                IconAnimationSystem.registerRandAnimation(ItemSets.spears),
                text: "2"
            );
            register(
                "Get2Plat",
                difficulty: 1,
                new Item(ItemID.PlatinumCoin),
                text: "2"
            );
            register(
                "DieToAltar",
                difficulty: 1,
                ModContent.GetInstance<Altars>().Item,
                modifier: die
            );
            register(
                "Equip5Accessories",
                difficulty: 1,
                accessories,
                text: "5",
                synergyTypes: new[] {"ME.15"}
            );
            register(
                "GetModifiedWoodSwordBowHammer",
                difficulty: 1,
                IconAnimationSystem.registerCycleAnimation(ItemID.WoodenSword, ItemID.WoodenBow, ItemID.WoodenHammer),
                modifier: craft
            );
            register(
                "ExplodeVillagerEnemySelf",
                difficulty: 1,
                new Item(ItemID.ExplosiveBunny),
                modifier: die,
                text: "3"
            );
            register(
                "GetCookedMarshmallow",
                difficulty: 1,
                new Item(ItemID.CookedMarshmallow)
            );
            register(
                "NoChopTrees",
                difficulty: 1,
                new Item(ItemID.CopperAxe),
                modifier: disallow,
                shouldEnable: notLockout,
                synergyTypes: new[] {"ME.1"}
            );
            register(
                "OpponentChopTrees",
                difficulty: 1,
                new Item(ItemID.CopperAxe),
                modifier: disallow,
                shouldEnable: twoLockout,
                synergyTypes: new[] {"ME.1"}
            );
            #endregion

            #region Difficulty 2 goals
            register(
                "CompleteFishingQuest",
                difficulty: 2,
                questFish,
                text: "1",
                synergyTypes: new[] {"ME.11"}
            );
            register(
                "Get3FrogLegs",
                difficulty: 2,
                new Item(ItemID.SauteedFrogLegs),
                text: "3"
            );
            register(
                "GetRockLobster",
                difficulty: 2,
                new Item(ItemID.RockLobster)
            );
            register(
                "PlaceAllSandcastles",
                difficulty: 2,
                new Item(ItemID.SandcastleBucket),
                text: "4"
            );
            register(
                "PlantAllHerbs",
                difficulty: 2,
                IconAnimationSystem.registerRandAnimation(ItemSets.herbs),
                text: "7",
                modifier: new Item(ItemID.ClayPot)
            );
            register(
                "InvFullOfBlocks",
                difficulty: 2,
                tiles
            );
            register(
                "Have12Buffs",
                difficulty: 2,
                ModContent.GetInstance<AnyBuff>().Item,
                text: "12"
            );
            #endregion

            #region Difficulty 3 goals
            register(
                "KillAnglerWithBoulder",
                difficulty: 3,
                ModContent.GetInstance<Angler>().Item,
                modifier: new Item(ItemID.Boulder)
            );
            register(
                "Stack4BarsOnDungeon",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(ItemSets.lowTierBars),
                modifier: IconAnimationSystem.registerCycleAnimation(ItemID.BlueBrick, ItemID.GreenBrick, ItemID.PinkBrick),
                text: "4"
            );
            register(
                "DrownWithBreathingReed",
                difficulty: 3,
                new Item(ItemID.BreathingReed),
                modifier: die
            );
            register(
                "WearCactusArmour",
                difficulty: 3,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CactusHelmet,
                    ItemID.CactusBreastplate,
                    ItemID.CactusLeggings
                )
            );
            ;
            register(
                "GrowGemTree",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(
                    ItemID.GemTreeAmberSeed,
                    ItemID.GemTreeAmethystSeed,
                    ItemID.GemTreeDiamondSeed,
                    ItemID.GemTreeEmeraldSeed,
                    ItemID.GemTreeRubySeed,
                    ItemID.GemTreeSapphireSeed,
                    ItemID.GemTreeTopazSeed
                )
            );
            register(
                "TrashSharkBait",
                difficulty: 3,
                new Item(ItemID.SharkBait),
                modifier: trash
            );
            register(
                "FillHouseWithBars",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(ItemSets.bars),
                modifier: ModContent.GetInstance<House>().Item
            );
            register(
                "GetAllCampfires",
                difficulty: 3,
                IconAnimationSystem.registerRandAnimation(ItemSets.phmCampfires),
                text: "9"
            );
            #endregion

            #region Difficulty 4 goals
            register(
                "DownEvilBoss",
                difficulty: 4,
                evilBoss,
                synergyTypes: new[] {"ME.4.1", "ME.4.2"}
            );
            register(
                "WearEvilArmour",
                difficulty: 4,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CrimsonHelmet,
                    ItemID.CrimsonScalemail,
                    ItemID.CrimsonGreaves,
                    ItemID.ShadowHelmet,
                    ItemID.ShadowScalemail,
                    ItemID.ShadowGreaves
                ),
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "KillEvilCritter",
                difficulty: 4,
                ModContent.GetInstance<EvilCritter>().Item,
                modifier: kill
            );
            register(
                "Sell100Hellstone",
                difficulty: 4,
                new Item(ItemID.Hellstone),
                modifier: sell,
                text: "100"
            );
            register(
                "SellFlamingMace",
                difficulty: 4,
                new Item(ItemID.FlamingMace),
                modifier: sell
            );
            #endregion

            #region Difficulty 5 goals
            register(
                "BreakLivingTreeLeaves",
                difficulty: 5,
                ModContent.GetInstance<LivingLeaf>().Item,
                modifier: new(ItemID.CopperPickaxe)
            );
            register(
                "EatGrubSoup",
                difficulty: 5,
                new Item(ItemID.GrubSoup)
            );
            register(
                "Get4CritterContainers",
                difficulty: 5,
                IconAnimationSystem.registerRandAnimation(ItemSets.critterContainers),
                text: "4"
            );
            register(
                "GetLemonadeOrAppleJuice",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(ItemID.Lemonade, ItemID.AppleJuice),
                modifier: craft
            );
            register(
                "WearVanityWinnerSet",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PlaguebringerHelmet,
                    ItemID.PlaguebringerChestplate,
                    ItemID.PlaguebringerGreaves,
                    ItemID.RoninHat,
                    ItemID.RoninShirt,
                    ItemID.RoninPants,
                    ItemID.TimelessTravelerHood,
                    ItemID.TimelessTravelerRobe,
                    ItemID.TimelessTravelerBottom,
                    ItemID.FloretProtectorHelmet,
                    ItemID.FloretProtectorChestplate,
                    ItemID.FloretProtectorLegs,
                    ItemID.CapricornMask,
                    ItemID.CapricornChestplate,
                    ItemID.CapricornLegs,
                    ItemID.CapricornTail,
                    ItemID.TVHeadMask,
                    ItemID.TVHeadSuit,
                    ItemID.TVHeadPants
                )
            );
            register(
                "Get4Shrooms",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.GlowingMushroom,
                    ItemID.GreenMushroom,
                    ItemID.Mushroom,
                    ItemID.StrangeGlowingMushroom,
                    ItemID.TealMushroom,
                    ItemID.ViciousMushroom,
                    ItemID.VileMushroom
                ),
                text: "4"
            );
            register(
                "Get3Watches",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CopperWatch,
                    ItemID.TinWatch,
                    ItemID.SilverWatch,
                    ItemID.TungstenWatch,
                    ItemID.GoldWatch,
                    ItemID.PlatinumWatch
                ),
                text: "3"
            );
            register(
                "GetTrash",
                difficulty: 5,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FishingSeaweed,
                    ItemID.OldShoe,
                    ItemID.TinCan
                ),
                text: "3"
            );
            #endregion

            #region Difficulty 6 goals
            register(
                "MakePotions.Magic",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.MagicPowerPotion,
                    ItemID.ManaRegenerationPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Explore",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.MiningPotion,
                    ItemID.ShinePotion,
                    ItemID.NightOwlPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Water",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.WaterWalkingPotion,
                    ItemID.FlipperPotion
                ),
                modifier: craft
            );
            register(
                "MakePotions.Trans",
                difficulty: 6,
                new Item(ItemID.GenderChangePotion),
                modifier: craft
            );
            register( // TODO find/make better icons for these
                "FindBiome.SurfaceMushroom",
                difficulty: 6,
                new Item(ItemID.DarkBlueSolution)
            );
            register(
                "FindBiome.EvilOcean",
                difficulty: 6,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PurpleSolution,
                    ItemID.RedSolution
                ),
                modifier: new(ItemID.TreasureMap)
            );
            register(
                "FindBiome.EvilDesert",
                difficulty: 6,
                IconAnimationSystem.registerRandAnimation(
                    ItemID.EbonsandBlock,
                    ItemID.CorruptSandstone,
                    ItemID.CorruptHardenedSand,
                    ItemID.CrimsandBlock,
                    ItemID.CrimsonSandstone,
                    ItemID.CrimsonHardenedSand
                )
            );
            register(
                "MakePotions.Titan",
                difficulty: 6,
                new Item(ItemID.TitanPotion),
                modifier: craft
            );
            #endregion

            #region Difficulty 7 goals
            register(
                "DeadMenTellNoTales",
                difficulty: 7,
                ModContent.GetInstance<DeadMenTellNoTales>().Item,
                synergyTypes: new[] {"ME.9"}
            );
            register(
                "Get5WoodArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.WoodHelmet,
                    ItemID.WoodBreastplate,
                    ItemID.WoodGreaves,
                    ItemID.RichMahoganyHelmet,
                    ItemID.RichMahoganyBreastplate,
                    ItemID.RichMahoganyGreaves,
                    ItemID.EbonwoodHelmet,
                    ItemID.EbonwoodBreastplate,
                    ItemID.EbonwoodGreaves,
                    ItemID.ShadewoodHelmet,
                    ItemID.ShadewoodBreastplate,
                    ItemID.ShadewoodGreaves,
                    ItemID.PearlwoodHelmet,
                    ItemID.PearlwoodBreastplate,
                    ItemID.PearlwoodGreaves,
                    ItemID.BorealWoodHelmet,
                    ItemID.BorealWoodBreastplate,
                    ItemID.BorealWoodGreaves,
                    ItemID.PalmWoodHelmet,
                    ItemID.PalmWoodBreastplate,
                    ItemID.PalmWoodGreaves,
                    ItemID.AshWoodHelmet,
                    ItemID.AshWoodBreastplate,
                    ItemID.AshWoodGreaves,
                    ItemID.SpookyHelmet,
                    ItemID.SpookyBreastplate,
                    ItemID.SpookyLeggings
                ),
                text: "5",
                synergyTypes: new[] {"ME.14"}
            );
            register(
                "WearPumpkinArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.PumpkinHelmet,
                    ItemID.PumpkinBreastplate,
                    ItemID.PumpkinLeggings
                )
            );
            register(
                "WearFossilArmour",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FossilHelm,
                    ItemID.FossilShirt,
                    ItemID.FossilPants
                )
            );
            register(
                "GetSummons",
                difficulty: 7,
                IconAnimationSystem.registerRandAnimation(ItemSets.summonStaves),
                text: "7"
            );
            register(
                "Get100Gel",
                difficulty: 7,
                new Item(ItemID.Gel),
                text: "100"
            );
            register(
                "StackHighTierBars",
                difficulty: 7,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.CrimtaneBar,
                    ItemID.MeteoriteBar,
                    ItemID.HellstoneBar,
                    ItemID.DemoniteBar,
                    ItemID.MeteoriteBar,
                    ItemID.HellstoneBar
                ),
                modifier: new(ItemID.SnowBlock)
            );
            register(
                "Get4GrassSeeds",
                difficulty: 7,
                IconAnimationSystem.registerRandAnimation(ItemSets.grassSeeds),
                text: "4"
            );
            #endregion

            #region Difficulty 8 goals
            register(
                "GetGemCritterCage",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(ItemSets.gemCritterCages)
            );
            register(
                "Get99Seeds",
                difficulty: 8,
                new Item(ItemID.Seed),
                text: "99"
            );
            register(
                "HelpGolfer",
                difficulty: 8,
                ModContent.GetInstance<Golfer>().Item,
                shouldEnable: anyLockout
            );
            register(
                "Get6Arrows",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(ItemSets.arrows),
                text: "6"
            );
            register(
                "GetSilverBullets",
                difficulty: 8,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.SilverBullet,
                    ItemID.TungstenBullet
                )
            );
            register(
                "Get8Hooks",
                difficulty: 8,
                IconAnimationSystem.registerRandAnimation(ItemSets.hooks),
                text: "8"
            );
            register(
                "Have5Debuffs",
                difficulty: 8,
                ModContent.GetInstance<AnyDebuff>().Item,
                text: "5"
            );
            #endregion

            #region Difficulty 9 goals
            register(
                "HaveMaxHealth",
                difficulty: 9,
                new Item(ItemID.LifeCrystal),
                text: "400"
            );
            register(
                "HaveMaxMana",
                difficulty: 9,
                new Item(ItemID.ManaCrystal),
                text: "200"
            );
            register(
                "UseFairy",
                difficulty: 9,
                IconAnimationSystem.registerCycleAnimation(
                    ItemID.FairyCritterPink,
                    ItemID.FairyCritterGreen,
                    ItemID.FairyCritterBlue
                )
            );
            register(
                "DownArmy",
                difficulty: 9,
                new Item(ItemID.GoblinBattleStandard),
                modifier: kill
            );
            register(
                "UsePoisonDart",
                difficulty: 9,
                new Item(ItemID.PoisonDart),
                modifier: IconAnimationSystem.registerCycleAnimation(
                    ItemID.Blowpipe,
                    ItemID.Blowgun
                )
            );
            register(
                "Get5Minecarts",
                difficulty: 9,
                IconAnimationSystem.registerRandAnimation(ItemSets.minecarts),
                text: "5"
            );
            register(
                "DownKSMelee",
                difficulty: 9,
                new Item(ItemID.KingSlimeTrophy),
                modifier: swordOrSpear,
                synergyTypes: new[] {"ME.3.2"}
            );
            register(
                "GetTorchGodsFavour",
                difficulty: 9,
                new Item(ItemID.TorchGodsFavor)
            );
            #endregion

            #region Difficulty 10 goals
            register(
                "MakePiano",
                difficulty: 10,
                IconAnimationSystem.registerRandAnimation(ItemSets.craftablePianos),
                modifier: craft
            );
            register(
                "ThrowBonesAtTargetDummy",
                difficulty: 10,
                new Item(ItemID.Bone),
                modifier: new(ItemID.TargetDummy),
                text: "35"
            );
            register(
                "DownSkele",
                difficulty: 10,
                new Item(ItemID.SkeletronTrophy),
                synergyTypes: new[] {"ME.7.1", "ME.7.2"}
            );
            register(
                "NoEquipAccessories",
                difficulty: 10,
                accessories,
                modifier: disallow,
                synergyTypes: new[] {"ME.1", "ME.15"},
                shouldEnable: notLockout
            );
            register(
                "OpponentEquipAccessories",
                difficulty: 10,
                accessories,
                modifier: disallow,
                synergyTypes: new[] {"ME.1", "ME.15"},
                shouldEnable: twoLockout
            );
            register(
                "NoPlatforms",
                difficulty: 10,
                platforms,
                modifier: disallow,
                synergyTypes: new[] {"ME.1"},
                shouldEnable: notLockout
            );
            register(
                "OpponentPlatforms",
                difficulty: 10,
                platforms,
                modifier: disallow,
                synergyTypes: new[] {"ME.1"},
                shouldEnable: twoLockout
            );
            register(
                "GetAnnouncementBox",
                difficulty: 10,
                new Item(ItemID.AnnouncementBox)
            );
            register(
                "TrashDungeonWeapon",
                difficulty: 10,
                IconAnimationSystem.registerRandAnimation(ItemSets.dungeonWeapons),
                modifier: trash
            );
            register(
                "TrashWaterBolt",
                difficulty: 10,
                new Item(ItemID.WaterBolt),
                modifier: trash
            );
            #endregion

            #region Difficulty 11 goals
            register(
                "RockBottom",
                difficulty: 11,
                ModContent.GetInstance<RockBottom>().Item
            );
            register(
                "HelpStylist",
                difficulty: 11,
                ModContent.GetInstance<Stylist>().Item,
                shouldEnable: anyLockout
            );
            register(
                "IntoOrbit",
                difficulty: 11,
                ModContent.GetInstance<IntoOrbit>().Item
            );
            register(
                "DownKSSpace",
                difficulty: 11,
                new Item(ItemID.KingSlimeTrophy),
                modifier: ModContent.GetInstance<IntoOrbit>().Item
            );
            register(
                "See3BlazingWheels",
                difficulty: 11,
                ModContent.GetInstance<BlazingWheel>().Item,
                text: "3"
            );
            register(
                "TraverseWholeWorld",
                difficulty: 11,
                new Item(ItemID.TrifoldMap)
            );
            register(
                "FindTemple",
                difficulty: 11,
                ModContent.GetInstance<TempleRaider>().Item
            );
            register(
                "Get5GemStaves",
                difficulty: 11,
                IconAnimationSystem.registerRandAnimation(ItemSets.gemStaves),
                text: "5"
            );
            #endregion

            #region Difficulty 12 goals
            #endregion

            #region Difficulty 13 goals
            #endregion

            #region Difficulty 14 goals
            #endregion

            #region Difficulty 15 goals
            #endregion

            #region Difficulty 16 goals
            #endregion

            #region Difficulty 17 goals
            #endregion

            #region Difficulty 18 goals
            #endregion

            #region Difficulty 19 goals
            #endregion

            #region Difficulty 20 goals
            #endregion

            #region Difficulty 21 goals
            #endregion

            #region Difficulty 22 goals
            #endregion

            #region Difficulty 23 goals
            #endregion

            #region Difficulty 24 goals
            #endregion
        }

        public override void PostSetupContent() {
            ItemSets.load();
            registerGoals();
        }
    }
}
