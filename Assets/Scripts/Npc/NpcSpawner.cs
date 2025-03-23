using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class NpcSpawner : MonoBehaviour
{

    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform Target;
    public GameObject[] NpcPrefab; // am array of prefabs that can be spawned, they will be chosen at random
    private int spawnTime = 3; // Time to wait before spawning a new npc
    private float timer; // the actual variable that keeps track of the time

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = spawnTime;
            float xPosition = Random.Range(spawnPointLeft.position.x, spawnPointRight.position.x); // choose a random x-coordinate between the entrances to spawn the npc
            float npcIndex = Random.Range(0, (float) NpcPrefab.Length - 0.01f);
             

            GameObject npc = Instantiate(NpcPrefab[(int) npcIndex], new Vector3(xPosition, spawnPointLeft.position.y, spawnPointLeft.position.z), Quaternion.identity);

            NpcMovement npcScript = npc.GetComponent<NpcMovement>();
            
            //  decide whether the npc should run up or down based on if the target is up or down from the spawn point
            if (Target.position.y < spawnPointLeft.position.y)
            {
                npcScript.RunDown();
            }
            else
            {
                npcScript.RunUp();

            }
        }
    }


}
