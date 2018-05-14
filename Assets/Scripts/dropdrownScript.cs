using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdrownScript : MonoBehaviour {

    GameObject label;
    Image color;
    Text text;

	// Use this for initialization
	void Start () {
        label = GameObject.Find("Label");
        color = GetComponent<Image>();
        text = label.GetComponent<Text>();

	}

    private void Update()
    {
        if (text.text == "Easy")
            color.color = new Color32(0, 85, 0, 255);
        if (text.text == "Medium")
            color.color = new Color32(0, 0, 200, 255);
        if (text.text == "Hard")
            color.color = new Color32(85, 0, 0, 255);
        if (text.text == "Extreme")
            color.color = new Color32(50, 50, 50, 255);
    }
}
