using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseSongLoad : MonoBehaviour
{
    public void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SongLoad);
    }

    void SongLoad()
    {
        SceneManager.LoadScene("songChooser");
    }

}
