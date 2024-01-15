using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;
    public string sceneName;

    private void Start()
    {
        if (fadeImage != null)
        {
            fadeImage.canvasRenderer.SetAlpha(1.0f);
            FadeOut();
        }
        else
        {
            Debug.LogError("Fade Image is not assigned in the inspector!");
        }
    }


    public void OnButtonClick()
    {
        Debug.Log("Button Clicked");
        StartCoroutine(ChangeSceneWithFade(sceneName));
    }

    IEnumerator ChangeSceneWithFade(string sceneName)
    {
        FadeIn();
        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene(sceneName);

        FadeOut();
        yield return new WaitForSeconds(fadeDuration);
    }

    private void FadeIn()
    {
        fadeImage.CrossFadeAlpha(1.0f, fadeDuration, false);
    }

    private void FadeOut()
    {
        fadeImage.CrossFadeAlpha(0.0f, fadeDuration, false);
    }
}
