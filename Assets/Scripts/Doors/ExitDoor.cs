using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
public class ExitDoor : MonoBehaviour
{

    public float numberOfKeysToGet = 3;
    public float numberKeysGotten = 0;

    Animator animator;

    public AudioSource audioSourceDoor;
    public AudioClip audioClipToPlay;

    private bool exitSoundAlreadyPlayed = false;

    void Start() {
        animator = GetComponent<Animator>();
    }
    void LateUpdate()
    {
        
        if(numberKeysGotten >= numberOfKeysToGet) {
            print("La porte c'est ouverte!");
            animator.SetBool("keysObtained", true);
            if(!exitSoundAlreadyPlayed) {

                audioSourceDoor.PlayOneShot(audioClipToPlay);
                exitSoundAlreadyPlayed = true;
            }
        }
    }
}