using UnityEngine;

public class SelectDoorScene : MonoBehaviour
{
    public PageManager pgm;
    bool isSelecting = false;
    int type;
    public PlayerMove playerMove;
    bool acted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelecting && !playerMove.isMoving && !acted)
        {
            if (type == 0)
            {
                pgm.Act("Battle");

            }
            else if (type == 1)
            {
                pgm.Act("Iteam");
            }
            else
            {
                pgm.Act("Dialogue");
            }
            acted = true;
        }
    }

    // Decide what content is behind each door
    void GenerateDoors()
    {

    }

    public void SelectDoor(int dType)
    {
        playerMove.isMoving = true;
        isSelecting = true;
        type = dType;
    }
}
