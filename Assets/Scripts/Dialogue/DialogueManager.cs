using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [Header("Getting Objects")]
    //using original chat instantiate its clone
    [SerializeField]
    private GameObject player;
    public static Transform player_position;
    [SerializeField]
    private GameObject chat_sprite;
    [SerializeField]
    private GameObject chat_text;
    [SerializeField]
    private GameObject chat_skip;
    [SerializeField]
    public GameObject chat_box;

    //actual index
    public int dialogue_index = 0;
    public int sentence_index = 0; 
    //created preview
    public bool preview_running = false;
    public bool started_dialogue = false;
    public bool started_sentence = false;
    public bool is_sentence_running = false;

    public Coroutine appearing_text;
    private void Awake()
    {
        player_position = player.transform;
    }
    private void Start()
    {
    }
    public void StartDialogue()
    {
        
        started_dialogue = true;
      //  Time.timeScale = 0;
        chat_box.SetActive(true);
    }

    
    public void DisplaySentence(string sentence)
    {
        started_sentence = true;
        Text text_box = chat_text.GetComponent<Text>();
        text_box.text = string.Empty;
        chat_skip.GetComponent<Text>().text = "e - display at once";
        sentence_index = 0;
        appearing_text = StartCoroutine(text_appear(sentence, text_box));
        


    }
    public void DisplaySpriteAnimated(GameObject npc)
    {
        chat_sprite.GetComponent<Image>().sprite = npc.GetComponent<SpriteRenderer>().sprite;
    }
    public bool CanContinue(int actual_sentence, int all_sentence)
    {
        if (actual_sentence >= all_sentence)
        {
            return false;
        }
        return true;
    }
    public void DisplaySentenceImmadiately(string sentence)
    {


        StopCoroutine(appearing_text);
        Text text_box = chat_text.GetComponent<Text>();
        text_box.text = string.Empty;
        text_box.text = sentence;
        chat_skip.GetComponent<Text>().text = "e - to next sentence";
        is_sentence_running = false;
        started_sentence = false;
        dialogue_index += 1;
        sentence_index = 0;
        
    
    }
    public void EndDialogue()
    {
        started_dialogue = false;
        chat_skip.SetActive(false);
        chat_box.SetActive(false);
        dialogue_index = 0;
       // Time.timeScale = 1;

    }


    public void DisplayPreviewSentence(GameObject npc_object)
    {
        preview_running = true;
        GameObject chat_box = npc_object.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        chat_box.SetActive(true);
        GameObject chat_text = chat_box.transform.GetChild(0).gameObject;
        chat_text.GetComponent<Text>().text = npc_object.GetComponent<PreviewSentence>().preview_sentence;
    }
    public void HidePreviewSentence(GameObject npc_object)
    {
        preview_running = false;
        GameObject chat_box = npc_object.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        chat_box.SetActive(false);
    }
    IEnumerator text_appear(string sentence,Text text_box)
    {
        is_sentence_running = true;
        for (sentence_index=0; sentence_index < sentence.Length; sentence_index++)
        {
            text_box.text += sentence[sentence_index];
            yield return new WaitForSecondsRealtime(0.1f);
        }
        yield return null;
        chat_skip.GetComponent<Text>().text = "e - to next sentence";
        is_sentence_running = false;
        started_sentence = false;
        dialogue_index += 1;
        sentence_index = 0;
    }

}

