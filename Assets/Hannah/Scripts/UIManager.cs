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
    private Vector3 duckInitPosition, duckFinalPosition;

    // Start is called before the first frame update
    void Start()
    {
        duckInitPosition = new Vector3(duckIcon.transform.position.x, duckIcon.transform.position.y, duckIcon.transform.position.z);
        duckFinalPosition = new Vector3(duckIcon.transform.position.x, progressBarMask.transform.position.y, duckIcon.transform.position.z);
        Debug.Log(duckFinalPosition);
    }

    // Update is called once per frame
    void Update()
    {
        bubbleText.text = "x " + BubbleCountScript.getNumBubbles();
        progressBarMask.fillAmount = Globals.percentageComplete;
        if (duckIcon.transform.position.y > duckFinalPosition.y)
        {
            duckIcon.gameObject.transform.position = duckInitPosition + ((duckFinalPosition - duckInitPosition) * Globals.percentageComplete);
        }
    }
}
