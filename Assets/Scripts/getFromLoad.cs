using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class getFromLoad : MonoBehaviour {
    public GameObject replay;
    public Text finalScore;
    public valueKeeper value;

    string finalscore;
    AudioSource TheMusic;
    Canvas canvas;
    RectTransform rectTransform;

    void Start () {
        Button replayBtn = replay.GetComponent<Button>();
        TheMusic = GameObject.Find("TheMusic").GetComponent<AudioSource>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>() ;
        canvas.enabled = false;
        TheMusic.Stop();
        TheMusic.Play();
        replayBtn.onClick.AddListener(Replay);

        finalscore = GameObject.FindGameObjectWithTag("score").GetComponent<Text>().text;
        finalScore.text = "final score: " + finalscore;
    }
	
	void Replay ()
    {
        TheMusic.Stop();
        value.score = 0;
        value.targetScore = 0;
        SceneManager.LoadScene("mainMenu");
    }
}
