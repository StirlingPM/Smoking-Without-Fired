using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    [SerializeField] bool canSee;
    [SerializeField] Animator[] studentAnimators;
    [SerializeField] AudioClip[] grunts;
    // Start is called before the first frame update
    void Start()
    {
        studentAnimators = GetComponentsInChildren<Animator>();
        foreach (Animator item in studentAnimators)
        {
            item.SetFloat("speed", Random.Range(.1f, 2f));
        }
        
    }

    public void StartLooking()
    {
        StartCoroutine(LookUpRandomly());
    }

    IEnumerator LookUpRandomly()
    {
        while (true)
        {
            float waitTime = Random.Range(1, 5);
            yield return new WaitForSeconds(waitTime);
            Animator selectedAnim = studentAnimators[Random.Range(0, studentAnimators.Length)];
            selectedAnim.SetTrigger("lookUp");
            AudioSource audio = selectedAnim.GetComponent<AudioSource>();
            audio.clip = grunts[Random.Range(0, grunts.Length)];
            audio.pitch = Random.Range(.75f, 1.25f);
            audio.Play();
            
            yield return new WaitForSeconds(.5f);
            GameManager.isSeen = true;
            yield return new WaitForSeconds(2);
            GameManager.isSeen = false;
        }
    }

    private void Update()
    {
        if(!(GameManager.gameState == CurrentGameState.Game))
        {
            StopAllCoroutines();
            GameManager.isSeen = false;
            GameManager.isSmoking = false;
        }
    }
}
