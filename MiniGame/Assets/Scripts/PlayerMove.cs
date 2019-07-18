using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 targetPos;
    public float moveSpd = 1;
    float moveDuration;
    float tStamp;
    Vector3 startPos;
    public bool isMoving = false;

    public Sprite[] qs;

    Sprite tL;
    Sprite tR;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        SetTexture();
        GetComponent<SpriteRenderer>().sprite = tL;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane p = new Plane(new Vector3(0, 0, -1), 0);
            float enter;
            if (p.Raycast(ray, out enter))
            {
                Vector3 pos = ray.GetPoint(enter);
                if (pos.y > 2)
                {
                    pos = new Vector3(pos.x, 2, pos.z);
                }

                if (pos.x > -7 || pos.y < 2)
                {
                    targetPos = pos;
                    startPos = transform.position;
                    animator.SetBool("isMoving", true);
                    isMoving = true;
                    moveDuration = Vector3.Magnitude(targetPos - transform.position) / moveSpd;
                    tStamp = Time.time;
                }

            }

        }

        if (Time.time - tStamp < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, (Time.time - tStamp) / moveDuration);
            if (targetPos.x <= startPos.x)
            {
                GetComponent<SpriteRenderer>().sprite = tL;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = tR;
            }
        }

        else
        {
            animator.SetBool("isMoving", false);
            isMoving = false;
        }


    }

    void SetTexture ()
    {
        if (GameData.whoIsPlayer == 0)
        {
            tL = qs[0];
            tR = qs[1];
        }
        if (GameData.whoIsPlayer == 1)
        {
            tL = qs[2];
            tR = qs[3];
        }
        if (GameData.whoIsPlayer == 2)
        {
            tL = qs[4];
            tR = qs[5];
        }
    }
}
