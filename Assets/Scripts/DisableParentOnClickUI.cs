using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParentOnClickUI : MonoBehaviour
{
    public GameObject parent;
    public WeaponSelection weapon_selection;
    public string name_of_weapon;
    // Update is called once per frame
    public void DisableParent()
    {
        parent.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        weapon_selection.weapon_selected = name_of_weapon;

    }
}
