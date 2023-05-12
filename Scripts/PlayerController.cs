using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    

    private Rigidbody rigidBody;


    [SerializeField] private float pushForce;
    private float movement;
    [SerializeField] private float speed;
    public Vector3 respawnPoint;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        respawnPoint = this.transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(0, -200f, pushForce * Time.fixedDeltaTime);
        rigidBody.velocity = new Vector3(movement * speed, rigidBody.velocity.y, rigidBody.velocity.z);

        FallDetector();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Barrier"))
        {
            gameManager.RespawnPlayer();
        }
    }

    private void FallDetector()
    {
        if (rigidBody.position.y < -7f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EndTrigger")
        {
            this.gameObject.SetActive(false);
            gameManager.LevelUp();
        }
    }
}
