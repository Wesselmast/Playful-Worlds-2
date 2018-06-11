using UnityEngine;
using UnityEngine.UI;

public class scoreKeeper : MonoBehaviour
{

    public float lerpSpeed = 2.5f;

    Text textComp;

    void Awake()
    {
        textComp = GetComponent<Text>();
        textComp.text = "0";

    }

    void FixedUpdate()
    {
        valueKeeper.instance.score = Mathf.Lerp(valueKeeper.instance.score, valueKeeper.instance.targetScore, Time.deltaTime * lerpSpeed);
        textComp.text = (Mathf.RoundToInt(valueKeeper.instance.score)).ToString();
    }
}
