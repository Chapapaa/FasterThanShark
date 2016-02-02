using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMap : MonoBehaviour
{
    public List<ShipRoom> shipMap = new List<ShipRoom>();
    public List<ShipRoom> enemyShipMap = new List<ShipRoom>();

    public void SetCharacterPosition(GameObject character, bool ally)
    {
        Vector3 charPos = character.transform.position;
        ShipCell cell = GetCellByPos(charPos);
        if (cell != null)
        {
            if(ally)
            {
                cell.crew = character;
            }
            else
            {
                cell.enemy = character;
            }
        }
    }
    public void SetCharacterPosition(GameObject character, bool ally, Vector3 targetPosition)
    {
        Vector3 charPos = targetPosition;
        ShipCell cell = GetCellByPos(charPos);
        if (cell != null)
        {
            if (ally)
            {
                cell.crew = character;
            }
            else
            {
                cell.enemy = character;
            }
        }
    }
    public void RemoveCharacterPosition(GameObject character, bool ally)
    {
        Vector3 charPos = character.transform.position;
        ShipCell cell = GetCellByPos(charPos);
        if (cell != null)
        {
            if (ally)
            {
                cell.crew = null;
            }
            else
            {
                cell.enemy = null;
            }
        }
    }
    public void RemoveCharacterPosition(GameObject character, bool ally, Vector3 targetPosition)
    {
        Vector3 charPos = targetPosition;
        ShipCell cell = GetCellByPos(charPos);
        if (cell != null)
        {
            if (ally)
            {
                cell.crew = null;
            }
            else
            {
                cell.enemy = null;
            }
        }
    }

    ShipCell GetCellByPos(Vector3 _position)
    {
        foreach(var room in shipMap)
        {
            foreach (var cell in room.cells)
            {
                float dist = Vector3.Distance(cell.position, _position);
                if (dist < 0.5f)
                {
                    return cell;
                }
            }
        }
        foreach (var room in enemyShipMap)
        {
            foreach (var cell in room.cells)
            {
                float dist = Vector3.Distance(cell.position, _position);
                if (dist < 0.5f)
                {
                    return cell;
                }
            }
        }
        return null;
    }


}



