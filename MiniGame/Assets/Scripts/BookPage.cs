using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookPage : MonoBehaviour
{
    //material of the page object
    private Material m_Material;
    public GameObject bookCam;
    float tStamp;
    bool stage2 = false;
    bool stage3 = false;
    public PageManager pm;

    void Start()
    {
        tStamp = Time.time;
        m_Material = GetComponent<MeshRenderer>().material;
        bookCam.transform.DORotate(new Vector3(-23, 0, 0), 3);
        bookCam.transform.DOLocalMove(new Vector3(0, -3, -14), 3);
        {
            m_Material.SetFloat("_Angle", 0);
            m_Material.DOFloat(10, "_Angle", 0.3f);
        }
    }


    void Update()
    {

        if (Time.time - tStamp > 3 && stage2 == false)
        {
            stage2 = true;
            m_Material.SetFloat("_Angle", 10);
            m_Material.DOFloat(180, "_Angle", 3);

        }
        if (Time.time - tStamp > 6 && stage3 == false)
        {
            stage3 = true;
            bookCam.transform.DORotate(new Vector3(0, 0, 0), 1.5f);
            bookCam.transform.DOLocalMove(new Vector3(0, 0, -10), 1.5f);

        }
    }
}
