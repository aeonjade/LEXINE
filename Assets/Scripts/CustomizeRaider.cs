using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeRaider : MonoBehaviour
{
    public CharacterStats characterStats;

    // Input Fields
    public TMP_InputField raiderNameInputField;
    public ToggleGroup positionToggleGroup;
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

    void Start()
    {
        creditsValue.text = characterStats.credits.ToString();
        SetLooksAndAttitude(characterStats.raiderRole);
    }

    public void OnRoleDropdownChanged(TMP_Dropdown dropdown)
    {
        characterStats.ChooseRole((ROLE)dropdown.value);
        characterStats.ChooseRace(characterStats.raiderRace);
        SetLooksAndAttitude(characterStats.raiderRole);
    }

    public void OnRaceDropdownChanged(TMP_Dropdown dropdown)
    {
        characterStats.ChooseRace((RACE)dropdown.value);
    }

    public void OnAlignmentDropdownChanged(TMP_Dropdown dropdown)
    {
        characterStats.alignment = (ALIGNMENT)dropdown.value;
    }

    public void SetRaiderName()
    {
        characterStats.raiderName = raiderNameInputField.text.Trim();
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

    private void ResetInputFields()
    {
        raiderNameInputField.text = "";
    }
}
