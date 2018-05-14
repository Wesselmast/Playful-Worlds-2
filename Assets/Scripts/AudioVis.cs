using UnityEngine;

public class AudioVis : MonoBehaviour {
    AudioSource audioSource;
    float[] samples = new float[512];
    float[] freqBand; 
    float[] bandBuffer;
    public static float[] audioBand;
    public static float[] audioBandBuffer;
    public static float amplitude, amplitudeBuffer;
    public static float amplitudeHighest;

    float[] bufferDecrease;
    float[] freqBandHighest;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        freqBand = new float[8];
        bandBuffer = new float[8];
        audioBand = new float[8];
        audioBandBuffer = new float[8];
        bufferDecrease = new float[8];
        freqBandHighest = new float[8];     
    }
    
	void Update () {
        GetSpectrumAudioSource();
        MakeFreqBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetAmplitude()
    {
        float currentAmp = 0f;
        float currentAmpBuffer = 0f;
        for (int i = 0; i < 8; i++)
        {
            currentAmp += audioBand[i];
            currentAmpBuffer += audioBandBuffer[i];
        }
        if (currentAmp > amplitudeHighest)
        {
            amplitudeHighest = currentAmp;
        }
        amplitude = currentAmp / amplitudeHighest;
        amplitudeBuffer = currentAmpBuffer / amplitudeHighest;
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = 0.005f;
            }
            else
            {
                bufferDecrease[i] = (bandBuffer[i] - freqBand[i]) / 8;
                bandBuffer[i] -= bufferDecrease[i];
            }
        }
    }

    void MakeFreqBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            float average = 0f;

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1); 
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
    }

}
