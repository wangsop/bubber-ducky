using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BubberController>(out BubberController bubber))
        {
            if (BubbleCountScript.numBubbles >= Globals.numBubblesNeeded)
            {
                Globals.win();
            } else
            {
                Globals.lose();
            }
        }
    }
}
