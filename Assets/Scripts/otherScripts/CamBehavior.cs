using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehavior : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D worldBounds;
    public GameObject player;

    float xMin, xMax, yMin, yMax;
    float camY, camX;   //position of camera

    float camSize;
    float camRatio;

    Camera mainCam;

    Vector3 smoothPos;

    public float smoothRate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        xMin = worldBounds.bounds.min.x;
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.max.y;

        // Temporal solution to worldBounds collider interfering with raycast collision
        // is to disable it
        worldBounds.gameObject.SetActive(false);

        mainCam = gameObject.GetComponent<Camera>();

        camSize = mainCam.orthographicSize;
        camRatio = (xMax + camSize) / 8.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //if (player.GetComponent<playerInteract>().dead == false)
        //{
            camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize) + 1f;
            camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);


            smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject.transform.position.z), smoothRate); //slowly lag move cam to position
            gameObject.transform.position = smoothPos;
        //}
    }
}
