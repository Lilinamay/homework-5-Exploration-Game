using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    public GameObject[] targets; // the objects to draw the line between
    private LineRenderer l;
    // Start is called before the first frame update
    void Start()
    {
        l = this.GetComponent<LineRenderer>();
        Vector2 p1 = targets[0].transform.position;
        l.SetPosition(0, p1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 p1 = targets[0].transform.position;
        Vector2 p2 = targets[1].transform.position;
        Vector2 lineVector = p2 - p1;
        l.SetPosition(0, p1);
        l.SetPosition(1, p2);
    }
}
