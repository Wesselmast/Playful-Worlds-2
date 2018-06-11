using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioVis : MonoBehaviour
{
    AudioSource audioSource;
    float[] samples = new float[512];
    float[] freqBand;
    float[] bandBuffer;
    float[] bufferDecrease;
    float[] freqBandHighest;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        freqBand = new float[8];
        bandBuffer = new float[8];
        bufferDecrease = new float[8];
        freqBandHighest = new float[8];
    }

    void Start()
    {
        StartCoroutine(playClip());
    }

    void Update()
    {
        GetSpectrumAudioSource();
        MakeFreqBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    IEnumerator playClip()
    {
        audioSource.clip = valueKeeper.instance.audioClip;      
        float clipLength = audioSource.clip.length;
        audioSource.Play();
        float t = 0;
        while (t < clipLength + 0.01f)
        {
            while (valueKeeper.instance.isPaused)
            {
                yield return null;
            }
            yield return null;
            t += Time.deltaTime;
        }
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float fadeTime = GetComponent<screenFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            valueKeeper.instance.audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            valueKeeper.instance.audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetAmplitude()
    {
        float currentAmp = 0f;
        float currentAmpBuffer = 0f;
        for (int i = 0; i < 8; i++)
        {
            currentAmp += valueKeeper.instance.audioBand[i];
            currentAmpBuffer += valueKeeper.instance.audioBandBuffer[i];
        }
        if (currentAmp > valueKeeper.instance.amplitudeHighest)
        {
            valueKeeper.instance.amplitudeHighest = currentAmp;
        }
        valueKeeper.instance.amplitude = currentAmp / valueKeeper.instance.amplitudeHighest;
        valueKeeper.instance.amplitudeBuffer = currentAmpBuffer / valueKeeper.instance.amplitudeHighest;
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 1, FFTWindow.Blackman);
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
