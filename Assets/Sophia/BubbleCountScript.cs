using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCountScript : MonoBehaviour
{
    [SerializeField] public static int numBubbles;
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
            Globals.lose();
        }
    }

    public static void addBubble()
    {
        numBubbles++;
    }

    public static void loseBubble()
    {
        numBubbles--;
    }
    public static int getNumBubbles()
    {
        return numBubbles;
    }
}
