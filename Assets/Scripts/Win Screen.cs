using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public int maxRings;
    public int currentRings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        int collectablesCount = FindObjectsOfType<Collectable>().Length;
        maxRings = GameObject.FindGameObjectsWithTag("Ring").Length;
        if (maxRings == 0)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
