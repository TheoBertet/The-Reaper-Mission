using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float healthPoints = 5;
    public float curHP = 0;
    public bool dead = false;
    public int nbSouls = 0;

    private GameObject UI;
    private bool firstDeath = true;


    private void Awake()
    {
        curHP = healthPoints;
        DontDestroyOnLoad(transform.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "ReaperDialog")
        {
            UI = GameObject.Find("UI").transform.Find("Canvas").gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(curHP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        dead = true;
        if(firstDeath)
        {
            SceneManager.LoadScene(4);
        }
        else
            SceneManager.LoadScene(2);
    }
    
    public bool isDead()
    {
        return dead;
    }

    public void Heal(float heal)
    {
        curHP = Math.Min(curHP + heal, healthPoints);
    }

    public void Damage(float damage)
    {
        curHP -= damage;
        UI.GetComponent<UIManager>().DisplaySkullLives();
    }

    public void AddSouls(int nbSoulsToAdd)
    {
        nbSouls += nbSoulsToAdd;
        UI.GetComponent<UIManager>().RefreshSouls();
    }

    public void RemoveSouls(int nbSoulsToRemove)
    {
        nbSouls -= nbSoulsToRemove;
        UI.GetComponent<UIManager>().RefreshSouls();
    }

    public void AddSkull()
    {
        healthPoints++;
        curHP++;
        UI.GetComponent<UIManager>().DisplaySkullLives();
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            dead = false;
            curHP = healthPoints;
            UI = GameObject.Find("UI").transform.Find("Canvas").gameObject;

            Transform spawnPoint = GameObject.Find("SpawnPlayerPoint").transform;
            transform.position = new Vector3(spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);
        }
        else if(level == 3)
        {
            dead = false;
            curHP = healthPoints;
            UI = GameObject.Find("UI").transform.Find("Canvas").gameObject;

            Transform spawnPoint = GameObject.Find("SpawnPlayerPoint").transform;
            transform.position = new Vector3(spawnPoint.position.x,
                spawnPoint.position.y,
                spawnPoint.position.z);
        }
        else if(level == 4)
        {
            dead = false;
            curHP = healthPoints;
            firstDeath = false;
        }
    }
}
