using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    internal static GameManager Instance;


    // private AudioSource sfx;

    // internal void PlaySfx(AudioClip clip) => sfx.PlayOneShot(clip);

    private void Awake()
{
    if (Instance == null) 
    {
        Instance = this;
    }
    else if (Instance != this) 
    {
        Destroy(gameObject);
    }
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
