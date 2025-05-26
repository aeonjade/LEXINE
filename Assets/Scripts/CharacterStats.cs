using System;
using TMPro;
using UnityEngine;

[Serializable]
public class CharacterStats : MonoBehaviour
{
    public string raiderName;
    public ROLE raiderRole;
    public RACE raiderRace;
    public ALIGNMENT alignment;
    public string looks1;
    public string looks2;
    public string looks3;
    public string attitude1;
    public string attitude2;
    public string attitude3;
    public POSITION position;
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public Armor armor = new Armor("Raider Cloth", 0);
    public string story;
    public int hpMax;
    public int hpCurrent;
    public int acTotal;
    public int acTemp = 0;
    public int strength;
    public int intelligence;
    public int dexterity;
    public int credits = 0;
    public int acrobatics;
    public int athletics;
    public int database;
    public int domination;
    public int eloquence;
    public int instinct;
    public int sensory;
    public int stealth;
    public int technology;
    public Skill starterSkill;
    public bool hasPowerRegulator = false;
    public bool hasMainDrive = false;
    public bool hasStabilizerUnit = false;
    public bool hasNavigationModule = false;
    public bool hasShieldGenerator = false;

    // Input Fields
    public TMP_InputField raiderNameInputField;

    public void ResetAll()
    {
        // Reset basic info
        raiderName = "";
        raiderRole = default;
        raiderRace = default;
        alignment = default;
        position = default;

        // Reset appearance and personality
        looks1 = "";
        looks2 = "";
        looks3 = "";
        attitude1 = "";
        attitude2 = "";
        attitude3 = "";
        story = "";

        // Reset equipment
        primaryWeapon = null;
        secondaryWeapon = null;
        armor = new Armor("Raider Cloth", 0);

        // Reset stats
        hpMax = 0;
        hpCurrent = 0;
        acTotal = 0;
        acTemp = 0;
        strength = 0;
        intelligence = 0;
        dexterity = 0;
        credits = 0;

        // Reset skills
        acrobatics = 0;
        athletics = 0;
        database = 0;
        domination = 0;
        eloquence = 0;
        instinct = 0;
        sensory = 0;
        stealth = 0;
        technology = 0;
        starterSkill = null;

        // Reset ship parts
        hasPowerRegulator = false;
        hasMainDrive = false;
        hasStabilizerUnit = false;
        hasNavigationModule = false;
        hasShieldGenerator = false;
    }

    public void ChooseRole(ROLE role)
    {
        ResetAll();
        switch (role)
        {
            case ROLE.Captain:
                raiderRole = ROLE.Captain;
                SetBaseStats(11, 13, 3, 0, 1);
                eloquence = 2;
                stealth = 1;
                primaryWeapon = new Weapon("Combat Knife", MODIFIER.STR, 1, DICE.d6, WEAPON_TYPE.Melee, DAMAGE_TYPE.Physical);
                break;
            case ROLE.Reaper:
                raiderRole = ROLE.Reaper;
                SetBaseStats(10, 12, 0, 3, 2);
                domination = 2;
                acrobatics = 1;
                primaryWeapon = new Weapon("Light Pistol", MODIFIER.DEX, 1, DICE.d6, WEAPON_TYPE.Ranged, DAMAGE_TYPE.Kinetic);
                break;
            case ROLE.Engineer:
                raiderRole = ROLE.Engineer;
                SetBaseStats(12, 14, 2, 1, 0);
                technology = 2;
                athletics = 1;
                primaryWeapon = new Weapon("Reinforced Gauntlet", MODIFIER.STR, 1, DICE.d6, WEAPON_TYPE.Melee, DAMAGE_TYPE.Physical);
                break;
            case ROLE.Surgeon:
                raiderRole = ROLE.Surgeon;
                SetBaseStats(9, 11, 1, 2, 3);
                sensory = 2;
                database = 1;
                primaryWeapon = new Weapon("Injector Pistol", MODIFIER.INT, 1, DICE.d4, WEAPON_TYPE.Ranged, DAMAGE_TYPE.Physical);
                break;
        }
    }

    private void SetBaseStats(int baseHP, int baseAC, int baseSTR, int baseDEX, int baseINT)
    {
        hpMax = baseHP;
        hpCurrent = hpMax;
        acTotal = baseAC;
        strength = baseSTR;
        dexterity = baseDEX;
        intelligence = baseINT;
    }

    public void ChooseRace(RACE race)
    {
        ChooseRole(raiderRole);
        switch (race)
        {
            case RACE.Earthkin:
                raiderRace = RACE.Earthkin;
                strength += 1;
                dexterity += 1;
                intelligence += 1;
                eloquence += 2;
                instinct += 1;
                break;
            case RACE.Cyborg:
                raiderRace = RACE.Cyborg;
                intelligence += 2;
                technology += 2;
                sensory += 1;
                break;
            case RACE.Steelforged:
                raiderRace = RACE.Steelforged;
                strength += 1;
                database += 2;
                technology += 1;
                break;
            case RACE.Demonoid:
                raiderRace = RACE.Demonoid;
                strength += 2;
                domination += 2;
                eloquence += 1;
                break;
            case RACE.Hexari:
                raiderRace = RACE.Hexari;
                dexterity += 1;
                instinct += 2;
                athletics += 1;
                break;
            case RACE.Drako:
                raiderRace = RACE.Drako;
                hpMax += 2;
                hpCurrent = hpMax;
                acTotal += 1;
                athletics += 2;
                acrobatics += 1;
                break;
            case RACE.Xentharian:
                raiderRace = RACE.Xentharian;
                dexterity += 2;
                stealth += 2;
                domination += 1;
                break;
        }
        ResetInputFields();
    }

    private void ResetInputFields()
    {
        raiderNameInputField.text = "";
    }

    public void PlayAsEien()
    {
        raiderName = "Eien";
        ChooseRole(ROLE.Captain);
        ChooseRace(RACE.Earthkin);
        starterSkill = new Skill("Tactical Orders", "Bonus Action", 1, "Turn",
        "Issue a quick battlefield directive to an ally. Once per turn, grant an ally +1d4 to their next attack roll.");
        alignment = ALIGNMENT.Neutral;
        looks1 = "Well-Groomed";
        looks2 = "Tall and Imposing";
        looks3 = "Sharp Eyes";
        attitude1 = "Calculated and Precise";
        attitude2 = "Diplomatic";
        attitude3 = "Mysterious";
        position = POSITION.Frontline;
        story = "A courageous space raider from a land unknown.";
    }

    public void PlayAsXyril()
    {
        raiderName = "Xyril";
        ChooseRole(ROLE.Surgeon);
        ChooseRace(RACE.Cyborg);
        starterSkill = new Skill("Nano-Stitcher", "Action", 2, "Long Rest",
        "Deploys microscopic repair nanites to rapidly seal wounds. Restore 1d6 HP.");
        alignment = ALIGNMENT.Neutral;
        looks1 = "Pure Clean-handed";
        looks2 = "Well-groomed";
        looks3 = "Elegant Uniform";
        attitude1 = "Warm-hearted";
        attitude2 = "Calculated";
        attitude3 = "Calm and Kind";
        position = POSITION.Backline;
        story = "A master of their trade from a faraway land.";
    }

    public void OnRoleDropdownChanged(TMP_Dropdown dropdown)
    {
        ChooseRole((ROLE)dropdown.value);
        ChooseRace(raiderRace);
    }

    public void OnRaceDropdownChanged(TMP_Dropdown dropdown)
    {
        ChooseRace((RACE)dropdown.value);
    }

    public void SetRaiderName()
    {
        raiderName = raiderNameInputField.text.Trim();
    }

}