using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject bubbleCounter;
    public TextMeshProUGUI bubbleText;
    private Color startColor;

    public GameObject progressBar;
    public Image progressBarMask;
    public Image duckIcon;

    public GameObject dialogueObject;
    public TextMeshProUGUI dialogueText;
    public Image dialogueButton;
    public float timeForTalkingLine;

    private Vector3 duckInitPosition, duckFinalPosition;
    public string[] dialogue;
    private int currentDialogue = 0;

    public GameObject introGround;
    public Camera introCamera;
    public Camera normalCamera;

    public AudioSource talkingAudio;

    // Start is called before the first frame update
    void Start()
    {
        bubbleCounter.SetActive(false);
        progressBar.SetActive(false);
        dialogueObject.SetActive(true);
        introGround.GetComponent<BoxCollider>().enabled = true;
        normalCamera.enabled = false;
        introCamera.enabled = true;

        startColor = bubbleText.color;

        ReadSentence();
        duckInitPosition = new Vector3(duckIcon.transform.position.x, duckIcon.transform.position.y, duckIcon.transform.position.z);
        duckFinalPosition = new Vector3(duckIcon.transform.position.x, progressBarMask.GetComponent<RectTransform>().rect.height, duckIcon.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Intro: " + Globals.introOccurring);
        //Debug.Log("Restart: " + Globals.isRestart);
        if (!Globals.introOccurring)
        {
            bubbleText.text = "x " + BubbleCountScript.getNumBubbles();
            bubbleText.color = (BubbleCountScript.getNumBubbles() < Globals.numBubblesNeeded) ? new Color(0.9f, 0.1f, 0.05f) : startColor;
            progressBarMask.fillAmount = Globals.percentageComplete;
            if (duckIcon.transform.position.y < duckFinalPosition.y)
            {
                duckIcon.gameObject.transform.position = duckInitPosition + ((duckFinalPosition - duckInitPosition) * Globals.percentageComplete);
            }
        } else if (Globals.isRestart) //specifically for restart, so the player doesn't have to hear the monologue again
        {
            bubbleCounter.SetActive(false);
            progressBar.SetActive(false);
            dialogueObject.SetActive(true);
            introGround.GetComponent<BoxCollider>().enabled = true;
            normalCamera.enabled = false;
            introCamera.enabled = true;

            currentDialogue = dialogue.Length;

            ReadSentence();
            Globals.isRestart = false;
        }
    }

    public void ReadSentence()
    {
        if (currentDialogue <= dialogue.Length)
        {
            StopAllCoroutines();
            talkingAudio.Stop();
            dialogueText.text = "";

            talkingAudio.Play();

            if (currentDialogue == dialogue.Length)
            {
                StartCoroutine(MakeSentence(("To clean the baby duck, you must have " + Globals.numBubblesNeeded + " bubbles. If you're in the red, you don't have enough. Now, get to it!").ToCharArray()));
            } else
            {
                StartCoroutine(MakeSentence(dialogue[currentDialogue].ToCharArray()));
            }
            currentDialogue++;
        } else
        {
            Globals.introOccurring = false;
            talkingAudio.Stop();
            introGround.GetComponent<BoxCollider>().enabled = false;
            introCamera.enabled = false;
            normalCamera.enabled = true;
            dialogueObject.SetActive(false);
            bubbleCounter.SetActive(true);
            progressBar.SetActive(true);
        }
        
    }

    IEnumerator MakeSentence(char[] sentence)
    {
        foreach (char character in sentence)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(timeForTalkingLine / sentence.Length);
        }
    }
}
