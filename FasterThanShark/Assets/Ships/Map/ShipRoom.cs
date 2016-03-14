using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipRoom {

    public Engine engine;
    public List<ShipCell> cells = new List<ShipCell>();
    public Vector3 roomPosition;

    // 2 cell room
    public ShipRoom(int size, Engine _engine, Vector3 _cell1, Vector3 _cell2)
    {
        cells.Clear();
        cells.Add(new ShipCell(_cell1, null, null));
        cells.Add(new ShipCell(_cell2, null, null));
        engine = _engine;
    }
    public ShipRoom(int size, Engine _engine, Vector3 _cell1, Vector3 _cell2, Vector3 roomPos)
    {
        roomPosition = roomPos;
        cells.Clear();
        cells.Add(new ShipCell(_cell1, null, null));
        cells.Add(new ShipCell(_cell2, null, null));
        engine = _engine;
    }
    // 4 cell Room
    public ShipRoom(int size, Engine _engine, Vector3 _cell1, Vector3 _cell2, Vector3 _cell3, Vector3 _cell4)
    {
        cells.Clear();
        cells.Add(new ShipCell(_cell1, null, null));
        cells.Add(new ShipCell(_cell2, null, null));
        cells.Add(new ShipCell(_cell3, null, null));
        cells.Add(new ShipCell(_cell4, null, null));
        engine = _engine;
    }
    public ShipRoom(int size, Engine _engine, Vector3 _cell1, Vector3 _cell2, Vector3 _cell3, Vector3 _cell4, Vector3 roomPos)
    {
        roomPosition = roomPos;
        cells.Clear();
        cells.Add(new ShipCell(_cell1, null, null));
        cells.Add(new ShipCell(_cell2, null, null));
        cells.Add(new ShipCell(_cell3, null, null));
        cells.Add(new ShipCell(_cell4, null, null));
        engine = _engine;
    }
}
