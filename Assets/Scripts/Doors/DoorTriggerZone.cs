using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerZone : MonoBehaviour
{
    public AudioSource audioSourceDoor;
    public AudioClip audioClipToPlay;
    // Start is called before the first frame update
    private void OnTriggerExit (Collider collision) {
        print("Collision");
        if (collision.CompareTag("Player")){
            GameObject.Find("Door").GetComponent<Animator>().enabled=true;
            audioSourceDoor.PlayOneShot(audioClipToPlay);
            Destroy(gameObject);


        }
    }
}
