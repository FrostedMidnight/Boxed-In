using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<Dialogue> dialogues;
    [SerializeField] private Image character;
    [SerializeField] private RectTransform leftCharacterPosition;
    [SerializeField] private RectTransform rightCharacterPosition;


    private Queue<string> sentences;

    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject testDialogueButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentences = new Queue<string>();
        dialogues = new Queue<Dialogue>();
    }

    public void StartDialogue(Dialogue[] dialogueSequence)
    {
        // Debug.Log("Starting dialogue");
        dialogues.Clear();

        foreach (Dialogue dialogue in dialogueSequence)
        {
            dialogues.Enqueue(dialogue);
        }

        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogues.Dequeue();

        nameText.text = dialogue.name;
        character.sprite = dialogue.image;
        character.gameObject.SetActive(character != null);

        RectTransform characterPosition = (dialogue.position == ImagePosition.Left)
        ? leftCharacterPosition
        : rightCharacterPosition;

        character.rectTransform.anchoredPosition = characterPosition.anchoredPosition;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            DisplayNextDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        // dialogueText.text = sentence;
        // Debug.Log(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1.0f / 60.0f); // To make the dialogue wait 1 frames per letter
        }
    }

    public void EndDialogue()
    {
        // Debug.Log("End of dialogue");
        dialogueBox.gameObject.SetActive(false);
        testDialogueButton.gameObject.SetActive(false);
        character.gameObject.SetActive(false);
    }
}
