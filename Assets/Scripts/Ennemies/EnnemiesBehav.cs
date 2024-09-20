using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesBehav : MonoBehaviour
{
    //https://discussions.unity.com/t/detect-if-player-is-in-range/99984
    public GameObject target;
    public int maxAttackRange = 2;
    public int minAttackRange = 0;

    public int seenMaxRange = 10;
    
    Animator animator;

    public AudioSource audioSource;

    public float volume = 1;

    private bool attackSoundPlayed = false;

    public List<AudioClip> soundsToPlay;

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
        if ((Vector3.Distance(transform.position, target.transform.position) < maxAttackRange)
           && (Vector3.Distance(transform.position, target.transform.position) > minAttackRange))
        {
            animator.SetBool("attack", true);
            if(!attackSoundPlayed) {
                audioSource.PlayOneShot(soundsToPlay[Random.Range(0,soundsToPlay.Count)], volume);
                attackSoundPlayed = true;
            }

            //transform.Translate(Vector3.forward * Time.deltaTime);
        } else {
            animator.SetBool("attack", false);
            attackSoundPlayed = false;
        }
    }
}
