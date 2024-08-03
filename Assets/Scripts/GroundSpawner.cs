using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++) {
            if(i < 4) {
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        } 
    }

    public void SpawnTile(bool spawnItems) 
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if(spawnItems) {
            temp.GetComponent<GroundTile>().SpawnObsbtcle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }
}
