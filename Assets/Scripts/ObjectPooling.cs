using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    
    public List<GameObject> objectPool;     // the pool of objects
    public GameObject pooledObject;         // the object to be pooled
    public int poolLimit;                   // how many instances of the object to pool
    
    // Start is called before the first frame update
    void Start()
    {
        objectPool = new List<GameObject>();    // create the object pool
        for(int i = 0; i < poolLimit; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);     // instantiate the object
            obj.SetActive(false);       // set the object to inactive
            objectPool.Add(obj);        // add the object to the pool
        }
    }

    // Update is called once per frame
    // void Update(){}

    // GetPooledObject returns the most recently unused/inactive object in the pool
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < objectPool.Count; i++)
        {
            if(!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];       // return the inactive object
            }
        }
        return null;    // returns nothing if there are no inactive objects in the pool
    }
}