using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitman : MonoBehaviour
{
    public CircleCollider2D trigger;
    public ParticleSystem death;
    public MeleeHitmanTrigger mht;
    public Rigidbody2D rb;
    
    public string State;
    public float speed;
    public float originalSpeed;
    public int uses;

    private void Awake()
    {
        trigger = gameObject.GetComponentInChildren<CircleCollider2D>();
        mht = gameObject.GetComponentInChildren<MeleeHitmanTrigger>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        originalSpeed = speed;
        State = "searching";
        uses = 50;
    }

    private void Update()
    {
        if (State == "attacking")
        {
            transform.position = Vector2.MoveTowards(transform.position, mht.target, speed * Time.deltaTime);
        }

        if (uses == 0)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(speeed());
        }
    }

    public IEnumerator speeed()
    {
        speed = 1;
        yield return new WaitForSeconds(0.5f);
        speed = originalSpeed;
    }
}
