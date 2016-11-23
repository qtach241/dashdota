using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;

namespace TableStorage.Models
{
    public class GameStateEntity : TableEntity
    {
        public GameStateEntity()
        {
        }

        public GameStateEntity(GameState gs)
        {
            MatchId = gs.Map.MatchId;
            Name = gs.Player.Name;
            Team = gs.Player.Team.ToString();
            ClockTime = gs.Map.ClockTime;
            Hero = gs.Hero.Name;
            Level = gs.Hero.Level;
            GoldPerMinute = gs.Player.GoldPerMinute;
            ExperiencePerMinute = gs.Player.ExperiencePerMinute;

            Networth = gs.Player.Gold +
                ItemPrice[gs.Items.Slot0.Name] +
                ItemPrice[gs.Items.Slot1.Name] +
                ItemPrice[gs.Items.Slot2.Name] +
                ItemPrice[gs.Items.Slot3.Name] +
                ItemPrice[gs.Items.Slot4.Name] +
                ItemPrice[gs.Items.Slot5.Name] +
                ItemPrice[gs.Items.Stash0.Name] +
                ItemPrice[gs.Items.Stash1.Name] +
                ItemPrice[gs.Items.Stash2.Name] +
                ItemPrice[gs.Items.Stash3.Name] +
                ItemPrice[gs.Items.Stash4.Name] +
                ItemPrice[gs.Items.Stash5.Name];

            Item0 = gs.Items.Slot0.Name;
            Item1 = gs.Items.Slot1.Name;
            Item2 = gs.Items.Slot2.Name;
            Item3 = gs.Items.Slot3.Name;
            Item4 = gs.Items.Slot4.Name;
            Item5 = gs.Items.Slot5.Name;

            NoTp = ((Item0 != "item_tpscroll") && (Item0 != "item_travel_boots") && (Item0 != "item_travel_boots_2")
                && (Item1 != "item_tpscroll") && (Item1 != "item_travel_boots") && (Item1 != "item_travel_boots_2")
                && (Item2 != "item_tpscroll") && (Item2 != "item_travel_boots") && (Item2 != "item_travel_boots_2")
                && (Item3 != "item_tpscroll") && (Item3 != "item_travel_boots") && (Item3 != "item_travel_boots_2")
                && (Item4 != "item_tpscroll") && (Item4 != "item_travel_boots") && (Item4 != "item_travel_boots_2")
                && (Item5 != "item_tpscroll") && (Item5 != "item_travel_boots") && (Item5 != "item_travel_boots_2"));

            NoUlt = ((gs.Hero.Level >= 6) &&
                (((gs.Abilities.Ability3 == null ? false : true) && (gs.Abilities.Ability3.IsUltimate) && (!gs.Abilities.Ability3.IsPassive) && (!gs.Abilities.Ability3.CanCast))
                || ((gs.Abilities.Ability4 == null ? false : true) && (gs.Abilities.Ability4.IsUltimate) && (!gs.Abilities.Ability4.IsPassive) && (!gs.Abilities.Ability4.CanCast))
                || ((gs.Abilities.Ability5 == null ? false : true) && (gs.Abilities.Ability5.IsUltimate) && (!gs.Abilities.Ability5.IsPassive) && (!gs.Abilities.Ability5.CanCast))));

            NoDetection = ((Item0 != "item_dust") && (Item0 != "item_ward_sentry") && (Item0 != "item_ward_dispenser") && (Item0 != "item_gem")
                && (Item1 != "item_dust") && (Item1 != "item_ward_sentry") && (Item1 != "item_ward_dispenser") && (Item1 != "item_gem")
                && (Item2 != "item_dust") && (Item2 != "item_ward_sentry") && (Item2 != "item_ward_dispenser") && (Item2 != "item_gem")
                && (Item3 != "item_dust") && (Item3 != "item_ward_sentry") && (Item3 != "item_ward_dispenser") && (Item3 != "item_gem")
                && (Item4 != "item_dust") && (Item4 != "item_ward_sentry") && (Item4 != "item_ward_dispenser") && (Item4 != "item_gem")
                && (Item5 != "item_dust") && (Item5 != "item_ward_sentry") && (Item5 != "item_ward_dispenser") && (Item5 != "item_gem"));

            LowHealth = (gs.Hero.HealthPercent < 50);

            ObsOffCooldown = (gs.Map.WardPurchaseCooldown == 0);

            MidasOffCooldown = (((gs.Items.Slot0.Name == "item_hand_of_midas") && (gs.Items.Slot0.CanCast))
                || ((gs.Items.Slot1.Name == "item_hand_of_midas") && (gs.Items.Slot1.CanCast))
                || ((gs.Items.Slot2.Name == "item_hand_of_midas") && (gs.Items.Slot2.CanCast))
                || ((gs.Items.Slot3.Name == "item_hand_of_midas") && (gs.Items.Slot3.CanCast))
                || ((gs.Items.Slot4.Name == "item_hand_of_midas") && (gs.Items.Slot4.CanCast))
                || ((gs.Items.Slot5.Name == "item_hand_of_midas") && (gs.Items.Slot5.CanCast)));
        }

        public string MatchId { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Hero { get; set; }
        public int Level { get; set; }
        public int ClockTime { get; set; }
        public int GoldPerMinute { get; set; }
        public int ExperiencePerMinute { get; set; }
        public int Networth { get; set; }
        public string Item0 { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string Item5 { get; set; }

        // Stored Alerts
        public bool NoTp { get; set; } = false;
        public bool NoUlt { get; set; } = false;
        public bool NoDetection { get; set; } = false;
        public bool LowHealth { get; set; } = false;
        public bool ObsOffCooldown { get; set; } = false;
        public bool MidasOffCooldown { get; set; } = false;

        private static readonly Dictionary<string, int> ComponentPrice = new Dictionary<string, int>()
        {
            // Basic Items
            { "item_courier", 100 },
            { "item_boots_of_elves", 450 },
            { "item_belt_of_strength", 450 },
            { "item_blade_of_alacrity", 1000 },
            { "item_blades_of_attack", 420 },
            { "item_blight_stone", 300 },
            { "item_blink", 2250 },
            { "item_boots", 400 },
            { "item_bottle", 660 },
            { "item_broadsword", 1200 },
            { "item_chainmail", 550 },
            { "item_circlet", 165 },
            { "item_clarity", 50 },
            { "item_claymore", 1400 },
            { "item_cloak", 550 },
            { "item_demon_edge", 2400 },
            { "item_dust", 180 },
            { "item_eagle", 3200 },
            { "item_enchanted_mango", 125 },
            { "item_energy_booster", 900 },
            { "item_faerie_fire", 75 },
            { "item_flying_courier", 150 },
            { "item_gauntlets", 150 },
            { "item_gem", 900 },
            { "item_ghost", 1500 },
            { "item_gloves", 500 },
            { "item_flask", 110 },
            { "item_helm_of_iron_will", 900 },
            { "item_hyperstone", 2000 },
            { "item_infused_raindrop", 225 },
            { "item_branches", 50 },
            { "item_javelin", 1500 },
            { "item_magic_stick", 200 },
            { "item_mantle", 150 },
            { "item_mithril_hammer", 1600 },
            { "item_lifesteal", 900 },
            { "item_mystic_staff", 2700 },
            { "item_ward_observer", 65 },
            { "item_ogre_axe", 1000 },
            { "item_orb_of_venom", 275 },
            { "item_platemail", 1400 },
            { "item_point_booster", 1200 },
            { "item_quarterstaff", 875 },
            { "item_quelling_blade", 200 },
            { "item_reaver", 3000 },
            { "item_ring_of_health", 850 },
            { "item_ring_of_protection", 175 },
            { "item_ring_of_regen", 325 },
            { "item_robe", 450 },
            { "item_relic", 3800 },
            { "item_sobi_mask", 325 },
            { "item_ward_sentry", 200 },
            { "item_shadow_amulet", 1300 },
            { "item_slippers", 150 },
            { "item_smoke_of_deceit", 50 },
            { "item_staff_of_wizardry", 1000 },
            { "item_stout_shield", 200 },
            { "item_talisman_of_evasion", 1700 },
            { "item_tango", 125 },
            { "item_tango_single", 0 },
            { "item_tome_of_knowledge", 150 },
            { "item_tpscroll", 50 },
            { "item_ultimate_orb", 2100 },
            { "item_vitality_booster", 1100 },
            { "item_void_stone", 850 },
            { "item_wind_lace", 235 },

            // Recipes
            { "item_recipe_abyssal_blade", 1550 },
            { "item_recipe_aether_lens", 550 },
            { "item_recipe_armlet", 550 },
            { "item_recipe_assault", 1300 },
            { "item_recipe_black_king_bar", 1375 },
            { "item_recipe_bloodstone", 900 },
            { "item_recipe_bloodthorn", 1000 },
            { "item_recipe_travel_boots", 2000 },
            { "item_recipe_bracer", 210 },
            { "item_recipe_buckler", 200 },
            { "item_recipe_crimson_guard", 600 },
            { "item_recipe_lesser_crit", 500 },
            { "item_recipe_greater_crit", 1000 },
            { "item_recipe_dagon", 1250 },
            { "item_recipe_diffusal_blade", 700 },
            { "item_recipe_ancient_janggo", 700 },
            { "item_recipe_cyclone", 650 },
            { "item_recipe_force_staff", 900 },
            { "item_recipe_guardian_greaves", 1700 },
            { "item_recipe_hand_of_midas", 1550 },
            { "item_recipe_headdress", 200 },
            { "item_recipe_heart", 1400 },
            { "item_recipe_hurricane_pike", 250 },
            { "item_recipe_iron_talon", 125 },
            { "item_recipe_sphere", 1000 },
            { "item_recipe_maelstrom", 700 },
            { "item_recipe_manta", 800 },
            { "item_recipe_mask_of_madness", 900 },
            { "item_recipe_mekansm", 900 },
            { "item_recipe_mjollnir", 900 },
            { "item_recipe_necronomicon", 1200 },
            { "item_recipe_null_talisman", 155 },
            { "item_recipe_orchid", 775 },
            { "item_recipe_pipe", 800 },
            { "item_recipe_radiance", 1350 },
            { "item_recipe_refresher", 1800 },
            { "item_recipe_sange", 600 },
            { "item_recipe_satanic", 1100 },
            { "item_recipe_shivas_guard", 600 },
            { "item_recipe_silver_edge", 300 },
            { "item_recipe_basher", 750 },
            { "item_recipe_soul_ring", 125 },
            { "item_recipe_urn_of_shadows", 250 },
            { "item_recipe_veil_of_discord", 400 },
            { "item_recipe_vladmir", 300 },
            { "item_recipe_wraith_band", 170 },
            { "item_recipe_yasha", 600 },
        };

        private static readonly Dictionary<string, int> ItemPriceLevel1 = new Dictionary<string, int>()
        {
            { "item_aether_lens",
                ComponentPrice["item_energy_booster"] +
                ComponentPrice["item_ring_of_health"] +
                ComponentPrice["item_recipe_aether_lens"]
            },
            { "item_ultimate_scepter",
                ComponentPrice["item_point_booster"] +
                ComponentPrice["item_ogre_axe"] +
                ComponentPrice["item_blade_of_alacrity"] +
                ComponentPrice["item_staff_of_wizardry"]
            },
            { "item_arcane_boots",
                ComponentPrice["item_boots"] +
                ComponentPrice["item_energy_booster"]
            },
            { "item_armlet",
                ComponentPrice["item_helm_of_iron_will"] +
                ComponentPrice["item_gloves"] +
                ComponentPrice["item_blades_of_attack"] +
                ComponentPrice["item_recipe_armlet"]
            },
            { "item_assault",
                ComponentPrice["item_platemail"] +
                ComponentPrice["item_hyperstone"] +
                ComponentPrice["item_chainmail"] +
                ComponentPrice["item_recipe_assault"]
            },
            { "item_black_king_bar",
                ComponentPrice["item_mithril_hammer"] +
                ComponentPrice["item_ogre_axe"] +
                ComponentPrice["item_recipe_black_king_bar"]
            },
            { "item_blade_mail",
                ComponentPrice["item_broadsword"] +
                ComponentPrice["item_chainmail"] +
                ComponentPrice["item_robe"]
            },
            { "item_travel_boots",
                ComponentPrice["item_boots"] +
                ComponentPrice["item_recipe_travel_boots"]
            },
            { "item_travel_boots_2",
                ComponentPrice["item_boots"] +
                ComponentPrice["item_recipe_travel_boots"] +
                ComponentPrice["item_recipe_travel_boots"]
            },
            { "item_bracer",
                ComponentPrice["item_circlet"] +
                ComponentPrice["item_gauntlets"] +
                ComponentPrice["item_recipe_bracer"]
            },
            { "item_buckler",
                ComponentPrice["item_chainmail"] +
                ComponentPrice["item_branches"] +
                ComponentPrice["item_recipe_buckler"]
            },
            { "item_butterfly",
                ComponentPrice["item_eagle"] +
                ComponentPrice["item_talisman_of_evasion"] +
                ComponentPrice["item_quarterstaff"]
            },
            { "item_lesser_crit",
                ComponentPrice["item_broadsword"] +
                ComponentPrice["item_blades_of_attack"] +
                ComponentPrice["item_recipe_lesser_crit"]
            },
            { "item_desolator",
                ComponentPrice["item_mithril_hammer"] +
                ComponentPrice["item_mithril_hammer"] +
                ComponentPrice["item_blight_stone"]
            },
            { "item_diffusal_blade",
                ComponentPrice["item_blade_of_alacrity"] +
                ComponentPrice["item_blade_of_alacrity"] +
                ComponentPrice["item_robe"] +
                ComponentPrice["item_recipe_diffusal_blade"]
            },
            { "item_diffusal_blade_2",
                ComponentPrice["item_blade_of_alacrity"] +
                ComponentPrice["item_blade_of_alacrity"] +
                ComponentPrice["item_robe"] +
                ComponentPrice["item_recipe_diffusal_blade"] +
                ComponentPrice["item_recipe_diffusal_blade"]
            },
            { "item_dragon_lance",
                ComponentPrice["item_ogre_axe"] +
                ComponentPrice["item_boots_of_elves"] +
                ComponentPrice["item_boots_of_elves"]
            },
            { "item_ethereal_blade",
                ComponentPrice["item_eagle"] +
                ComponentPrice["item_ghost"]
            },
            { "item_cyclone",
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_wind_lace"] +
                ComponentPrice["item_void_stone"] +
                ComponentPrice["item_recipe_cyclone"]
            },
            { "item_skadi",
                ComponentPrice["item_ultimate_orb"] +
                ComponentPrice["item_ultimate_orb"] +
                ComponentPrice["item_point_booster"] +
                ComponentPrice["item_orb_of_venom"]
            },
            { "item_force_staff",
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_ring_of_regen"] +
                ComponentPrice["item_recipe_force_staff"]
            },
            { "item_glimmer_cape",
                ComponentPrice["item_shadow_amulet"] +
                ComponentPrice["item_cloak"]
            },
            { "item_hand_of_midas",
                ComponentPrice["item_gloves"] +
                ComponentPrice["item_recipe_hand_of_midas"]
            },
            { "item_headdress",
                ComponentPrice["item_ring_of_regen"] +
                ComponentPrice["item_branches"] +
                ComponentPrice["item_recipe_headdress"]
            },
            { "item_heart",
                ComponentPrice["item_reaver"] +
                ComponentPrice["item_vitality_booster"] +
                ComponentPrice["item_recipe_heart"]
            },
            { "item_helm_of_the_dominator",
                ComponentPrice["item_helm_of_iron_will"] +
                ComponentPrice["item_lifesteal"]
            },
            { "item_hood_of_defiance",
                ComponentPrice["item_ring_of_health"] +
                ComponentPrice["item_cloak"] +
                ComponentPrice["item_ring_of_regen"]
            },
            { "item_iron_talon",
                ComponentPrice["item_quelling_blade"] +
                ComponentPrice["item_ring_of_protection"] +
                ComponentPrice["item_recipe_iron_talon"]
            },
            { "item_maelstrom",
                ComponentPrice["item_mithril_hammer"] +
                ComponentPrice["item_gloves"] +
                ComponentPrice["item_recipe_maelstrom"]
            },
            { "item_magic_wand",
                ComponentPrice["item_magic_stick"] +
                ComponentPrice["item_branches"] +
                ComponentPrice["item_branches"] +
                ComponentPrice["item_circlet"]
            },
            { "item_mask_of_madness",
                ComponentPrice["item_lifesteal"] +
                ComponentPrice["item_recipe_mask_of_madness"]
            },
            { "item_medallion_of_courage",
                ComponentPrice["item_chainmail"] +
                ComponentPrice["item_sobi_mask"] +
                ComponentPrice["item_blight_stone"]
            },
            { "item_monkey_king_bar",
                ComponentPrice["item_demon_edge"] +
                ComponentPrice["item_javelin"] +
                ComponentPrice["item_javelin"]
            },
            { "item_moon_shard",
                ComponentPrice["item_hyperstone"] +
                ComponentPrice["item_hyperstone"]
            },
            { "item_necronomicon",
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_belt_of_strength"] +
                ComponentPrice["item_recipe_necronomicon"]
            },
            { "item_necronomicon_2",
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_belt_of_strength"] +
                ComponentPrice["item_recipe_necronomicon"] +
                ComponentPrice["item_recipe_necronomicon"]
            },
            { "item_necronomicon_3",
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_belt_of_strength"] +
                ComponentPrice["item_recipe_necronomicon"] +
                ComponentPrice["item_recipe_necronomicon"] +
                ComponentPrice["item_recipe_necronomicon"]
            },
            { "item_null_talisman",
                ComponentPrice["item_circlet"] +
                ComponentPrice["item_mantle"] +
                ComponentPrice["item_recipe_null_talisman"]
            },
            { "item_oblivion_staff",
                ComponentPrice["item_quarterstaff"] +
                ComponentPrice["item_robe"] +
                ComponentPrice["item_sobi_mask"]
            },
            { "item_ward_dispenser",
                ComponentPrice["item_ward_sentry"] +
                ComponentPrice["item_ward_observer"]
            },
            { "item_pers",
                ComponentPrice["item_ring_of_health"] +
                ComponentPrice["item_void_stone"]
            },
            { "item_phase_boots",
                ComponentPrice["item_boots"] +
                ComponentPrice["item_blades_of_attack"] +
                ComponentPrice["item_blades_of_attack"]
            },
            { "item_poor_mans_shield",
                ComponentPrice["item_stout_shield"] +
                ComponentPrice["item_slippers"] +
                ComponentPrice["item_slippers"]
            },
            { "item_power_treads",
                ComponentPrice["item_boots"] +
                ComponentPrice["item_gloves"] +
                ComponentPrice["item_belt_of_strength"]
            },
            { "item_radiance",
                ComponentPrice["item_relic"] +
                ComponentPrice["item_recipe_radiance"]
            },
            { "item_rapier",
                ComponentPrice["item_relic"] +
                ComponentPrice["item_demon_edge"]
            },
            { "item_ring_of_basilius",
                ComponentPrice["item_sobi_mask"] +
                ComponentPrice["item_ring_of_protection"]
            },
            { "item_rod_of_atos",
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_staff_of_wizardry"] +
                ComponentPrice["item_vitality_booster"]
            },
            { "item_sange",
                ComponentPrice["item_ogre_axe"] +
                ComponentPrice["item_belt_of_strength"] +
                ComponentPrice["item_recipe_sange"]
            },
            { "item_sheepstick",
                ComponentPrice["item_mystic_staff"] +
                ComponentPrice["item_ultimate_orb"] +
                ComponentPrice["item_void_stone"]
            },
            { "item_invis_sword",
                ComponentPrice["item_claymore"] +
                ComponentPrice["item_shadow_amulet"]
            },
            { "item_shivas_guard",
                ComponentPrice["item_mystic_staff"] +
                ComponentPrice["item_platemail"] +
                ComponentPrice["item_recipe_shivas_guard"]
            },
            { "item_basher",
                ComponentPrice["item_javelin"] +
                ComponentPrice["item_belt_of_strength"] +
                ComponentPrice["item_recipe_basher"]
            },
            { "item_soul_booster",
                ComponentPrice["item_point_booster"] +
                ComponentPrice["item_vitality_booster"] +
                ComponentPrice["item_energy_booster"]
            },
            { "item_soul_ring",
                ComponentPrice["item_ring_of_regen"] +
                ComponentPrice["item_sobi_mask"] +
                ComponentPrice["item_recipe_soul_ring"]
            },
            { "item_tranquil_boots",
                ComponentPrice["item_boots"] +
                ComponentPrice["item_ring_of_protection"] +
                ComponentPrice["item_ring_of_regen"]
            },
            { "item_urn_of_shadows",
                ComponentPrice["item_sobi_mask"] +
                ComponentPrice["item_gauntlets"] +
                ComponentPrice["item_gauntlets"] +
                ComponentPrice["item_recipe_urn_of_shadows"]
            },
            { "item_vanguard",
                ComponentPrice["item_ring_of_health"] +
                ComponentPrice["item_vitality_booster"] +
                ComponentPrice["item_stout_shield"]
            },
            { "item_wraith_band",
                ComponentPrice["item_circlet"] +
                ComponentPrice["item_slippers"] +
                ComponentPrice["item_recipe_wraith_band"]
            },
            { "item_yasha",
                ComponentPrice["item_blade_of_alacrity"] +
                ComponentPrice["item_boots_of_elves"] +
                ComponentPrice["item_recipe_yasha"]
            },
        };

        private static readonly Dictionary<string, int> ItemPriceLevel2 = new Dictionary<string, int>()
        {
            { "item_abyssal_blade",
                ItemPriceLevel1["item_vanguard"] +
                ItemPriceLevel1["item_basher"] +
                ComponentPrice["item_recipe_abyssal_blade"]
            },
            { "item_bfury",
                ComponentPrice["item_claymore"] +
                ComponentPrice["item_broadsword"] +
                ItemPriceLevel1["item_pers"] +
                ComponentPrice["item_quelling_blade"]
            },
            { "item_bloodstone",
                ItemPriceLevel1["item_soul_booster"] +
                ItemPriceLevel1["item_soul_ring"] +
                ComponentPrice["item_recipe_bloodstone"]
            },
            { "item_crimson_guard",
                ItemPriceLevel1["item_vanguard"] +
                ItemPriceLevel1["item_buckler"] +
                ComponentPrice["item_recipe_crimson_guard"]
            },
            { "item_greater_crit",
                ItemPriceLevel1["item_lesser_crit"] +
                ComponentPrice["item_demon_edge"] +
                ComponentPrice["item_recipe_greater_crit"]
            },
            { "item_dagon",
                ComponentPrice["item_staff_of_wizardry"] +
                ItemPriceLevel1["item_null_talisman"] +
                ComponentPrice["item_recipe_dagon"]
            },
            { "item_dagon_2",
                ComponentPrice["item_staff_of_wizardry"] +
                ItemPriceLevel1["item_null_talisman"] +
                ComponentPrice["item_recipe_dagon"]*2
            },
            { "item_dagon_3",
                ComponentPrice["item_staff_of_wizardry"] +
                ItemPriceLevel1["item_null_talisman"] +
                ComponentPrice["item_recipe_dagon"]*3
            },
            { "item_dagon_4",
                ComponentPrice["item_staff_of_wizardry"] +
                ItemPriceLevel1["item_null_talisman"] +
                ComponentPrice["item_recipe_dagon"]*4
            },
            { "item_dagon_5",
                ComponentPrice["item_staff_of_wizardry"] +
                ItemPriceLevel1["item_null_talisman"] +
                ComponentPrice["item_recipe_dagon"]*5
            },
            { "item_ancient_janggo",
                ItemPriceLevel1["item_bracer"] +
                ComponentPrice["item_ring_of_regen"] +
                ComponentPrice["item_wind_lace"] +
                ComponentPrice["item_recipe_ancient_janggo"]
            },
            { "item_echo_sabre",
                ComponentPrice["item_ogre_axe"] +
                ItemPriceLevel1["item_oblivion_staff"]
            },
            { "item_heavens_halberd",
                ItemPriceLevel1["item_sange"] +
                ComponentPrice["item_talisman_of_evasion"]
            },
            { "item_hurricane_pike",
                ItemPriceLevel1["item_force_staff"] +
                ItemPriceLevel1["item_dragon_lance"] +
                ComponentPrice["item_recipe_hurricane_pike"]
            },
            { "item_sphere",
                ItemPriceLevel1["item_pers"] +
                ComponentPrice["item_ultimate_orb"] +
                ComponentPrice["item_recipe_sphere"]
            },
            { "item_lotus_orb",
                ItemPriceLevel1["item_pers"] +
                ComponentPrice["item_platemail"] +
                ComponentPrice["item_energy_booster"]
            },
            { "item_manta",
                ComponentPrice["item_ultimate_orb"] +
                ItemPriceLevel1["item_yasha"] +
                ComponentPrice["item_recipe_manta"]
            },
            { "item_mekansm",
                ItemPriceLevel1["item_buckler"] +
                ItemPriceLevel1["item_headdress"] +
                ComponentPrice["item_recipe_mekansm"]
            },
            { "item_mjollnir",
                ComponentPrice["item_hyperstone"] +
                ItemPriceLevel1["item_maelstrom"] +
                ComponentPrice["item_recipe_mjollnir"]
            },
            { "item_octarine_core",
                ComponentPrice["item_mystic_staff"] +
                ItemPriceLevel1["item_soul_booster"]
            },
            { "item_orchid",
                ItemPriceLevel1["item_oblivion_staff"] +
                ItemPriceLevel1["item_oblivion_staff"] +
                ComponentPrice["item_recipe_orchid"]
            },
            { "item_pipe",
                ItemPriceLevel1["item_hood_of_defiance"] +
                ItemPriceLevel1["item_headdress"] +
                ComponentPrice["item_recipe_pipe"]
            },
            { "item_refresher",
                ItemPriceLevel1["item_pers"] +
                ItemPriceLevel1["item_pers"] +
                ComponentPrice["item_recipe_refresher"]
            },
            { "item_ring_of_aquila",
                ItemPriceLevel1["item_wraith_band"] +
                ItemPriceLevel1["item_ring_of_basilius"]
            },
            { "item_sange_and_yasha",
                ItemPriceLevel1["item_sange"] +
                ItemPriceLevel1["item_yasha"]
            },
            { "item_satanic",
                ComponentPrice["item_reaver"] +
                ItemPriceLevel1["item_helm_of_the_dominator"] +
                ComponentPrice["item_recipe_satanic"]
            },
            { "item_silver_edge",
                ItemPriceLevel1["item_invis_sword"] +
                ComponentPrice["item_ultimate_orb"] +
                ComponentPrice["item_recipe_silver_edge"]
            },
            { "item_solar_crest",
                ItemPriceLevel1["item_medallion_of_courage"] +
                ComponentPrice["item_talisman_of_evasion"]
            },
            { "item_veil_of_discord",
                ComponentPrice["item_helm_of_iron_will"] +
                ItemPriceLevel1["item_null_talisman"] +
                ItemPriceLevel1["item_null_talisman"] +
                ComponentPrice["item_recipe_veil_of_discord"]
            },
            { "item_vladmir",
                ComponentPrice["item_lifesteal"] +
                ItemPriceLevel1["item_ring_of_basilius"] +
                ItemPriceLevel1["item_headdress"] +
                ComponentPrice["item_recipe_vladmir"]
            },
        };

        private static readonly Dictionary<string, int> ItemPriceLevel3 = new Dictionary<string, int>()
        {
            { "item_bloodthorn",
                ItemPriceLevel2["item_orchid"] +
                ItemPriceLevel1["item_lesser_crit"] +
                ComponentPrice["item_recipe_bloodthorn"]
            },
            { "item_guardian_greaves",
                ItemPriceLevel2["item_mekansm"] +
                ItemPriceLevel1["item_arcane_boots"] +
                ComponentPrice["item_recipe_guardian_greaves"]
            },
        };

        /// <summary>
        /// Internal Item Name Reference: http://dota2.gamepedia.com/Cheats#Item_names
        /// </summary>
        private static readonly Dictionary<string, int> ItemPrice = new Dictionary<string, int>()
        {
            { "empty", 0 },
            { "item_aegis", 0 },
            { "item_cheese", 0 },

            // Basic Items
            { "item_courier", ComponentPrice["item_courier"] },
            { "item_boots_of_elves", ComponentPrice["item_boots_of_elves"] },
            { "item_belt_of_strength", ComponentPrice["item_belt_of_strength"] },
            { "item_blade_of_alacrity", ComponentPrice["item_blade_of_alacrity"] },
            { "item_blades_of_attack", ComponentPrice["item_blades_of_attack"] },
            { "item_blight_stone", ComponentPrice["item_blight_stone"] },
            { "item_blink", ComponentPrice["item_blink"] },
            { "item_boots", ComponentPrice["item_boots"] },
            { "item_bottle", ComponentPrice["item_bottle"] },
            { "item_broadsword", ComponentPrice["item_broadsword"] },
            { "item_chainmail", ComponentPrice["item_chainmail"] },
            { "item_circlet", ComponentPrice["item_circlet"] },
            { "item_clarity", ComponentPrice["item_clarity"] },
            { "item_claymore", ComponentPrice["item_claymore"] },
            { "item_cloak", ComponentPrice["item_cloak"] },
            { "item_demon_edge", ComponentPrice["item_demon_edge"] },
            { "item_dust", ComponentPrice["item_dust"] },
            { "item_eagle", ComponentPrice["item_eagle"] },
            { "item_enchanted_mango", ComponentPrice["item_enchanted_mango"] },
            { "item_energy_booster", ComponentPrice["item_energy_booster"] },
            { "item_faerie_fire", ComponentPrice["item_faerie_fire"] },
            { "item_flying_courier", ComponentPrice["item_flying_courier"] },
            { "item_gauntlets", ComponentPrice["item_gauntlets"] },
            { "item_gem", ComponentPrice["item_gem"] },
            { "item_ghost", ComponentPrice["item_ghost"] },
            { "item_gloves", ComponentPrice["item_gloves"] },
            { "item_flask", ComponentPrice["item_flask"] },
            { "item_helm_of_iron_will", ComponentPrice["item_helm_of_iron_will"] },
            { "item_hyperstone", ComponentPrice["item_hyperstone"] },
            { "item_infused_raindrop", ComponentPrice["item_infused_raindrop"] },
            { "item_branches", ComponentPrice["item_branches"] },
            { "item_javelin", ComponentPrice["item_javelin"] },
            { "item_magic_stick", ComponentPrice["item_magic_stick"] },
            { "item_mantle", ComponentPrice["item_mantle"] },
            { "item_mithril_hammer", ComponentPrice["item_mithril_hammer"] },
            { "item_lifesteal", ComponentPrice["item_lifesteal"] },
            { "item_mystic_staff", ComponentPrice["item_mystic_staff"] },
            { "item_ward_observer", ComponentPrice["item_ward_observer"] },
            { "item_ogre_axe", ComponentPrice["item_ogre_axe"] },
            { "item_orb_of_venom", ComponentPrice["item_orb_of_venom"] },
            { "item_platemail", ComponentPrice["item_platemail"] },
            { "item_point_booster", ComponentPrice["item_point_booster"] },
            { "item_quarterstaff", ComponentPrice["item_quarterstaff"] },
            { "item_quelling_blade", ComponentPrice["item_quelling_blade"] },
            { "item_reaver", ComponentPrice["item_reaver"] },
            { "item_ring_of_health", ComponentPrice["item_ring_of_health"] },
            { "item_ring_of_protection", ComponentPrice["item_ring_of_protection"] },
            { "item_ring_of_regen", ComponentPrice["item_ring_of_regen"] },
            { "item_robe", ComponentPrice["item_robe"] },
            { "item_relic", ComponentPrice["item_relic"] },
            { "item_sobi_mask", ComponentPrice["item_sobi_mask"] },
            { "item_ward_sentry", ComponentPrice["item_ward_sentry"] },
            { "item_shadow_amulet", ComponentPrice["item_shadow_amulet"] },
            { "item_slippers", ComponentPrice["item_slippers"] },
            { "item_smoke_of_deceit", ComponentPrice["item_smoke_of_deceit"] },
            { "item_staff_of_wizardry", ComponentPrice["item_staff_of_wizardry"] },
            { "item_stout_shield", ComponentPrice["item_stout_shield"] },
            { "item_talisman_of_evasion", ComponentPrice["item_talisman_of_evasion"] },
            { "item_tango", ComponentPrice["item_tango"] },
            { "item_tango_single", ComponentPrice["item_tango_single"] },
            { "item_tome_of_knowledge", ComponentPrice["item_tome_of_knowledge"] },
            { "item_tpscroll", ComponentPrice["item_tpscroll"] },
            { "item_ultimate_orb", ComponentPrice["item_ultimate_orb"] },
            { "item_vitality_booster", ComponentPrice["item_vitality_booster"] },
            { "item_void_stone", ComponentPrice["item_void_stone"] },
            { "item_wind_lace", ComponentPrice["item_wind_lace"] },

            // Recipes
            { "item_recipe_abyssal_blade", ComponentPrice["item_recipe_abyssal_blade"] },
            { "item_recipe_aether_lens", ComponentPrice["item_recipe_aether_lens"] },
            { "item_recipe_armlet", ComponentPrice["item_recipe_armlet"] },
            { "item_recipe_assault", ComponentPrice["item_recipe_assault"] },
            { "item_recipe_black_king_bar", ComponentPrice["item_recipe_black_king_bar"] },
            { "item_recipe_bloodstone", ComponentPrice["item_recipe_bloodstone"] },
            { "item_recipe_bloodthorn", ComponentPrice["item_recipe_bloodthorn"] },
            { "item_recipe_travel_boots", ComponentPrice["item_recipe_travel_boots"] },
            { "item_recipe_bracer", ComponentPrice["item_recipe_bracer"] },
            { "item_recipe_buckler", ComponentPrice["item_recipe_buckler"] },
            { "item_recipe_crimson_guard", ComponentPrice["item_recipe_crimson_guard"] },
            { "item_recipe_lesser_crit", ComponentPrice["item_recipe_lesser_crit"] },
            { "item_recipe_greater_crit", ComponentPrice["item_recipe_greater_crit"] },
            { "item_recipe_dagon", ComponentPrice["item_recipe_dagon"] },
            { "item_recipe_diffusal_blade", ComponentPrice["item_recipe_diffusal_blade"] },
            { "item_recipe_ancient_janggo", ComponentPrice["item_recipe_ancient_janggo"] },
            { "item_recipe_cyclone", ComponentPrice["item_recipe_cyclone"] },
            { "item_recipe_force_staff", ComponentPrice["item_recipe_force_staff"] },
            { "item_recipe_guardian_greaves", ComponentPrice["item_recipe_guardian_greaves"] },
            { "item_recipe_hand_of_midas", ComponentPrice["item_recipe_hand_of_midas"] },
            { "item_recipe_headdress", ComponentPrice["item_recipe_headdress"] },
            { "item_recipe_heart", ComponentPrice["item_recipe_heart"] },
            { "item_recipe_hurricane_pike", ComponentPrice["item_recipe_hurricane_pike"] },
            { "item_recipe_iron_talon", ComponentPrice["item_recipe_iron_talon"] },
            { "item_recipe_sphere", ComponentPrice["item_recipe_sphere"] },
            { "item_recipe_maelstrom", ComponentPrice["item_recipe_maelstrom"] },
            { "item_recipe_manta", ComponentPrice["item_recipe_manta"] },
            { "item_recipe_mask_of_madness", ComponentPrice["item_recipe_mask_of_madness"] },
            { "item_recipe_mekansm", ComponentPrice["item_recipe_mekansm"] },
            { "item_recipe_mjollnir", ComponentPrice["item_recipe_mjollnir"] },
            { "item_recipe_necronomicon", ComponentPrice["item_recipe_necronomicon"] },
            { "item_recipe_null_talisman", ComponentPrice["item_recipe_null_talisman"] },
            { "item_recipe_orchid", ComponentPrice["item_recipe_orchid"] },
            { "item_recipe_pipe", ComponentPrice["item_recipe_pipe"] },
            { "item_recipe_radiance", ComponentPrice["item_recipe_radiance"] },
            { "item_recipe_refresher", ComponentPrice["item_recipe_refresher"] },
            { "item_recipe_sange", ComponentPrice["item_recipe_sange"] },
            { "item_recipe_satanic", ComponentPrice["item_recipe_satanic"] },
            { "item_recipe_shivas_guard", ComponentPrice["item_recipe_shivas_guard"] },
            { "item_recipe_silver_edge", ComponentPrice["item_recipe_silver_edge"] },
            { "item_recipe_basher", ComponentPrice["item_recipe_basher"] },
            { "item_recipe_soul_ring", ComponentPrice["item_recipe_soul_ring"] },
            { "item_recipe_urn_of_shadows", ComponentPrice["item_recipe_urn_of_shadows"] },
            { "item_recipe_veil_of_discord", ComponentPrice["item_recipe_veil_of_discord"] },
            { "item_recipe_vladmir", ComponentPrice["item_recipe_vladmir"] },
            { "item_recipe_wraith_band", ComponentPrice["item_recipe_wraith_band"] },
            { "item_recipe_yasha", ComponentPrice["item_recipe_yasha"] },

            // Upgraded Items
            { "item_abyssal_blade", ItemPriceLevel2["item_abyssal_blade"] },
            { "item_aether_lens", ItemPriceLevel1["item_aether_lens"] },
            { "item_ultimate_scepter", ItemPriceLevel1["item_ultimate_scepter"] },
            { "item_arcane_boots", ItemPriceLevel1["item_arcane_boots"] },
            { "item_armlet", ItemPriceLevel1["item_armlet"] },
            { "item_assault", ItemPriceLevel1["item_assault"] },
            { "item_bfury", ItemPriceLevel2["item_bfury"] },
            { "item_black_king_bar", ItemPriceLevel1["item_black_king_bar"] },
            { "item_blade_mail", ItemPriceLevel1["item_blade_mail"] },
            { "item_bloodstone", ItemPriceLevel2["item_bloodstone"] },
            { "item_bloodthorn", ItemPriceLevel3["item_bloodthorn"] },
            { "item_travel_boots", ItemPriceLevel1["item_travel_boots"] },
            { "item_travel_boots_2", ItemPriceLevel1["item_travel_boots_2"] },
            { "item_bracer", ItemPriceLevel1["item_bracer"] },
            { "item_buckler", ItemPriceLevel1["item_buckler"] },
            { "item_butterfly", ItemPriceLevel1["item_butterfly"] },
            { "item_crimson_guard", ItemPriceLevel2["item_crimson_guard"] },
            { "item_lesser_crit", ItemPriceLevel1["item_lesser_crit"] },
            { "item_greater_crit", ItemPriceLevel2["item_greater_crit"] },
            { "item_dagon", ItemPriceLevel2["item_dagon"] },
            { "item_dagon_2", ItemPriceLevel2["item_dagon_2"] },
            { "item_dagon_3", ItemPriceLevel2["item_dagon_3"] },
            { "item_dagon_4", ItemPriceLevel2["item_dagon_4"] },
            { "item_dagon_5", ItemPriceLevel2["item_dagon_5"] },
            { "item_desolator", ItemPriceLevel1["item_desolator"] },
            { "item_diffusal_blade", ItemPriceLevel1["item_diffusal_blade"] },
            { "item_diffusal_blade_2", ItemPriceLevel1["item_diffusal_blade_2"] },
            { "item_dragon_lance", ItemPriceLevel1["item_dragon_lance"] },
            { "item_ancient_janggo", ItemPriceLevel2["item_ancient_janggo"] },
            { "item_echo_sabre", ItemPriceLevel2["item_echo_sabre"] },
            { "item_ethereal_blade", ItemPriceLevel1["item_ethereal_blade"] },
            { "item_cyclone", ItemPriceLevel1["item_cyclone"] },
            { "item_skadi", ItemPriceLevel1["item_skadi"] },
            { "item_force_staff", ItemPriceLevel1["item_force_staff"] },
            { "item_glimmer_cape", ItemPriceLevel1["item_glimmer_cape"] },
            { "item_guardian_greaves", ItemPriceLevel3["item_guardian_greaves"] },
            { "item_hand_of_midas", ItemPriceLevel1["item_hand_of_midas"] },
            { "item_headdress", ItemPriceLevel1["item_headdress"] },
            { "item_heart", ItemPriceLevel1["item_heart"] },
            { "item_heavens_halberd", ItemPriceLevel2["item_heavens_halberd"] },
            { "item_helm_of_the_dominator", ItemPriceLevel1["item_helm_of_the_dominator"] },
            { "item_hood_of_defiance", ItemPriceLevel1["item_hood_of_defiance"] },
            { "item_hurricane_pike", ItemPriceLevel2["item_hurricane_pike"] },
            { "item_iron_talon", ItemPriceLevel1["item_iron_talon"] },
            { "item_sphere", ItemPriceLevel2["item_sphere"] },
            { "item_lotus_orb", ItemPriceLevel2["item_lotus_orb"] },
            { "item_maelstrom", ItemPriceLevel1["item_maelstrom"] },
            { "item_magic_wand", ItemPriceLevel1["item_magic_wand"] },
            { "item_manta", ItemPriceLevel2["item_manta"] },
            { "item_mask_of_madness", ItemPriceLevel1["item_mask_of_madness"] },
            { "item_medallion_of_courage", ItemPriceLevel1["item_medallion_of_courage"] },
            { "item_mekansm", ItemPriceLevel2["item_mekansm"] },
            { "item_mjollnir", ItemPriceLevel2["item_mjollnir"] },
            { "item_monkey_king_bar", ItemPriceLevel1["item_monkey_king_bar"] },
            { "item_moon_shard", ItemPriceLevel1["item_moon_shard"] },
            { "item_necronomicon", ItemPriceLevel1["item_necronomicon"] },
            { "item_necronomicon_2", ItemPriceLevel1["item_necronomicon_2"] },
            { "item_necronomicon_3", ItemPriceLevel1["item_necronomicon_3"] },
            { "item_null_talisman", ItemPriceLevel1["item_null_talisman"] },
            { "item_oblivion_staff", ItemPriceLevel1["item_oblivion_staff"] },
            { "item_ward_dispenser", ItemPriceLevel1["item_ward_dispenser"] },
            { "item_octarine_core", ItemPriceLevel2["item_octarine_core"] },
            { "item_orchid", ItemPriceLevel2["item_orchid"] },
            { "item_pers", ItemPriceLevel1["item_pers"] },
            { "item_phase_boots", ItemPriceLevel1["item_phase_boots"] },
            { "item_pipe", ItemPriceLevel2["item_pipe"] },
            { "item_poor_mans_shield", ItemPriceLevel1["item_poor_mans_shield"] },
            { "item_power_treads", ItemPriceLevel1["item_power_treads"] },
            { "item_radiance", ItemPriceLevel1["item_radiance"] },
            { "item_rapier", ItemPriceLevel1["item_rapier"] },
            { "item_refresher", ItemPriceLevel2["item_refresher"] },
            { "item_ring_of_aquila", ItemPriceLevel2["item_ring_of_aquila"] },
            { "item_ring_of_basilius", ItemPriceLevel1["item_ring_of_basilius"] },
            { "item_rod_of_atos", ItemPriceLevel1["item_rod_of_atos"] },
            { "item_sange", ItemPriceLevel1["item_sange"] },
            { "item_sange_and_yasha", ItemPriceLevel2["item_sange_and_yasha"] },
            { "item_satanic", ItemPriceLevel2["item_satanic"] },
            { "item_sheepstick", ItemPriceLevel1["item_sheepstick"] },
            { "item_invis_sword", ItemPriceLevel1["item_invis_sword"] },
            { "item_shivas_guard", ItemPriceLevel1["item_shivas_guard"] },
            { "item_silver_edge", ItemPriceLevel2["item_silver_edge"] },
            { "item_basher", ItemPriceLevel1["item_basher"] },
            { "item_solar_crest", ItemPriceLevel2["item_solar_crest"] },
            { "item_soul_booster", ItemPriceLevel1["item_soul_booster"] },
            { "item_soul_ring", ItemPriceLevel1["item_soul_ring"] },
            { "item_tranquil_boots", ItemPriceLevel1["item_tranquil_boots"] },
            { "item_urn_of_shadows", ItemPriceLevel1["item_urn_of_shadows"] },
            { "item_vanguard", ItemPriceLevel1["item_vanguard"] },
            { "item_veil_of_discord", ItemPriceLevel2["item_veil_of_discord"] },
            { "item_vladmir", ItemPriceLevel2["item_vladmir"] },
            { "item_wraith_band", ItemPriceLevel1["item_wraith_band"] },
            { "item_yasha", ItemPriceLevel1["item_yasha"] },
        };
    }
}
