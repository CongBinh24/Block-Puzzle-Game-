using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    int[,] O1 =
     {
        {1,0,0},
        {0,0,0},
        {0,0,0}

     };

    int[,] O2 =
    {
        {1,1,0},
        {1,1,0},
        {0,0,0}
    };

    int[,] O3 = {
        {1,1,1},
        {1,1,1},
        {1,1,1}
    };
    int[,] L1 =
    {
        {1,0,0},
        {1,0,0},
        {1,1,1}
    }; 

    int[,] L2 =
     {
        {1,1,1},
        {1,0,0},
        {1,0,0}

     };

    int[,] L3= {
        {1,1,1},
        {0,0,1},
        {0,0,1}
    };

    int[,] L4 = {
        {0,0,1},
        {0,0,1},
        {1,1,1}
    };

    int[,] Lnho1 =
    {
        {1,1,0},
        {1,0,0},
        {0,0,0}
    };

    int[,] Lnho2 =
    {
        {0,1,1},
        {0,0,1},
        {0,0,0}
    }; 
    
    int[,] Lnho3=
    {
        {0,0,0},
        {1,0,0},
        {1,1,0}
    };

    int[,] Lnho4 =
   {
        {0,0,0},
        {0,0,1},
        {0,1,1}
    };



    int[,] I1 = {
        {0,0,0},
        {1,1,1},
        {0,0,0}
    };


    int[,] I2 = {
        {0,1,0},
        {0,1,0},
        {0,1,0}
    };

    int[,] Inho1 =
    {
        {0,0,0},
        {1,1,0},
        {0,0,0},
    };

    int[,] Inho2 =
    {
        {0,1,0},
        {0,1,0},
        {0,0,0},
    };

    //int[,] Lngang = {
    //    {0,0,1},
    //    {1,1,1}
    //};

    public List<GroupType> listType= new List<GroupType>();


    public static Shape Instance;
    public GameObject List;
    private Vector3 startPosition;

    // Start is called before the first frame update
   
    void Start()
    {
        Instance = this;
        startPosition = transform.localPosition;
        listType.Add(new GroupType(1, O1));
        listType.Add(new GroupType(2, O2));
        listType.Add(new GroupType(3, O3));
        listType.Add(new GroupType(4, L1));
        listType.Add(new GroupType(5, L2));
        listType.Add(new GroupType(6, L3));
        listType.Add(new GroupType(7, L4));
        listType.Add(new GroupType(8, I1));
        listType.Add(new GroupType(9, I2));
        listType.Add(new GroupType(10, Lnho1));
        listType.Add(new GroupType(11, Lnho2));
        listType.Add(new GroupType(12, Lnho3));
        listType.Add(new GroupType(13, Lnho4));
        listType.Add(new GroupType(14, Inho1)); 
        listType.Add(new GroupType(15, Inho2));
        createRandom();
    }

    //public GroupType getGroupType(int typeget)
    //{
     
    //    for (int  i = 0;  i < listType.Count;  i++)
    //    {
    //        GroupType groupType = listType[i];
    //        int type = groupType.TypeGroup;
           
    //        if (type == typeget)
    //        {
    //            return groupType;
    //            Debug.Log("createGBlock " + typeget + "  " + type);
    //        }
    //    }
    //    Debug.Log("createGBlock2 " + typeget + "  ");
    //    return null;
    //}
    public void createRandom()
    {
        if (List != null)
            GameObject.Destroy(List);
        List = GameObject.Instantiate(new GameObject());
        List.transform.SetParent(transform);
        List.transform.position = new Vector3(0,0,0);
        for (int i = 0; i < 3; i++)
        {
            //int ran = Random.Range(1, 5);
            //Debug.LogError(ran);
            //GameObject b = GameObject.Instantiate(Resources.Load("Prefabs/" + ran) as GameObject);
            //b.transform.SetParent(List.transform);
            //b.transform.position = new Vector3(-3.5f + 3.5f * i, -7, -1);
            //b.GetComponent<Draggable>().posStart = b.transform.position;
            //Debug.Log(transform.position.y);
            //GroupBlock groupBlock = Instantiate(Grid.Instance.groupBlockPref, new Vector2(0, 0), Quaternion.identity);
            //groupBlock.Setprefabs(Grid.Instance.BlockModel);
            //groupBlock.initGroupBlock(listType[i].Grid_type);
            //groupBlock.transform.SetParent(List.transform);
            //groupBlock.transform.position = new Vector3(-3.5f + 3.5f * i, -7, -1);
            //GroupBlock groupBlock = creatGBlock(listType[5].Grid_type, new Vector3(-3.5f + 3.5f * i, -7, -1));
            GroupBlock groupBlock = creatGBlock(listType[Random.Range(1,15)].Grid_type, new Vector3(-3.5f + 3.5f * i, -7, -1));
        }
    }
    public GroupBlock creatGBlock(int [,] grid_type, Vector3 pos)
    {
        GroupBlock groupBlock = Instantiate(Grid.Instance.groupBlockPref, new Vector2(0, 0), Quaternion.identity);
        groupBlock.Setprefabs(Grid.Instance.BlockModel);
        groupBlock.initGroupBlock(grid_type);
        groupBlock.transform.SetParent(List.transform);
        groupBlock.transform.position = pos;

        //Debug.Log("createGBlock");
        return groupBlock;
    }

    public bool Isanyshapesquareactive()
    {
        return transform.localPosition == startPosition;
    }

  

}
