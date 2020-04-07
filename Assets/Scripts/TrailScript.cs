using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{

    public GameObject TrailPreFab;
    private Queue<GameObject> ObjectTrail = new Queue<GameObject>();

    public float trailFalloff = 2.0f;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddToQueue(GameObject QueueObject) {
        ObjectTrail.Enqueue(QueueObject);
    }
}
