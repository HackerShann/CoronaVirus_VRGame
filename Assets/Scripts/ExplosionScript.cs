using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //as soon as the explosion starts- invoke the function to destroy it once enough time has passed. otherwise, we will have lots of empty game objects in the scene, and we dont want that.
        Invoke("DeleteExplosion", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DeleteExplosion()//define delete explosion
    {
        Destroy(this.gameObject);
    }

}
