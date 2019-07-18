using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseUI : MonoBehaviour
{
    public int id = 0;
    public mCharacter c;
    // Start is called before the first frame update
    void Start()
    {
        if (id == 0)
        {
            c = GameObject.Find("c0").GetComponent<mCharacter>();
        }
        if (id == 1)
        {
            c = GameObject.Find("c1").GetComponent<mCharacter>();
        }
        if (id == 2)
        {
            c = GameObject.Find("c2").GetComponent<mCharacter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = c.defense.ToString();
    }
}
