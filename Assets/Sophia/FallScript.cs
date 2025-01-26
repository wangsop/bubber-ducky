using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BubberController>(out BubberController bubber))
        {
            Globals.lose();
        }
    }
}
