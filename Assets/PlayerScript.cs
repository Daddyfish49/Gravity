using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 2f;

    private bool isGrounded = false;
    private Rigidbody rigid = null;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
            HandleInput();
        
    }
    //Handles all input to the player
    void HandleInput()
    {
        KeyCode[] keys =
        {
            KeyCode.W,
            KeyCode.S,
            KeyCode.A,
            KeyCode.D,
            KeyCode.Space
        };

        foreach (var key in keys)
        {
            if (Input.GetKey(key))
            {
                Move(key);
            }

        }
    }

    //seperate move function for moving player
    void Move(KeyCode key)
    {
        Vector3 position = rigid.position;
        Quaternion rotation = rigid.rotation;
        switch (key)
        {
            case KeyCode.W:
                position += transform.forward * movementSpeed * Time.deltaTime;
                break;
            case KeyCode.S:
                position += -transform.forward * movementSpeed * Time.deltaTime;
                break;
            case KeyCode.A:
                rotation *= Quaternion.AngleAxis(-rotationSpeed, Vector3.up);
                break;
            case KeyCode.D:
                rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.up);
                break;
            case KeyCode.Space:
                if (isGrounded)
                {
                    //Add force to stimulate jumping
                    rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                    isGrounded = false;
                }
                break;
        }
        rigid.MovePosition(position);
        rigid.MoveRotation(rotation);
    }

    void OnCollisionEnter(Collision col)
    {
        isGrounded = true;
    }
}
