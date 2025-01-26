using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI bubbleText;
    public Image progressBarMask;
    public Image duckIcon;

    public TextMeshProUGUI dialogueText;
    public Image dialogueButton;
    public float timeForTalkingLine;

    private Vector3 duckInitPosition, duckFinalPosition;
    public string[] dialogue;
    private int currentDialogue = 0;

    // Start is called before the first frame update
    void Start()
    {
        ReadSentence();
        duckInitPosition = new Vector3(duckIcon.transform.position.x, duckIcon.transform.position.y, duckIcon.transform.position.z);
        duckFinalPosition = new Vector3(duckIcon.transform.position.x, progressBarMask.GetComponent<RectTransform>().rect.height, duckIcon.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        bubbleText.text = "x " + BubbleCountScript.getNumBubbles();
        progressBarMask.fillAmount = Globals.percentageComplete;
        if (duckIcon.transform.position.y < duckFinalPosition.y)
        {
            duckIcon.gameObject.transform.position = duckInitPosition + ((duckFinalPosition - duckInitPosition) * Globals.percentageComplete);
        }
    }

    public void ReadSentence()
    {
        if (currentDialogue < dialogue.Length)
        {
            StopAllCoroutines();
            dialogueText.text = "";
            StartCoroutine(MakeSentence(dialogue[currentDialogue].ToCharArray()));
            currentDialogue++;
        } else
        {
            //Make stuff happen to get to main level
        }
        
    }

    IEnumerator MakeSentence(char[] sentence)
    {
        Debug.Log(timeForTalkingLine / sentence.Length);

        foreach (char character in sentence)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(timeForTalkingLine / sentence.Length);
        }
    }
}
