using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{



}
public class MonsterB
{
    protected int hp,dmg;
    protected float speed;
    protected float attack_cooldown;
    protected bool isranged;
    protected float range;
    public MonsterB(int hpb,float speedb,int dmgb,float attack_cooldownb,bool israngedb,float rangeb)
    {
        hp = hpb;
        speed = speedb;
        dmg = dmgb;
        attack_cooldown = attack_cooldownb;
        isranged = israngedb;
        range = rangeb;
    }
    public int _hp
    {
        get { return hp; }
        set { hp = value; }
    }
    public float _speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public int _dmg
    {
        get { return dmg; }
        set { dmg = value; }
    }
    public float _attack_cooldown
    {
        get { return attack_cooldown; }
        set { attack_cooldown = value; }
    }
    public bool _isranged
    {
        get { return isranged; }
        set { isranged = value; }
    }
    public float _range
    {
        get { return range; }
        set { range = value; }
    }


    public void DealDamage(Collider2D player)
    {
        player.GetComponent<PlayerHealth>().TakeDamage(dmg);
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }


    
    public void FollowPlayer(Transform self_position,Transform target_position, float speed)
    {
        self_position.position = Vector2.MoveTowards(self_position.position, target_position.position, 1f*speed * Time.deltaTime);
        
    }
    
}
