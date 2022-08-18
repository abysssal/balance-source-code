using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomber : MonoBehaviour
{
    public int speed;
    public float hp;
    public int dmg;
    public int reward;
    public Vector2 target;
    public Orb orbScript;
    public Player plrScript;
    public ParticleSystem deathParticles;
    public Transform targetTrans;
    public Rigidbody2D myRb;
    public Rigidbody2D plrRB;
    public AudioSource hit;

    private void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        targetTrans = GameObject.Find("Orb").GetComponent<Transform>();
        orbScript = GameObject.Find("Orb").GetComponent<Orb>();
        plrScript = GameObject.Find("Player").GetComponent<Player>();
        plrRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        hit = GameObject.Find("hitEnemy").GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, plrRB.position, speed * Time.deltaTime);
        if (hp <= 0)
        {
            Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            plrScript.gold += reward;
            plrScript.kills += 1;
            plrScript.totalKills += 1;
        }

        if (!orbScript.balance)
        {
            hp = hp * 25;
            speed += 2;
            target = plrRB.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Orb")
        {
            orbScript.HP -= dmg;
            plrScript.gold -= reward;
            plrScript.kills -= 1;
            plrScript.totalKills -= 1;
            hp = 0;
        }

        if (col.gameObject.tag == "Player")
        {
            plrScript.HP = 0;
            hp = 0;
            hit.Play();
        }

        if (col.gameObject.tag == "bulllet")
        {
            Bullet bulScr = col.gameObject.GetComponent<Bullet>();
            hp -= bulScr.damage;
            hit.Play();
        }

        if (col.gameObject.tag == "Wall")
        {
            Wall wallScr = col.gameObject.GetComponent<Wall>();
            plrScript.gold -= reward;
            wallScr.hp -= dmg;
            plrScript.kills -= 1;
            plrScript.totalKills -= 1;
            hp = 0;
            hit.pitch = Random.Range(0.7f, 1.3f);
            hit.Play();
        }

        if (col.gameObject.tag == "mHitman")
        {
            MeleeHitman hisScr = col.gameObject.GetComponent<MeleeHitman>();
            hisScr.uses -= 1;
            hp = 0;
        }

        if (col.gameObject.tag == "spHitman")
        {
            MeleeHitman hisScr = col.gameObject.GetComponent<MeleeHitman>();
            hisScr.uses -= 1;
            hp -= 50;
        }

        if (col.gameObject.tag == "stHitman")
        {
            MeleeHitman hisScr = col.gameObject.GetComponent<MeleeHitman>();
            hisScr.uses -= 1;
            hp -= 100;
        }
    }
}
