using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Material[] materials;
    int currentMaterialIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        ApplyMaterialToScenario();
    }

    private void OnTriggerExit(Collider collider)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObsbtcle()
    {
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnCoins()
    {
        int coinsToSpawn = 5;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointCollider(collider);
        }

        point.y = 1;
        return point;
    }

    void ApplyMaterialToScenario()
    {
        Transform scenarioTransform = transform.Find("Scenario");

        if (scenarioTransform != null)
        {
            MeshRenderer meshRenderer = scenarioTransform.GetComponent<MeshRenderer>();

            if (meshRenderer != null && materials.Length > 0)
            {
                Material[] mats = meshRenderer.materials; // Obtém todos os materiais aplicados
                mats[0] = materials[currentMaterialIndex]; // Substitui o primeiro material (ou qualquer outro índice desejado)
                meshRenderer.materials = mats; // Atualiza o Mesh Renderer com os novos materiais

                // Incrementa o índice para o próximo tile
                currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;
            }
        }
    }
}
