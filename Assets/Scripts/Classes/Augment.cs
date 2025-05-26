using System;

[Serializable]
public class Augment
{
    public string augmentName;
    public string augmentType;
    public int cooldownAmount;
    public string cooldownInterval;
    public string augmentDescription;

    public Augment(string augmentName, string augmentType, int cooldownAmount, string cooldownInterval, string augmentDescription)
    {
        this.augmentName = augmentName;
        this.augmentType = augmentType;
        this.cooldownAmount = cooldownAmount;
        this.cooldownInterval = cooldownInterval;
        this.augmentDescription = augmentDescription;
    }

}
