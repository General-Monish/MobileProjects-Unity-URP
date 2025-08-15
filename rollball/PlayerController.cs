using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick; // Reference to the joystick script
    public float speed = 10f; // Movement speed
    public TextMeshProUGUI counttxt;
    public GameObject gameWintxt;
    public GameObject gamelosetxt;
    public GameObject restartbtn;
    public bool islost=false;

    private Rigidbody rb;
    int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Score();
        gameWintxt.SetActive(false);
        gamelosetxt.SetActive(false);
        restartbtn.SetActive(false);
    }

    void FixedUpdate()
    {
        // Get input from the joystick
        float hor = joystick.inputDirection.x;
        float ver = joystick.inputDirection.y;

        // Calculate movement direction
        Vector3 direction = new Vector3(-hor, 0, -ver);

        // Move the player using Rigidbody
        rb.AddForce(direction * speed*Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            
            other.gameObject.SetActive(false);
            count++;
            Score();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            islost = true;
            Destroy(gameObject);
            gamelosetxt.SetActive(true);
            restartbtn.SetActive(true);
        }
    }

    void Score()
    {
        counttxt.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            gameWintxt.SetActive(true);
        }
    }
}
