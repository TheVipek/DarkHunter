using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static WeaponSettings gun;
    void Awake()
    {
        gun = new WeaponSettings(40, 0.5f, 8, 16,1);
        AmmoController.max_ammo_amount = gun._ammo;
        AmmoController.current_ammo_amount = gun._ammo;
        Bullet.bullet_damage = gun._dmg;
        Bullet.bullet_range = gun._range;
    }
    void Start()
    {
    }
    void Update()
    {
        
    }
}
