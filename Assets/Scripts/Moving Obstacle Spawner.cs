using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingObstacleSpawner : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    public GameObject MovingObstacle;
    public float spawnRate = 5;
    public float timer = 0;
    public float distance = 100;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
            AudioSource.Play();
        }
    }

    private void SpawnObstacle()
    {
        playerTransform = player.transform;
        Vector3 newObjectLocation = (playerTransform.forward * distance) + player.transform.position;
        Instantiate(MovingObstacle, newObjectLocation, player.transform.rotation);

    }
}
