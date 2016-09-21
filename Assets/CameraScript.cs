using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    //insert player into game object

    public GameObject player;

    Vector3 offset;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }


    void LateUpdate()
    {
        
        float turnAngle = player.transform.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0, turnAngle, 0);

        transform.position = player.transform.position - (rotation * offset);
        //keeps the camera looking at the player
        transform.LookAt(player.transform);

    }
}