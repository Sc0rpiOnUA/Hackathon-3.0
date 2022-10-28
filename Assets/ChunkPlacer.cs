using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Chunk[] _chunkPrefabs;
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private int _chunkCount;
    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(_firstChunk);
    }

    private void Update()
    {
        if (_player.position.z > spawnedChunks[spawnedChunks.Count - 1].end.position.z - 15)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(GetRandomChunk());
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].end.position - newChunk.begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= _chunkCount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private Chunk GetRandomChunk()
    {
        List<float> chances = new List<float>();
        for (int i = 0; i < _chunkPrefabs.Length; i++)
        {
            chances.Add(_chunkPrefabs[i].ChanceFromDistance.Evaluate(_player.transform.position.z));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if (value < sum)
            {
                return _chunkPrefabs[i];
            }
        }

        return _chunkPrefabs[_chunkPrefabs.Length - 1];
    }
}