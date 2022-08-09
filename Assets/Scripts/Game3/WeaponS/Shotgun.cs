using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public static WeaponSettings shotgun;
    void Awake()
    {
        shotgun = new WeaponSettings(25, 1.5f, 4, 12,4);
        AmmoController.max_ammo_amount = shotgun._ammo;
        AmmoController.current_ammo_amount = shotgun._ammo;
        Bullet.bullet_damage = shotgun._dmg;
        Bullet.bullet_range = shotgun._range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
