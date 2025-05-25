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
    public int armorClassTotal;
    public int armorClassTemp = 0;
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

    public void ChooseRole()
    {

    }

    public void ChooseRace()
    {

    }

    private void EquipStarterEquipment()
    {

    }

    public void PlayAsEien()
    {

    }

    public void PlayAsXyril()
    {

    }

    private void CreateCharacter()
    {

    }
}