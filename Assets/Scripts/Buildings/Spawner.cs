using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject spawnPrefab;
    [SerializeField]
    protected Transform spawnPoint;
    [SerializeField]
    protected bool spawnEnabled;
    [SerializeField]
    protected float spawnInterval;
    private float currentInterval;

    private void Update()
    {
        if(!spawnEnabled) { return; }

        currentInterval += Time.deltaTime;

        if (currentInterval >= spawnInterval)
        {
            Spawn();
            currentInterval = 0f;
        }
    }

    protected GameObject Spawn()
    {
        if(spawnPrefab && spawnPoint)
        {
            return Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Spawner Setup incomplete : " + name, gameObject);
            return null;
        }
    }
}
