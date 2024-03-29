﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Do initialization here
public class GameStartScene : MonoBehaviour
{
    public PageManager pm;
    public mCharacter c0;
    public mCharacter c1;
    public mCharacter c2;
    public GameObject textImg;
    public GameObject btn1;
    public GameObject btn2;
    public static bool T30;
    public static bool T60;

    public GameObject audioS;
    float tStamp = 10000;

    bool acted = false;

    // Start is called before the first frame update
    void Start()
    {
        c0 = GameObject.Find("c0").GetComponent<mCharacter>();
        c1 = GameObject.Find("c1").GetComponent<mCharacter>();
        c2 = GameObject.Find("c2").GetComponent<mCharacter>();
        DontDestroyOnLoad(c0.gameObject);
        DontDestroyOnLoad(c1.gameObject);
        DontDestroyOnLoad(c2.gameObject);
        DontDestroyOnLoad(audioS);
        T30 = true;
        T60 = true;
        SelectPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time - tStamp);
        //initialize characters
        c0.Init(0, "师兄", 100, 25, 7, 3);
        c1.Init(1, "师姐", 100, 25, 7, 1);
        c2.Init(2, "师妹", 100, 25, 7, 15);

        if  (Time.time - tStamp > 6 && !acted)
        {
            pm.Act("SelectDoor");
            textImg.SetActive(false);
            acted = true;
        }

        if (Time.time - tStamp < 2)
        {
            textImg.GetComponent<Image>().color = Vector4.Lerp(new Vector4(1, 1, 1, 0), new Vector4(1, 1, 1, 1), (Time.time - tStamp));
        }


        if (Time.time - tStamp > 5f && Time.time - tStamp < 6f)
        {
            textImg.GetComponent<Image>().color = Vector4.Lerp(new Vector4(1, 1, 1, 1), new Vector4(1, 1, 1, 0), (Time.time - tStamp - 7.5f));
        }
    }

    void SelectPlayer()
    {
        float r = Random.value;
        if (r < 0.33f)
        {
            c0.isPlayer = true;
            GameData.whoIsPlayer = 0;
        }
        else if (r < 0.67f)
        {
            c1.isPlayer = true;
            GameData.whoIsPlayer = 1;
        }
        else
        {
            c2.isPlayer = true;
            GameData.whoIsPlayer = 2;
        }
    }

    public void NextScene()
    {
        tStamp = Time.time;
        btn1.SetActive(false);
        btn2.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
