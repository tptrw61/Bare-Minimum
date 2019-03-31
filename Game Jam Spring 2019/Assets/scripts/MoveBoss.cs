using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    private Vector3 targetpos;
    public AudioSource footsteps;
    public fax_interact fax;
    public float distance;
    public float time;
    public float speed;
    public Stamina stress;
    
    private bool showing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.left * distance;
    }

    public void Show()
    {
        this.targetpos = new Vector3(8.6f, .5f, 0f);
        if (!fax.working)
        {
            stress.increaseStress();
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, Time.deltaTime*speed);
        if(showing && Vector3.Distance(transform.position, targetpos)<= 0.1f)
        {
            showDialogue();
        }
    }

    private void showDialogue()
    {

    }
    
    public IEnumerator TimerSound(float time)
    {
        yield return new WaitForSeconds(time-5);
        footsteps.Play();
        StartCoroutine(TimerBoss(5));
    }

    private IEnumerator TimerBoss(float time)
    {
        yield return new WaitForSeconds(time);
        Show();
    }

    public void Hide()
    {
        this.targetpos = new Vector3(2.6f, .5f, 0f);
    }
}