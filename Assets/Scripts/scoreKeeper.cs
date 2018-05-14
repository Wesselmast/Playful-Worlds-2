using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreKeeper : MonoBehaviour {

    public static float targetScore;
    public static float score;
    public float lerpSpeed = 2.5f;

    Text textComp;

	void Awake() {
        textComp = GetComponent<Text>();
        textComp.text = "0";

    }

	void FixedUpdate () {
        score = Mathf.Lerp(score, targetScore, Time.deltaTime * lerpSpeed);
        textComp.text = (Mathf.RoundToInt(score)).ToString();
        }
}
