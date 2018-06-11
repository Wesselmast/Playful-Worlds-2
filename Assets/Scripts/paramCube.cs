using UnityEngine;

public class paramCube : MonoBehaviour
{
    public float startScale, scaleMulti;
    public bool useBuffer = true;

    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[8];    

    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject instanceCube = Instantiate(sampleCubePrefab, this.transform);
            instanceCube.transform.localPosition = new Vector3(i, 0, 0);
            instanceCube.name = "SampleCube " + i;
            sampleCube[i] = instanceCube;
        }
    }


    void Update()
    {
        for (int i = 0; i < 8; i++)
            {
                //bovenste twee if statements checks tegen NaN errors etc
                if (valueKeeper.instance.audioBand[i] > 0)
                {
                    if (sampleCube[i] != null)
                    {
                        if (useBuffer)
                        {
                            sampleCube[i].transform.localScale = new Vector3(1, (valueKeeper.instance.audioBandBuffer[i] * scaleMulti) + startScale, 1);
                        }
                    //testing purposes voor geen buffer
                    if (!useBuffer)
                    {
                        sampleCube[i].transform.localScale = new Vector3(transform.localScale.x, (valueKeeper.instance.audioBand[i] * scaleMulti) + startScale, transform.localScale.z);
                    }
                    }
                }
            
            }

            
    }


}
