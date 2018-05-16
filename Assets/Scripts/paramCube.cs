using UnityEngine;

public class paramCube : MonoBehaviour
{
    public float startScale, scaleMulti;
    public bool useBuffer = true;
    public valueKeeper value;

    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[8];

    

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject instanceCube = Instantiate(sampleCubePrefab);
            instanceCube.transform.position = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
            instanceCube.transform.parent = this.transform;
            instanceCube.name = "SampleCube " + i;
            sampleCube[i] = instanceCube;
        }
    }

    void Update()
    {
            for (int i = 0; i < 8; i++)
            {
                //bovenste twee if statements checks tegen NaN errors etc
                if (value.audioBand[i] > 0)
                {
                    if (sampleCube[i] != null)
                    {
                        if (useBuffer)
                        {
                            sampleCube[i].transform.localScale = new Vector3(transform.localScale.x, (value.audioBandBuffer[i] * scaleMulti) + startScale, transform.localScale.z);
                        }
                    //testing purposes voor geen buffer
                    if (!useBuffer)
                    {
                        sampleCube[i].transform.localScale = new Vector3(transform.localScale.x, (value.audioBand[i] * scaleMulti) + startScale, transform.localScale.z);
                    }
                    }
                }
            
            }

            
    }


}
