using UnityEngine;

public class Coin : MonoBehaviour
{

    private GameManager gameManager;
    public int scoreValue;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other + "girdi");
            gameManager.AddScore(scoreValue);
            Destroy(this.gameObject);
        }
    }

}
