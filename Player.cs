using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    public Camera cam;
    public Canvas infoCanvas;
    public Text fpsCounter;
    public Text coinCount;
    public Text deathText;
    public Slider hpBar;
    public Orb orbScr;

    [Header("Integers and floats")]
    public float speed;
    public int dashingDMG;
    public int kills;
    public int totalKills;
    public int gold;
    public int HP;
    public int maxHP;

    [Header("Vector Values")]
    public Vector2 mousePos;

    [Header("Booleans")]
    public bool dashed;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        infoCanvas = GameObject.Find("DebugScreen").GetComponent<Canvas>();
        orbScr = GameObject.Find("Orb").GetComponent<Orb>();
        fpsCounter = GameObject.Find("FPSCount").GetComponent<Text>();
        deathText = GameObject.Find("DiedText").GetComponent<Text>();
        hpBar = GameObject.Find("plrHPBar").GetComponent<Slider>();
        InvokeRepeating("LogFPS", 1, 1);
    }

    private void Update()
    {
        hpBar.value = HP;
        coinCount.text = gold.ToString();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.D))
        {
            movePlr(1, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            movePlr(-1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            movePlr(0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movePlr(0, -1);
        }

        if (Input.GetKeyDown(KeyCode.F1) && !infoCanvas.enabled)
        {
            infoCanvas.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.F1) && infoCanvas.enabled) {
            infoCanvas.enabled = false;
        }

        if (HP <= 0)
        {
            StartCoroutine(die());
        }
    }

    public void movePlr(int xDir, int yDir)
    {
        rb.AddForce(new Vector2(xDir * Time.deltaTime * speed, yDir * Time.deltaTime * speed), ForceMode2D.Impulse);
    }

    public void LogFPS()
    {
        float avgFrameRate = Time.frameCount / Time.time;
        Debug.Log(avgFrameRate.ToString());
        fpsCounter.text = "FPS: " + avgFrameRate.ToString();
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

    public IEnumerator die()
    {
        if (orbScr.balance)
        {
            deathText.enabled = true;
            rb.bodyType = RigidbodyType2D.Static;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(3);
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.transform.position = new Vector3(0, 0, 0);
            deathText.enabled = false;
            HP = 100;
            gold -= 15;
        } else if (!orbScr.balance)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
