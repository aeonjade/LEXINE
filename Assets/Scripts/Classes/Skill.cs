using System;

[Serializable]
public class Skill
{
    public string skillName;
    public string skillType;
    public int cooldownAmount;
    public string cooldownInterval;
    public string skillDescription;

    public Skill(string skillName, string skillType, int cooldownAmount, string cooldownInterval, string skillDescription)
    {
        this.skillName = skillName;
        this.skillType = skillType;
        this.cooldownAmount = cooldownAmount;
        this.cooldownInterval = cooldownInterval;
        this.skillDescription = skillDescription;
    }

}
