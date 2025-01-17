using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene instance;
    public GameObject loadingScreen;
    public Image loadingBarFill;

    private float _target;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false; // Prevent the scene from activating immediately

        loadingScreen.SetActive(true);

        do
        {
            await Task.Delay(100);
            _target = scene.progress; // Update the target based on the loading progress
        } while (scene.progress < 0.9f);

        // Add a slight delay to allow the loading bar to fill up
        await Task.Delay(500); // Adjust this delay as needed

        // Ensure the loading bar fills to 1.0
        _target = 1.0f;
        while (loadingBarFill.fillAmount < 1.0f)
        {
            await Task.Delay(100); // Wait a bit before checking again
        }

        scene.allowSceneActivation = true; // Now allow the scene to activate
        loadingScreen.SetActive(false);
    }

    private void Update()
    {
        loadingBarFill.fillAmount = Mathf.MoveTowards(loadingBarFill.fillAmount, _target, 3 * Time.deltaTime);
    }
}