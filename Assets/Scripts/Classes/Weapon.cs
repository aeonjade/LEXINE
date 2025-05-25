using System;

[Serializable]
public class Weapon
{
    public string weaponName;
    public MODIFIER modifier;
    public int rollNumber;
    public DICE dice;

    public Weapon(string weaponName, MODIFIER modifier, int rollNumber, DICE dice)
    {
        this.weaponName = weaponName;
        this.modifier = modifier;
        this.rollNumber = rollNumber;
        this.dice = dice;
    }

}
