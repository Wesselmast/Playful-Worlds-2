using System;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public float speedHighest = 10f;
    public float jumpHeighest = 5f;
    bool isJumping = false;
    Rigidbody rigidB;
    float yVel;
    public GameObject floor;
    public GameObject backdrop;
    public GameObject player;
    public GameObject score;
    public GameObject unhit;
    GameObject[] pickups;
    GameObject[] cubes;
    public Material black;
    public Material otherColor;

    private void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        otherColor.SetColor("_EmissionColor", valueKeeper.instance.dropColor);
    }
    private void Update()
    {
        pickups = GameObject.FindGameObjectsWithTag("pickup");
        cubes = GameObject.FindGameObjectsWithTag("cube");

        //-1 of 1 in range True  = 1, False - 0 (Thanks Jesse!)
        int dir = 2 * Convert.ToInt16(valueKeeper.instance.rightSideUp) - 1;

        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            yVel = jumpHeighest * dir;
            isJumping = true;
        }

        if (isJumping)
            yVel += -9.81f * dir * 1.5f * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && !isJumping)
            Flip();

        if (valueKeeper.instance.rightSideUp)
        {
            floor.GetComponent<MeshRenderer>().material = black;
            backdrop.GetComponent<MeshRenderer>().material = black;
            player.GetComponent<MeshRenderer>().material = black;
            score.GetComponent<Text>().color = otherColor.GetColor("_EmissionColor");
            if (unhit != null)
                unhit.GetComponent<Text>().color = otherColor.GetColor("_EmissionColor");
            foreach (GameObject cube in cubes)
            {
                cube.GetComponent<MeshRenderer>().material = otherColor;
            }
            foreach (GameObject pickup in pickups)
            {
                if (pickup != null)
                    pickup.GetComponent<MeshRenderer>().material = black;
            }
        }
        if (!valueKeeper.instance.rightSideUp)
        {
            floor.GetComponent<MeshRenderer>().material = otherColor;
            backdrop.GetComponent<MeshRenderer>().material = otherColor;
            player.GetComponent<MeshRenderer>().material = otherColor;
            score.GetComponent<Text>().color = black.GetColor("_EmissionColor");
            if (unhit != null)
                unhit.GetComponent<Text>().color = black.GetColor("_EmissionColor");
            foreach (GameObject cube in cubes)
            {
                cube.GetComponent<MeshRenderer>().material = black;
            }
            foreach (GameObject pickup in pickups)
            {
                if (pickup != null)
                    pickup.GetComponent<MeshRenderer>().material = otherColor;
            }
        }
    }
    void FixedUpdate()
    {


        //player beweegd op de amplitude van de muziek
        speedHighest = valueKeeper.instance.amplitude * 50;
        rigidB.velocity = new Vector3(speedHighest, 0, 0);
        rigidB.velocity = Vector3.ProjectOnPlane(rigidB.velocity, transform.up);
        rigidB.velocity += Vector3.ProjectOnPlane(Vector3.up * yVel, transform.right);


    }

    void Flip()
    {
        Vector3 pos = transform.localPosition;
        transform.localPosition = new Vector3(pos.x, pos.y * -1 );
        valueKeeper.instance.rightSideUp = !valueKeeper.instance.rightSideUp;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "floor")
        {
            isJumping = false;
            yVel = 0;
        }
    }
}

