using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireSpreader : MonoBehaviour
{
    private int _fireCount = 0;
    [SerializeField] private AnimatedTile _burntTile;
    [SerializeField] private Tilemap _forest;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private float _spreadRate = 5.0f;
    [SerializeField] private ParticleSystem _waterSplash;

    public delegate void FireSpreadStopped();
    public event FireSpreadStopped OnFireSpreadStopped;

    // Start is called before the first frame update
    void Start()
    {
        CountFireTiles();
        InvokeRepeating("SpreadFire", _spreadRate, _spreadRate);
    }

    void CountFireTiles()
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
                        _fireCount++;
                    }
                }
            }
        }

        Debug.Log("Fire Count: " + _fireCount);
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
                                if (tileAtPosition.name.Contains("tree") && _tilemap.GetTile(position) == null)
                                {
                                    _tilemap.SetTile(position, _burntTile);
                                    _fireCount++;
                                }
                            }
                        }
                    }
                }
            }
        }

        Debug.Log("Fire Count: " + _fireCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectile")
        {
            // Find which tile the projectile is on
            Vector3Int cell = _tilemap.WorldToCell(other.transform.position);

            TileBase tileBase = _tilemap.GetTile(cell);
            if(tileBase == null)
            {
                return;
            }
            else if(tileBase.name == "FireAnimation")
            {
                ParticleSystem particle = Instantiate(_waterSplash, other.transform.position, Quaternion.identity);
                Destroy(particle.gameObject, 1.0f);

                _tilemap.SetTile(cell, null);
                _fireCount--;
        
                if( _fireCount == 0 )
                {
                    CancelInvoke("SpreadFire");
                    OnFireSpreadStopped?.Invoke();
                }
            }
        }
    }
}
