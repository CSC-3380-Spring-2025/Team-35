using UnityEngine;
// purpose: when characters collider with the object containing this script. they will be destroyed. so it looks like the npcs are exiting the building
public class BuildingExit : MonoBehaviour
{
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        // add a check for npc layer later, since you do not want to detroy the player or enemies

        Destroy(collision.gameObject);
    }
}
