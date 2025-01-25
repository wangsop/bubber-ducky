using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleHitScript : MonoBehaviour
{

    private SphereCollider sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = this.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        BubbleCountScript.addBubble();
        Destroy(gameObject);
    }
}
