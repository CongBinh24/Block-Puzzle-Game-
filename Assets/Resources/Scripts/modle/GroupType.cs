using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupType : MonoBehaviour
{
    int typeGroup;
    int[,] grid_type;

    public GroupType(int _typeGroup, int [,] _grid_type)
    {
        typeGroup = _typeGroup;
        grid_type = _grid_type;
    }

    public int TypeGroup { get => typeGroup; set => typeGroup = value; }
    public int[,] Grid_type { get => grid_type; set => grid_type = value; }


}
