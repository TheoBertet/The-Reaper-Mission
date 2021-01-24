using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject skullLife;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        DisplaySkullLives();
        RefreshSouls();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplaySkullLives()
    {
        RemoveSkullLives();
        Transform SkullPos = transform.Find("HPPos").Find("Skulls");
        for(int index = 0; index < player.GetComponent<PlayerManager>().curHP; index++)
        {
            float posX = SkullPos.position.x + 35 * index;
            float posY = SkullPos.position.y;

            GameObject skull = Instantiate(skullLife, SkullPos);
            skull.transform.position = new Vector3(posX, posY);
        }
    }

    public void RemoveSkullLives()
    {
        Transform SkullPos = transform.Find("HPPos").Find("Skulls");
        foreach (Transform child in SkullPos)
        {
            Destroy(child.gameObject);
        }
    }

    public void RefreshSouls()
    {
        transform.Find("SoulsPos").Find("nbSouls").GetComponent<TextMeshProUGUI>().SetText("{0}", player.GetComponent<PlayerManager>().nbSouls);
    }
}
