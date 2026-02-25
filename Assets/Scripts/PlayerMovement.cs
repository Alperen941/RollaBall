using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0; 
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    
    void Start()
    {
        //Initialize rigidbody physics component
        rb = GetComponent <Rigidbody>(); 
    }
    
    void FixedUpdate() 
    { 
        // create a vector movement
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        
        // add the movement vector to the object using the rigidbody component
        rb.AddForce(movement * speed);        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
        }
    }
    
    void OnMove(InputValue movementValue) 
    {
        // get movement input
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        // initialize movement axis
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
}
