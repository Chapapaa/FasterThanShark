using UnityEngine;
using System.Collections;

public class Door  {

	public bool open = true;
    public int posX;
    public int posY;

	public Door()
	{
		open = true;
	}
    
	public Door(bool _open)
	{
		open = _open;
	}

    public void _Init(bool _open, int _posX, int _posY)
    {
        open = _open;
        posX = _posX;
        posY = _posY;
    }
}
