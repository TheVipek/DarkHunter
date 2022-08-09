using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController3 : MonoBehaviour
{
    [Header("Instruction")]
    [SerializeField]
    GameObject instruction;
    [Header ("PanelToSetActive")]
    [SerializeField]
    GameObject panel;
    [Header("Enemies left text")]
    [SerializeField]
    GameObject counter;
    [Header ("Weapons to select")]
    [SerializeField]
    GameObject gun, shotgun, rifle;
    [Header ("Position stuff")]
    [Header ("Player position")]
    [SerializeField]
    public static GameObject player;

    public bool isweaponused = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        gameObject.GetComponent<WeaponSelection>().SpawnSelection(panel);

    }
    void Start()
    {
        // CALL WEAPON SELECTION 

    }

    void Update()
    {
        
        if(isweaponused == false && string.IsNullOrEmpty(GetComponent<WeaponSelection>().weapon_selected) != true)
        {
            if(GetComponent<WeaponSelection>().weapon_selected == "revolver")
            {
                var weapon = Instantiate(original: gun, parent:player.transform);
                weapon.name = gun.name;
                
            }
            else if(GetComponent<WeaponSelection>().weapon_selected == "rifle")
            {
                var weapon = Instantiate(original: rifle, parent: player.transform);
                weapon.name = rifle.name;
            }
            else if(GetComponent<WeaponSelection>().weapon_selected == "shotgun")
            {var weapon = Instantiate(original: shotgun, parent: player.transform);
                weapon.name = shotgun.name;
             }
            isweaponused = true;
        }
      /*  if(isweaponused ==true && first_instruction == true)
        {
            StartCoroutine(showing_time());
            first_instruction = false;
        }*/

    }
    IEnumerator showing_time()
    {
        instruction.SetActive(true);
        yield return new WaitForSeconds(3); 
        instruction.SetActive(false);
        yield return null;

    }
}
