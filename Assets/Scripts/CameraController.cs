using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    private GameObject backGround;

    [SerializeField]
    private float parallaxIntensity;

    [SerializeField]
    float dist;
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, -10), dist*Time.deltaTime);
        parallax();
    }
    void parallax()
    {
        backGround.transform.position = new Vector3(transform.position.x * parallaxIntensity, transform.position.y*parallaxIntensity, backGround.transform.position.z);
    }
}
