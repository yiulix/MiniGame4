using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScene : MonoBehaviour
{
    public PageManager pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
    {
        pm.Act("SelectDoor");
    }
}
