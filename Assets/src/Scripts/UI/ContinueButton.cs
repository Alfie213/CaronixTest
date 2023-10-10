using TMPro;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private PlayerDataHandler playerDataHandler;

    public void Handle_OnClick()
    {
        playerDataHandler.SetName(inputField.text);
        EventBus.OnContinueButtonSubmit.Publish();
    }
}
