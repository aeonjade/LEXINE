using System;

[Serializable]
public class Armor
{
    public string armorName;
    public int additionalArmorClass;
    public Armor(string armorName, int additionalArmorClass)
    {
        this.armorName = armorName;
        this.additionalArmorClass = additionalArmorClass;
    }
}
