using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Do initialization here
public class GameStartScene : MonoBehaviour
{
    public PageManager pm;
    public mCharacter c0;
    public mCharacter c1;
    public mCharacter c2;



    // Start is called before the first frame update
    void Start()
    {
        c0 = GameObject.Find("c0").GetComponent<mCharacter>();
        c1 = GameObject.Find("c1").GetComponent<mCharacter>();
        c2 = GameObject.Find("c2").GetComponent<mCharacter>();
        DontDestroyOnLoad(c0.gameObject);
        DontDestroyOnLoad(c1.gameObject);
        DontDestroyOnLoad(c2.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        //initialize characters
        c0.Init(0, "师兄", 100, 10, 10, 2);
        c1.Init(1, "师姐", 100, 10, 10, 2);
        c2.Init(2, "师妹", 100, 10, 10, 15);
    }

    public void NextScene()
    {
        pm.Act("SelectDoor");
    }
}
