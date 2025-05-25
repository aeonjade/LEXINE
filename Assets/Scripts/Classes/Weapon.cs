using System;

[Serializable]
public class Weapon
{
    public string weaponName;
    public MODIFIER modifier;
    public int rollNumber;
    public DICE dice;
    public WEAPON_TYPE weaponType;
    public DAMAGE_TYPE damageType;

    public Weapon(string weaponName, MODIFIER modifier, int rollNumber, DICE dice, WEAPON_TYPE weaponType, DAMAGE_TYPE damageType)
    {
        this.weaponName = weaponName;
        this.modifier = modifier;
        this.rollNumber = rollNumber;
        this.dice = dice;
        this.weaponType = weaponType;
        this.damageType = damageType;
    }

}
