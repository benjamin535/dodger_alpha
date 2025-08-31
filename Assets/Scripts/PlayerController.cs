using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // for TextMeshPro

public class PlayerController : MonoBehaviour
{
    // variables
    private Rigidbody rb;
    public float speed = 10f;
    public float jumpForce = 5f;
    private int coinsCollected = 0;
    public int coinsToWin = 4;
    public GameObject portal;  // assign in Inspector
    private bool isGrounded = true;
    // HUD
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timerText;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        portal.SetActive(false); // hide portal at start

    
        // Save the current scene name as the "last level"
        PlayerPrefs.SetString("LastLevel", SceneManager.GetActiveScene().name);

        

    }
    void Update()// gameplay logic
    {
        // Jump (only when grounded)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        // fall off map then GameOver
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate()
    {
        // get input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // movement force (ball will roll naturally)
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {   
        // check if player landed back on the ground
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;

        if (collision.gameObject.CompareTag("Obstacle"))
            SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Coin"))
    {
        Destroy(other.gameObject);//removes collected coin from scene
        coinsCollected++;

        if (coinsCollected >= coinsToWin)
        {
            portal.SetActive(true); // unlock portal
        }
    }

    if (other.CompareTag("Portal"))
    {
        // check which scene player in
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Level1")
        {
            SceneManager.LoadScene("Level2"); // go to Level 2
        }
        else if (currentScene == "Level2")
        {
            SceneManager.LoadScene("Win"); // finish the game
        }
    }
    
}

}
