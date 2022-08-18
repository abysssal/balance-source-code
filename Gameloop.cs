using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameloop : MonoBehaviour
{
    [Header("Mineables")]
    public GameObject gold;

    [Header("Enemies")]
    public GameObject speedyEnemy;
    public GameObject normalEnemy;
    public GameObject lightningEnemy;
    public GameObject tankEnemy;
    public GameObject suicideEnemy;

    public float easySpawnRate;
    public float harderSpawnRate;
    public float suicideSpawnRate;

    public int timeBeforeEasySpawn;
    public int timeBeforeHarderSpawn;
    public int timeBeforeSuicideSpawn;

    [Header("Game Storage Information")]
    public int place;
    public int types;

    public Vector2 places1 = new Vector2(-200, 200);
    public Vector2 places2 = new Vector2(200, 180);

    public Vector2 places3 = new Vector2(-200, -200);
    public Vector2 places4 = new Vector2(200, -180);

    public void Awake()
    {
       types = Random.Range(0, 2);
       place = Random.Range(0, 2);
       places1 = new Vector2(-200, 200);
       places2 = new Vector2(200, 180);
       places3 = new Vector2(-200, -200);
       places4 = new Vector2(200, -180);

       for (int i = 1; i < 500; i++)
       {
           Instantiate(gold, new Vector3(Random.Range(places1.x, places4.x), Random.Range(places1.y, places3.y), 0), Quaternion.identity);
       }

       InvokeRepeating("ezDiff", timeBeforeEasySpawn, easySpawnRate);
       InvokeRepeating("harderDiff", timeBeforeHarderSpawn, harderSpawnRate);
       InvokeRepeating("suicideDiff", timeBeforeSuicideSpawn, suicideSpawnRate);
    }

    public void ezDiff()
    {
        place = Random.Range(0, 2);
        types = Random.Range(0, 2);
        if (place == 0)
        {
            if (types == 0)
            {
                Instantiate(normalEnemy, new Vector3(Random.Range(places1.x, places2.x), Random.Range(places1.y, places2.y), 0), Quaternion.identity);
            }

            if (types == 1)
            {
                Instantiate(speedyEnemy, new Vector3(Random.Range(places1.x, places2.x), Random.Range(places1.y, places2.y), 0), Quaternion.identity);
            }
        } 
        else if (place == 1)
        {
            if (types == 0)
            {
                Instantiate(normalEnemy, new Vector3(Random.Range(places3.x, places4.x), Random.Range(places3.y, places4.y), 0), Quaternion.identity);
            }

            if (types == 1)
            {
                Instantiate(speedyEnemy, new Vector3(Random.Range(places3.x, places2.x), Random.Range(places4.y, places4.y), 0), Quaternion.identity);
            }
        }
    }

    public void harderDiff()
    {
        place = Random.Range(0, 2);
        types = Random.Range(0, 2);
        if (place == 0)
        {
            if (types == 0)
            {
                Instantiate(tankEnemy, new Vector3(Random.Range(places1.x, places2.x), Random.Range(places1.y, places2.y), 0), Quaternion.identity);
            }

            if (types == 1)
            {
                Instantiate(lightningEnemy, new Vector3(Random.Range(places1.x, places2.x), Random.Range(places1.y, places2.y), 0), Quaternion.identity);
            }
        }
        else if (place == 1)
        {
            if (types == 0)
            {
                Instantiate(tankEnemy, new Vector3(Random.Range(places3.x, places4.x), Random.Range(places3.y, places4.y), 0), Quaternion.identity);
            }

            if (types == 1)
            {
                Instantiate(lightningEnemy, new Vector3(Random.Range(places3.x, places2.x), Random.Range(places4.y, places4.y), 0), Quaternion.identity);
            }
        }
    }

    public void suicideDiff()
    {
        place = Random.Range(0, 2);
        types = Random.Range(0, 2);
        if (place == 0)
        {
            if (types == 0)
            {
                Instantiate(suicideEnemy, new Vector3(Random.Range(places1.x, places2.x), Random.Range(places1.y, places2.y), 0), Quaternion.identity);
            }

            if (types == 1)
            {
                Instantiate(suicideEnemy, new Vector3(Random.Range(places1.x, places2.x), Random.Range(places1.y, places2.y), 0), Quaternion.identity);
            }
        }
        else if (place == 1)
        {
            if (types == 0)
            {
                Instantiate(suicideEnemy, new Vector3(Random.Range(places3.x, places4.x), Random.Range(places3.y, places4.y), 0), Quaternion.identity);
            }

            if (types == 1)
            {
                Instantiate(suicideEnemy, new Vector3(Random.Range(places3.x, places2.x), Random.Range(places4.y, places4.y), 0), Quaternion.identity);
            }
        }
    }
}
