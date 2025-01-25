using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        BubbleCountScript.loseBubble();
        Destroy(gameObject);
    }
}
