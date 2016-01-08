using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour  {

	public Map_Ship01 worldMap;
	public Node currentNode;
	public List<Node> AllNodes = new List<Node>();
	public List<Node> OpenL = new List<Node>();
	public List<Node> CloseL = new List<Node>();

	// Tableaux représentant la map.
	// Toute modification de la map devra etre répercutée ici
	// Ici : Map de 15 * 10;
	Node[][] nodesArrayXY = new Node[15][];
	Door[][] doorArrayX = new Door[15][];
	Door[][] doorArrayY = new Door[15][];



	// Use this for initialization
	void Start () 
	{
		// Chargement de la map dans les tableaux
		nodesArrayXY[0] = new Node[10] 	{ worldMap.a1, 		worldMap.b1, 	worldMap.c1, 	worldMap.d1, 	worldMap.e1,	worldMap.f1, 		worldMap.g1, 	worldMap.h1, 	worldMap.i1, 	worldMap.j1 };
		nodesArrayXY[1] = new Node[10] 	{ worldMap.a2, 		worldMap.b2, 	worldMap.c2, 	worldMap.d2, 	worldMap.e2,	worldMap.f2, 		worldMap.g2, 	worldMap.h2, 	worldMap.i2, 	worldMap.j2 };
		nodesArrayXY[2] = new Node[10] 	{ worldMap.a3, 		worldMap.b3, 	worldMap.c3, 	worldMap.d3, 	worldMap.e3,	worldMap.f3, 		worldMap.g3, 	worldMap.h3, 	worldMap.i3, 	worldMap.j3 };
		nodesArrayXY[3] = new Node[10] 	{ worldMap.a4, 		worldMap.b4, 	worldMap.c4, 	worldMap.d4, 	worldMap.e4,	worldMap.f4, 		worldMap.g4, 	worldMap.h4, 	worldMap.i4, 	worldMap.j4 };
		nodesArrayXY[4] = new Node[10] 	{ worldMap.a5, 		worldMap.b5, 	worldMap.c5, 	worldMap.d5, 	worldMap.e5,	worldMap.f5, 		worldMap.g5, 	worldMap.h5, 	worldMap.i5, 	worldMap.j5 };
		nodesArrayXY[5] = new Node[10] 	{ worldMap.a6, 		worldMap.b6, 	worldMap.c6, 	worldMap.d6, 	worldMap.e6,	worldMap.f6, 		worldMap.g6, 	worldMap.h6, 	worldMap.i6, 	worldMap.j6 };
		nodesArrayXY[6] = new Node[10] 	{ worldMap.a7, 		worldMap.b7, 	worldMap.c7, 	worldMap.d7, 	worldMap.e7,	worldMap.f7, 		worldMap.g7, 	worldMap.h7, 	worldMap.i7, 	worldMap.j7 };
		nodesArrayXY[7] = new Node[10] 	{ worldMap.a8, 		worldMap.b8, 	worldMap.c8, 	worldMap.d8, 	worldMap.e8,	worldMap.f8, 		worldMap.g8, 	worldMap.h8, 	worldMap.i8, 	worldMap.j8 };
		nodesArrayXY[8] = new Node[10] 	{ worldMap.a9, 		worldMap.b9, 	worldMap.c9, 	worldMap.d9, 	worldMap.e9,	worldMap.f9, 		worldMap.g9, 	worldMap.h9, 	worldMap.i9, 	worldMap.j9 };
		nodesArrayXY[9] = new Node[10] 	{ worldMap.a10, 	worldMap.b10, 	worldMap.c10, 	worldMap.d10, 	worldMap.e10,	worldMap.f10,	 	worldMap.g10, 	worldMap.h10, 	worldMap.i10, 	worldMap.j10 };
		nodesArrayXY[10] = new Node[10] { worldMap.a11, 	worldMap.b11, 	worldMap.c11, 	worldMap.d11, 	worldMap.e11,	worldMap.f11, 		worldMap.g11, 	worldMap.h11, 	worldMap.i11, 	worldMap.j11 };
		nodesArrayXY[11] = new Node[10] { worldMap.a12, 	worldMap.b12, 	worldMap.c12, 	worldMap.d12, 	worldMap.e12,	worldMap.f12, 		worldMap.g12, 	worldMap.h12, 	worldMap.i12, 	worldMap.j12 };
		nodesArrayXY[12] = new Node[10]	{ worldMap.a13, 	worldMap.b13, 	worldMap.c13, 	worldMap.d13, 	worldMap.e13,	worldMap.f13, 		worldMap.g13, 	worldMap.h13, 	worldMap.i13, 	worldMap.j13 };
		nodesArrayXY[13] = new Node[10] { worldMap.a14, 	worldMap.b14, 	worldMap.c14, 	worldMap.d14, 	worldMap.e14,	worldMap.f14, 		worldMap.g14, 	worldMap.h14, 	worldMap.i14, 	worldMap.j14 };
		nodesArrayXY[14] = new Node[10]	{ worldMap.a15, 	worldMap.b15, 	worldMap.c15, 	worldMap.d15, 	worldMap.e15,	worldMap.f15, 		worldMap.g15, 	worldMap.h15, 	worldMap.i15, 	worldMap.j15 };

		doorArrayX[0] = new Door[10] 	{ worldMap.dX_a1, 		worldMap.dX_b1, 	worldMap.dX_c1, 	worldMap.dX_d1, 	worldMap.dX_e1,		worldMap.dX_f1, 		worldMap.dX_g1, 	worldMap.dX_h1, 	worldMap.dX_i1, 	worldMap.dX_j1 };
		doorArrayX[1] = new Door[10] 	{ worldMap.dX_a2, 		worldMap.dX_b2, 	worldMap.dX_c2, 	worldMap.dX_d2, 	worldMap.dX_e2,		worldMap.dX_f2, 		worldMap.dX_g2, 	worldMap.dX_h2, 	worldMap.dX_i2, 	worldMap.dX_j2 };
		doorArrayX[2] = new Door[10] 	{ worldMap.dX_a3, 		worldMap.dX_b3, 	worldMap.dX_c3, 	worldMap.dX_d3, 	worldMap.dX_e3,		worldMap.dX_f3, 		worldMap.dX_g3, 	worldMap.dX_h3, 	worldMap.dX_i3, 	worldMap.dX_j3 };
		doorArrayX[3] = new Door[10] 	{ worldMap.dX_a4, 		worldMap.dX_b4, 	worldMap.dX_c4, 	worldMap.dX_d4, 	worldMap.dX_e4,		worldMap.dX_f4, 		worldMap.dX_g4, 	worldMap.dX_h4, 	worldMap.dX_i4, 	worldMap.dX_j4 };
		doorArrayX[4] = new Door[10] 	{ worldMap.dX_a5, 		worldMap.dX_b5, 	worldMap.dX_c5, 	worldMap.dX_d5, 	worldMap.dX_e5,		worldMap.dX_f5, 		worldMap.dX_g5, 	worldMap.dX_h5, 	worldMap.dX_i5, 	worldMap.dX_j5 };
		doorArrayX[5] = new Door[10] 	{ worldMap.dX_a6, 		worldMap.dX_b6, 	worldMap.dX_c6, 	worldMap.dX_d6, 	worldMap.dX_e6,		worldMap.dX_f6, 		worldMap.dX_g6, 	worldMap.dX_h6, 	worldMap.dX_i6, 	worldMap.dX_j6 };
		doorArrayX[6] = new Door[10] 	{ worldMap.dX_a7, 		worldMap.dX_b7, 	worldMap.dX_c7, 	worldMap.dX_d7, 	worldMap.dX_e7,		worldMap.dX_f7, 		worldMap.dX_g7, 	worldMap.dX_h7, 	worldMap.dX_i7, 	worldMap.dX_j7 };
		doorArrayX[7] = new Door[10] 	{ worldMap.dX_a8, 		worldMap.dX_b8, 	worldMap.dX_c8, 	worldMap.dX_d8, 	worldMap.dX_e8,		worldMap.dX_f8, 		worldMap.dX_g8, 	worldMap.dX_h8, 	worldMap.dX_i8, 	worldMap.dX_j8 };
		doorArrayX[8] = new Door[10] 	{ worldMap.dX_a9, 		worldMap.dX_b9, 	worldMap.dX_c9, 	worldMap.dX_d9, 	worldMap.dX_e9,		worldMap.dX_f9, 		worldMap.dX_g9, 	worldMap.dX_h9, 	worldMap.dX_i9, 	worldMap.dX_j9 };
		doorArrayX[9] = new Door[10] 	{ worldMap.dX_a10, 		worldMap.dX_b10, 	worldMap.dX_c10, 	worldMap.dX_d10, 	worldMap.dX_e10,	worldMap.dX_f10, 		worldMap.dX_g10, 	worldMap.dX_h10, 	worldMap.dX_i10, 	worldMap.dX_j10 };
		doorArrayX[10] = new Door[10] 	{ worldMap.dX_a11, 		worldMap.dX_b11, 	worldMap.dX_c11, 	worldMap.dX_d11, 	worldMap.dX_e11,	worldMap.dX_f11, 		worldMap.dX_g11, 	worldMap.dX_h11, 	worldMap.dX_i11, 	worldMap.dX_j11 };
		doorArrayX[11] = new Door[10] 	{ worldMap.dX_a12, 		worldMap.dX_b12, 	worldMap.dX_c12, 	worldMap.dX_d12, 	worldMap.dX_e12,	worldMap.dX_f12, 		worldMap.dX_g12, 	worldMap.dX_h12, 	worldMap.dX_i12, 	worldMap.dX_j12 };
		doorArrayX[12] = new Door[10]	{ worldMap.dX_a13, 		worldMap.dX_b13, 	worldMap.dX_c13, 	worldMap.dX_d13, 	worldMap.dX_e13,	worldMap.dX_f13, 		worldMap.dX_g13, 	worldMap.dX_h13, 	worldMap.dX_i13, 	worldMap.dX_j13 };
		doorArrayX[13] = new Door[10] 	{ worldMap.dX_a14, 		worldMap.dX_b14, 	worldMap.dX_c14, 	worldMap.dX_d14, 	worldMap.dX_e14,	worldMap.dX_f14, 		worldMap.dX_g14, 	worldMap.dX_h14, 	worldMap.dX_i14, 	worldMap.dX_j14 };
		doorArrayX[14] = new Door[10]	{ worldMap.dX_a15, 		worldMap.dX_b15, 	worldMap.dX_c15, 	worldMap.dX_d15, 	worldMap.dX_e15,	worldMap.dX_f15, 		worldMap.dX_g15, 	worldMap.dX_h15, 	worldMap.dX_i15, 	worldMap.dX_j15 };

		doorArrayY[0] = new Door[10] 	{ worldMap.dY_a1, 		worldMap.dY_b1, 	worldMap.dY_c1, 	worldMap.dY_d1, 	worldMap.dY_e1,		worldMap.dY_f1, 		worldMap.dY_g1, 	worldMap.dY_h1, 	worldMap.dY_i1, 	worldMap.dY_j1 };
		doorArrayY[1] = new Door[10] 	{ worldMap.dY_a2, 		worldMap.dY_b2, 	worldMap.dY_c2, 	worldMap.dY_d2, 	worldMap.dY_e2,		worldMap.dY_f2, 		worldMap.dY_g2, 	worldMap.dY_h2, 	worldMap.dY_i2, 	worldMap.dY_j2 };
		doorArrayY[2] = new Door[10] 	{ worldMap.dY_a3, 		worldMap.dY_b3, 	worldMap.dY_c3, 	worldMap.dY_d3, 	worldMap.dY_e3,		worldMap.dY_f3, 		worldMap.dY_g3, 	worldMap.dY_h3, 	worldMap.dY_i3, 	worldMap.dY_j3 };
		doorArrayY[3] = new Door[10] 	{ worldMap.dY_a4, 		worldMap.dY_b4, 	worldMap.dY_c4, 	worldMap.dY_d4, 	worldMap.dY_e4,		worldMap.dY_f4, 		worldMap.dY_g4, 	worldMap.dY_h4, 	worldMap.dY_i4, 	worldMap.dY_j4 };
		doorArrayY[4] = new Door[10] 	{ worldMap.dY_a5, 		worldMap.dY_b5, 	worldMap.dY_c5, 	worldMap.dY_d5, 	worldMap.dY_e5,		worldMap.dY_f5, 		worldMap.dY_g5, 	worldMap.dY_h5, 	worldMap.dY_i5, 	worldMap.dY_j5 };
		doorArrayY[5] = new Door[10] 	{ worldMap.dY_a6, 		worldMap.dY_b6, 	worldMap.dY_c6, 	worldMap.dY_d6, 	worldMap.dY_e6,		worldMap.dY_f6, 		worldMap.dY_g6, 	worldMap.dY_h6, 	worldMap.dY_i6, 	worldMap.dY_j6 };
		doorArrayY[6] = new Door[10] 	{ worldMap.dY_a7, 		worldMap.dY_b7, 	worldMap.dY_c7, 	worldMap.dY_d7, 	worldMap.dY_e7,		worldMap.dY_f7, 		worldMap.dY_g7, 	worldMap.dY_h7, 	worldMap.dY_i7, 	worldMap.dY_j7 };
		doorArrayY[7] = new Door[10] 	{ worldMap.dY_a8, 		worldMap.dY_b8, 	worldMap.dY_c8, 	worldMap.dY_d8, 	worldMap.dY_e8,		worldMap.dY_f8, 		worldMap.dY_g8, 	worldMap.dY_h8, 	worldMap.dY_i8, 	worldMap.dY_j8 };
		doorArrayY[8] = new Door[10] 	{ worldMap.dY_a9, 		worldMap.dY_b9, 	worldMap.dY_c9, 	worldMap.dY_d9, 	worldMap.dY_e9,		worldMap.dY_f9, 		worldMap.dY_g9, 	worldMap.dY_h9, 	worldMap.dY_i9, 	worldMap.dY_j9 };
		doorArrayY[9] = new Door[10] 	{ worldMap.dY_a10, 		worldMap.dY_b10, 	worldMap.dY_c10, 	worldMap.dY_d10, 	worldMap.dY_e10,	worldMap.dY_f10, 		worldMap.dY_g10, 	worldMap.dY_h10, 	worldMap.dY_i10, 	worldMap.dY_j10 };
		doorArrayY[10] = new Door[10] 	{ worldMap.dY_a11, 		worldMap.dY_b11, 	worldMap.dY_c11, 	worldMap.dY_d11, 	worldMap.dY_e11,	worldMap.dY_f11, 		worldMap.dY_g11, 	worldMap.dY_h11, 	worldMap.dY_i11, 	worldMap.dY_j11 };
		doorArrayY[11] = new Door[10] 	{ worldMap.dY_a12, 		worldMap.dY_b12, 	worldMap.dY_c12, 	worldMap.dY_d12, 	worldMap.dY_e12,	worldMap.dY_f12, 		worldMap.dY_g12, 	worldMap.dY_h12, 	worldMap.dY_i12, 	worldMap.dY_j12 };
		doorArrayY[12] = new Door[10]	{ worldMap.dY_a13, 		worldMap.dY_b13, 	worldMap.dY_c13, 	worldMap.dY_d13, 	worldMap.dY_e13,	worldMap.dY_f13, 		worldMap.dY_g13, 	worldMap.dY_h13, 	worldMap.dY_i13, 	worldMap.dY_j13 };
		doorArrayY[13] = new Door[10] 	{ worldMap.dY_a14, 		worldMap.dY_b14, 	worldMap.dY_c14, 	worldMap.dY_d14, 	worldMap.dY_e14,	worldMap.dY_f14, 		worldMap.dY_g14, 	worldMap.dY_h14, 	worldMap.dY_i14, 	worldMap.dY_j14 };
		doorArrayY[14] = new Door[10]	{ worldMap.dY_a15, 		worldMap.dY_b15, 	worldMap.dY_c15, 	worldMap.dY_d15, 	worldMap.dY_e15,	worldMap.dY_f15, 		worldMap.dY_g15, 	worldMap.dY_h15, 	worldMap.dY_i15, 	worldMap.dY_j15 };

		// Récupération de toutes les cases de la map.
		AllNodes.Add(worldMap.a0);
		AllNodes.Add(worldMap.a1);
		AllNodes.Add(worldMap.a2);
		AllNodes.Add(worldMap.a3);
		AllNodes.Add(worldMap.a4);
		AllNodes.Add(worldMap.a5);
		AllNodes.Add(worldMap.a6);
		AllNodes.Add(worldMap.a7);
		AllNodes.Add(worldMap.a8);
		AllNodes.Add(worldMap.a9);
		AllNodes.Add(worldMap.a10);
		AllNodes.Add(worldMap.a11);
		AllNodes.Add(worldMap.a12);
		AllNodes.Add(worldMap.a13);
		AllNodes.Add(worldMap.a14);
		AllNodes.Add(worldMap.a15);
		AllNodes.Add(worldMap.b1);
		AllNodes.Add(worldMap.b2);
		AllNodes.Add(worldMap.b3);
		AllNodes.Add(worldMap.b4);
		AllNodes.Add(worldMap.b5);
		AllNodes.Add(worldMap.b6);
		AllNodes.Add(worldMap.b7);
		AllNodes.Add(worldMap.b8);
		AllNodes.Add(worldMap.b9);
		AllNodes.Add(worldMap.b10);
		AllNodes.Add(worldMap.b11);
		AllNodes.Add(worldMap.b12);
		AllNodes.Add(worldMap.b13);
		AllNodes.Add(worldMap.b14);
		AllNodes.Add(worldMap.b15);
		AllNodes.Add(worldMap.c1);
		AllNodes.Add(worldMap.c2);
		AllNodes.Add(worldMap.c3);
		AllNodes.Add(worldMap.c4);
		AllNodes.Add(worldMap.c5);
		AllNodes.Add(worldMap.c6);
		AllNodes.Add(worldMap.c7);
		AllNodes.Add(worldMap.c8);
		AllNodes.Add(worldMap.c9);
		AllNodes.Add(worldMap.c10);
		AllNodes.Add(worldMap.c11);
		AllNodes.Add(worldMap.c12);
		AllNodes.Add(worldMap.c13);
		AllNodes.Add(worldMap.c14);
		AllNodes.Add(worldMap.c15);
		AllNodes.Add(worldMap.d1);
		AllNodes.Add(worldMap.d2);
		AllNodes.Add(worldMap.d3);
		AllNodes.Add(worldMap.d4);
		AllNodes.Add(worldMap.d5);
		AllNodes.Add(worldMap.d6);
		AllNodes.Add(worldMap.d7);
		AllNodes.Add(worldMap.d8);
		AllNodes.Add(worldMap.d9);
		AllNodes.Add(worldMap.d10);
		AllNodes.Add(worldMap.d11);
		AllNodes.Add(worldMap.d12);
		AllNodes.Add(worldMap.d13);
		AllNodes.Add(worldMap.d14);
		AllNodes.Add(worldMap.d15);
		AllNodes.Add(worldMap.e1);
		AllNodes.Add(worldMap.e2);
		AllNodes.Add(worldMap.e3);
		AllNodes.Add(worldMap.e4);
		AllNodes.Add(worldMap.e5);
		AllNodes.Add(worldMap.e6);
		AllNodes.Add(worldMap.e7);
		AllNodes.Add(worldMap.e8);
		AllNodes.Add(worldMap.e9);
		AllNodes.Add(worldMap.e10);
		AllNodes.Add(worldMap.e11);
		AllNodes.Add(worldMap.e12);
		AllNodes.Add(worldMap.e13);
		AllNodes.Add(worldMap.e14);
		AllNodes.Add(worldMap.e15);
		AllNodes.Add(worldMap.f1);
		AllNodes.Add(worldMap.f2);
		AllNodes.Add(worldMap.f3);
		AllNodes.Add(worldMap.f4);
		AllNodes.Add(worldMap.f5);
		AllNodes.Add(worldMap.f6);
		AllNodes.Add(worldMap.f7);
		AllNodes.Add(worldMap.f8);
		AllNodes.Add(worldMap.f9);
		AllNodes.Add(worldMap.f10);
		AllNodes.Add(worldMap.f11);
		AllNodes.Add(worldMap.f12);
		AllNodes.Add(worldMap.f13);
		AllNodes.Add(worldMap.f14);
		AllNodes.Add(worldMap.f15);
		AllNodes.Add(worldMap.g1);
		AllNodes.Add(worldMap.g2);
		AllNodes.Add(worldMap.g3);
		AllNodes.Add(worldMap.g4);
		AllNodes.Add(worldMap.g5);
		AllNodes.Add(worldMap.g6);
		AllNodes.Add(worldMap.g7);
		AllNodes.Add(worldMap.g8);
		AllNodes.Add(worldMap.g9);
		AllNodes.Add(worldMap.g10);
		AllNodes.Add(worldMap.g11);
		AllNodes.Add(worldMap.g12);
		AllNodes.Add(worldMap.g13);
		AllNodes.Add(worldMap.g14);
		AllNodes.Add(worldMap.g15);
		AllNodes.Add(worldMap.h1);
		AllNodes.Add(worldMap.h2);
		AllNodes.Add(worldMap.h3);
		AllNodes.Add(worldMap.h4);
		AllNodes.Add(worldMap.h5);
		AllNodes.Add(worldMap.h6);
		AllNodes.Add(worldMap.h7);
		AllNodes.Add(worldMap.h8);
		AllNodes.Add(worldMap.h9);
		AllNodes.Add(worldMap.h10);
		AllNodes.Add(worldMap.h11);
		AllNodes.Add(worldMap.h12);
		AllNodes.Add(worldMap.h13);
		AllNodes.Add(worldMap.h14);
		AllNodes.Add(worldMap.h15);
		AllNodes.Add(worldMap.i1);
		AllNodes.Add(worldMap.i2);
		AllNodes.Add(worldMap.i3);
		AllNodes.Add(worldMap.i4);
		AllNodes.Add(worldMap.i5);
		AllNodes.Add(worldMap.i6);
		AllNodes.Add(worldMap.i7);
		AllNodes.Add(worldMap.i8);
		AllNodes.Add(worldMap.i9);
		AllNodes.Add(worldMap.i10);
		AllNodes.Add(worldMap.i11);
		AllNodes.Add(worldMap.i12);
		AllNodes.Add(worldMap.i13);
		AllNodes.Add(worldMap.i14);
		AllNodes.Add(worldMap.i15);
		AllNodes.Add(worldMap.j1);
		AllNodes.Add(worldMap.j2);
		AllNodes.Add(worldMap.j3);
		AllNodes.Add(worldMap.j4);
		AllNodes.Add(worldMap.j5);
		AllNodes.Add(worldMap.j6);
		AllNodes.Add(worldMap.j7);
		AllNodes.Add(worldMap.j8);
		AllNodes.Add(worldMap.j9);
		AllNodes.Add(worldMap.j10);
		AllNodes.Add(worldMap.j11);
		AllNodes.Add(worldMap.j12);
		AllNodes.Add(worldMap.j13);
		AllNodes.Add(worldMap.j14);
		AllNodes.Add(worldMap.j15);
	}

	/// <summary>
	/// Converts the position to the corresponding Node.
	/// </summary>
	/// <returns>The Node with the corresponding position.</returns>
	/// <param name="posX">Position x.</param>
	/// <param name="posY">Position y.</param>
	Node ConvertPosToNode(int posX, int posY)
	{
		foreach(Node myNode in AllNodes)
		{
			if(myNode.posX == posX && myNode.posY == posY)
			{
				return myNode;
			}
		}
		return worldMap.a0;
	}
	/// <summary>
	/// Gets the node to go from the Given positions.
	/// </summary>
	/// <returns>The node to go (the first step of the path)</returns>
	/// <param name="startNodePosX">Start Node position x.</param>
	/// <param name="startNodePosY">Start Node position y.</param>
	/// <param name="endNodePosX">Destination Node position x.</param>
	/// <param name="endNodePosY">Final Destination Node position y.</param>
	public Node GetNodeToGo(int startNodePosX, int startNodePosY, int endNodePosX, int endNodePosY)
	{
		/*
		 * Algorithme de pathfinding de type A*
		 * Déplacement dans 4 directions : up,right,bottom,left ( pas de diagonales ) 
		 * Récupere toutes les cases de la map
		 * pour chaque case Initialise les valeurs de H,G,F
		 * H étant la distance de la case par rapport à la case d'arrivée
		 * G étant la distance de la case par rapport à la case de départ
		 * F étant H + G;
		 * Depuis la case de départ regarde toutes les cases adjacentes, et choisit la case avec la plus petite valeur de F.
		 * Rajoute la case en question à la liste des cases visitées et initialise sa case parente
		 * Répete l'opération jusqu'a trouver un chemin
		 * Retourne ensuite la premiere case du chemin trouvé
		 * En cas d'erreur retourne la case de la map par défaut : a0 (posX = -1, posY = -1, !walkable)
		 */
		Node startNode = ConvertPosToNode(startNodePosX, startNodePosY);	// Récupération du Node de départ
		Node endNode = ConvertPosToNode(endNodePosX,endNodePosY );			// Récupération du Node de destination
        if (startNode == endNode)
        {
            return startNode;
        }
		OpenL = new List<Node>();		// Liste des nodes à visiter
		CloseL = new List<Node>();		// Liste des nodes déjà visités
		int indexX = startNode.posX;	// Index du tableau
		int indexY = startNode.posY;	// Index du tableau
		worldMap.ResetMap();		// Reset de toutes les valeurs de la map.
		if(!startNode.walkable)		// Si la case de base n'est pas praticable;
		{
			return worldMap.a0;		// Renvoie le Node par défaut.
		}
		currentNode = startNode;	// Initialise le node courant
		currentNode.gValue = 0;		// Initialise la veleur de G du node courant
		currentNode.parentNode = currentNode;		// Initialise le Node parent (Au début le node de départ est son propre parent)
		foreach (Node x in AllNodes)				// Initialise les valeurs de H de toutes les cases de la map
		{
			x.hValue = Mathf.Abs(endNode.posX - x.posX) + Mathf.Abs(endNode.posY - x.posY);
		}

		int i = 0;										// pour eviter une potentielle boucle infinie
		while (i < 1000)								// Début de la boucle de pathfinding
		{
			i++;
			CloseL.Add(currentNode);					// Ajoute le node courant dans la ClosedList (cases visitées)

			// Ajoute toutes les cases valides adjacentes aux Nodes potentiels (OpenList).
			// Cas particulier pour chaque direction
			// Prends en compte les portes
			if( (indexY + 1 < 10))
			{
				if((!CloseL.Contains(nodesArrayXY[indexX][indexY + 1])) && (!OpenL.Contains(nodesArrayXY[indexX][indexY + 1])) && nodesArrayXY[indexX][indexY + 1].walkable)
				{
					if(doorArrayY[indexX][indexY].open == true)
					{
						OpenL.Add(nodesArrayXY[indexX][indexY + 1]);
					}
				}
			}
			if( !(indexX + 1 > 14))
			{
				if((!CloseL.Contains(nodesArrayXY[indexX + 1][indexY])) && (!OpenL.Contains(nodesArrayXY[indexX + 1][indexY])) && nodesArrayXY[indexX + 1][indexY].walkable)
				{
					if(doorArrayX[indexX][indexY].open == true)
					{
						OpenL.Add(nodesArrayXY[indexX + 1][indexY]);
					}
				}
			}
			if( !(indexY - 1 < 0))
			{
				if((!CloseL.Contains(nodesArrayXY[indexX][indexY - 1])) && (!OpenL.Contains(nodesArrayXY[indexX][indexY - 1])) && nodesArrayXY[indexX][indexY - 1].walkable)
				{
					if(doorArrayY[indexX][indexY - 1].open == true)
					{
						OpenL.Add(nodesArrayXY[indexX][indexY - 1]);
					}
				}
			}
			if( !(indexX - 1 < 0))
			{
				if((!CloseL.Contains(nodesArrayXY[indexX - 1][indexY])) && (!OpenL.Contains(nodesArrayXY[indexX - 1][indexY])) && nodesArrayXY[indexX - 1][indexY].walkable)
				{
					if(doorArrayX[indexX - 1][indexY].open == true)
					{
						OpenL.Add(nodesArrayXY[indexX - 1][indexY]);
					}
				}
			}
			if(OpenL.Count <= 0)		// Si aucunes cases adjacentes possibles return (Si le chemin est bloqué)
			{
				return worldMap.a0;
			}
			foreach (Node y in OpenL)					// Pour chaque node à visiter, initialise la G et F value ainsi que le node parent
			{
				y.parentNode = GetParentNode(y, CloseL);	// Initialise un Node parent temporaire pour chaque case à visiter
				y.gValue = y.parentNode.gValue + 1;
				y.fValue = y.hValue + y.gValue;
			}
			currentNode = SortNodesByFValue(OpenL);		// Trouve le prochain node à visiter et l'initialise comme étant le node courant
			currentNode.parentNode = GetParentNode(currentNode, CloseL);	// Initialise proprement le Node parent du Node courant
			indexX = currentNode.posX;		// Rafraichissement des index
			indexY = currentNode.posY;
			OpenL.Remove(currentNode);		// Suppression du Node courant de l'OpenList
			if(!currentNode.walkable)		// Si le node courant n'est pas valide return (précaution pas forcément nécessaire) ;
			{
				return worldMap.a0;
			}
			if(currentNode.posX == endNode.posX && currentNode.posY == endNode.posY)	// Si le node courant est le node d'arrivée, fin;
			{
				int j = 0; // Pour eviter une boucle infinie
				// Remonte tous les parents du node d'arrivée pour trouver le node à parcourir adjacent au Node de départ
				while ((currentNode.parentNode.posY != startNode.posY || currentNode.parentNode.posX != startNode.posX) && j < 1000)
				{
					j++;
					currentNode = currentNode.parentNode;
				}
				return currentNode; // Renvoi le Node adjacent au Node de départ
			}
		}
		return worldMap.a0;
	}

	/// <summary>
	/// Gets the parent of the given Node.
	/// </summary>
	/// <returns>The parent Node.</returns>
	/// <param name="CurrentNode">Current node.</param>
	/// <param name="ClosedList">Closed list.</param>
	Node GetParentNode(Node CurrentNode, List<Node> ClosedList)
	{
		/*
		 * Regarde tous les Nodes visités adjacent au Node courant
		 * Si aucune porte n'est entre les deuxn ajoute ce Node à la liste des parents potentiels
		 * Si les parents potentiels sont plusieurs
		 * Récupere le Node parent potentiel ayant la valeur de G la plus petite ( le plus proche du point de départ )
		 * Return le Node parent choisi
		 */
		List<Node> tempList = new List<Node>();
		foreach(Node visitedNode in ClosedList)
		{
			if(visitedNode.posX == CurrentNode.posX && CurrentNode.posY == visitedNode.posY  - 1 && doorArrayY[CurrentNode.posX][CurrentNode.posY].open)
			{
				tempList.Add (visitedNode);
			}
			else if(visitedNode.posX - 1 == CurrentNode.posX && CurrentNode.posY == visitedNode.posY && doorArrayX[CurrentNode.posX][CurrentNode.posY].open)
			{
				tempList.Add (visitedNode);
			}
			else if(visitedNode.posX == CurrentNode.posX && CurrentNode.posY == visitedNode.posY + 1 && doorArrayY[CurrentNode.posX][CurrentNode.posY - 1].open)
			{
				tempList.Add (visitedNode);
			}
			else if(visitedNode.posX + 1 == CurrentNode.posX && CurrentNode.posY == visitedNode.posY && doorArrayX[CurrentNode.posX - 1][CurrentNode.posY].open)
			{
				tempList.Add (visitedNode);
			}
		}

		Node parentNode = worldMap.a0;
		if(tempList.Count > 1)
		{
			int Gvalue = 999;
			parentNode = worldMap.a0;
			foreach(Node a in tempList)
			{
				if(a.gValue < Gvalue)
				{
					parentNode = a;
				}
			}
		}
		else
		{
			parentNode = tempList[0];
		}
		return parentNode;
	}

	/// <summary>
	/// Sorts the nodes by F value.
	/// </summary>
	/// <returns>The nodes by F value.</returns>
	/// <param name="myListToSort">My list to sort.</param>
	Node SortNodesByFValue(List<Node> myListToSort)
	{
		Node minNode = new Node();
		int FValue;
		FValue = 9999;
		
		foreach( Node myNode in myListToSort )
		{
			if(myNode.fValue < FValue)
			{
				FValue = myNode.fValue;
				minNode = myNode;
			}

		}
		return minNode;
	}









}
