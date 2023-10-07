using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Checks the value of InputField.
/// If value is null or white space -> disables Button interactable.
/// Else -> enables Button interactable.
/// </summary>
public class InputFieldChecker : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button continueButton;

    private void OnEnable()
    {
        inputField.onValueChanged.AddListener(Handle_onValueChanged);
    }

    private void OnDisable()
    {
        inputField.onValueChanged.RemoveListener(Handle_onValueChanged);
    }

    private void Handle_onValueChanged(string value)
    {
        ChangeButtonInteractable(continueButton, !string.IsNullOrWhiteSpace(value));
    }

    private void ChangeButtonInteractable(Button button, bool state)
    {
        continueButton.interactable = state;
    }
}
