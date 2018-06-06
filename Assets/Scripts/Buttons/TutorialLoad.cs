using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialLoad : MonoBehaviour {

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Tut);
    }

    void Tut()
    {
        valueKeeper.instance.seenTut = true;
        SceneManager.LoadScene("tutorial");
    }
}
