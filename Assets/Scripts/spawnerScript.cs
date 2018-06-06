using UnityEngine;

public class spawnerScript : MonoBehaviour {
    public GameObject[] objects;

    public float[] sides = new float[2];
    float timer;
    
    private void Awake()
    {
        if(valueKeeper.instance.dropColor == new Color32(0, 85, 0, 255))
        {
            valueKeeper.instance.difficulty = 0.3f;
        }
        if (valueKeeper.instance.dropColor == new Color32(0, 0, 200, 255))
        {
            valueKeeper.instance.difficulty = 0.2f;
        }
        if (valueKeeper.instance.dropColor == new Color32(85, 0, 0, 255))
        {
            valueKeeper.instance.difficulty = 0.1f;
        }
        if (valueKeeper.instance.dropColor == new Color32(50, 50, 50, 255))
        {
            valueKeeper.instance.difficulty = 0.05f;
        }
    }
    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (playerController.rightSideUp)
            {
                sides[0] = 0.5f;
                sides[1] = -2f;
            }
            if (!playerController.rightSideUp)
            {
                sides[0] = 0.5f;
                sides[1] = 7f;
            }

            int indexPickup = Random.Range(0, objects.Length);
            int indexSides = Random.Range(0, sides.Length);

            foreach (GameObject pickup in objects)
            {
                if (indexSides == 1)
                {
                    //FLIP THE DAMN THING AROUND LIKE SHIT
                }
            }


            Instantiate(objects[indexPickup], new Vector3(transform.position.x + sides[indexSides], transform.position.y, transform.position.z), transform.rotation);

            //duurde me veels te lang voordat ik door had dat ik soms door 0 zat te delen..
            if(valueKeeper.instance.amplitude != 0)
                timer = valueKeeper.instance.difficulty / valueKeeper.instance.amplitude; 
        }
        
    }
}
