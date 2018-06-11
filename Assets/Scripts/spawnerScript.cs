using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject[] objects;

    public float[] sides = new float[2];
    float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (valueKeeper.instance.rightSideUp)
            {
                sides[0] = 0.5f;
                sides[1] = -2f;
            }
            if (!valueKeeper.instance.rightSideUp)
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
            if (valueKeeper.instance.amplitude != 0)
                timer = valueKeeper.instance.difficulty / valueKeeper.instance.amplitude;
        }

    }
}
