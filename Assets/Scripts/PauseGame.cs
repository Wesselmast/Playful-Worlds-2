using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public AudioSource theMusic;
    public GameObject player;
    playerController script;
    public GameObject pause;
    public valueKeeper value;

    void Start()
    {
        script = player.GetComponent<playerController>();
        pause.SetActive(false);

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "game")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!value.isPaused)
                {
                    Time.timeScale = 0;
                    theMusic.Pause();
                    value.isPaused = true;
                    pause.SetActive(true);
                    script.enabled = false;
                }
                else
                {
                    Time.timeScale = 1;
                    theMusic.UnPause();
                    value.isPaused = false;
                    pause.SetActive(false);
                    script.enabled = true;
                }

            }
        }
        else
            value.isPaused = false;
    }
}
