using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour {

	public void Start () {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Exit);
	}

    void Exit()
    {
        Application.Quit();
    }
	
}
