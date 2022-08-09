using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterSpawner : MonoBehaviour
{
    [Header ("WAYPOINTS")]
    public List<Transform> points;
    [Header("MONSTER TYPES")]
    public List<GameObject> monsters;
    //  public GameObject tanky;
    //  public GameObject speedy;
    //  public GameObject standard;


    [Header("Parent for monsters")]
    public GameObject enemies;

    [Header("Displayers")]
    public GameObject enemies_left;
    public GameObject break_left;
    [Header("Phase1 Settings")]
    public int phase1;
    public float frequency1;
    
    [Header("Phase2 Settings")]
    public int phase2;
    public float frequency2;
    [Header("Phase 3 Settings")]
    public int phase3;
    public float frequency3;

    [Header("Break between phases")]
    public float breaktime;

    public static bool beaten1, beaten2, beaten3;
    bool beat1started = false, beat2started = false, beat3started = false;
    public static bool ready_for_next;

    private void Awake()
    {
        beaten1 = false;
        beaten2 = false;
        beaten3 = false;
        ready_for_next = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(beaten1==false && Time.timeScale == 1)
        {

            Phase(ph:phase1, fr:frequency1,range_enemies:0,br:breaktime);
            beaten1 = true;


        }
        if (beaten1 == true && beaten2 == false && ready_for_next == true && Time.timeScale == 1)
        {
            ready_for_next = false;

            Phase(ph: phase2, fr: frequency2, range_enemies: 1, br: breaktime);
            beaten2 = true;
        }
        if((beaten1 == true && beaten2 == true) && beaten3==false && ready_for_next == true && Time.timeScale == 1)
        {
            ready_for_next = false;
            Phase(ph: phase3, fr: frequency3, range_enemies: 2, br: 3f);
            beaten3 = true;
        }
        if(beaten1 ==true && beaten2 == true && beaten3==true && ready_for_next == true)
        {

        }
        
        
    }
    void Phase(int ph,float fr,int range_enemies,float br)
    {
        StartCoroutine(SpawningMonsters(ph, fr, range_enemies,br));
    }

    void SpawnMonster(List<GameObject> monsters,int range_enemies)
    {
        int position_index = Random.Range(0, points.Count);
        int monsters_index;

        if (range_enemies > 0)
        {
            monsters_index = Random.Range(0, range_enemies+1);
        }
        else
        {
            monsters_index = 0;
        }

        GameObject enemy =Instantiate(monsters[monsters_index], position: points[position_index].position, Quaternion.identity);
        enemy.transform.parent = enemies.transform;
        
    }
    IEnumerator SpawningMonsters(int amount,float frequency,int range_enemies, float br)
    {
        if (amount > 0)
        {
            enemies_left.SetActive(true);
            enemies_left.transform.GetChild(1).GetComponent<Text>().text = amount.ToString();
        }


        while (amount > 0) 
        { 
            //SPAWNMONSTER
            SpawnMonster(monsters, range_enemies);
            amount -= 1;
            enemies_left.transform.GetChild(1).GetComponent<Text>().text = amount.ToString();
            yield return new WaitForSecondsRealtime(frequency);
        }
        if (enemies.transform.childCount > 0)
        {
            yield return new WaitForSecondsRealtime(1);
        }
        if (enemies_left.activeSelf)
        {
            enemies_left.SetActive(false);

        }
    
        break_left.SetActive(true);
        while(br > 0)
        {
            br -= 1;
            break_left.transform.GetChild(0).GetComponent<Text>().text = br.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        break_left.SetActive(false);
        ready_for_next = true;
        yield return null;
        



    }
    IEnumerator BreakBetweenPhases(float breaktime, bool beaten)
    {
        


        yield return null;
        

    }
}
