using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstCinematic : MonoBehaviour
{
    public GameObject image;
    public GameObject dialog;
    public float secondsBeforeFirstSentence = 3f;
    public float secondsBetweenSentences = 5f;
    private float timeCode = 0f;

    public string[] sentences;
    public GameObject[] sprites;
    public int[] keyframeForImage;
    public int currentSentence = 0;
    public int currentImage = 0;
    private bool imageChanged = false;
    private GameObject lastSprite;

    // Start is called before the first frame update
    void Start()
    {
        timeCode = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSentence < sentences.Length)
        {
            if (currentSentence == 0)
            {
                if (Time.time > timeCode + secondsBeforeFirstSentence)
                {
                    dialog.GetComponent<TextMeshProUGUI>().SetText(sentences[0]);
                    currentSentence++;
                    timeCode = Time.time;
                }
            }
            else
            {
                if (Time.time > timeCode + secondsBetweenSentences)
                {
                    dialog.GetComponent<TextMeshProUGUI>().SetText(sentences[currentSentence]);
                    currentSentence++;
                    timeCode = Time.time;
                    imageChanged = false;
                }
            }
        }
        else
        {
            if (Time.time > timeCode + secondsBetweenSentences)
                SceneManager.LoadScene(3);
        }

        foreach (int keyframe in keyframeForImage)
        {
            if(keyframe+1 == currentSentence && !imageChanged)
            {
                if (lastSprite != null)
                    Destroy(lastSprite);

                lastSprite = Instantiate(sprites[currentImage], image.transform);
                lastSprite.transform.position = new Vector3(image.transform.position.x, image.transform.position.y, 5);
                currentImage++;
                imageChanged = true;
            }
        }
    }
}
