using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAnimationLogic : MonoBehaviour
{
    private Animator animator;
    private float timeToBlink;
    private IEnumerator doBlinkCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        timeToBlink = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToBlink)
        {
            doBlinkCoroutine = DoBlink();
            StartCoroutine(doBlinkCoroutine);
        }
    }

    private IEnumerator DoBlink()
    {
        animator.Play("Spike_Blink");
        yield return new WaitForSeconds(0.4f);
        animator.Play("Spike_Idle");
        timeToBlink = Time.time + Random.Range(0.4f, 10f);
    }
}
