using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
    

    public
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ChangeGravity();
    }



    void ChangeGravity()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Physics.gravity = new Vector3(0, 9.81F, 0);


            transform.up = Vector3.Slerp(transform.up, new Vector3(0, -1, 0), Time.deltaTime * 4);
            
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
            transform.up = Vector3.Slerp(transform.up, new Vector3(0, 1, 0), Time.deltaTime * 4);
            

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Physics.gravity = new Vector3(-9.81F, 0, 0);
            transform.right = Vector3.Slerp(transform.up, new Vector3(0, 0, 1), Time.deltaTime * 4);
            

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Physics.gravity = new Vector3(9.81F, 0, 0);
            transform.right = Vector3.Slerp(transform.up, new Vector3(0, 0, -1), Time.deltaTime * 4);
            

        }
    }
}