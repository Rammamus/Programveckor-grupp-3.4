using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
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

        loadingScreen.SetActive(true);

        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);


        scene.allowSceneActivation = true;
        loadingScreen.SetActive(false);
    }

    private void Update()
    {
        loadingBarFill.fillAmount = Mathf.MoveTowards(loadingBarFill.fillAmount, _target, 3 * Time.deltaTime);
    }
}