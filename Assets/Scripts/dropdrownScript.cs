using UnityEngine;
using UnityEngine.UI;

public class dropdrownScript : MonoBehaviour
{

    GameObject label;
    Image color;
    Text text;

    void Awake()
    {
        label = GameObject.Find("Label");
        color = GetComponent<Image>();
        text = label.GetComponent<Text>();
    }

    void Update()
    {
        if (text.text == "Easy")
        {
            valueKeeper.instance.dropColor = new Color32(0, 85, 0, 255);
            valueKeeper.instance.difficulty = 0.3f;
        }
        if (text.text == "Medium")
        {
            valueKeeper.instance.dropColor = new Color32(0, 0, 255, 255);
            valueKeeper.instance.difficulty = 0.2f;
        }
        if (text.text == "Hard")
        {
            valueKeeper.instance.dropColor = new Color32(100, 0, 0, 255);
            valueKeeper.instance.difficulty = 0.1f;
        }
        if (text.text == "Extreme")
        {
            valueKeeper.instance.dropColor = new Color32(65, 65, 65, 255);
            valueKeeper.instance.difficulty = 0.05f;
        }
        color.color = valueKeeper.instance.dropColor;
    }
}
