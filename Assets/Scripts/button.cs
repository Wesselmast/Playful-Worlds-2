using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour {
    public valueKeeper value;
    public Button tutorial;
    public Button play;
    public Button exit;
    public Button choose;
    public Button mainMenu;
    public Material otherColor;
    public Image dropdown;

    void Start () {
        value.images = FindObjectsOfType<Image>();
        value.texts = FindObjectsOfType<Text>();
        if (play != null)
        {
            play.onClick.AddListener(Play);
            play.interactable = false;
        }
        if (exit != null)
            exit.onClick.AddListener(Exit);
        if (tutorial != null)
            tutorial.onClick.AddListener(Tutorial);
        if (choose != null)
            choose.onClick.AddListener(Choose);
        if (mainMenu != null)
            mainMenu.onClick.AddListener(MainMenu);
        
    }

    private void Update()
    {
        if (value.seenTut && play != null)
            play.interactable = true;

        if (dropdown != null)
            value.dropColor = dropdown.color; ;
        foreach (Image img in value.images)
        {
            if (img.transform.name != "Image")
              img.color = value.dropColor;
        }
        foreach(Text text in value.texts)
        {
            if(text != null)    
                if (text.transform.name != "Text" && text.transform.name != "Label")
                    text.color = value.dropColor;
        }
    }

    void Play ()
    {
        StartCoroutine(ToPlay());
    }

    void Choose()
    {
        //chooseButton stuff
    }
   

    IEnumerator ToPlay()
    {
        float fadeTime = GetComponent<screenFader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("TheMusic"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
        value.seenTut = true;
    }

    void MainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }


    void Exit()
    {
        Application.Quit();
    }
}
