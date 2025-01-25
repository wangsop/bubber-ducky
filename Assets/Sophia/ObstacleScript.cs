using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] BubbleCountScript bcs;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        bcs.loseBubble();
        Destroy(gameObject);
        //PlayerController.Slow();
    }
}
