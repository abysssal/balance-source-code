using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb : MonoBehaviour
{
    public int HP;
    public bool balance = true;

    public Slider hpBar;
    public CircleCollider2D col;
    public Text text;
    public SpriteRenderer sr;

    private void Awake()
    {
        hpBar = GameObject.Find("orbHPBar").GetComponent<Slider>();
        text = GameObject.Find("BalancedText").GetComponent<Text>();
        col = gameObject.GetComponent<CircleCollider2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        hpBar.value = HP;
        if (HP <= 0)
        {
            balance = false;
            text.enabled = true;
            col.enabled = false;
            sr.enabled = false;
            int childs = transform.childCount;
            for (int i = childs - 1; i >= 0; i--)
            {
                GameObject.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
