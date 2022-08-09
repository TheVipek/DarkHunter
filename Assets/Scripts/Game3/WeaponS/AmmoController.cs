using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoController : MonoBehaviour
{
    public GameObject max_child;
    public GameObject actual_child;
    public static int max_ammo_amount;
    public static int current_ammo_amount;
    private bool got_weapon = false;
    void Start()
    {

    }
    void Update()
    {
        if (GameController3.player.transform.childCount > 1 && got_weapon == false)
        {
            max_ammo_ui(max_ammo_amount);
            got_weapon = true;
        }
        if (got_weapon) {
            actual_ammo_ui(current_ammo_amount);
        }
            
    }

    public void max_ammo_ui(int max_value)
    {
        max_child.GetComponent<Text>().text = max_value.ToString();

    }
    public void actual_ammo_ui(int actual_value)
    {
        actual_child.GetComponent<Text>().text = actual_value.ToString();
    }
}
