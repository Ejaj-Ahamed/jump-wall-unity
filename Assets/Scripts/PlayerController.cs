using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Ground"){
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Ground"){
            canJump = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        // Debug.Log(other.gameObject.tag.ToString());
        if(other.gameObject.tag == "Obstacle"){
            SceneManager.LoadScene("GameScene");
        }
    }
}
