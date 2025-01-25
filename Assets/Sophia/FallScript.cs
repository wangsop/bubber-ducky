using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //lose screen & reset
        Debug.Log("You lost! Fell off the map");
    }
}
