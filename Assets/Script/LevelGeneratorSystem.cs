using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSystem : MonoBehaviour
{
    public BaseGridObject[] BaseGridObjectsPrefabs;
    //public static int[,] LevelGrid = new int[,]

    public List<string> LevelFileNames = new List<string>();

    public static int[,] Grid = new int[,]
    {
        { 1,1,1,1,1,1,1,1,1,1},
        { 1,0,1,0,4,0,0,3,0,1},
        { 1,0,2,0,0,1,0,0,0,1},
        { 1,1,0,0,0,1,1,0,0,1},
        { 1,0,0,1,0,1,4,0,1,1},
        { 1,0,0,1,0,3,0,0,0,1},
        { 1,1,1,1,1,1,1,1,1,1}
    };

    private void Awake()
    {
         var level = LevelFileNames[Random.Range(0, LevelFileNames.Count - 1)];
         Grid = Appdatasystem.Load<Level> (level).grid;
        for(int i = 0 ; i < Grid.GetLength(0); i++)
        {
            for(int j = 0; j < Grid.GetLength(1); j ++)
            {
                var objectType = Grid[i, j];
                var gridObjectPrefab = BaseGridObjectsPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPosition = new IntVector2(j, -i);
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y, 0f);
                //Instantiate(BaseGridObjectsPrefabs[Grid[i,j]], new Vector3(j , -i, 0), Quaternion.identity);
            }
        }
    }

   
}
public class Level
{
    public int[,] grid;
}
