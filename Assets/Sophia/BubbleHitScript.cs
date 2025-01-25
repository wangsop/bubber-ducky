using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHitScript : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        BubbleCountScript.addBubble();
        Destroy(gameObject);
    }
}
