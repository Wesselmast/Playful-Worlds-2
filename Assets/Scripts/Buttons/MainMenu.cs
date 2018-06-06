using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    Canvas canvas;

    void Start()
    {
        Button replayBtn = GetComponent<Button>();

        if (canvas != null)
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        replayBtn.onClick.AddListener(Replay);
    }

    void Replay()
    {
        SceneManager.LoadScene("mainMenu");
        if (canvas != null)
            Destroy(canvas);
        valueKeeper.instance.ResetStuff();

    }
}
