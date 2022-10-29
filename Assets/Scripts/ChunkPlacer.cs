using System.Collections.Generic;
using System.Collections;
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
    private int chunksToFork = -1;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    private int nextWayContinue;
    private bool isTurned;
    private bool forkSpawned = false;
    private bool canTurn = false;
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
            else if(chunksToFork == 0)
            {
                SpawnForkChunk(_forkChunkPrefabs, _defaultChunkPrefabs);
            }
        }
    }

    private void SpawnForkChunk(Chunk[] forkChunks, Chunk[] defaultChunks)
    {
        isTurned = _player.GetComponent<TramController>().isTurned;
        canTurn = _player.GetComponent<TramController>().canTurn;
        nextWayContinue = _player.GetComponent<TramController>().turnWay;
        if (forkSpawned == false)
        {
            Chunk newChunk = Instantiate(GetRandomChunk(forkChunks), gameObject.transform);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].ends[0].position; //- newChunk.begin.localPosition * 100;
            spawnedChunks.Add(newChunk);
            forkSpawned = true;

        }
        else if(isTurned&&forkSpawned&&canTurn)
        {
            Chunk newChunk = Instantiate(GetRandomChunk(defaultChunks), gameObject.transform);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].ends[nextWayContinue].position; //- newChunk.begin.localPosition * 30;
            spawnedChunks.Add(newChunk);
            chunksToFork = 20;
            forkSpawned = false;
        }
        if (spawnedChunks.Count >= _chunkCount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }

    }
    private void SpawnChunk(Chunk[] chunks)
    {
        Chunk newChunk = Instantiate(GetRandomChunk(chunks), gameObject.transform);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].ends[0].position;// - newChunk.begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= _chunkCount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private Chunk GetRandomChunk(Chunk[] chunkArray)
    {
        int value = Random.Range(0, chunkArray.Length);
        return chunkArray[value];
    }
}