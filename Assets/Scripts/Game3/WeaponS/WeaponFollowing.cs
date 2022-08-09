using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollowing : MonoBehaviour
{
    
    public PlayerMovement player_move;
    public float rotationZ;
    void Start()
    {
        player_move = GameController3.player.GetComponent<PlayerMovement>();
    }
    void Update()
    {
        RotateWeapon();
        weaponFollowPlayer();
    }
    void RotateWeapon()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (rotationZ >= -60 && rotationZ <= 60)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
        else if (((rotationZ <= -120 && rotationZ >= -180) || (rotationZ >= 130 && rotationZ <= 180)))
        {
            transform.rotation = Quaternion.Euler(180, 0, -rotationZ);
        }


    }
    void weaponFollowPlayer()
    {
        if (rotationZ >= -60 && rotationZ <= 60)
            {
                transform.position = new Vector3(GameController3.player.transform.position.x + 0.5f, GameController3.player.transform.position.y, GameController3.player.transform.position.z);
            }
            else if ((rotationZ <= -120 && rotationZ >= -180) || (rotationZ >= 130 && rotationZ <= 180))
            {
                transform.position = new Vector3(GameController3.player.transform.position.x - 0.5f, GameController3.player.transform.position.y, GameController3.player.transform.position.z);
            }

    }
}
