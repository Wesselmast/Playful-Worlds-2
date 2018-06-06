using System.Collections.Generic;
using UnityEngine;

public class endlessness : MonoBehaviour {
    GameObject theCamera;
    GameObject player;
    public AudioSource theMusic;
    public GameObject cubeMakerPrefab;
    List<GameObject> kids = new List<GameObject>();
    int currentCubeMaker;
    int lerpValue;

    private void Awake()
    {
        player = GameObject.Find("Player");
        player.GetComponent<MeshRenderer>().enabled = true;
        theCamera = GameObject.Find("Main Camera");
    }

    void Start ()
    {
            float normalized = theMusic.clip.length / 600;
            if (normalized < 1)
            {
                //groter dan 10 minuten dus mag niet
            }
            lerpValue = (int)Mathf.Lerp(10, 20, normalized);

            transform.parent = this.transform;
            for (int i = 0; i < lerpValue; i++)
            {
                GameObject cubeMaker = Instantiate(cubeMakerPrefab);
                cubeMaker.transform.position = new Vector3(transform.position.x + (i * 8), transform.position.y, transform.position.z);
                cubeMaker.transform.parent = this.transform;
                cubeMaker.name = "CubeMaker " + i;
                kids.Add(cubeMaker);
            }

    }

    void Update()
    {
            //dit moet hier staan omdat for some reason de cubeMakerMaker op een vreemde manier angles berekend (en positie) Valentijn help!
            transform.eulerAngles = new Vector3(0, 0, -10);

            if (theCamera.transform.position.x >= (currentCubeMaker + 1) * 8)
            {
                kids[currentCubeMaker % lerpValue].transform.localPosition += new Vector3(lerpValue * 8, 0, 0);
                currentCubeMaker++;
            }
    }

}
