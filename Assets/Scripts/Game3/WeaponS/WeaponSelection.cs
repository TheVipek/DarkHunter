using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public string weapon_selected;

    void Start()
    {
        
    }
    public void SpawnSelection(GameObject panel_to_respawn)
    {
        Time.timeScale = 0;
        if (!panel_to_respawn.activeSelf)
        {
            panel_to_respawn.SetActive(true);
        }
        
    }
    public void Selected()
    {
        Time.timeScale = 1;
    }
}
