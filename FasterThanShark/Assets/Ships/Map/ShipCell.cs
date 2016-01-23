using UnityEngine;
using System.Collections;

public class ShipCell {

    public Vector3 position;
    public GameObject crew;
    public GameObject enemy;
    public ShipCell(Vector3 _position, GameObject _crew, GameObject _enemy)
    {
        position = _position;
        crew = _crew;
        enemy = _enemy;
    }
}
