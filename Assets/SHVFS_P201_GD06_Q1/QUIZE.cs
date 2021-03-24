using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SHVFS_P201_GD06_Q1;

public class QUIZE : MonoBehaviour
{
    // Start is called before the first frame update

    public int numeric = 5;
    public string Name;
    public int number01 ;
    public int number02;
    public int sum;

    public string[] studentsName;

    void Start()
    {
        number01 = 10;
        number02 = 20;
        string[] studentsName = new string[5];
        studentsName[0] = "lyon";
        studentsName[1] = "Nico";
        studentsName[2] = "Nan";
        studentsName[3] = "Jesson";
        studentsName[4] = "Jeff";
        
    }
    public void Sumnumber(int numberA, int numberB)
    {

        numberA = number01;
        numberB = number02;
        return numberA + numberB;
    }
    

    // Update is called once per frame
    void Update()
    {
        for(i = 0; i<string studentsName[i];i++)
        {

        }
        
    }
}
