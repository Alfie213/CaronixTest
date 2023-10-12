using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private SceneLoader.AvailableScene sceneToLoad;

    private Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(Handle_OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(Handle_OnClick);
    }

    private void Handle_OnClick()
    {
        EventBus.OnLoadSceneButtonClick.Publish(sceneToLoad);
    }
}
