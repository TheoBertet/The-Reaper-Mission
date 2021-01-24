using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform adventurerSpawningPoint;
    public GameObject adventurer;
    public float spawningMobTime = 10f; //Seconds

    private float lastSpawningTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            adventurerSpawningPoint = GameObject.Find("SpawningMobPoint").transform;
            spawnAdventurer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Time.time > lastSpawningTime + spawningMobTime)
            {
                spawnAdventurer();
            }
        }
    }

    public void spawnAdventurer()
    {
        GameObject newAdventurer = Instantiate(adventurer);
        newAdventurer.transform.position = new Vector3(adventurerSpawningPoint.position.x, adventurerSpawningPoint.position.y, 0);

        lastSpawningTime = Time.time;
    }


    private void OnLevelWasLoaded(int level)
    {
        if(level != 0)
        {
            GameObject.Find("Player").SetActive(true);
        }
        else
        {
            GameObject.Find("Player").SetActive(false);
        }

        if(level == 2)
        {
            GameObject.Find("Main Camera").GetComponent<CameraClamping>().targetToFollow = GameObject.Find("Player").transform;

            adventurerSpawningPoint = GameObject.Find("SpawningMobPoint").transform;
            spawnAdventurer();
        }
    }
}
