using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int skullPrice = 0;
    public int basePrice = 2;

    private bool playerIsNear = false;

    // Start is called before the first frame update
    void Start()
    {
        RefreshIndications();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsNear && Input.GetKeyDown(KeyCode.F) && HasPlayerEnoughSouls())
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().RemoveSouls(skullPrice);
            GameObject.Find("Player").GetComponent<PlayerManager>().AddSkull();
            RefreshIndications();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ShowIndications();
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HideIndications();
            playerIsNear = false;
        }
    }

    public bool HasPlayerEnoughSouls()
    {
        if(GameObject.Find("Player").GetComponent<PlayerManager>().nbSouls >= skullPrice)
        {
            return true;
        }
        return false;
    }

    public void ShowIndications()
    {
        transform.Find("Indications").gameObject.SetActive(true);
    }

    public void HideIndications()
    {
        transform.Find("Indications").gameObject.SetActive(false);
    }

    public void ProcessPrice()
    {
        float healthpoints = GameObject.Find("Player").GetComponent<PlayerManager>().healthPoints;
        if(healthpoints <= 1)
        {
            skullPrice = 0;
        }
        else
        {
            skullPrice = (int)(healthpoints * basePrice -2);
        }
    }

    public void RefreshIndications()
    {
        ProcessPrice();
        string souls = "Soul";
        if(skullPrice > 1)
        {
            souls += "s";
        }
        transform.Find("Indications").GetComponent<TextMesh>().text =
            "Press F to buy a Skull !\nPrice: " + skullPrice + " " + souls;
    }
}
