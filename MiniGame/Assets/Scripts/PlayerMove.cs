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

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
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
                targetPos = ray.GetPoint(enter);
                startPos = transform.position;
                animator.SetBool("isMoving", true);
                isMoving = true;
                moveDuration = Vector3.Magnitude(targetPos - transform.position) / moveSpd;
                tStamp = Time.time;

            }

        }

        if (Time.time - tStamp < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, (Time.time - tStamp) / moveDuration);
        }

        else
        {
            animator.SetBool("isMoving", false);
            isMoving = false;
        }


    }
}
