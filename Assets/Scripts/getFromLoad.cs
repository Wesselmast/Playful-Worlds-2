using UnityEngine;
using UnityEngine.UI;

public class getFromLoad : MonoBehaviour {
    Text finalScore;

    void Start () {
        finalScore =  gameObject.GetComponent<Text>();
        finalScore.text = "final score: " + Mathf.RoundToInt(valueKeeper.instance.score).ToString();
    }   
}