using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdrownScript : MonoBehaviour {

    GameObject label;
    Image color;
    Text text;

	void Awake () {
        label = GameObject.Find("Label");
        color = GetComponent<Image>();
        text = label.GetComponent<Text>();
    }

    void Update()
    {
        if (text.text == "Easy")
            valueKeeper.instance.dropColor = new Color32(0, 85, 0, 255);
        if (text.text == "Medium")
            valueKeeper.instance.dropColor = new Color32(0, 0, 200, 255);
        if (text.text == "Hard")
            valueKeeper.instance.dropColor = new Color32(85, 0, 0, 255);
        if (text.text == "Extreme")
            valueKeeper.instance.dropColor = new Color32(50, 50, 50, 255);
        color.color = valueKeeper.instance.dropColor;
    }
}
