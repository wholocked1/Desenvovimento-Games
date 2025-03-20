using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid",1,1);
    }

    private void SpawnAsteroid(){
        var position = this.transform.position;
        position.y = Random.Range(-4,4);
        Instantiate(this.asteroidPrefab, position, Quaternion.identity);
    }

}
