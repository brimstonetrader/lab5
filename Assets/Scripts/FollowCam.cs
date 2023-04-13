using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject sprite;
    public float boundaryPercent;
    public Camera camera;
    public float easing;


    // Start is called before the first frame update
    void Start()
    {
    }

    void FixedUpdate() {

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 spriteLoc = sprite.transform.position;
        Vector3 pos = camera.transform.position;

        if (spriteLoc.x != pos.x) {
            pos.x += (spriteLoc.x - pos.x);
        }

        if (spriteLoc.z != (pos.z - 10)) {
            pos.z += (spriteLoc.z - pos.z + 10);
        }

        pos = Vector3.Lerp(transform.position, pos, easing);

        transform.position = pos;

    }
}
