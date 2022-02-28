using System;
using Game;
using Sein.World;
using System.Linq;

public static class RandomizerSwitch
{

    public static void SkillPointPickup()
    {
        PickupMessage("Ability Cell");
        if(Randomizer.ZeroXP)
        {
            return;
        }
        Characters.Sein.Level.GainSkillPoint();
        Characters.Sein.Inventory.SkillPointsCollected++;
    }
    
    public static void MaxEnergyContainerPickup() 
    {
        PickupMessage("Energy Cell");
        if (Characters.Sein.Energy.Max == 0f)
        {
            Characters.Sein.SoulFlame.FillSoulFlameBar();
        }
        Characters.Sein.Energy.Max += 1.0f;
        if (Characters.Sein.Energy.Current < Characters.Sein.Energy.Max)
        {
            Characters.Sein.Energy.Current = Characters.Sein.Energy.Max;
        }
    }
    
    public static void ExpOrbPickup(int Value)
    {
        PickupMessage(Value.ToString() + " experience");
        if(Randomizer.ZeroXP)
        {
            return;
        }
        Characters.Sein.Level.GainExperience(RandomizerBonus.ExpWithBonuses(Value, true));
    }
    
    public static void KeystonePickup() {
        PickupMessage("Keystone");
        Characters.Sein.Inventory.CollectKeystones(1);     
    }
    
    public static void MaxHealthContainerPickup() 
    {
        PickupMessage("Health Cell");
        Characters.Sein.Mortality.Health.GainMaxHeartContainer();
    }
    
    public static void MapStonePickup() 
    {
        PickupMessage("Map Stone");
        Characters.Sein.Inventory.MapStones++;
    }
    public static void AbilityPickup(int Ability) {
        Randomizer.GiveAbility = true;
        switch (Ability)
        {
        case 0:
            PickupMessage("$Bash$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Bash, true);
            break;
        case 2:
            PickupMessage("$Charge Flame$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeFlame, true);
            break;
        case 3:
            PickupMessage("$Wall Jump$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.WallJump, true);
            break;
        case 4:
            PickupMessage("$Stomp$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Stomp, true);
            break;
        case 5:
            PickupMessage("$Double Jump$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.DoubleJump, true);
            break;
        case 8:
            PickupMessage("$Charge Jump$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeJump, true);
            break;
        case 12:
            PickupMessage("$Climb$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Climb, true);
            break;
        case 14:
            PickupMessage("$Glide$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Glide, true);
            break;
        case 15:
            PickupMessage("$Spirit Flame$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.SpiritFlame, true);
            break;
        case 50:
            PickupMessage("$Dash$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Dash, true);
            break;
        case 51:
            PickupMessage("$Grenade$", 300);
            Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Grenade, true);
            break;
        }
        Randomizer.GiveAbility = false;
        RandomizerStatsManager.FoundSkill(Ability);
    }
    
    public static void SilentAbility(int Ability) {
        bool success = false;
        try {
            Randomizer.GiveAbility = true;
            switch (Ability)
            {
            case 0:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Bash, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Bash, true);
                success = Characters.Sein.Abilities.Bash.Active;
                break;
            case 2:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeFlame, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeFlame, true);
                success = Characters.Sein.Abilities.ChargeFlame.Active;
                break;
            case 3:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.WallJump, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.WallJump, true);
                success = Characters.Sein.Abilities.WallJump.Active;
                break;
            case 4:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Stomp, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Stomp, true);
                success = Characters.Sein.Abilities.Stomp.Active;
                break;
            case 5:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.DoubleJump, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.DoubleJump, true);
                success = Characters.Sein.Abilities.Stomp.Active;
                break;
            case 8:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeJump, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.ChargeJump, true);
                success = Characters.Sein.Abilities.ChargeJump.Active;
                break;
            case 12:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Climb, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Climb, true);
                success = Characters.Sein.Abilities.GrabWall.Active;
                break;
            case 14:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Glide, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Glide, true);
                success = Characters.Sein.Abilities.Glide.Active;
                break;
            case 15:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.SpiritFlame, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.SpiritFlame, true);
                success = Characters.Sein.Abilities.SpiritFlame.Active;
                break;
            case 50:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Dash, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Dash, true);
                success = Characters.Sein.Abilities.Dash.Active;
                break;
            case 51:
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Grenade, false);
                Characters.Sein.PlayerAbilities.SetAbility(AbilityType.Grenade, true);
                success = Characters.Sein.Abilities.Grenade.Active;
                break;
            }
        } catch (Exception e) {
            
        }
        finally {
            Characters.Sein.Prefabs.EnsureRightPrefabsAreThereForAbilities();
            Randomizer.GiveAbility = false;
            if(success)
                Randomizer.FixCutscenePickup = -1;
        }
    }
    public static void EventPickup(int Value) 
    {
        switch (Value)
        {
            case 0:
                PickupMessage("*Water Vein*", 300);
                Keys.GinsoTree = true;
                break;
            case 1:
                PickupMessage("*Clean Water*#", 300);
                Sein.World.Events.WaterPurified = true;
                break;
            case 2:
                PickupMessage("#Gumon Seal#", 300);
                Keys.ForlornRuins = true;
                break;
            case 3:
                PickupMessage("#Wind Restored#", 300);
                Sein.World.Events.WindRestored = true;
                break;
            case 4:
                PickupMessage("@Sunstone@", 300);
                Keys.MountHoru = true;
                break;
            case 5:
                PickupMessage("@Warmth Returned@", 300);
                break;
        }
        RandomizerStatsManager.FoundEvent(Value);
    }
    
    public static void TeleportPickup(string Value)
    {
        int shardCount = -1;
        char colorChar = ' ';
        string shardPart = "";
        if(Value == "Ginso")
        {
            Characters.Sein.Inventory.SetRandomizerItem(1024, 1);
            shardCount = RandomizerBonus.WaterVeinShards();
            shardPart = "Water Vein";
            colorChar = '*';
        }
        if(Value == "Forlorn")
        {
            Characters.Sein.Inventory.SetRandomizerItem(1025, 1);
            shardCount = RandomizerBonus.GumonSealShards();
            shardPart = "Gumon Seal";
            colorChar = '#';
        }
        if(Value == "Horu")
        {
            Characters.Sein.Inventory.SetRandomizerItem(1026, 1);
            shardCount = RandomizerBonus.SunstoneShards();
            shardPart = "Sunstone";
            colorChar = '@';
        }

        if(Randomizer.Shards && shardCount >= 0 && shardCount < 2)
        {
            if(shardCount == 1){
                shardPart = "1 more " + shardPart + " shard to activate";
            }
            else{
                shardPart = "2 " + shardPart + " shards to activate";  
            }
            PickupMessage(colorChar + "Broken " + Value + " teleporter\nCollect " + shardPart + colorChar, 300);
            return;
        }
        TeleporterController.Activate(Randomizer.TeleportTable[Value].ToString(), false);
        PickupMessage(colorChar + Value + " teleporter activated" + colorChar);
    }
    
    public static void GivePickup(RandomizerAction Action, int coords, bool found_locally=true)
    {
        try {
            switch (Action.Action) {
                case "RP":
                case "MU":
                    string[] pieces = ((string)Action.Value).Split('/');
                    for(int i = 0; i < pieces.Length; i+=2)
                    {
                        string code = pieces[i];
                        if(Randomizer.StringKeyPickupTypes.Contains(code)) {
                            RandomizerSwitch.GivePickup(new RandomizerAction(code, pieces[i+1]), coords, false);
                        } else {
                            int id;
                            int.TryParse(pieces[i+1], out id);
                            RandomizerSwitch.GivePickup(new RandomizerAction(code, id), coords, false);
                        }
                    }
                    SilentMode = false;
                    break;
                case "AC":
                    SkillPointPickup();
                    break;
                case "EC":
                    MaxEnergyContainerPickup();
                    break;
                case "EX":
                    ExpOrbPickup((int)Action.Value);
                    break;
                case "KS":
                    KeystonePickup();
                    break;
                case "HC":
                    MaxHealthContainerPickup();
                    break;
                case "MS":
                    MapStonePickup();
                    break;
                case "SK":
                    if(Randomizer.CutscenePickupLocs.Contains(coords))
                        Randomizer.FixCutscenePickup = (int)Action.Value;
                    AbilityPickup((int)Action.Value);
                    break;
                case "EV":
                    EventPickup((int)Action.Value);
                    break;
                case "RB":
                    RandomizerBonus.UpgradeID((int)Action.Value);
                    break;
                case "TP":
                    TeleportPickup((string)Action.Value);
                    break;
                case "SH":
                    string message = ((string)Action.Value).Replace("AltR", RandomizerRebinding.ReturnToStart.FirstBindName());
                    if(message.Length > 1 && message[1] == '=') {
                        var parts = message.Split(',').ToList();
                        var flags = parts.FindAll(ele => ele.Length >= 2 && ele[1] == '=');
                        message = String.Join(",", parts.FindAll(ele => ele.Length < 2 || ele[1] != '=').ToArray());
                        int duration = 120;
                        foreach(var flag in flags) {
                            var p = flag.Split('=');
                            if(p.Length != 2)
                                continue;
                            if(p[0] == "d")
                                int.TryParse(p[1], out duration);
                            else if(p[0] == "s")
                                SilentMode = (p[1].Trim().ToLower() == "true");
                        }
                        Randomizer.showHint(message, duration);
                    } else 
                        Randomizer.showHint(message);
                    break;
                case "WT":
                    RandomizerTrackedDataManager.SetRelic(Randomizer.RelicZoneLookup[(string)Action.Value]);
                    int relics = Characters.Sein.Inventory.GetRandomizerItem(302);
                    string relicStr = "\n("+relics.ToString() + "/" + Randomizer.RelicCount.ToString() + ")";
                    if(relics >= Randomizer.RelicCount) {
                        relicStr = "$" + relicStr + "$";
                    }
                    PickupMessage((string)Action.Value + relicStr, 480);
                    break;
                case "WS":
                case "WP":
                    Randomizer.SaveAfterWarp = Action.Action == "WS";
                    string[] xy = ((string)Action.Value).Split(',');
                    if(xy.Length > 2 && xy[2] == "force") {
                        Randomizer.WarpTo(new UnityEngine.Vector3(float.Parse(xy[0]), float.Parse(xy[1])), 15);
                    }
                    else {
                        Randomizer.WarpTarget = new UnityEngine.Vector3(float.Parse(xy[0]), float.Parse(xy[1]));
                        Randomizer.WarpSource = Characters.Sein.Position;
                        Randomizer.CanWarp = 7;
                    }
                    break;
                case "NO":
                    break;
            }
            BingoController.OnItem(Action, coords);
            RandomizerTrackedDataManager.UpdateBitfields();
        }
        catch(Exception e) {
            Randomizer.LogError("Give Pickup(" + Action.ToString() + ", " + coords.ToString() + "): " + e.Message);
        }
        if(found_locally && Randomizer.Sync)
            RandomizerSyncManager.FoundPickup(Action, coords);
        if(found_locally)
            Randomizer.OnCoord(coords);
    }
    public static bool SilentMode = false;
    public static void PickupMessage(string text, int frames=120) {
        if(SilentMode)
        {
            if(RandomizerSettings.Dev)
                Randomizer.log(text + " (squelched)");
            return;
        }
        Randomizer.showHint(text, frames);
    }
}