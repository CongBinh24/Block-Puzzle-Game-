using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public static Grid Instance;

    //public GameObject square;
    public BlockModel BlockModel;
    public GroupBlock groupBlockPref;
    public Shape shape;

    int _score;
    public int column = 9;
    public int row = 9;
    public BlockModel[,] grid;
    float size = 1;
    //float padding = 0.5f;
    public float startX = -4f;
    public float startY = 6f;
    //public static Shape shade;
    //public Vector2 startposition = new Vector2(-3.7f, -1.57f);
    //public int number;

    public GameObject ScorePannel;
    public Text ScoreText;

    BlockModel blockModel;
    int anothertypeblock;
    public int Score { get => _score; set => _score = value; }

    private void Awake()
    {
        blockModel = GetComponent<BlockModel>();
        anothertypeblock = BlockModel.type_block;
        Score = 0;
        ScoreText.text = " " + Score;
        Instance = this;
        grid = new BlockModel[row, column];
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < column; y++)
            {
                BlockModel square1 = grid[x, y];
                Vector2 vt = new Vector2(startX + y * size, startY - x * size);
                square1 = Instantiate(BlockModel, vt, Quaternion.identity);
                square1.Setup(x, y);
                grid[x, y] = square1;
            }
        }

    }
  
    public void CheckActive()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (grid[i, j].type_block == 0)
                    break;
                if( j == column - 1)
                {
                    xoaHang(i);
                    Score += 10;
                    ScoreText.text = Score.ToString();
                }
            }
        }

        for (int j = 0; j < column; j++)
        {
            for (int i = 0; i < row; i++)
            {
                if (grid[i, j].type_block == 0)
                    break;  
                if(i == row - 1)
                {
                    xoaCot(j);
                    Score += 10;
                    ScoreText.text = Score.ToString();
                }
            }
        }
    }
    public void xoaHang(int numRow)
    {
        for (int i = 0; i < column; i++)
        {
            grid[numRow, i].set_ColorType(0);
        }
    }

    public void xoaCot(int numColumn)
    {
        for (int i = 0; i < row; i++)
        {
            grid[i, numColumn].set_ColorType(0);
        }
    }

    //Chuyen doi vi tri tu World sang Grid
    public BlockModel WorldToGridPosition(float WorldPosX, float WorldPosY)
    {
        float x = /*(int)*/(WorldPosX - (startX - 0.5f));
        float y = /*(int)*/(startY + 0.5f - WorldPosY);
        if (x < 0 || x >= row || y < 0 || y >= column)
        {
            return null;
        }
        BlockModel result = grid[(int)y, (int)x];
        return result;

        //float startXLeftDown = startX - size * 0.5f;
        //float startYLeftDown = startY - size * 0.5f;

        //float rightXLimit = row * size + startXLeftDown;
        //float upperYLimit = column * size + startYLeftDown;
        //if (WorldPosX < startXLeftDown || WorldPosX > rightXLimit || WorldPosY < startYLeftDown || WorldPosY > upperYLimit)
        //{
        //    return null;
        //}

        //WorldPosX = WorldPosX - startXLeftDown;
        //WorldPosY = WorldPosY - startYLeftDown;

        //int x = Mathf.FloorToInt(WorldPosX / size);
        //int y = Mathf.FloorToInt(WorldPosY / size);
        //BlockModel result = grid[y, x];

        //return result;
    }
    
    public void CheckGameOVer()
    {
        
    }
}

