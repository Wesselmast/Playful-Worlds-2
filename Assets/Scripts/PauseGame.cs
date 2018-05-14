using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public static bool isPaused = false;
    public AudioSource theMusic;
    public GameObject player;
    playerController script;
    public GameObject pause;

    void Start()
    {
        script = player.GetComponent<playerController>();
        pause.SetActive(false);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                theMusic.Pause();
                isPaused = true;
                pause.SetActive(true);
                script.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                theMusic.UnPause();
                isPaused = false;
                pause.SetActive(false);
                script.enabled = true;
            }
        }
	}
}
