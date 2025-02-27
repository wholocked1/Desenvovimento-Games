using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BLockCountManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            if (scene.name == "level1")
            {
                SceneManager.LoadScene("level2");
            }
            else if (scene.name == "level2")
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
