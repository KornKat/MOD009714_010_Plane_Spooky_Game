using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Image healthbar;
    public AudioSource WindNoise;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MovingObstacle"))
        {
            health -= other.GetComponent<MovingObstacle>().damage;
            healthbar.fillAmount = health / 100f;
            WindNoise.Play();
        }
    }

}