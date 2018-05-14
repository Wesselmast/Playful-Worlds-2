using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextOnSongEnd : MonoBehaviour {
    public GameObject canvas;
    public AudioSource theMusic;

    private void Start()
    {
        DontDestroyOnLoad(canvas.gameObject);
        DontDestroyOnLoad(theMusic.gameObject);
    }

    void Update() { 
        if (!theMusic.isPlaying && !PauseGame.isPaused) 
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
