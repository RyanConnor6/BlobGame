using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class procgene : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap obstacleTilemap;
    public Tile groundTile;
    public Tile pillarTile;

    public int mapWidth = 20;
    public int mapHeight = 10;
    public int maxpillarSpacing = 10;
    public int minpillarSpacing = 5;
    public int maxpillarHeight = 3;
    public int minpillarHeight = 1;

    private bool newSpacing = true;
    private int pillarSpacing = 0;
    private int pillarHeight = 1;
    private int lastPillarx = 15;

    private void Start()
    {
        GenerateTilemap();
    }

    void GenerateTilemap()
    {
        groundTilemap.ClearAllTiles();
        obstacleTilemap.ClearAllTiles();

        for (int x = 15; x < mapWidth; x++)
        {
            if (newSpacing == true)
            {
                pillarSpacing = Random.Range(minpillarSpacing, maxpillarSpacing);
                newSpacing = false;
                lastPillarx = x;
            }

            Vector3Int tilePosition = new Vector3Int(x, -2, 0);
            groundTilemap.SetTile(tilePosition, groundTile);

            if (x == lastPillarx + pillarSpacing)
            {
                pillarHeight = Random.Range(minpillarHeight, maxpillarHeight);
                for (int h = 1; h < pillarHeight; h++)
                {
                    obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), pillarTile);
                }
                newSpacing = true;
            }
        }
    }
}