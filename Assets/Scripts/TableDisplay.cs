using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TableDisplay : MonoBehaviour
{
    [SerializeField]
    public GameObject TablePanel;
    [SerializeField]
    public GameObject TableText;
    [SerializeField]
    public string table_content;


    private GameObject table_info;

    private bool player_colliding = false;
    private bool table_active = false;
    void Start()
    {
        table_info = gameObject.transform.GetChild(0).transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && player_colliding == true)
        {
            TablePanel.SetActive(true);
            TableText.GetComponent<Text>().text = table_content;
            //DISPLAY TABLE CONTENT
        }
        if(Input.GetKeyDown(KeyCode.E) && table_active == true)
        {
            TablePanel.SetActive(false);
            table_active = false;
        }
        if (TablePanel.activeSelf)
        {
            table_active = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            table_info.SetActive(true);
            player_colliding = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            table_info.SetActive(false);
            player_colliding = false;
        }
    }
}
