using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Pathfinding pathfindingSCR;
	public int playerPositionX = 0;
	public int PlayerPositionY = 0;
	public float moveSpeed;
	public bool moving = false;
	bool activeCoroutine = false;
	Vector2 lastPosition = new Vector2(-1,-1);

	private IEnumerator myCoroutine;

	public void MoveToNode(int posX, int posY)
	{
		if(activeCoroutine)
		{
			StopCoroutine(myCoroutine);
			activeCoroutine = false;
		}
		myCoroutine = Move (posX, posY);
		StartCoroutine(myCoroutine);
	}


	IEnumerator Move(int posX, int posY)
	{
		/*
		 * Les Vector2 Représentent les cases du Pathfinding leurs valeurs sont donc ajustées pour correspondre à la grille de Nodes
		 * Les Vector3 représentent des position réelles des objets dans la scene leurs valeurs sont donc ajustées pour correspondre à la scene.
		 */
		moving = true;		// Permet de savoir si le personnage est en mouvement
		activeCoroutine = true;		// Permet de savoir si la coroutine est déjà en cours d'execution.
		while((transform.localPosition.x * 2) != posX || (transform.localPosition.y * 2)  != posY) // Tant que la position du personnage n'est pas égale à la destination finale voulue.
		{
			Node targetNode = pathfindingSCR.GetNodeToGo(playerPositionX,PlayerPositionY,posX,posY);	 // Node le plus proche à atteindre.				
			Vector2 targetNodePos = new Vector2(targetNode.posX, targetNode.posY);		 // Position du Node sur la grille du pathfinding
			Vector3 targetNodePosition = new Vector3((float)targetNodePos.x / 2,( float)targetNodePos.y / 2);		// Position du Node dans la scene
			Vector2 playerPos = new Vector2(transform.localPosition.x * 2, transform.localPosition.y * 2);		// Position du joueur sur la grille du pathfinding
			/*
			 * Si le Node le plus proche à atteindre n'est pas sur le meme axe en X ou Y que le joueur (dans la scene),
			 * OU que le Node à atteindre est le Node par défaut (WorldMap.a0 (posX = -1, posY = -1))
			 * ET que la derniere position du joueur sur le pathfinding est connue (au moins une case parcourue)
			 * (Cas particulier)
			 */
			if(((targetNodePos.x != playerPos.x && targetNodePos.y != playerPos.y)|| targetNode.posX == -1 ) && lastPosition.x != -1)
			{
				Vector3 lastPositionPos = new Vector3((float)lastPosition.x / 2, (float)lastPosition.y / 2); // Récupere la position dans la scene du dernier Node parcouru
				if(playerPos.x != lastPosition.x || playerPos.y != lastPosition.y ) // Si on a pas encore atteint la derniere position connus, se déplace vers elle.
				{
					playerPos.x = transform.localPosition.x * 2;
					playerPos.y = transform.localPosition.y * 2;
					lastPositionPos.z = transform.localPosition.z;	// ( permet de garder la position du joueur en Z )
					transform.localPosition = Vector3.MoveTowards(transform.localPosition, lastPositionPos ,moveSpeed); // se déplace vers la case.
				}
			}
			/*
			 * Si le Node le plus proche à atteindre est sur le meme axe en X ou Y que le joueur dans la scene.
			 * Déplacement vers le node à atteindre (targetNodePos)
			 * (Cas général)
			 */
			else if(playerPos != targetNodePos)
			{
				playerPos.x = transform.localPosition.x * 2;
				playerPos.y = transform.localPosition.y * 2;
				targetNodePosition.z = transform.localPosition.z;
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetNodePosition ,moveSpeed);
			}
			// Sinon c'est qu'on est arrivé à un node, on met donc a jour les infos de position
			else
			{
				playerPositionX = (int)targetNodePos.x;
				PlayerPositionY = (int)targetNodePos.y;
				lastPosition = new Vector2(playerPositionX,PlayerPositionY);
			}
			yield return new WaitForSeconds(0.01f);
		}
		moving = false;
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}
}
