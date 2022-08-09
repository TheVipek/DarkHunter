using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public static WeaponSettings rifle;
    void Awake()
    {
        rifle = new WeaponSettings(4, 0.15f, 15, 30,1);
        AmmoController.max_ammo_amount = rifle._ammo;
        AmmoController.current_ammo_amount = rifle._ammo;
        Bullet.bullet_damage = rifle._dmg;
        Bullet.bullet_range = rifle._range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
