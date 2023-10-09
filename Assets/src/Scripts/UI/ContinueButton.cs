using TMPro;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private PlayerData playerData;
    
    public void Handle_OnClick()
    {
        AssignPlayerName();
        // Switch scene;
    }

    private void AssignPlayerName()
    {
        playerData.enteredName = true;
        playerData.playerName = nameInputField.text;
    }
}
