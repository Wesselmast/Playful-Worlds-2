using UnityEngine;

public class spawnerScript : MonoBehaviour {
    public GameObject[] objects;
    public static float difficulty;
    float[] sides = new float[2];
    float timer;
    
    private void Awake()
    {
        if(button.dropColor == new Color32(0, 85, 0, 255))
        {
            difficulty = 0.3f;
        }
        if (button.dropColor == new Color32(0, 0, 200, 255))
        {
            difficulty = 0.2f;
        }
        if (button.dropColor == new Color32(85, 0, 0, 255))
        {
            difficulty = 0.1f;
        }
        if (button.dropColor == new Color32(50, 50, 50, 255))
        {
            difficulty = 0.05f;
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

            Instantiate(objects[indexPickup], new Vector3(transform.position.x + sides[indexSides], transform.position.y, transform.position.z), transform.rotation);

            //duurde me veels te lang voordat ik door had dat ik soms door 0 zat te delen..
            if(AudioVis.amplitude != 0)
                timer = difficulty / AudioVis.amplitude;
            print(difficulty);
 
        }
        
    }
}
