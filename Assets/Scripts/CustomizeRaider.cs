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

    }

    private void ResetInputFields()
    {
        raiderNameInputField.text = "";
    }
}
