using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition3 : MonoBehaviour
{
    public GameObject teleport_gameobject;
    public GameObject key_gameobject;

    private bool end_game=false;

    void Update()
    {
        if(MonsterSpawner.beaten1 && MonsterSpawner.beaten2 && MonsterSpawner.beaten3 && MonsterSpawner.ready_for_next && !end_game)
        {
            Debug.Log("end game");
            end_game = true;
        }

        if (end_game)
        {
            Invoke("ShowTeleport", 1.5f);
            Invoke("ShowKey", 0.5f);
        }
        
        
    }

    void ShowTeleport()
    {
        teleport_gameobject.SetActive(true);
        
    }

    void ShowKey()
    {
        key_gameobject.SetActive(true);
    }
    
}
