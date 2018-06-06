using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public GameObject player;
    playerController script;
    public GameObject pause;
    public AudioSource theMusic;

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
                if (!valueKeeper.instance.isPaused)
                {
                    Time.timeScale = 0;
                    theMusic.Pause();
                    valueKeeper.instance.isPaused = true;
                    pause.SetActive(true);
                    script.enabled = false;
                }
                else
                {
                    Time.timeScale = 1;
                    theMusic.UnPause();
                    valueKeeper.instance.isPaused = false;
                    pause.SetActive(false);
                    script.enabled = true;
                }

            }
        }
        else
            valueKeeper.instance.isPaused = false;
    }
}
