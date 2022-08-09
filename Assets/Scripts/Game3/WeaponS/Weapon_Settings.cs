using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Settings : MonoBehaviour { }

public class WeaponSettings
{
    protected int dmg, range,ammo;
    protected float cooldown;
    protected int bullets_per_shot;
    public WeaponSettings(int m_dmg,float m_cooldown,int m_range,int m_ammo,int m_bullets_per_shot)
    {
        dmg = m_dmg;
        cooldown = m_cooldown;
        range = m_range;
        ammo = m_ammo;
        bullets_per_shot = m_bullets_per_shot;
    }
    public int _dmg
    {
        get { return dmg; }
        set { dmg = value; }
    }
    public float _cooldown
    {
        get { return cooldown;}
        set { cooldown = value; }
    }
    public int _range
    {
        get { return range; }
        set { range = value; }
    }
    public int _ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }
    public int _bullets_per_shot
    {
        get { return bullets_per_shot; }
        set { bullets_per_shot = value; }
    }
    
    public int Reload()
    {
        return this._ammo;
    }
}


