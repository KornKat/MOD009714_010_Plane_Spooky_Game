using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Image healthbar;
    public AudioSource WindNoise;
    public AudioSource DeadNoise;
    public ParticleSystem Explosion;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {

            Instantiate(Explosion, transform.position, Quaternion.identity);
            Explosion.Play();
            DeadNoise.Play();
            StartCoroutine(LoadScene(1f));
        }
    }

    private IEnumerator LoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MovingObstacle"))
        {
            health -= other.GetComponent<MovingObstacle>().damage;
            healthbar.fillAmount = health / 100f;
            WindNoise.Play();
        }
        if (other.gameObject.CompareTag("Ring"))
        {
           if (health < 100) 
            {
                health += other.GetComponent<Collectable>().heal;
                healthbar.fillAmount = health / 100f;
            }
            
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            health -= other.GetComponent<Obstacle>().damage;
            healthbar.fillAmount = health / 100f;
        }
    }

}