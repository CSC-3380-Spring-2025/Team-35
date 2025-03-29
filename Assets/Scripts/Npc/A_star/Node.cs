using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Node cameFrom;

    public int gridX, gridY;
    public List<Node> connections;
    public float gScore;
    public float hScore;

    public bool walkable = true;

    public float FScore()
    {
        return gScore + hScore;
    }

    private void OnDrawGizmosSelected()
    {
     if (walkable)
     {
        Gizmos.color = Color.green;
     }
     else
     {
        Gizmos.color = Color.red;
     }   
     Gizmos.DrawWireSphere(transform.position, 2f);
    }


}
