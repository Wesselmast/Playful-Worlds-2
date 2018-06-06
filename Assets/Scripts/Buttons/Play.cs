using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {

    private void Start()
    { 
        Button btn = GetComponent<Button>();
        btn.interactable = false;
        if (valueKeeper.instance.seenTut)
            btn.interactable = true;
        btn.onClick.AddListener(PlayNow);

    }

    private void PlayNow()
    {
        StartCoroutine(ToPlay());
    }

    IEnumerator ToPlay()
    {
        float fadeTime = GetComponent<screenFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("TheMusic"));
        SceneManager.LoadScene("game");
    }
}
