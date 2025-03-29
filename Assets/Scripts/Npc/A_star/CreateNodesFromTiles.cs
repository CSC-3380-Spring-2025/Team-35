using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateNodesFromTiles : MonoBehaviour
{

    public Grid gridbase;
    public Tilemap ground;
    public List<Tilemap> obstacleLayers;
    public GameObject nodePrefab;

    // bounds of where we search for tiles    
    public int scanStartX = -250, scanStartY = -250, scanFinishX = 250, scanFinishY = 250;

    public List<GameObject> unsortedNodes;
    public GameObject[,] nodes; // 2d array for sorted nodes, may contain null entries if the map is of uneven shape, ie has gaps

    public int gridBoundX = 0, gridBoundY = 0;
    void Awake()
    {
     unsortedNodes = new List<GameObject>();  
     GenerateNodes(); 
    }
    public void GenerateNodes()
    {
        CreateNodes();
    }


    void CreateNodes()
    {
        int gridX = 0;
        int gridY = 0;

        bool foundTileOnLastPass = false;

        // scan tiles and create nodes based on where they are
        for (int x = scanStartX; x < scanFinishX; x++) 
        {
            for (int y = scanStartY; y < scanFinishY; y++)
            {
                TileBase tb = ground.GetTile(new Vector3Int(x, y, 0));
                if (tb != null)
                {
                    bool foundObstacle = false;
                    foreach (Tilemap t in obstacleLayers)
                    {
                        TileBase tb2 = t.GetTile(new Vector3Int(x, y, 0));

                        if (tb2 != null)
                        {
                            foundObstacle = true;
                        }

                        // this add unwalkable edge around unwalkable nodes
                        if (unwalkableNodeBorder > 0)
                        {
                            List<TileBase> neighbours = GetNeighbouringTiles(x, y, t);
                            foreach (TileBase tl in neighbours)
                            {
                                if (tl != null)
                                {
                                    foundObstacle = true;
                                }
                            }
                        }
                    }

                    if (foundObstacle == false)
                    {
                        // if we haven't found obstacles then we create a walkable node and assign its grid coordinates
                        Vector3 coordinates = new Vector3(x + 0.5f + gridbase.transform.position.x, y + 0.5f + gridbase.transform.position.y, 0 );
                        // the gridbase component makes sure we create our nodes in the right place
                        GameObject node = (GameObject) Instantiate(nodePrefab, coordinates, Quaternion.Euler(0, 0, 0));
                        //
                        // more code here see video min 11
                        //
                        Node nodeScript = node.GetComponent<Node>();
                        nodeScript.gridX = gridX;
                        nodeScript.gridY = gridY;
                        nodeScript.walkable = true;

                        foundTileOnLastPass = true;
                        unsortedNodes.Add(node);

                        node.name = "NODE " + gridX.ToString() + ":" + gridY.ToString();
                    }
                    else
                    {

                        Vector3 coordinates = new Vector3(x + 0.5f + gridbase.transform.position.x, y + 0.5f + gridbase.transform.position.y, 0 );
                        // the gridbase component makes sure we create our nodes in the right place
                        GameObject node = (GameObject) Instantiate(nodePrefab, coordinates, Quaternion.Euler(0, 0, 0));
                        // set color to red, this doesn't work yet:
                        node.GetComponent<Node>().walkable = false;
                        
                        //
                        //
                        //

                        Node nodeScript = node.GetComponent<Node>();
                        nodeScript.gridX = gridX;
                        nodeScript.gridY = gridY;
                        nodeScript.walkable = false;

                        foundTileOnLastPass = true;
                        unsortedNodes.Add(node);

                        node.name = "UNWALKABLE NODE" + gridX.ToString() + " : " + gridY.ToString();
                    }

                    gridY++;

                    if (gridX > gridBoundX)
                    {
                        gridBoundX = gridX;
                    }
                    if (gridY > gridBoundY)
                    {
                        gridBoundY = gridY;
                    }
                }
            }
            // outside y loop
            if (foundTileOnLastPass == true) // the grid is going from bottom to top on the Y axis on each iteration of the loop
            // so if we have found tiles we increment the gridX and reset the Y position
            {
                gridX++;
                gridY = 0;
                foundTileOnLastPass = false;
            }

        }

        nodes = new GameObject[gridBoundX + 1, gridBoundY + 1];
        foreach (GameObject g in unsortedNodes)
        {
         // wt code, see min 15  
         Node nodeScript = g.GetComponent<Node>();
         nodes[nodeScript.gridX, nodeScript.gridY] = g; 
        }


    }

    public int unwalkableNodeBorder = 1;

    List<TileBase> GetNeighbouringTiles(int x, int y, Tilemap t)
    {
        return new List<TileBase>();
    }
}
