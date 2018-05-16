using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreKeeper : MonoBehaviour {

    public valueKeeper value;
    public float lerpSpeed = 2.5f;

    Text textComp;

	void Awake() {
        textComp = GetComponent<Text>();
        textComp.text = "0";

    }

	void FixedUpdate () {
        value.score = Mathf.Lerp(value.score, value.targetScore, Time.deltaTime * lerpSpeed);
        textComp.text = (Mathf.RoundToInt(value.score)).ToString();
        }
}
