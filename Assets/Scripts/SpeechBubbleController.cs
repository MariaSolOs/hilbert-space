using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeechBubbleController : MonoBehaviour
{
    [SerializeField] float speechBubbleDisplayTime = 1.5f;

    private GameObject speechText = default;
    private static string[] speechBubbleMessages = {"AUCH", "WRONG!", "ARGHH"};

    private void Start()
    {
        ShowBubble(false);
        speechText = transform.Find("Speech Bubble Text").gameObject;
    }

    private void ShowBubble(bool show) {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(show);
        }
    }

    public IEnumerator ShowSpeechBubble() {
        ShowBubble(true);

        int randIndex = UnityEngine.Random.Range(0, speechBubbleMessages.Length);
        speechText.GetComponent<TMP_Text>().text = speechBubbleMessages[randIndex];

        yield return new WaitForSeconds(speechBubbleDisplayTime);

        ShowBubble(false);
    }
}
