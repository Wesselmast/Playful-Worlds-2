using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadNextOnSongEnd : MonoBehaviour {
    public GameObject canvas;
    public AudioSource theMusic;
    public valueKeeper value;

    private void Start()
    {
        DontDestroyOnLoad(canvas.gameObject);
        DontDestroyOnLoad(theMusic.gameObject);
    }

    void Update() { 
        if (!theMusic.isPlaying && !value.isPaused) 
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
