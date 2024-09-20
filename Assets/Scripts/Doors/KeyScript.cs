using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
public class KeyScript : MonoBehaviour
{
    public AudioSource audioSourceKey;
    public AudioClip audioClipToPlay;
 
    private void OnCollisionEnter(Collision collision) {
        print("Collision avec une clé!");
        if (collision.gameObject.CompareTag("Player")){
            GameObject.Find("ExitDoor").GetComponent<ExitDoor>().numberKeysGotten += 1;
            
            audioSourceKey.PlayOneShot(audioClipToPlay);
            Destroy(gameObject);
        }
    }
}