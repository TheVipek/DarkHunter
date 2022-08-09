using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip teleport, hit, collect, laser, explode, shoot,
                            destroy, jump, dash, bip, shoot2, noAmmo, reload;

    static AudioSource audioSource;


    private void Start()
    {

        collect = Resources.Load<AudioClip>("collect");
        teleport = Resources.Load<AudioClip>("teleport");
        hit = Resources.Load<AudioClip>("hit");
        laser = Resources.Load<AudioClip>("laser");
        explode = Resources.Load<AudioClip>("explode");
        shoot = Resources.Load<AudioClip>("shoot");
        destroy = Resources.Load<AudioClip>("destroy");
        jump = Resources.Load<AudioClip>("jump");
        dash = Resources.Load<AudioClip>("dash");
        bip = Resources.Load<AudioClip>("bip");
        shoot2 = Resources.Load<AudioClip>("shoot2");
        noAmmo = Resources.Load<AudioClip>("noammo");
        reload = Resources.Load<AudioClip>("reload");

        
        audioSource = GetComponent<AudioSource>();

    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "collect":
                audioSource.PlayOneShot(collect);
                break;

            case "teleport":
                audioSource.PlayOneShot(teleport);
                break;

            case "hit":
                audioSource.PlayOneShot(hit);
                break;
            
            case "laser":
                audioSource.PlayOneShot(laser);
                break;
           
            case "explode":
                audioSource.PlayOneShot(explode);
                break;

            case "shoot":
                audioSource.PlayOneShot(shoot);
                break;

            case "destroy":
                audioSource.PlayOneShot(destroy);
                break;

            case "jump":
                audioSource.PlayOneShot(jump) ;
                break;

            case "dash":
                audioSource.PlayOneShot(dash);
                break;

            case "bip":
                audioSource.PlayOneShot(bip);
                break;

            case "noammo":
                audioSource.PlayOneShot(noAmmo);
                break;

            case "shoot2":
                audioSource.PlayOneShot(shoot2);
                break;

            case "reload":
                audioSource.PlayOneShot(reload);
                break;


        }
    }
}
