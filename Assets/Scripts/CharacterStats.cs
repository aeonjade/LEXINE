using System;
using TMPro;
using UnityEngine;
using System.IO;

[Serializable]
public class CharacterStats : MonoBehaviour
{
    [Serializable]
    private class WeaponData
    {
        public string weaponName;
        public MODIFIER modifier;
        public int rollNumber;
        public DICE dice;
        public WEAPON_TYPE weaponType;
        public DAMAGE_TYPE damageType;
    }

    [Serializable]
    private class ArmorData
    {
        public string armorName;
        public int additionalArmorClass;
    }

    [Serializable]
    private class AugmentData
    {
        public string augmentName;
        public string augmentType;
        public int cooldownAmount;
        public string cooldownInterval;
        public string augmentDescription;
    }

    [Serializable]
    private class SaveData
    {
        // Basic Info
        public string raiderName;
        public ROLE raiderRole;
        public RACE raiderRace;
        public ALIGNMENT alignment;
        public string looks1, looks2, looks3;
        public string attitude1, attitude2, attitude3;
        public POSITION position;
        public string story;

        // Equipment
        public WeaponData primaryWeapon;
        public WeaponData secondaryWeapon;
        public ArmorData armor;
        public AugmentData coreAugment;

        // Stats & Skills
        public int hpMax, hpCurrent, acTotal, acTemp;
        public int strength, intelligence, dexterity, credits;
        public int acrobatics, athletics, database, domination;
        public int eloquence, instinct, sensory, stealth, technology;

        // Ship Parts & Appearance
        public bool hasPowerRegulator, hasMainDrive, hasStabilizerUnit;
        public bool hasNavigationModule, hasShieldGenerator, hasType2Portrait;
    }

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
    public Augment coreAugment;
    public bool hasPowerRegulator = false;
    public bool hasMainDrive = false;
    public bool hasStabilizerUnit = false;
    public bool hasNavigationModule = false;
    public bool hasShieldGenerator = false;
    public bool hasType2Portrait = false;


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
        coreAugment = null;

        // Reset ship parts
        hasPowerRegulator = false;
        hasMainDrive = false;
        hasStabilizerUnit = false;
        hasNavigationModule = false;
        hasShieldGenerator = false;

        hasType2Portrait = false;
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
    }


    public void PlayAsEien()
    {
        raiderName = "Eien";
        ChooseRole(ROLE.Captain);
        ChooseRace(RACE.Earthkin);
        coreAugment = new Augment("Tactical Orders", "Passive", 0, "Does not stack",
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
        coreAugment = new Augment("Nano-Stitcher", "Action", 2, "Long Rest",
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

    public void SaveCharacter()
    {
        var saveData = new SaveData
        {
            // Basic Info
            raiderName = this.raiderName,
            raiderRole = this.raiderRole,
            raiderRace = this.raiderRace,
            alignment = this.alignment,
            looks1 = this.looks1,
            looks2 = this.looks2,
            looks3 = this.looks3,
            attitude1 = this.attitude1,
            attitude2 = this.attitude2,
            attitude3 = this.attitude3,
            position = this.position,
            story = this.story,

            // Equipment
            primaryWeapon = primaryWeapon != null ? new WeaponData
            {
                weaponName = primaryWeapon.weaponName,
                modifier = primaryWeapon.modifier,
                rollNumber = primaryWeapon.rollNumber,
                dice = primaryWeapon.dice,
                weaponType = primaryWeapon.weaponType,
                damageType = primaryWeapon.damageType
            } : null,
            secondaryWeapon = secondaryWeapon != null ? new WeaponData
            {
                weaponName = secondaryWeapon.weaponName,
                modifier = secondaryWeapon.modifier,
                rollNumber = secondaryWeapon.rollNumber,
                dice = secondaryWeapon.dice,
                weaponType = secondaryWeapon.weaponType,
                damageType = secondaryWeapon.damageType
            } : null,
            armor = new ArmorData { armorName = armor.armorName, additionalArmorClass = armor.additionalArmorClass },
            coreAugment = coreAugment != null ? new AugmentData
            {
                augmentName = coreAugment.augmentName,
                augmentType = coreAugment.augmentType,
                cooldownAmount = coreAugment.cooldownAmount,
                cooldownInterval = coreAugment.cooldownInterval,
                augmentDescription = coreAugment.augmentDescription
            } : null,

            // Stats & Skills
            hpMax = this.hpMax,
            hpCurrent = this.hpCurrent,
            acTotal = this.acTotal,
            acTemp = this.acTemp,
            strength = this.strength,
            intelligence = this.intelligence,
            dexterity = this.dexterity,
            credits = this.credits,

            // Skills
            acrobatics = this.acrobatics,
            athletics = this.athletics,
            database = this.database,
            domination = this.domination,
            eloquence = this.eloquence,
            instinct = this.instinct,
            sensory = this.sensory,
            stealth = this.stealth,
            technology = this.technology,

            // Ship Parts & Appearance
            hasPowerRegulator = this.hasPowerRegulator,
            hasMainDrive = this.hasMainDrive,
            hasStabilizerUnit = this.hasStabilizerUnit,
            hasNavigationModule = this.hasNavigationModule,
            hasShieldGenerator = this.hasShieldGenerator,
            hasType2Portrait = this.hasType2Portrait
        };

        string json = JsonUtility.ToJson(saveData, true);
        string path = Path.Combine(Application.persistentDataPath, $"{raiderName}_character.json");
        File.WriteAllText(path, json);
        Debug.Log($"Character saved to: {path}");
    }

    public void LoadCharacter(string characterName)
    {
        string path = Path.Combine(Application.persistentDataPath, $"{characterName}_character.json");
        if (!File.Exists(path))
        {
            Debug.LogWarning($"No save file found at: {path}");
            return;
        }

        string json = File.ReadAllText(path);
        var saveData = JsonUtility.FromJson<SaveData>(json);

        // Basic Info
        this.raiderName = saveData.raiderName;
        this.raiderRole = saveData.raiderRole;
        this.raiderRace = saveData.raiderRace;
        this.alignment = saveData.alignment;
        this.looks1 = saveData.looks1;
        this.looks2 = saveData.looks2;
        this.looks3 = saveData.looks3;
        this.attitude1 = saveData.attitude1;
        this.attitude2 = saveData.attitude2;
        this.attitude3 = saveData.attitude3;
        this.position = saveData.position;
        this.story = saveData.story;

        // Equipment
        this.primaryWeapon = saveData.primaryWeapon != null ?
            new Weapon(saveData.primaryWeapon.weaponName, saveData.primaryWeapon.modifier,
                      saveData.primaryWeapon.rollNumber, saveData.primaryWeapon.dice,
                      saveData.primaryWeapon.weaponType, saveData.primaryWeapon.damageType) : null;

        this.secondaryWeapon = saveData.secondaryWeapon != null ?
            new Weapon(saveData.secondaryWeapon.weaponName, saveData.secondaryWeapon.modifier,
                      saveData.secondaryWeapon.rollNumber, saveData.secondaryWeapon.dice,
                      saveData.secondaryWeapon.weaponType, saveData.secondaryWeapon.damageType) : null;

        this.armor = new Armor(saveData.armor.armorName, saveData.armor.additionalArmorClass);

        this.coreAugment = saveData.coreAugment != null ?
            new Augment(saveData.coreAugment.augmentName, saveData.coreAugment.augmentType,
                       saveData.coreAugment.cooldownAmount, saveData.coreAugment.cooldownInterval,
                       saveData.coreAugment.augmentDescription) : null;

        // Stats & Skills
        this.hpMax = saveData.hpMax;
        this.hpCurrent = saveData.hpCurrent;
        this.acTotal = saveData.acTotal;
        this.acTemp = saveData.acTemp;
        this.strength = saveData.strength;
        this.intelligence = saveData.intelligence;
        this.dexterity = saveData.dexterity;
        this.credits = saveData.credits;

        // Skills
        this.acrobatics = saveData.acrobatics;
        this.athletics = saveData.athletics;
        this.database = saveData.database;
        this.domination = saveData.domination;
        this.eloquence = saveData.eloquence;
        this.instinct = saveData.instinct;
        this.sensory = saveData.sensory;
        this.stealth = saveData.stealth;
        this.technology = saveData.technology;

        // Ship Parts & Appearance
        this.hasPowerRegulator = saveData.hasPowerRegulator;
        this.hasMainDrive = saveData.hasMainDrive;
        this.hasStabilizerUnit = saveData.hasStabilizerUnit;
        this.hasNavigationModule = saveData.hasNavigationModule;
        this.hasShieldGenerator = saveData.hasShieldGenerator;
        this.hasType2Portrait = saveData.hasType2Portrait;

        Debug.Log($"Character loaded from: {path}");
    }

}