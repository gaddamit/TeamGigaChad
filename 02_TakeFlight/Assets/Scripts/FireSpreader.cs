using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireSpreader : MonoBehaviour
{

    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private AnimatedTile _burntTile;
    [SerializeField] private Tilemap _forest;
    [SerializeField] private float _spreadRate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpreadFire", 5.0f, _spreadRate);
    }

    void SpreadFire()
    {
        BoundsInt bounds = _tilemap.cellBounds;
        TileBase[] allTiles = _tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                Vector3Int localPlace = (new Vector3Int(bounds.x + x, bounds.y + y, bounds.z));
                Vector3 place = _tilemap.CellToWorld(localPlace);
                TileBase tile = allTiles[x + y * bounds.size.x];

                if (tile != null)
                {
                    if (tile.name == "FireAnimation")
                    {
                        Vector3Int[] positions = new Vector3Int[8];
                        positions[0] = new Vector3Int(localPlace.x + 1, localPlace.y, localPlace.z);
                        positions[1] = new Vector3Int(localPlace.x - 1, localPlace.y, localPlace.z);
                        positions[2] = new Vector3Int(localPlace.x, localPlace.y + 1, localPlace.z);
                        positions[3] = new Vector3Int(localPlace.x, localPlace.y - 1, localPlace.z);
                        positions[4] = new Vector3Int(localPlace.x + 1, localPlace.y - 1, localPlace.z);
                        positions[5] = new Vector3Int(localPlace.x + 1, localPlace.y + 1, localPlace.z);
                        positions[6] = new Vector3Int(localPlace.x - 1, localPlace.y - 1, localPlace.z);
                        positions[6] = new Vector3Int(localPlace.x - 1, localPlace.y + 1, localPlace.z);

                        foreach (Vector3Int position in positions)
                        {
                            TileBase tileAtPosition = _forest.GetTile(position);
                            if (tileAtPosition != null)
                            {
                                if (tileAtPosition.name.Contains("tree"));
                                {
                                    _tilemap.SetTile(position, _burntTile);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fire has spread to " + other.name);
    }
}
