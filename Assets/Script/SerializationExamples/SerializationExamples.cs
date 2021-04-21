using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;//json files
using UnityEngine.UI;

public class SerializationExamples : MonoBehaviour
{
    ///{"name":"Nan","ID":"0ffdbda5-faaf-43e8-b92d-723be01c6a36","HP":9000} FORMAT TO jESON
    public TextAsset EnemyFile;
    public Enemy Enemy;
    public Text EnemyText;
    // Start is called before the first frame update

  
    public void OnEnable()
        
    {
        var enemyData = File.ReadAllText($"{Application.dataPath}/StreamingData/EnemyFile.json");
        Enemy = JsonConvert.DeserializeObject<Enemy>(enemyData);
        EnemyText.text = $"{Enemy.name}:{Enemy.HP} HP";


        Debug.Log(enemyData);
    }

    public void OnDisable()
    {
        Enemy = new Enemy() { name = "Nan", ID = Guid.NewGuid(), HP = 9000 };


        //LOOKS AT OUR ENEMY, TURN THE class do a text file 
        var serializedEnemy = JsonConvert.SerializeObject(Enemy);
        File.WriteAllText($"{Application.dataPath}/StreamingData/EnemyFile.json", serializedEnemy);


        Debug.Log(serializedEnemy);
    }
}


[Serializable]
public class Enemy
{
    
    public string name;
    public Guid ID;
    public int HP;

}


//public class AppDataSystem
//{
//    public AppDataSystem tData;
//    public Text Tinfo;

//    public string[] FileName;

 

//    void start()
//    {
    
//    }
//    //save method, for saving a type to a file with a provided by the person saving
//    //load method, for loading objects of any type,given a fillname
//    //this should give me an enemy object
//    //APPDATA SYSTEM,SAVE(ENEMY, "enemy1")
//    //var enemy = appdataSystem.load<Enemy>("Enemy1");
//    public static void Saveing<T>(T Obj, string FileID)
//    {
//        //serialized save;
//        var serializedTtype = JsonConvert.SerializeObject(Obj);
//        File.WriteAllText($"{Application.dataPath}/StreamingData/{typeof(T)}.json", serializedTtype);
//        Debug.Log(serializedTtype);

//        var filePath = $"{Application.dataPath}/StreamingData/{typeof(T)}.json";

//        string[] FileName = File.ReadAllLines(filePath);
        
//        for (int i = 0; i < FileName.Length; i++)
//        {
//            string txtString = FileName[i];
//            for (int j = 0; j < FileName.Length; j++)
//            {
//                if (j != i)
//                {
//                    if (txtString.Equals(FileName[j]))
//                    {
//                        Debug.Log("the" + i + "equels" + j + "you can't save the file name");
//                    }
//                    else
//                    {
//                        Debug.Log("you can save the FileName");

//                    }
                        
//                }
//            }
//        }


//    }

//    public void Reading<T>(string FileID)
//    {
//        //deserialize Read;
//        var TData = File.ReadAllText($"{Application.dataPath}/StreamingData/{typeof(T)}.json");
//        tData =JsonConvert.DeserializeObject<AppDataSystem>(TData);
//        Tinfo.text = FileID;

//        if(File.Exists(FileID))
//        {


//        }

//    }

//}
