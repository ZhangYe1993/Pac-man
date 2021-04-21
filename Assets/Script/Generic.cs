using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generic : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEnable()
        {
        var marriage1 = new PairStringString() { First = "Chun-li", Second = "Einstein" };
        var marriage2 = new Pair<int, int> { First = 5, Second = 6 };

        PrintTheThing("Nico");

    }

    public class PairStringString
    {
        public string First;
        public string Second;
    }

    public class PairIntFloat
    {
        public string First;
        public string Second;
    }

    public class PairIntInt
    {
        public string First;
        public string Second;
    }

    //GENERIC CLASSES
    //
    public class Pair<T,U>
    {
        public T First;
        public U Second;
    }

 
    //generics methods to the rescue
    //再用这个方法时，就不需要再次定义一个类型，直接在引用内容中写你需要输出的参数，他会自定义T的类型
    public void PrintTheThing<T>(T thing)
    {
        Debug.Log(thing);
    }

    public void PrintTheThings<T>(List<T> things)
    {
        for (var i = 0;i< things.Count; i++)
        {
            Debug.Log(things[i]);
        }
    }

    
    public T Produce<T>( ) where T:new()//return type 
    {
        T returnValue = new T();
        return returnValue;


    }
}
