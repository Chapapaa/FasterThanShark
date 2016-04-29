using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMap : MonoBehaviour
{
    public List<ShipRoom> shipMap = new List<ShipRoom>();
    public List<ShipRoom> enemyShipMap = new List<ShipRoom>();

    public void ResetEnemyShipMap()
    {
        enemyShipMap.Clear();
    }

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

    public ShipRoom GetRoomByPos(Vector3 _position)
    {
        foreach (var room in shipMap)
        {
            foreach (var cell in room.cells)
            {
                float dist = Vector3.Distance(cell.position, _position);
                if (dist < 0.9f)
                {
                    return room;
                }
            }
        }
        foreach (var room in enemyShipMap)
        {
            foreach (var cell in room.cells)
            {
                float dist = Vector3.Distance(cell.position, _position);
                if (dist < 0.9f)
                {
                    return room;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapIndex">0 for ally, 1 for enemy</param>
    public ShipRoom GetRandomAllyRoom()
    {
        
        int randomNumber = Random.Range(0, shipMap.Count);
        return shipMap[randomNumber];
        
    }

    public void DestroyChar(GameObject character)
    {
        foreach (ShipRoom room in shipMap)
        {
            foreach(ShipCell cell in room.cells)
            {
                if(cell.crew == character)
                {
                    cell.crew = null;
                    return;
                }
                if (cell.enemy == character)
                {
                    cell.enemy = null;
                    return;
                }
            }
        }
        foreach (ShipRoom room in enemyShipMap)
        {
            foreach (ShipCell cell in room.cells)
            {
                if (cell.crew == character)
                {
                    cell.crew = null;
                    return;
                }
                if (cell.enemy == character)
                {
                    cell.enemy = null;
                    return;
                }
            }
        }
    }

}



