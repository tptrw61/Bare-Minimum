using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class MoveBoss : MonoBehaviour
{
    private Vector3 targetpos;
    public AudioSource footsteps;
    public fax_interact fax;
    public DialogueRunner dialouge;
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
        showing = true;
        if (!fax.working)
        {
            stress.increaseStress();
            dialouge.startNode = "Slacking";
        }
        else
        {
            dialouge.startNode = "Working";
        }
        dialouge.StartDialogue();
    }



    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, Time.deltaTime*speed);
        if(showing && Vector3.Distance(transform.position, targetpos)<= 0.1f && !dialouge.isDialogueRunning)
        {
            Hide();
        }
    }
    
    public IEnumerator TimerSound(float time)
    {
        yield return new WaitForSeconds(time-5);
        footsteps.Play();
        StartCoroutine(TimerBoss(2));
    }

    private IEnumerator TimerBoss(float time)
    {
        yield return new WaitForSeconds(time);
        Show();
    }

    public void Hide()
    {
        this.targetpos = new Vector3(2.6f, .5f, 0f);
        showing = false;
    }
}