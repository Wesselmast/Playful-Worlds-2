using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class fileChooser : MonoBehaviour
{

    public GameObject buttonPrefab;
    public GameObject canvas;
    int position = -100;

    string path;
    public List<AudioClip> audioList = new List<AudioClip>();

    void Start()
    {
        path = Application.dataPath + "\\AudioFolder\\";
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            path = Application.dataPath;
            path += "\\..\\";
            path += "\\AudioFolder\\";
        }

        StartCoroutine(loadAudioFile());
    }

    IEnumerator loadAudioFile()
    {
        Debug.Log("Started Reading files");
        var info = new DirectoryInfo(path);
        var fileInfo = info.GetFiles("*.wav");
        foreach (FileInfo file in fileInfo)
        {

            Debug.Log(file.FullName);
            WWW www = new WWW(file.FullName);
            yield return www;

            AudioClip audioClip = www.GetAudioClip(false, true, AudioType.WAV);

            audioClip.name = file.Name;
            audioList.Add(audioClip);

            //stop met laden als er meer dan 10 wav files zijn
            if (audioList.Count >= 10)
                break;
        }
        Debug.Log("Stopped Reading files");
        SpawnButtons();

    }

    void PlayAudio()
    {
        AudioSource aSource = gameObject.AddComponent<AudioSource>();
        aSource.clip = audioList[0];
        aSource.spatialBlend = 0;
        aSource.volume = 1;
        aSource.Play();
    }

    void SpawnButtons()
    {
        foreach (AudioClip clip in audioList)
        {
            GameObject button = Instantiate(buttonPrefab);
            button.transform.SetParent(canvas.transform);
            button.transform.localPosition = new Vector3(0, position, 0);
            button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            Text buttonText = button.GetComponentInChildren<Text>();
            buttonText.text = clip.name;
            position += 20;

            Button theButton = button.GetComponent<Button>();
            theButton.onClick.AddListener(delegate { OnClickButton(clip); });
        }
    }

    void OnClickButton(AudioClip clip)
    {
        valueKeeper.instance.audioClip = clip;
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");
        valueKeeper.instance.ResetStuff();

    }

}
