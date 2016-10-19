using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    GameManager gameManager;

    public float spawnTimer = 3.0f;
    private float spawnTime;

    public GameObject enemy;

    // Use this for initialization
    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {

        //Spawn enemy at random X position
        if (Time.time > spawnTime) {

            Instantiate(enemy, transform.position, transform.rotation);

            spawnTime = Time.time + spawnTimer;
        }
    }
}
