using TMPro;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private PlayerData playerData;
    
    public void Handle_OnClick()
    {
        AssignPlayerName();
        // Switch scene;
    }

    private void AssignPlayerName()
    {
        playerData.enteredName = true;
        playerData.playerName = inputField.text;
    }
}
