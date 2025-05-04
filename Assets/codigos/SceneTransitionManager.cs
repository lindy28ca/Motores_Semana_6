using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(FadeOutAndLoad(sceneName));
    }

    IEnumerator FadeOutAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator FadeIn()
    {
        float t = fadeDuration;
        Color c = fadeImage.color;
        while (t > 0)
        {
            t -= Time.deltaTime;
            c.a = t / fadeDuration;
            fadeImage.color = c;
            yield return null;
        }
        c.a = 0;
        fadeImage.color = c;
    }

    public IEnumerator FadeOut()
    {
        float t = 0;
        Color c = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = t / fadeDuration;
            fadeImage.color = c;
            yield return null;
        }
        c.a = 1;
        fadeImage.color = c;
    }
    public IEnumerator FadeEffect()
    {
        yield return SceneTransitionManager.Instance.FadeOut();
        yield return new WaitForSeconds(fadeDuration);
        yield return SceneTransitionManager.Instance.FadeIn();
    }
}
