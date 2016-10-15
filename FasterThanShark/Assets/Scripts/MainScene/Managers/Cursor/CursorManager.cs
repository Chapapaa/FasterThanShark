using UnityEngine;
using System.Collections;

public class CursorManager : MonoBehaviour {

    public Texture2D cursorDefaultTexture;
    public Texture2D cursorBattle1Texture;
    public Texture2D cursorBattle2Texture;
    public CursorMode cursorMode = CursorMode.Auto;
    Vector2 hotSpot = Vector2.zero;
    Vector2 hotSpot1 = Vector2.zero;
    Vector2 hotSpot2 = Vector2.zero;

    void Start()
    {
        hotSpot1 = new Vector2(cursorBattle1Texture.width / 2f, cursorBattle1Texture.height / 2f);
        hotSpot2 = new Vector2(cursorBattle2Texture.width / 2f, cursorBattle2Texture.height / 2f);
        ChangeCursor("default");
    }
    public void ChangeCursor(string _mode)
    {
        if (_mode == "default")
        {
            Cursor.SetCursor(cursorDefaultTexture, hotSpot, cursorMode);
        }
        else if (_mode == "battle1")
        {

            Cursor.SetCursor(cursorBattle1Texture, hotSpot1, cursorMode);
        }
        else if (_mode == "battle2")
        {
            Cursor.SetCursor(cursorBattle2Texture, hotSpot2, cursorMode);
        }
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    ChangeCursor("default");
        //}
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    ChangeCursor("battle1");
        //}
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    ChangeCursor("battle2");
        //}
        //Vector3 currentMouse = Input.mousePosition;
        //Ray ray = Camera.main.ScreenPointToRay(currentMouse);
        //RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        //Debug.DrawLine(ray.origin, hit.point);
    }
    
}
