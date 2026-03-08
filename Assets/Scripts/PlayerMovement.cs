using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winText;
    
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int count;
    
    void Start()
    {
        //Initialize rigidbody physics component
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winText.SetActive(false);
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
            count++;
            SetCountText();
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

    void SetCountText() 
    {
        countText.text =  "Count: " + count.ToString();
        if (count >= 8) 
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            winText.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }   
}
