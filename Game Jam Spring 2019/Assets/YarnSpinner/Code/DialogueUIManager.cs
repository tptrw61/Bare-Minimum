// A basic DialogueUIBehavior for YarnSpinner
// by Jessica Coan
using System.Collections;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class DialogueUIManager : Yarn.Unity.DialogueUIBehaviour
{
    // Unity Editor accessible fields
    public Transform DialoguePanel;
    public TextMeshProUGUI Speaker;
    public TextMeshProUGUI Dialogue;
    public TextMeshProUGUI[] ChoiceTexts;
    public Transform ChoicePanel;
    public float CrawlTime;

    // Delegate passed in to handle selecting options and branching dialogue.
    Yarn.OptionChooser SetSelectedOption;

    // Regular expression matcher. Gets the speaker of a line of dialogue formatted like Speaker: Dialouge.
    Regex speakerTester = new Regex(@"^.+:\s");

    bool dialogueActive;

    private void Awake()
    {
        DialoguePanel.gameObject.SetActive(false);
        ChoicePanel.gameObject.SetActive(false);
    }

    // Returns true if a dialogue is active
    public bool IsDialogueActive()
    {
        return dialogueActive;
    } 

    // Called when the dialogue is being displayed
    public override IEnumerator RunLine(Yarn.Line line)
    {
        string speaker = speakerTester.Match(line.text).Value;
        string dialogue = line.text.Remove(0, speaker.Length);
        Speaker.text = speaker;

        string str = "";
        for (int i = 0; i < dialogue.Length; i++)
        {
            if (Input.anyKeyDown)
            {
                Dialogue.text = dialogue;
                yield return new WaitForSecondsRealtime(0.5f);
                break;
            }
            str += dialogue[i];
            Dialogue.text = str;

            // Runs the next iteration of this for loop after a certain amount of time
            yield return new WaitForSecondsRealtime(CrawlTime);
        }

        while (Input.anyKeyDown == false)
        {
            // Runs the next iteration of this while loop on the next frame
            yield return null;
        }
    }

    // Called when it is time to present options to the player
    public override IEnumerator RunOptions(Yarn.Options optionsCollection,
                                                Yarn.OptionChooser optionChooser)
    {
        ChoicePanel.gameObject.SetActive(true);

        for (int i = 0; i < optionsCollection.options.Count; i++)
        {
            string optionString = optionsCollection.options[i];
            ChoiceTexts[i].transform.parent.gameObject.SetActive(true);
            ChoiceTexts[i].text = optionString;
        }

        SetSelectedOption = optionChooser;

        while (SetSelectedOption != null)
        {
            yield return null;
        }

        foreach (var button in ChoiceTexts)
        {
            button.transform.parent.gameObject.SetActive(false);
        }
    }

    // Runs one of the optional commands
    public override IEnumerator RunCommand(Yarn.Command command)
    {
        // Since we're not using any commands for this demo, this coroutine is empty

        // Ends a coroutine. Required if you're not returning an IEnumerator elsewhere
        yield break;
    }

    // Handles selecting one of the options
    public void SetOption(int selectedOption)
    {
        // Runs the delegate for selecting an option
        SetSelectedOption(selectedOption);

        // Remove the delegate so that we can continue with the dialogue
        SetSelectedOption = null;
    }

    // Called when the dialogue system has started running.
    public override IEnumerator DialogueStarted()
    {
        dialogueActive = true;
        DialoguePanel.gameObject.SetActive(true);

        yield break;
    }

    // Called when the dialogue system had stopped running
    public override IEnumerator DialogueComplete()
    {
        dialogueActive = false;

        DialoguePanel.gameObject.SetActive(false);
        ChoicePanel.gameObject.SetActive(false);

        yield break;
    }
}