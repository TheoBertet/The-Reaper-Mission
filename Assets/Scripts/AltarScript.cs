using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltarScript : MonoBehaviour
{
    public bool playerIsNear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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


    public void ShowIndications()
    {
        transform.Find("Indications").gameObject.SetActive(true);
    }

    public void HideIndications()
    {
        transform.Find("Indications").gameObject.SetActive(false);
    }
}
