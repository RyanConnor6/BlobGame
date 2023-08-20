using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class procgenerooms : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap wallTilemap;
    public Tile wallTile;
    public Tile groundTile;
    public Tile upTile;
    public Tile rightTile;
    public Tile downTile;
    public int roomSize = 12;

    private int roomplaceposX = 15;
    private int roomplaceposY = -2;
    private int nextXStart = 0;
    private int nextYStart = 0;
    private int lastroomType = 2; //0 is open from left, can move right up or down. 1 is open from top, can move right or up. 2 is open from bottom, can move right or down.

    private void Start()
    {
        GenerateTilemap();
    }

    void GenerateTilemap()
    {
        nextXStart = roomplaceposX;
        nextYStart = roomplaceposY;
        for (int rooms = 0; rooms < 1; rooms++)
        {
            if (lastroomType == 0) //Last room went right, can go right up or down
            {
                int randomValue = Random.Range(0, 3);
                //int randomValue = 2;

                switch (randomValue)
                {
                    case 0: // Go right

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;

                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            Vector3Int tilePosition2 = new Vector3Int(roomplaceposX, roomplaceposY + roomSize -1, 0);
                            groundTilemap.SetTile(tilePosition1, rightTile);
                            groundTilemap.SetTile(tilePosition2, rightTile);
                            for (int j = 0; j < roomSize + 1; j++)
                            {
                                Vector3Int tilePosition3 = new Vector3Int(roomplaceposX, roomplaceposY + j, 0);
                                //wallTilemap.SetTile(tilePosition3, wallTile);
                            }
                            roomplaceposX++;
                        }
                        roomplaceposX--;

                        nextXStart = roomplaceposX;
                        nextYStart = roomplaceposY;
                        lastroomType = 0;
                        break;

                    case 1: // Go up

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;

                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, upTile);
                            for (int j = 0; j < roomSize + 1; j++)
                            {
                                Vector3Int tilePosition3 = new Vector3Int(roomplaceposX, roomplaceposY + j, 0);
                                //wallTilemap.SetTile(tilePosition3, wallTile);
                            }
                            roomplaceposX++;
                        }
                        roomplaceposX--;
                        for (int i = 0; i < roomSize - 1; i++)
                        {
                            roomplaceposY++;
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, upTile);
                        }
                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        nextYStart = roomplaceposY;

                        lastroomType = 1;
                        break;

                    case 2: //Go down

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;
                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition2 = new Vector3Int(roomplaceposX, roomplaceposY + roomSize - 1, 0);
                            groundTilemap.SetTile(tilePosition2, downTile);
                            for (int j = 0; j < roomSize + 1; j++)
                            {
                                Vector3Int tilePosition3 = new Vector3Int(roomplaceposX, roomplaceposY + j, 0);
                                //wallTilemap.SetTile(tilePosition3, wallTile);
                            }
                            roomplaceposX++;
                        }
                        roomplaceposX--;
                        for (int i = 0; i < roomSize - 1; i++)
                        {
                            roomplaceposY++;
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, downTile);
                        }

                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        nextYStart = roomplaceposY - roomSize * 2 + 2;
                        lastroomType = 2;
                        break;

                    default:

                        Debug.Log("Value is not 1, 2, or 3");
                        // Code for default case
                        break;
                }
            }

            if (lastroomType == 1) // Last room went up, can go right or up
            {
                int randomValue = Random.Range(0, 2);
                //int randomValue = 1;

                switch (randomValue)
                {
                    case 0: // Go right

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;

                        for (int i = 0; i < roomSize - 1; i++)
                        {
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, rightTile);
                            roomplaceposY++;
                        }

                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition2 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition2, rightTile);
                            for (int j = 0; j < roomSize + 1; j++)
                            {
                                Vector3Int tilePosition3 = new Vector3Int(roomplaceposX, roomplaceposY + j, 0);
                                //wallTilemap.SetTile(tilePosition3, wallTile);
                            }
                            roomplaceposX++;
                        }
                        roomplaceposX--;

                        nextXStart = roomplaceposX + 1;
                        nextYStart = roomplaceposY - roomSize + 1;

                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        lastroomType = 0;
                        break;

                    case 1: // Go up

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;

                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            Vector3Int tilePosition2 = new Vector3Int(roomplaceposX + roomSize - 1, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, upTile);
                            groundTilemap.SetTile(tilePosition2, upTile);
                            roomplaceposY++;
                        }

                        nextYStart += roomSize;

                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        lastroomType = 1;
                        break;

                    default:

                        Debug.Log("Value is not 1, 2, or 3");
                        // Code for default case
                        break;
                }
            }

            if (lastroomType == 2) // Last room went down, can go right or down
            {
                //int randomValue = Random.Range(0, 2);
                int randomValue = 1;

                switch (randomValue)
                {
                    case 0: // Go right

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;

                        for (int i = 0; i < roomSize - 1; i++)
                        {
                            roomplaceposY++;
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, rightTile);
                        }

                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition2 = new Vector3Int(roomplaceposX, roomplaceposY - roomSize + 1, 0);
                            groundTilemap.SetTile(tilePosition2, rightTile);
                            for (int j = 0; j < roomSize + 1; j++)
                            {
                                Vector3Int tilePosition3 = new Vector3Int(roomplaceposX, roomplaceposY + j, 0);
                                //wallTilemap.SetTile(tilePosition3, wallTile);
                            }
                            roomplaceposX++;
                        }
                        roomplaceposX--;

                        nextXStart = roomplaceposX + 1;
                        nextYStart = roomplaceposY - roomSize + 1;

                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        lastroomType = 0;
                        break;

                    case 1: // Go down

                        roomplaceposX = nextXStart;
                        roomplaceposY = nextYStart;

                        for (int i = 0; i < roomSize; i++)
                        {
                            Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
                            Vector3Int tilePosition2 = new Vector3Int(roomplaceposX + roomSize - 1, roomplaceposY, 0);
                            groundTilemap.SetTile(tilePosition1, downTile);
                            groundTilemap.SetTile(tilePosition2, downTile);
                            roomplaceposY++;
                        }

                        nextYStart -= roomSize;

                        //Vector3Int tilePosition5 = new Vector3Int(nextXStart, nextYStart, 0);
                        //groundTilemap.SetTile(tilePosition5, wallTile);

                        lastroomType = 2;
                        break;

                    default:

                        Debug.Log("Value is not 1, 2, or 3");
                        // Code for default case
                        break;
                }
            }

        }
    }
}


//CODE TO GENERATE ROOM

/*
roomplaceposX = nextXStart;
roomplaceposY = nextYStart;
for (int i = 0; i < roomSize; i++)
{
    Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
    Vector3Int tilePosition2 = new Vector3Int(roomplaceposX, roomplaceposY + roomSize, 0);
    groundTilemap.SetTile(tilePosition1, groundTile);
    groundTilemap.SetTile(tilePosition2, groundTile);
    for (int j = 0; j < roomSize + 1; j++)
    {
        Vector3Int tilePosition3 = new Vector3Int(roomplaceposX, roomplaceposY + j, 0);
        wallTilemap.SetTile(tilePosition3, wallTile);
    }
    roomplaceposX++;
}
roomplaceposX--;
nextXStart = roomplaceposX;
nextYStart = roomplaceposY;
for (int i = 0; i < roomSize - 1; i++)
{
    roomplaceposY++;
    Vector3Int tilePosition1 = new Vector3Int(roomplaceposX, roomplaceposY, 0);
    groundTilemap.SetTile(tilePosition1, groundTile);
}
*/