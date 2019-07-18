using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageManager : MonoBehaviour
{
    public RenderTexture rt;
    public GameObject bookCam;
    public GameObject page;
    public GameObject rPage;
    public GameObject lPage;

    public Texture2D rPageRt;

    public float tStamp;
    public bool isActing = false;
    bool enableR = false;


    string nextScene;
    Dictionary<string, string> rPageTex;
    // Start is called before the first frame update
    void Start()
    {
        rPageTex = new Dictionary<string, string>();
        rPageTex.Add("SelectDoor", "test");
        rPageTex.Add("Battle", "bg");
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableR && isActing && Time.time - tStamp > 0.05f)
        {
            rPage.SetActive(true);
            rPageRt = Resources.Load(rPageTex[nextScene]) as Texture2D;
            rPage.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rPageRt);
            enableR = true;
        }

        if (Time.time - tStamp > 8.5f && isActing)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void Act(string nScene)
    {
        isActing = true;
        nextScene = nScene;
        tStamp = Time.time;
        GameObject mainCam = GameObject.FindWithTag("MainCamera");
        mainCam.GetComponent<Camera>().targetTexture = rt;

        bookCam.SetActive(true);
        page.SetActive(true);
        lPage.SetActive(true);


    }
}
