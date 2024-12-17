using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleVirusScript : MonoBehaviour
{
    private float SpeedFactor;
    private float RandomX;
    private float RandomY;
    private float RandomZ;

    public GameObject MyExplosion;

    // Start is called before the first frame update
    void Start()
    {

        //start moving this virus in a random direction amd speed
        SpeedFactor = ApplicationData.SpeedFactor;//get speed frm MyGameManager
        RandomX = UnityEngine.Random.Range(-SpeedFactor, SpeedFactor);
        RandomY = UnityEngine.Random.Range(-SpeedFactor, SpeedFactor);
        RandomZ = UnityEngine.Random.Range(-SpeedFactor, SpeedFactor);

        //make sure it is never smaller than 0.7+-
        if (RandomX > -0.7 && RandomX < 0.7)
        {
            RandomX = 1.5f;
        }

        if (RandomY > -0.7 && RandomY < 0.7)
        {
            RandomY = 1.2f;
        }

        if (RandomZ > -0.7 && RandomZ < 0.7)
        {
            RandomZ = -1.8f;
        }

        GetComponent<ConstantForce>().relativeForce = new Vector3(RandomX, RandomY, RandomZ);
        GetComponent<ConstantForce>().relativeTorque = new Vector3(RandomX / 20, RandomY / 40, RandomZ / 30);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision WhatHit)
    {
        if (WhatHit.gameObject.CompareTag("injector"))//if a virus hit the wall: make it bounce and change direction randomly
        {

            if (WhatHit.gameObject.GetComponent<ConstantForce>().enabled == true)
            { //was the injector in flight? we want to ignore viruses flying into injectors while still in the hand.

                Destroy(this.gameObject);//destroy virus

                Destroy(WhatHit.gameObject);//destroy the injector that hit the wall
                Instantiate(MyExplosion, transform.position, transform.rotation);//make a new explosion
                ApplicationData.HowManyViruses--;//one less virus!

            }//end "if the injector was in flight and not stil in the hand"


        }//end if a injector hit the virus

    }
}
