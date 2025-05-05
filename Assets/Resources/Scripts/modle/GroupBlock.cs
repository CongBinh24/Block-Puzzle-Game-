using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBlock : MonoBehaviour
{
    public static GroupBlock Instance;
   
    public BlockModel BlockModel;
    int[,] grid_gruop;

    public Draggable draggable;
    public Vector3 startPosition;

    public  List<BlockModel> _blockModel = new List<BlockModel>();
    bool legal_Merce = false;

    private void Start()
    {
        Instance = this;
    }

    public void creatGB (GameObject obparent, Vector2 pos)
    {
      
        this.transform.SetParent(obparent.transform);
        this.transform.position = pos;
      
    }

    public void Setprefabs(BlockModel BlockModel)
    {
        this.BlockModel = BlockModel;
    }

    int size = 1;
    public void initGroupBlock(int[,] grid)
    {
        draggable = this.GetComponent<Draggable>();
        this.grid_gruop = grid;
        startPosition = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 posStart = new Vector2(-size,size);
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                int type = this.grid_gruop[x, y];
                //Debug.Log("L :"+ x + "  " + y + " = " + type);
                if(type != 0)
                {
                    Vector2 vt = new Vector2(posStart.x+ y * size, posStart.y- x * size);
                    BlockModel square1 = Instantiate(BlockModel, vt, Quaternion.identity,this.transform);
                    square1.Setup(x, y);
                    square1.set_ColorType(1);
                    draggable.addBlock(square1);
                    _blockModel.Add(square1);
                }
                //BlockModel square1 = grid[x, y];
                //Vector2 vt = new Vector2(startX + y * size, startY - x * size);
                //square1 = Instantiate(BlockModel, vt, Quaternion.identity);
                //square1.Setup(x, y);
                //grid[x, y] = square1;
            }
        }
    }
    public void touchDown(Vector2  pos)
    {
        this.startPosition = (pos);
        checkGroupBlock();

    }
    public void touchUp()
    {

        legal_Merce = checkALL();
        //Debug.Log("TouchUp :"+ legal_Merce);
        if (legal_Merce) touchUpAll();
        //if (checkALL())
        //{
        //touchUpAll();
        //xet 
        //    //destroy 
        //}   
        if (Shape.Instance.List.transform.childCount == 1)
            Shape.Instance.createRandom();
        Destroy(gameObject);
    }
    public bool checkALL()
    {
        for (int i = 0; i < _blockModel.Count; i++)
        {
            if (!_blockModel[i].check())
            {
                return false;
            }
        }
        return true;
    }
    public void touchUpAll()
    {
        for (int i = 0; i < _blockModel.Count; i++)
        {
            _blockModel[i].touchUp();
        }
    }
    public void touchDrag()
    {
        //this.startPosition = (pos);
        checkGroupBlock();
    }
    public void checkGroupBlock()
    {
        legal_Merce = true;
        for (int i = 0; i < _blockModel.Count; i++)
        {
            BlockModel blockModel = _blockModel[i].checkInGridWorld();
            //check dieu kien null
            //if (blockModel != null) Debug.Log("blockModel :" + i+"  "+blockModel.row+"  "+blockModel.column);
            if (blockModel == null)
            {   
                //Debug.Log("Null :" + i);
                legal_Merce = false;
            }
        }
        if (!legal_Merce) return;
        for (int i = 0; i < _blockModel.Count; i++) _blockModel[i].save_BlockinGrid(_blockModel[i].blockInGrid);
    }

}
