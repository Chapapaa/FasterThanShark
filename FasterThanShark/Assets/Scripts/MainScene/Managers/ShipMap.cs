using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMap : MonoBehaviour
{
    public List<ShipRoom> shipMap = new List<ShipRoom>();
    public List<ShipRoom> enemyShipMap = new List<ShipRoom>();

    void Start()
    {
        StartCoroutine(RefreshCharsPosCrt());
    }


    public void ResetEnemyShipMap()
    {
        enemyShipMap.Clear();
    }

    public ShipCell SetCharacterPosition(GameObject character, bool ally)
    {
        Vector3 target = character.transform.position;
        return SetCharacterPosition(character, ally, target);
    }
    public ShipCell SetCharacterPosition(GameObject character, bool ally, Vector3 targetPosition)
    {
        ShipRoom room = GetRoomByPos(targetPosition);
        if (room != null)
        {
            foreach(ShipCell cell in room.cells)
            {
                if (ally)
                {
                    if(cell.crew == null)
                    {
                        cell.crew = character;
                        return cell;
                    }
                }
                else
                {
                    if (cell.enemy == null)
                    {
                        cell.enemy = character;
                        return cell;
                    }
                }
            } 
        }
        return null;
    }
    public void RemoveCharacterPosition(GameObject character, bool ally)
    {
        foreach(ShipRoom room in shipMap)
        {
            foreach(ShipCell cell in room.cells)
            {
                if(ally)
                {
                    if(cell.crew == character)
                    {
                        cell.crew = null;
                        return;
                    }
                }
                else
                {
                    if (cell.enemy == character)
                    {
                        cell.enemy = null;
                        return;
                    }
                }
            }
        }
        foreach (ShipRoom room in enemyShipMap)
        {
            foreach (ShipCell cell in room.cells)
            {
                if (ally)
                {
                    if (cell.crew == character)
                    {
                        cell.crew = null;
                        return;
                    }
                }
                else
                {
                    if (cell.enemy == character)
                    {
                        cell.enemy = null;
                        return;
                    }
                }
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

    public ShipCell IsRoomEmpty(Vector3 targetPos, bool ally)
    {
        ShipRoom myRoom = GetRoomByPos(targetPos);
        foreach(ShipCell cell in myRoom.cells)
        {
            if(ally)
            {
                if (cell.crew == null)
                {
                    return cell;
                }
            }
            else
            {
                if(cell.enemy == null)
                {
                    return cell;
                }
            }
        }
        return null;
    }

    ShipCell GetCellByPos(Vector3 _position)
    {
        foreach(ShipRoom room in shipMap)
        {
            foreach (ShipCell cell in room.cells)
            {
                float distX = Mathf.Abs(cell.position.x - _position.x);
                float distY = Mathf.Abs(cell.position.y - _position.y);
                if (distX < 0.4f && distY < 0.4f)
                {
                    return cell;
                }
            }
        }
        foreach (ShipRoom room in enemyShipMap)
        {
            foreach (ShipCell cell in room.cells)
            {
                float distX = Mathf.Abs(cell.position.x - _position.x);
                float distY = Mathf.Abs(cell.position.y - _position.y);
                if (distX < 0.4f && distY < 0.4f)
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
            if(Vector3.Distance(room.roomPosition, _position) < 0.45f)
            {
                return room;
            }
            foreach(ShipCell cell in room.cells)
            {
                float distX = Mathf.Abs(cell.position.x - _position.x);
                float distY = Mathf.Abs(cell.position.y - _position.y);
                if(distX < 0.45f && distY < 0.45f)
                {
                    return room;
                }

            }
        }
        foreach (var room in enemyShipMap)
        {
            if (Vector3.Distance(room.roomPosition, _position) < 0.45f)
            {
                return room;
            }
            foreach (ShipCell cell in room.cells)
            {
                float distX = Mathf.Abs(cell.position.x - _position.x);
                float distY = Mathf.Abs(cell.position.y - _position.y);
                if (distX < 0.45f && distY < 0.45f)
                {
                    return room;
                }
            }
        }
        return null;
    }
    public Vector3 GetEnginePos(Engine.engineType engineType, bool isAlly)
    {
        if(isAlly)
        {
            foreach (ShipRoom room in shipMap)
            {
                if (room.engine.engine == engineType)
                {
                    return room.roomPosition;
                }
            }
        }
        else
        {
            foreach (ShipRoom room in enemyShipMap)
            {
                if (room.engine.engine == engineType)
                {
                    return room.roomPosition;
                }
            }
        }
        return Vector3.zero;
    }

    public ShipRoom GetRandomAllyRoom()
    {
        
        int randomNumber = Random.Range(0, shipMap.Count);
        return shipMap[randomNumber];
        
    }
    public ShipRoom GetRandomEnnemyRoom()
    {
        int randomNumber = Random.Range(0, enemyShipMap.Count);
        return enemyShipMap[randomNumber];
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

    

    IEnumerator RefreshCharsPosCrt()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            foreach(ShipRoom room in shipMap)
            {
                if(room.engine.engine != Engine.engineType.other)
                {
                    if(!room.engine.operated && room.cells[0].crew == null)
                    {
                        foreach(ShipCell cell in room.cells)
                        {
                            if(cell.crew != null)
                            {
                                CharacterManager charMng = cell.crew.GetComponent<CharacterManager>();
                                if(!charMng.isMoving && !charMng.isRepairing)
                                {
                                    cell.crew.GetComponent<PlayerMovement>().MoveToNode(room.roomPosition);
                                }
                            }
                        }
                    }
                }
            }
            foreach (ShipRoom room in enemyShipMap)
            {
                if (room.engine.engine != Engine.engineType.other)
                {
                    if (!room.engine.operated && room.cells[0].enemy == null)
                    {
                        foreach (ShipCell cell in room.cells)
                        {
                            if (cell.enemy != null)
                            {
                                CharacterManager charMng = cell.enemy.GetComponent<CharacterManager>();
                                if (!charMng.isMoving && !charMng.isRepairing)
                                {
                                    cell.enemy.GetComponent<PlayerMovement>().MoveToNode(room.roomPosition);
                                }

                            }
                        }
                    }
                }
            }

        }
    }

    void OnDrawGizmos()
    {
        foreach(ShipRoom room in shipMap)
        {
            foreach(ShipCell cell in room.cells)
            {
                if(cell.crew != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(cell.position, 0.2f);
                }
                if (cell.enemy != null)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(cell.position, 0.2f);
                }
            }
        }
        foreach (ShipRoom room in enemyShipMap)
        {
            foreach (ShipCell cell in room.cells)
            {
                if (cell.crew != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawSphere(cell.position, 0.2f);
                }
                if (cell.enemy != null)
                {
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(cell.position, 0.2f);
                }
            }
        }


    }
}



