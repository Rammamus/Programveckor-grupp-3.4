using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBarFill;

    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            // Log the raw progress value
            Debug.Log($"Raw Loading Progress: {operation.progress}");

            // Calculate the progress value
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBarFill.fillAmount = progressValue;

            Debug.Log($"Setting Fill Amount: {progressValue}"); // Debug log to check fill amount

            // Check if the operation is done
            if (operation.progress >= 0.9f)
            {
                // Wait for a moment before activating the scene
                yield return new WaitForSeconds(1f); // Adjust the delay as needed

                // Allow the scene to activate
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}

