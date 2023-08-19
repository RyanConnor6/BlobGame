using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class procgene : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap obstacleTilemap;
    public Tile groundTile;
    public Tile stage1Tile;
    public Tile stage2Tile;
    public Tile stage3Tile;
    public Tile stage4Tile;
    public Tile stage5Tile;
    public Tile stage6Tile;
    public Tile stage7Tile;
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

            if (x < 100)
            {
                groundTilemap.SetTile(tilePosition, groundTile);
            }else if (x < 200)
            {
                groundTilemap.SetTile(tilePosition, stage1Tile);
            }
            else if (x < 300)
            {
                groundTilemap.SetTile(tilePosition, stage2Tile);
            }
            else if (x < 400)
            {
                groundTilemap.SetTile(tilePosition, stage3Tile);
            }
            else if (x < 500)
            {
                groundTilemap.SetTile(tilePosition, stage4Tile);
            }
            else if (x < 600)
            {
                groundTilemap.SetTile(tilePosition, stage5Tile);
            }
            else if (x < 700)
            {
                groundTilemap.SetTile(tilePosition, stage6Tile);
            }
            else if (x < 800)
            {
                groundTilemap.SetTile(tilePosition, stage7Tile);
            }
            else
            {
                groundTilemap.SetTile(tilePosition, groundTile);
            }

            if (x == lastPillarx + pillarSpacing)
            {
                pillarHeight = Random.Range(minpillarHeight, maxpillarHeight);
                for (int h = 1; h < pillarHeight; h++)
                {
                    if (x < 100)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), pillarTile);
                    }
                    else if (x < 200)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage1Tile);
                    }
                    else if (x < 300)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage2Tile);
                    }
                    else if (x < 400)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage3Tile);
                    }
                    else if (x < 500)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage4Tile);
                    }
                    else if (x < 600)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage5Tile);
                    }
                    else if (x < 700)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage6Tile);
                    }
                    else if (x < 800)
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), stage7Tile);
                    }
                    else
                    {
                        obstacleTilemap.SetTile(tilePosition + new Vector3Int(0, h, 0), pillarTile);
                    }
                }
                newSpacing = true;
            }
        }
    }
}