using UnityEngine;

public class pickup : MonoBehaviour {

    GameObject backdrop;
    GameObject unhit;

    private void Start()
    {
        backdrop = GameObject.Find("backdrop");
        unhit = GameObject.FindGameObjectWithTag("Bonus");
    }
    private void Update()
    {
        //de 26 is een punt wat net buiten de range van de camera zit (sorry voor hardcode!)
        if (backdrop.transform.position.x - 26 >= gameObject.transform.position.x)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            //omdat ik de pickups onder 1 tag vallen onderscheid ik ze met layers
            if (gameObject.layer == 8)
            {
                if (unhit)
                    scoreKeeper.targetScore += 200;
                else
                    scoreKeeper.targetScore += 100;
                Destroy(gameObject);
            }
            if (gameObject.layer == 9)
            {
                scoreKeeper.targetScore -= 50;
                Destroy(gameObject);
                Destroy(unhit);
            }
        }
    }
}
