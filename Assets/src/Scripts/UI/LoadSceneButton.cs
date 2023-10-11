using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private SceneLoader.AvailableScene sceneToLoad;

    public void Handle_OnClick()
    {
        EventBus.OnContinueButtonSubmit.Publish();
        SceneLoader.LoadAvailableScene(sceneToLoad);
    }
}
