using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFill : MonoBehaviour
{
    public Camera bookCam;
    // Start is called before the first frame update
    void Start()
    {
        float h = Mathf.Tan(bookCam.fieldOfView * Mathf.Deg2Rad * 0.5f) * 1 * 2f;

        transform.localScale = new Vector3(h * bookCam.aspect, 1f, h);

        if (gameObject.name == "lPage")
        {
            transform.localPosition -= new Vector3(h * bookCam.aspect * 10, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}