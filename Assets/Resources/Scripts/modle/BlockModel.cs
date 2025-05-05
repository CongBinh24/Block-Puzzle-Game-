using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockModel : MonoBehaviour
{
    public static BlockModel Instance;
    public int type_block = 0;
    public int row;
    public int column;
    SpriteRenderer spr;

    public GroupBlock groupBlock; 
    public void Setup(int r, int c)
    {
        this.row = r;
        this.column = c;
    }

    private void Awake()
    {
        Instance = this;
        spr = GetComponent<SpriteRenderer>();
        set_ColorType(0);

    }
    public int getType_block()
    {
        return type_block;
    }
    public void set_ColorType(int type_color)
    {
        this.type_block = type_color;
        switch (type_color)
        {
            case 0:
                spr.color = Color.white;
                break;
            case 1:
                spr.color = Color.red;
                break;
            case 2:
                spr.color = Color.green;
                break;
            case 3:
                spr.color = Color.yellow;
                break;
            case 4:
                spr.color = Color.blue;
                break;
        }
    }
    public BlockModel blockInGrid = null;
    public BlockModel checkInGridWorld()
    {
        BlockModel blockModel = Grid.Instance.WorldToGridPosition(transform.position.x, transform.position.y);
        if (blockInGrid != null)
        {
            blockInGrid.gameObject.active = true;
            blockInGrid = null;
        }
        if (blockModel != null && blockModel.type_block != 0) return null;
        blockInGrid = blockModel;
        return blockModel;
    }
     
    public void save_BlockinGrid(BlockModel blockModel)
    {
       
        if (blockModel != null && blockModel.type_block == 0)
        {
            if (blockInGrid != null && !blockModel.Equals(blockInGrid))
            {
                blockInGrid.gameObject.active = true;
                blockModel.gameObject.active = false;
                blockInGrid = blockModel;
            }
            else
            {
                blockInGrid = blockModel;
                blockInGrid.gameObject.active = false;
            }
        }
        else
        {
            blockInGrid = null;
        }
    }
    public bool check()
    {
        if (blockInGrid != null) return true;
  
        return false;
    }
    public void touchUp()
    {
        
        if (blockInGrid != null)
        {
            blockInGrid.gameObject.active = true;
            blockInGrid.set_ColorType(4);
        }
       
        Grid.Instance.CheckActive();
        blockInGrid = null;
    }
}
