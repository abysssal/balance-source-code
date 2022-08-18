using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitmanTrigger : MonoBehaviour
{
    public MeleeHitman hitmanScr;
    public Rigidbody2D hitmanRB;
    public Rigidbody2D enemyRb;
    public Rigidbody2D emptyRb;

    public Vector2 target;

    private void Awake()
    {
        hitmanScr = gameObject.GetComponentInParent<MeleeHitman>();
        hitmanRB = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (hitmanScr.State == "searching")
            {
                hitmanScr.State = "attacking";
                enemyRb = col.gameObject.GetComponent<Rigidbody2D>();
                InvokeRepeating("UpdateTarget", 0, 0.1f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (hitmanScr.State == "attacking")
            {
                hitmanScr.State = "searching";
            }
        }
    }

    public void UpdateTarget()
    {
        if (hitmanScr.State == "attacking")
        {
            target = enemyRb.position;
        }

        if (hitmanScr.State == "searching")
        {
            enemyRb = emptyRb;
        }
    }
}