using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private SceneLoader.AvailableScene sceneToLoad;

    private SceneLoader sceneLoader;
    
    public void Handle_OnClick()
    {
        EventBus.OnContinueButtonSubmit.Publish();
        sceneLoader.LoadAvailableScene(sceneToLoad);
    }
}
