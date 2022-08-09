using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    [SerializeField]
    private DialogueManager dialogue_manager;
    [SerializeField]
    private GameObject interact;
    private string[] npc_sentences;
    private int sentences_length;
    private bool player_collision = false;
    private bool talked_once=false;

    private void Awake()
    {
        npc_sentences = gameObject.GetComponent<Sentences>().sentences;
        sentences_length = npc_sentences.Length;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, DialogueManager.player_position.position) < 4 && dialogue_manager.preview_running == false && talked_once == false)
        {
            dialogue_manager.DisplayPreviewSentence(gameObject);
        }
        else if(Vector3.Distance(gameObject.transform.position, DialogueManager.player_position.position) > 4 && dialogue_manager.preview_running == true && talked_once == false)
        {
            dialogue_manager.HidePreviewSentence(gameObject);
        }

        if (dialogue_manager.started_dialogue == true)
        {
            dialogue_manager.DisplaySpriteAnimated(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E) && dialogue_manager.started_dialogue == false && player_collision == true)
        {
            dialogue_manager.StartDialogue();
            dialogue_manager.DisplaySentence(npc_sentences[dialogue_manager.dialogue_index]);
        }
        else if (Input.GetKeyDown(KeyCode.E) && dialogue_manager.started_dialogue == true)
        {
            if (dialogue_manager.CanContinue(dialogue_manager.dialogue_index, sentences_length) && dialogue_manager.started_sentence == false)
            {
                dialogue_manager.DisplaySentence(npc_sentences[dialogue_manager.dialogue_index]);
            }
            else if (dialogue_manager.is_sentence_running == true)
            {
                dialogue_manager.DisplaySentenceImmadiately(npc_sentences[dialogue_manager.dialogue_index]);
            }
            else
            {
                dialogue_manager.HidePreviewSentence(gameObject);
                talked_once = true;
                dialogue_manager.EndDialogue();
            }
            /* if (dialogue_manager.is_sentence_running)
             {
                 dialogue_manager.DisplaySentenceImmadiately(npc_sentences[dialogue_manager.dialogue_index]);
             }*/
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_collision = true;
            if(dialogue_manager.started_dialogue == false)
            {
                // DISPLAY CLICK E TO INTERACT
                interact.SetActive(true);
            }

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_collision = false;
            interact.SetActive(false);
            // HIDE "CLICK E TO INTERACT" 
        }

    }
}



   