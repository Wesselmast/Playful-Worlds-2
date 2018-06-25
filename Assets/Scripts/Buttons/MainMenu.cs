using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Button replayBtn = GetComponent<Button>();
        replayBtn.onClick.AddListener(Replay);
    }

    void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainMenu");
        valueKeeper.instance.ResetStuff();

    }
}
