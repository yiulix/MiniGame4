using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int id = 0;
    public mCharacter c;
    public Vector3 originPos;
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

        originPos = transform.position;
    }

    void Update()
    {
        transform.localScale = new Vector3((float)c.health / 100, 1, 1);
        transform.position = originPos - new Vector3((float)(Mathf.Max(0, 100-c.health)) * 0.75f, 0, 0);
    }
}
