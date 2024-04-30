using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;

    [Header("Dialogue Data")]
    [SerializeField] private List<DialogueEntry> dialogueEntries;
    private int currentDialogueIndex = 0;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] typingSounds;

    [Header("Typing Effect")]
    [SerializeField] private float typingSpeed = 0.05f;

    private bool isCurrentlyTyping = false;

    void Start()
    {
        if (dialogueEntries.Count == 0)
        {
            Debug.LogError("No dialogue entries provided.");
            return;
        }

        StartDialogue();
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        DisplayNextLine();
    }

    private void DisplayNextLine()
    {
        if (currentDialogueIndex < dialogueEntries.Count)
        {
            var entry = dialogueEntries[currentDialogueIndex];
            nameText.text = entry.speakerName;
            StartCoroutine(TypeLine(entry.dialogueText));
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine(string line)
    {
        isCurrentlyTyping = true;
        dialogueText.text = "";
        foreach (char c in line)
        {
            dialogueText.text += c;
            PlayTypingSound();
            yield return new WaitForSeconds(typingSpeed);
        }
        isCurrentlyTyping = false;
        currentDialogueIndex++;  // Move to the next line after finishing typing
    }

    private void PlayTypingSound()
    {
        if (typingSounds != null && typingSounds.Length > 0)
        {
            AudioClip randomTypingSound = typingSounds[Random.Range(0, typingSounds.Length)];
            audioSource.PlayOneShot(randomTypingSound);
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCurrentlyTyping)
        {
            DisplayNextLine();
        }
    }
}
