using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Chunk[] _defaultChunkPrefabs;
    [SerializeField] private Chunk[] _forkChunkPrefabs;
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private int _chunkCount;
    [SerializeField] private int _spawnDistance;
    private int chunksToFork = 20;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    
    private void Start()
    {
        spawnedChunks.Add(_firstChunk);
    }

    private void Update()
    {
        if (_player.position.z > spawnedChunks[spawnedChunks.Count - 1].ends[0].position.z - _spawnDistance)
        {
            if (chunksToFork != 0)
            {
                SpawnChunk(_defaultChunkPrefabs);
                chunksToFork--;
            }
            else
            {
                SpawnForkChunk(_forkChunkPrefabs);
                chunksToFork = 20;
            }
        }
    }

    private void SpawnForkChunk(Chunk[] chunks)
    {
        int nextWayContinue = (int)Mathf.Round(Random.Range(0f,1f));
        Chunk newChunk = Instantiate(GetRandomChunk(chunks), gameObject.transform);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].ends[0].position- newChunk.begin.localPosition*100;
        spawnedChunks.Add(newChunk);
        newChunk = Instantiate(GetRandomChunk(_defaultChunkPrefabs), gameObject.transform);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].ends[nextWayContinue].position - newChunk.begin.localPosition*30;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= _chunkCount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }

    }
    private void SpawnChunk(Chunk[] chunks)
    {
        Chunk newChunk = Instantiate(GetRandomChunk(chunks), gameObject.transform);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].ends[0].position - newChunk.begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= _chunkCount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private Chunk GetRandomChunk(Chunk[] chunkArray)
    {
        List<float> chances = new List<float>();
        for (int i = 0; i < chunkArray.Length; i++)
        {
            chances.Add(chunkArray[i].ChanceFromDistance.Evaluate(_player.transform.position.z));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if (value < sum)
            {
                return chunkArray[i];
            }
        }

        return chunkArray[chunkArray.Length - 1 ];
    }
}