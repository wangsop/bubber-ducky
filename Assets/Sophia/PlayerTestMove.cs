using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestMove : MonoBehaviour
{
    [SerializeField] GameObject bubble;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bubble.transform.position, Time.deltaTime);
    }
}
