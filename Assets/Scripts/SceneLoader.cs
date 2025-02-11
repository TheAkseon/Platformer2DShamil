using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button button;
    public string NameScene;

    private void Start()
    {
        button.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(NameScene);
    }
}
