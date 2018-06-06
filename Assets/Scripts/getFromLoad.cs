using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class getFromLoad : MonoBehaviour {
    Text finalScore;

    void Start () {
        finalScore =  gameObject.GetComponent<Text>();
        finalScore.text = "final score: " + Mathf.RoundToInt(valueKeeper.instance.score).ToString();
    }   
}