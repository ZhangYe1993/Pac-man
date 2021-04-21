using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;//json files
using UnityEngine.UI;

public class Appdatasystem
{
    // Start is called before the first frame update
public static T Save<T>(T appData,string fileName)
    {
        //GET PATH FOLDER BASED  on the type ,automatically
        //for example ,if we save an enemy type object, it will be in a folder called "Enemys"

        var path = $"{Application.dataPath}/{typeof(T)}/";
        if(!Directory.Exists(path))//methods calling 
        {
            Directory.CreateDirectory(path);
        }

        if (!File.Exists($"{path}{fileName}"))
        {
            var fileStream = File.Create($"{path}{fileName}.json");
            fileStream.Close();
        }

        File.WriteAllText($"{path}/{fileName}.json", JsonConvert.SerializeObject(appData));
        return appData;
    }

    public static T Load<T>(string fileName) where T : new()
    {
        var path = $"{Application.dataPath}/{typeof(T)}/";
        if(File.Exists($"{path}{fileName}"))
        {
            var appData = JsonConvert.DeserializeObject<T>(File.ReadAllText($"{path}{fileName}.json"));
            return appData;
        }
        return Save(new T(), fileName);
    }
}
