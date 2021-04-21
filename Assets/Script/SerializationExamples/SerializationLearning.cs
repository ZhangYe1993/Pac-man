using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class SerializationLearning : MonoBehaviour
{
    // Start is called before the first frame update
    public void JsonSerialize(object data, string filePath)
    {
        //内部使用这个方法
        JsonSerializer jsonSerializer = new JsonSerializer();
        if (File.Exists(filePath)) File.Delete(filePath);

        StreamWriter sw = new StreamWriter(filePath);
        JsonWriter jsonWriter = new JsonTextWriter(sw);

        jsonSerializer.Serialize(jsonWriter, data);
        jsonWriter.Close();
        sw.Close();
    }

    public object JsonDeSerialize(Type dataType,string filePath)
    {
        JObject obj = null;
        JsonSerializer jsonSerializer = new JsonSerializer();
        if(File.Exists(filePath))
        {
            StreamReader sr = new StreamReader(filePath);
            JsonReader jsonReader = new JsonTextReader(sr);
            obj = jsonSerializer.Deserialize(jsonReader) as JObject;
            jsonReader.Close();
            sr.Close();


        }
        return obj.ToObject(dataType);
    }
}
