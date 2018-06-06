using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextOnSongEnd : MonoBehaviour {
    public AudioSource theMusic;

    void Update()
    {
        if (!theMusic.isPlaying && !valueKeeper.instance.isPaused)
        {
            theMusic.Stop();
            StartCoroutine(FadeOut());

        }
    }

    IEnumerator FadeOut()
    {
        float fadeTime = GetComponent<screenFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
