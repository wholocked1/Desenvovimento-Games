using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public GUISkin layout;
    GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }
    public void Score(){
        Bullet projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
        if(projectile.destroyed){Score++;}
        

    }
    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Score);
        
    }
}
