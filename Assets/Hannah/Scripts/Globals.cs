using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public GameObject currentTrack;
    public GameObject player;
    public static Vector3 playerStartingPosition;
    public static float percentageComplete;
    public static int numBubblesNeeded = 5; 
    // Start is called before the first frame update
    void Start()
    {
        playerStartingPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //for now, it's wherever the player starts; we can fix this later
    }

    // Update is called once per frame
    void Update()
    {
        float trackLength = currentTrack.transform.position.z + (currentTrack.GetComponent<MeshRenderer>().bounds.size.z / 2);
        percentageComplete = (player.transform.position.z - playerStartingPosition.z) / (trackLength - playerStartingPosition.z);
    }

    public static void win()
    {
        //change to win screen, stuff
        Debug.Log("You win");
    }
    public static void lose()
    {
        //lose stuff
        Debug.Log("You lose");
    }
}
