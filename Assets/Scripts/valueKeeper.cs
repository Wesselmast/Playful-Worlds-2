using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Valuekeeper", menuName = "Valuekeeper")]
public class valueKeeper : ScriptableObject {
    public float[] audioBand = new float[8];
    public float[] audioBandBuffer = new float[8];
    public float amplitude;
    public float amplitudeBuffer;
    public float amplitudeHighest;
    public Color dropColor;
    public Image[] images;
    public Text[] texts;
    public bool seenTut = false;
    public bool isPaused = false;
    public float targetScore;
    public float score;
}
