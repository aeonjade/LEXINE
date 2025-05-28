using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomizeRaider : MonoBehaviour
{
    public CharacterStats characterStats;

    // Input Fields
    public TMP_InputField raiderNameInputField;
    public TMP_InputField raiderStoryInputField;
    public ToggleGroup positionToggleGroup;
    public ToggleGroup coreAugmentToggleGroup;
    public ToggleGroup looks1ToggleGroup;
    public ToggleGroup looks2ToggleGroup;
    public ToggleGroup looks3ToggleGroup;
    public ToggleGroup attitude1ToggleGroup;
    public ToggleGroup attitude2ToggleGroup;
    public ToggleGroup attitude3ToggleGroup;
    public Toggle raiderType2;
    public Toggle coreAugment1Toggle;
    public TextMeshProUGUI creditsValue;
    public TextMeshProUGUI looks1A;
    public TextMeshProUGUI looks1B;
    public TextMeshProUGUI looks2A;
    public TextMeshProUGUI looks2B;
    public TextMeshProUGUI looks3A;
    public TextMeshProUGUI looks3B;
    public TextMeshProUGUI attitude1A;
    public TextMeshProUGUI attitude1B;
    public TextMeshProUGUI attitude2A;
    public TextMeshProUGUI attitude2B;
    public TextMeshProUGUI attitude3A;
    public TextMeshProUGUI attitude3B;
    public TextMeshProUGUI coreAugment1;
    public TextMeshProUGUI coreAugment2;
    public TextMeshProUGUI coreAugment1Description;
    public TextMeshProUGUI coreAugment2Description;
    public TextMeshProUGUI primaryWeapon;
    public TextMeshProUGUI primaryWeaponDescription;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI armorDescription;

    public Button confirmButton;
    public Button saveButton;


    public Image raiderPortrait;
    public Sprite type1Portrait;
    public Sprite type2Portrait;

    public TextMeshProUGUI hpValue;
    public TextMeshProUGUI acValue;
    public TextMeshProUGUI strengthValue;
    public TextMeshProUGUI dexterityValue;
    public TextMeshProUGUI intelligenceValue;
    public TextMeshProUGUI acrobaticsValue;
    public TextMeshProUGUI athleticsValue;
    public TextMeshProUGUI databaseValue;
    public TextMeshProUGUI dominationValue;
    public TextMeshProUGUI eloquenceValue;
    public TextMeshProUGUI instinctValue;
    public TextMeshProUGUI sensoryValue;
    public TextMeshProUGUI stealthValue;
    public TextMeshProUGUI technologyValue;

    public TMP_Dropdown roleDropdown;
    public TMP_Dropdown raceDropdown;
    public TMP_Dropdown alignmentDropdown;

    void Start()
    {
        characterStats.ChooseRole(characterStats.raiderRole);
        characterStats.ChooseRace(characterStats.raiderRace);
    }


    public void OnRoleDropdownChanged(TMP_Dropdown dropdown)
    {
        RACE originalRace = characterStats.raiderRace;
        characterStats.ResetAll();
        characterStats.ChooseRole((ROLE)dropdown.value);
        characterStats.ChooseRace(originalRace);
        ResetInputFields();
    }

    public void OnRaceDropdownChanged(TMP_Dropdown dropdown)
    {
        ROLE originalRole = characterStats.raiderRole;
        characterStats.ResetAll();
        characterStats.ChooseRole(originalRole);
        characterStats.ChooseRace((RACE)dropdown.value);
        ResetInputFields();
    }

    public void OnAlignmentDropdownChanged(TMP_Dropdown dropdown)
    {
        characterStats.alignment = (ALIGNMENT)dropdown.value;
    }

    public void SetStatsAndSkills()
    {
        hpValue.text = characterStats.hpMax.ToString();
        acValue.text = characterStats.acTotal.ToString();
        strengthValue.text = characterStats.strength.ToString();
        dexterityValue.text = characterStats.dexterity.ToString();
        intelligenceValue.text = characterStats.intelligence.ToString();
        acrobaticsValue.text = characterStats.acrobatics.ToString();
        athleticsValue.text = characterStats.athletics.ToString();
        databaseValue.text = characterStats.database.ToString();
        dominationValue.text = characterStats.domination.ToString();
        eloquenceValue.text = characterStats.eloquence.ToString();
        instinctValue.text = characterStats.instinct.ToString();
        sensoryValue.text = characterStats.sensory.ToString();
        stealthValue.text = characterStats.stealth.ToString();
        technologyValue.text = characterStats.technology.ToString();
    }

    public void SetRaiderName()
    {
        characterStats.raiderName = raiderNameInputField.text.Trim();
        CheckInputs();
    }

    public void SetRaiderStory()
    {
        characterStats.story = raiderStoryInputField.text.Trim();
        CheckInputs();
    }

    public void SetRaiderPosition()
    {
        characterStats.position = (POSITION)Enum.Parse(typeof(POSITION), positionToggleGroup.ActiveToggles().FirstOrDefault().name);
    }

    public void SetLooksAndAttitude(ROLE role)
    {
        switch (role)
        {
            case ROLE.Captain:
                looks1A.text = "Well-Groomed";
                looks1B.text = "Rough and Scruffy";
                looks2A.text = "Tall and Imposing";
                looks2B.text = "Short and Mean";
                looks3A.text = "Sharp Eyes";
                looks3B.text = "Warm Smile";
                attitude1A.text = "Calculated and Precise";
                attitude1B.text = "Impulsive";
                attitude2A.text = "Diplomatic";
                attitude2B.text = "Aggressive";
                attitude3A.text = "Mysterious";
                attitude3B.text = "Easy to Read";
                break;
            case ROLE.Reaper:
                looks1A.text = "Mysterious";
                looks1B.text = "Tactical and Sleek";
                looks2A.text = "Slender and Agile";
                looks2B.text = "Muscular";
                looks3A.text = "Worn out Boots";
                looks3B.text = "High-Tech Gear";
                attitude1A.text = "Patient";
                attitude1B.text = "Rash";
                attitude2A.text = "Detached";
                attitude2B.text = "Personal";
                attitude3A.text = "Methodical";
                attitude3B.text = "Chaotic";
                break;
            case ROLE.Engineer:
                looks1A.text = "Grimy and Geared-up";
                looks1B.text = "Clean and Shiny";
                looks2A.text = "Messy and Worn-out";
                looks2B.text = "Tidy and Prepared";
                looks3A.text = "Rough and Handmade";
                looks3B.text = "Advanced";
                attitude1A.text = "Calm and Careful";
                attitude1B.text = "Rushed and Careless";
                attitude2A.text = "Warm and Relaxed";
                attitude2B.text = "Mocking and distrustful";
                attitude3A.text = "Tech-whisperer";
                attitude3B.text = "Focused and Serious";
                break;
            case ROLE.Surgeon:
                looks1A.text = "Pure Clean-handed";
                looks1B.text = "Cold and heartless";
                looks2A.text = "Well-groomed";
                looks2B.text = "Messy and Tired";
                looks3A.text = "Elegant Uniform";
                looks3B.text = "Bloody and worn";
                attitude1A.text = "Warm-hearted";
                attitude1B.text = "Cold-hearted";
                attitude2A.text = "Calculated";
                attitude2B.text = "Unrestrained";
                attitude3A.text = "Calm and Kind";
                attitude3B.text = "Hot-Tempered";
                break;
        }
    }

    public void SetRaiderPortrait()
    {
        characterStats.hasType2Portrait = raiderType2.isOn;
        raiderPortrait.sprite = characterStats.hasType2Portrait ? type2Portrait : type1Portrait;
    }

    public void SetRaiderLooks1()
    {
        characterStats.looks1 = looks1ToggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SetRaiderLooks2()
    {
        characterStats.looks2 = looks2ToggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SetRaiderLooks3()
    {
        characterStats.looks3 = looks3ToggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SetRaiderAttitude1()
    {
        characterStats.attitude1 = attitude1ToggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SetRaiderAttitude2()
    {
        characterStats.attitude2 = attitude2ToggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SetRaiderAttitude3()
    {
        characterStats.attitude3 = attitude3ToggleGroup.ActiveToggles().FirstOrDefault().GetComponentInChildren<TextMeshProUGUI>().text;
    }

    public void SetRaiderCoreAugment()
    {
        switch (characterStats.raiderRole)
        {
            case ROLE.Captain:
                coreAugment1.text = "Commanding Voice";
                coreAugment1Description.text = "(Passive, Does not stack) Your words carry authority, demanding attention. +2 to Eloquence and Domination checks.";
                coreAugment2.text = "Tactical Orders";
                coreAugment2Description.text = "(Bonus, Once per turn) Issue a quick battlefield directive to an ally. Once per turn, grant an ally +1d4 to their next attack roll.";
                break;
            case ROLE.Reaper:
                coreAugment1.text = "Quick Strike";
                coreAugment1Description.text = "(Bonus, 3-turn Cooldown) Load your next attack with precision and speed. Deal 1d6 damage to an enemy.";
                coreAugment2.text = "Stealth Module";
                coreAugment2Description.text = "(Bonus, Stealth Check) You Hide in the shadows, attempting to avoid detection. Grants Advantage on your next attack if successful.";
                break;
            case ROLE.Engineer:
                coreAugment1.text = "Fortify Armor";
                coreAugment1Description.text = "(Bonus, Once per encounter) Your reinforced gear absorbs incoming fire. Reduce incoming damage by 1d6 for one turn.";
                coreAugment2.text = "Overclock Shields";
                coreAugment2Description.text = "(Bonus, Once per long rest) Divert extra power to personal shields. Temporarily gain 10 HP for 2 turns.";
                break;
            case ROLE.Surgeon:
                coreAugment1.text = "Nano-Stitcher";
                coreAugment1Description.text = "(Action, Twice per long rest) Deploys microscopic repair nanites to rapidly seal wounds. Restore 1d6 HP.";
                coreAugment2.text = "Neural Overclock";
                coreAugment2Description.text = "(Action, Once per encounter) Inject an ally with a stimulant. Target gains +2 to attack rolls for 2 turns.";
                break;
        }
    }

    public void ChooseRaiderCoreAugment()
    {
        switch (characterStats.raiderRole)
        {
            case ROLE.Captain:
                characterStats.coreAugment = coreAugment1Toggle.isOn ? new Augment("Commanding Voice", "Passive", 0, "Does not stack", "Your words carry authority, demanding attention. +2 to Eloquence and Domination checks.")
                 : new Augment("Tactical Orders", "Bonus", 1, "Once per turn", "Issue a quick battlefield directive to an ally. Once per turn, grant an ally +1d4 to their next attack roll.");
                break;
            case ROLE.Reaper:
                characterStats.coreAugment = coreAugment1Toggle.isOn ? new Augment("Quick Strike", "Bonus", 3, "3-turn Cooldown", "Load your next attack with precision and speed. Deal 1d6 damage to an enemy.")
                 : new Augment("Stealth Module", "Bonus", 1, "Stealth Check", "You Hide in the shadows, attempting to avoid detection. Grants Advantage on your next attack if successful.");
                break;
            case ROLE.Engineer:
                characterStats.coreAugment = coreAugment1Toggle.isOn ? new Augment("Fortify Armor", "Bonus", 1, "Once per encounter", "Your reinforced gear absorbs incoming fire. Reduce incoming damage by 1d6 for one turn.")
                 : new Augment("Overclock Shields", "Bonus", 1, "Once per long rest", "Divert extra power to personal shields. Temporarily gain 10 HP for 2 turns.");
                break;
            case ROLE.Surgeon:
                characterStats.coreAugment = coreAugment1Toggle.isOn ? new Augment("Nano-Stitcher", "Action", 2, "Twice per long rest", "Deploys microscopic repair nanites to rapidly seal wounds. Restore 1d6 HP.")
                 : new Augment("Neural Overclock", "Action", 1, "Once per encounter", "Inject an ally with a stimulant. Target gains +2 to attack rolls for 2 turns.");
                break;
        }
    }

    public void SetRaiderEquipment()
    {
        primaryWeapon.text = characterStats.primaryWeapon.weaponName;
        armor.text = characterStats.armor.armorName;

        primaryWeaponDescription.text = $"{characterStats.primaryWeapon.rollNumber} {characterStats.primaryWeapon.dice} {characterStats.primaryWeapon.weaponType} {characterStats.primaryWeapon.damageType}";
        armorDescription.text = $"+{characterStats.armor.additionalArmorClass} AC";
    }

    public void ResetInputFields()
    {
        // Reset input fields
        raiderNameInputField.text = "";
        raiderStoryInputField.text = "";

        // Reset base choices
        characterStats.alignment = ALIGNMENT.Neutral;

        // Reset portrait
        characterStats.hasType2Portrait = false;
        raiderPortrait.sprite = type1Portrait;
        if (raiderType2 != null) raiderType2.isOn = false;

        // Reset toggle groups
        if (positionToggleGroup != null)
        {
            var firstToggle = positionToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderPosition();
        }

        // Reset core augment
        if (coreAugment1Toggle != null) coreAugment1Toggle.isOn = true;
        SetRaiderCoreAugment();
        ChooseRaiderCoreAugment();

        // Reset looks and attitudes
        SetLooksAndAttitude(characterStats.raiderRole);
        if (looks1ToggleGroup != null)
        {
            var firstToggle = looks1ToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderLooks1();
        }
        if (looks2ToggleGroup != null)
        {
            var firstToggle = looks2ToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderLooks2();
        }
        if (looks3ToggleGroup != null)
        {
            var firstToggle = looks3ToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderLooks3();
        }
        if (attitude1ToggleGroup != null)
        {
            var firstToggle = attitude1ToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderAttitude1();
        }
        if (attitude2ToggleGroup != null)
        {
            var firstToggle = attitude2ToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderAttitude2();
        }
        if (attitude3ToggleGroup != null)
        {
            var firstToggle = attitude3ToggleGroup.GetComponentsInChildren<Toggle>().FirstOrDefault();
            if (firstToggle != null) firstToggle.isOn = true;
            SetRaiderAttitude3();
        }

        // Reset equipment and stats
        SetRaiderEquipment();
        SetStatsAndSkills();

        // Reset buttons
        confirmButton.interactable = false;
        saveButton.interactable = false;
    }

    public void CheckInputs()
    {
        confirmButton.interactable = (raiderNameInputField.text.Trim() != "" && raiderStoryInputField.text.Trim() != "") ? true : false;
        saveButton.interactable = (raiderNameInputField.text.Trim() != "" && raiderStoryInputField.text.Trim() != "") ? true : false;
    }

    public void PressConfirm()
    {
        Invoke("StartAdventure", 2f);
    }

    private void StartAdventure()
    {
        SceneManager.LoadScene("Game");
    }

    public void ResetDropdowns()
    {
        roleDropdown.value = 0;
        raceDropdown.value = 0;
        alignmentDropdown.value = 0;
    }
}
