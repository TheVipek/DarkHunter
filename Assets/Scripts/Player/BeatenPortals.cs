using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatenPortals : MonoBehaviour
{
    private GameObject[] instances;
    public Dictionary<string, bool> Portals = new Dictionary<string, bool>
    {
        {"Barrier1",false },
        {"Barrier2",false },
        {"Barrier3",false }
    };
    private void Awake()
    {

    }
    void Start()
    {
        instances = GameObject.FindGameObjectsWithTag("stagebarrier");
        if(instances.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
