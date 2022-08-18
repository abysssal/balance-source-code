using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject woodWall;
    public GameObject stoneWall;
    public GameObject goldWall;
    public GameObject meleeHitman;
    public GameObject speedyHitman;
    public GameObject stronkHitman;

    public GameObject bulletPrefab;
    public Transform gunTip;
    public Canvas buildingMenu;
    public Text selectedText;
    public Text lastUpgrade;
    public Player plrScr;
    public AudioSource shoot;
    public SpriteRenderer outLine;

    public float bulletForce;
    public float dmgMultiplier;
    public float rangeAdd;
    public int buildSelected;
    public int choice;

    public bool building = false;

    private void Awake()
    {
        plrScr = gameObject.GetComponent<Player>();
        buildingMenu = GameObject.Find("BuildingMenu").GetComponent<Canvas>();
        selectedText = GameObject.Find("WhatIsSelected").GetComponent<Text>();
        lastUpgrade = GameObject.Find("LastUpgrade").GetComponent<Text>();
        dmgMultiplier = 1;
        rangeAdd = 0;
    }

    private void Update()
    {
        if (!building)
        {
            outLine.enabled = false;
        }

        if (building)
        {
            outLine.enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!building)
            {
                outLine.enabled = false;
                if (plrScr.gold >= 1)
                {
                    StartCoroutine(FireBullet());
                    shoot.pitch = Random.Range(0.5f, 1.3f);
                    shoot.Play();
                }
            } else if (building)
            {
                if (buildSelected == 1)
                {
                    outLine.enabled = true;
                    if (plrScr.gold >= 75)
                    {
                        StartCoroutine(BuildWoodWall());
                    }
                }

                if (buildSelected == 2)
                {
                    outLine.enabled = true;
                    if (plrScr.gold >= 150)
                    {
                        StartCoroutine(BuildStoneWall());
                    }
                }

                if (buildSelected == 3)
                {
                    outLine.enabled = true;
                    if (plrScr.gold >= 225)
                    {
                        StartCoroutine(BuildGoldWall());
                    }
                }

                if (buildSelected == 4)
                {
                    outLine.enabled = false;
                    if (plrScr.gold >= 200)
                    {
                        StartCoroutine(HireMeleeHitman());
                    }
                }

                if (buildSelected == 5)
                {
                    outLine.enabled = false;
                    if (plrScr.gold >= 225)
                    {
                        StartCoroutine(HireSpeedyHitman());
                    }
                }

                if (buildSelected == 6)
                {
                    outLine.enabled = false;
                    if (plrScr.gold >= 250)
                    {
                        StartCoroutine(HireStronkHitman());
                    }
                }
            }

            if (plrScr.kills >= 20)
            {
                choice = Random.Range(0, 3);
                if (choice == 0)
                {
                    dmgMultiplier += 0.1f;
                    plrScr.kills = 0;
                    lastUpgrade.text = "Last Upgrade: Damage";
                }
                
                if (choice == 1)
                {
                    bulletForce += 2.5f;
                    plrScr.kills = 0;
                    lastUpgrade.text = "Last Upgrade: Bullet Speed";
                }

                if (choice == 2)
                {
                    rangeAdd += 0.5f;
                    plrScr.kills = 0;
                    lastUpgrade.text = "Last Upgrade: Range";
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!building)
            {
                building = true;
                buildingMenu.enabled = true;
            } else if (building)
            {
                building = false;
                buildingMenu.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildSelected = 1;
            selectedText.text = "Wood wall selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildSelected = 2;
            selectedText.text = "Stone wall selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            buildSelected = 3;
            selectedText.text = "Gold wall selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            buildSelected = 4;
            selectedText.text = "Melee hitman selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            buildSelected = 5;
            selectedText.text = "Speedy hitman selected";
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            buildSelected = 6;
            selectedText.text = "Stronk hitman selected";
        }
    }

    public IEnumerator FireBullet()
    {
        plrScr.gold--;
        GameObject bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        Rigidbody2D bRB = bullet.GetComponent<Rigidbody2D>();
        bRB.AddForce(gunTip.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuildWoodWall()
    {
        plrScr.gold -= 75;
        GameObject wall = Instantiate(woodWall, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuildStoneWall()
    {
        plrScr.gold -= 150;
        GameObject wall = Instantiate(stoneWall, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator BuildGoldWall()
    {
        plrScr.gold -= 225;
        GameObject wall = Instantiate(goldWall, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator HireMeleeHitman()
    {
        plrScr.gold -= 200;
        GameObject hitman = Instantiate(meleeHitman, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator HireSpeedyHitman()
    {
        plrScr.gold -= 225;
        GameObject hitman = Instantiate(speedyHitman, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }

    public IEnumerator HireStronkHitman()
    {
        plrScr.gold -= 250;
        GameObject hitman = Instantiate(stronkHitman, gunTip.position, gunTip.rotation);
        yield return new WaitForSeconds(1);
    }
}