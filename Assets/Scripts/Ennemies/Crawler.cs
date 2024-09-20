using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    //https://discussions.unity.com/t/detect-if-player-is-in-range/99984
    public GameObject target;

    
    public AudioSource audioSource;

    public List<AudioClip> listOfStepSounds;
    public float maxFollowRange = 2f;
    public float minFollowRange = 0.5f;

    public float seenMaxRange = 5;
    
    public float speed = 0.01f;

    public float numberSecBeforeNextStep = 0.5f;
    private float elapsedTime = 0f;
    private float nextMomentPlayStepSound;
    public float volume = 0.5f;
    Animator animator;

    private Vector3 targetTran;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
        targetTran = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, target.transform.position) < seenMaxRange) {

            //Permet à la créature de regarder le joueur
            //https://discussions.unity.com/t/how-can-i-make-a-game-object-look-at-another-object/98932
            Quaternion _lookRotation = Quaternion.LookRotation((target.transform.position - transform.position).normalized);
            transform.rotation = _lookRotation;
            print("je regarde le joueur");
        }
        if ((Vector3.Distance(transform.position, target.transform.position) < maxFollowRange)
           && (Vector3.Distance(transform.position, target.transform.position) >= minFollowRange))
        {
            //Permet à la créature de se déplacer vers le joueur
            transform.position = Vector3.MoveTowards(transform.position,  target.transform.position, speed);
            animator.SetBool("moving", true);

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= nextMomentPlayStepSound) {
                elapsedTime = 0;
                AudioClip soundToPlay = listOfStepSounds[Random.Range(0,listOfStepSounds.Count)];
                audioSource.PlayOneShot(soundToPlay, volume);
                //numberSecBeforeNextStep += numberSecBeforeNextStep;
                Debug.Log("played the sound" + soundToPlay);
            }
        } else {
            animator.SetBool("moving", false);
        }
    }
}
