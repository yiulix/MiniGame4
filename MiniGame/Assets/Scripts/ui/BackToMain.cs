using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMain : MonoBehaviour
{

    public PageManager pgm;
    // Start is called before the first frame update
    void Start()
    {
        pgm = GameObject.Find("PageManager").GetComponent<PageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        if (GameObject.Find("BattleAudio"))
        {
            GameObject.Find("BattleAudio").SetActive(false);
            GameObject.Find("Audio").SetActive(true);
        }

        pgm.Act("GameStart");
    }
}
