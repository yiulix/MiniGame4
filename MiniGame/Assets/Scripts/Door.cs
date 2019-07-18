using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SelectDoorScene selectDoorScene;
    public int id;
    public int type = -1;
    // Start is called before the first frame update
    void Start()
    {
        float r = Random.value;
        if (r < 0.31f)
        {
            type = 0;
            
        }
        else if (r < 0.54f)
        {
            type = 1;
        }
        else
        {
            type = 2;
        }
        Debug.Log("door " + id + ", type " + type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        selectDoorScene.SelectDoor(type);
    }
}
