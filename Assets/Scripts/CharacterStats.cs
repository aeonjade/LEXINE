using UnityEngine;

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
    public bool hasPowerRegulator = false;
    public bool hasMainDrive = false;
    public bool hasStabilizerUnit = false;
    public bool hasNavigationModule = false;
    public bool hasShieldGenerator = false;

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

        // Reset ship parts
        hasPowerRegulator = false;
        hasMainDrive = false;
        hasStabilizerUnit = false;
        hasNavigationModule = false;
        hasShieldGenerator = false;
    }

    public void ChooseRole(ROLE role)
    {
        switch (role)
        {
            case ROLE.CAPTAIN:
                SetBaseStats(11, 13, 3, 0, 1);
                eloquence = 2;
                stealth = 1;
                primaryWeapon = new Weapon("Combat Knife", MODIFIER.STR, 1, DICE.D6, WEAPON_TYPE.MELEE, DAMAGE_TYPE.PHYSICAL);
                break;
            case ROLE.REAPER:
                SetBaseStats(10, 12, 0, 3, 2);
                domination = 2;
                acrobatics = 1;
                primaryWeapon = new Weapon("Light Pistol", MODIFIER.DEX, 1, DICE.D6, WEAPON_TYPE.RANGED, DAMAGE_TYPE.KINETIC);
                break;
            case ROLE.ENGINEER:
                SetBaseStats(12, 14, 2, 1, 0);
                technology = 2;
                athletics = 1;
                primaryWeapon = new Weapon("Reinforced Gauntlet", MODIFIER.STR, 1, DICE.D6, WEAPON_TYPE.MELEE, DAMAGE_TYPE.PHYSICAL);
                break;
            case ROLE.SURGEON:
                SetBaseStats(9, 11, 1, 2, 3);
                sensory = 2;
                database = 1;
                primaryWeapon = new Weapon("Injector Pistol", MODIFIER.INT, 1, DICE.D4, WEAPON_TYPE.RANGED, DAMAGE_TYPE.PHYSICAL);
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
        switch (race)
        {
            case RACE.EARTHKIN:
                strength += 1;
                dexterity += 1;
                intelligence += 1;
                eloquence += 2;
                instinct += 1;
                break;
            case RACE.CYBORG:
                intelligence += 2;
                technology += 2;
                sensory += 1;
                break;
            case RACE.STEELFORGED:
                strength += 1;
                database += 2;
                technology += 1;
                break;
            case RACE.DEMONOID:
                strength += 2;
                domination += 2;
                eloquence += 1;
                break;
            case RACE.HEXARI:
                dexterity += 1;
                instinct += 2;
                athletics += 1;
                break;
            case RACE.DRAKO:
                hpMax += 2;
                hpCurrent = hpMax;
                acTotal += 1;
                athletics += 2;
                acrobatics += 1;
                break;
            case RACE.XENTHARIAN:
                dexterity += 2;
                stealth += 2;
                domination += 1;
                break;
        }
    }

    public void PlayAsEien()
    {
        raiderName = "Eien";
        ChooseRole(ROLE.CAPTAIN);
        ChooseRace(RACE.EARTHKIN);
        alignment = ALIGNMENT.NEUTRAL;
    }

    public void PlayAsXyril()
    {
        raiderName = "Xyril";
        ChooseRole(ROLE.SURGEON);
        ChooseRace(RACE.CYBORG);
        alignment = ALIGNMENT.NEUTRAL;
    }

    private void CreateCharacter()
    {

    }
}