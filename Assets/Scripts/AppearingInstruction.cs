using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AppearingInstruction : MonoBehaviour
{
    public string text;
    public int index;
    public TextMeshPro text_empty;
    public float appearing_speed;
    public float disappear_speed;
    public Animator animator_controller;

    private void Awake()
    {
        text = gameObject.GetComponent<TextMeshPro>().text;
        gameObject.GetComponent<TextMeshPro>().text = string.Empty;
        text_empty = gameObject.GetComponent<TextMeshPro>();
    }
    void Start()
    {
         animator_controller.SetTrigger("appear");
         StartCoroutine(instruction_appear());
    }

    IEnumerator instruction_appear()
    {
        int text_count = text.Length;
        for (index=0; index < text_count; index++)
        {
            text_empty.text += text[index];
            yield return new WaitForSeconds(appearing_speed);

        }
        animator_controller.SetTrigger("disappear");
        yield return new WaitForSeconds(disappear_speed);
        Destroy(gameObject);
        yield return null;


    }
}
