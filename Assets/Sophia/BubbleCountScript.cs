using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCountScript : MonoBehaviour
{
    [SerializeField] public int numBubbles;
    // Start is called before the first frame update
    void Start()
    {
        numBubbles = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (numBubbles == 0)
        {
            //send to lose screen
        }
    }

    public void addBubble()
    {
        numBubbles++;
    }

    public void loseBubble()
    {
        numBubbles--;
    }
    public int getNumBubbles()
    {
        return numBubbles;
    }
}
