using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Transform player;
    public float pushForce;
    private Rigidbody rb;
    public float timer = 0;
    public float timePoint = 4;
    public float damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
        rb = GetComponent<Rigidbody>();
        if (rb != null && player != null )
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.AddForce(direction * pushForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timePoint) 
        {
            timer += Time.deltaTime;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    
}
