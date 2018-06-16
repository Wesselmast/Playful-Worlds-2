using UnityEngine;
using UnityEngine.UI;

public class valueKeeper : MonoBehaviour
{

    public static valueKeeper instance;

    public float[] audioBand = new float[8];
    public float[] audioBandBuffer = new float[8];
    public float amplitude;
    public AudioClip audioClip;
    public float difficulty;
    public float amplitudeBuffer;
    public float amplitudeHighest;
    public Color dropColor;
    public Image[] images;
    public Text[] texts;
    public ParticleSystem[] particleSystems;
    public bool seenTut = false;
    public bool isPaused = false;
    public bool rightSideUp;
    public float targetScore;
    public float score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
            DestroyImmediate(gameObject);
    }


    private void Update()
    {
        images = FindObjectsOfType<Image>();
        texts = FindObjectsOfType<Text>();
        particleSystems = FindObjectsOfType<ParticleSystem>();

        foreach (Image img in images)
        {
            if (img.transform.name != "Image" && img.transform.name != "Blocker")
                img.color = dropColor;
        }
        foreach (Text text in texts)
        {
            if (text.transform.name != "Text" && text.transform.name != "Label" && text.transform.name != "Item Label")
                text.color = dropColor;
        }
        foreach (ParticleSystem system in particleSystems)
        {
            var main = system.main;
            main.startColor = dropColor;
        }

    }

    public void ResetStuff()
    {
        score = 0;
        targetScore = 0;
        audioBand = new float[8];
        audioBandBuffer = new float[8];
        amplitude = 0;
        amplitudeBuffer = 0;
        amplitudeHighest = 0;
        isPaused = false;
        rightSideUp = true;
    }

}
