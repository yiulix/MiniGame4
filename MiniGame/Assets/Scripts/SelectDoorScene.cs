using UnityEngine;

public class SelectDoorScene : MonoBehaviour
{
    public PageManager pgm;
    bool isSelecting = false;
    int doorID;
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
            pgm.Act("Battle");
            acted = true;
        }
    }

    // Decide what content is behind each door
    void GenerateDoors()
    {

    }

    public void SelectDoor(int id)
    {
        playerMove.isMoving = true;
        isSelecting = true;
        doorID = id;
    }
}
