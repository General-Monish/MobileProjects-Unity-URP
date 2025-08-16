using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
public class PlayerJ : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpSpeed;
    bool canJump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            canJump = false; // Prevent double jump
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Jumper");
        }
    }
}
