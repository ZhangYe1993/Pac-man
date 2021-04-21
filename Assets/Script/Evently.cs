using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;



public class Evently
{
    private static Evently eventManagerInstance;
    public static Evently Instance => eventManagerInstance ?? (eventManagerInstance = new Evently());
    //Dictionnary has key and an value ,key is unique in the Dictionary, you need check there is this type 
    //Dictionnary must be checked before you 
    //dictionnary IDictionary<int, string> numberNames = new Dictionary<int, string>();
    private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>();
    [SerializeField]  
    //if i the player eat some powerful pill has some effect
    //listen listener register
    public void Subscribe<T>(Action<T> del)
    {
        if (delegates.ContainsKey(typeof(T)))
        {
            delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)], del);

        }
        else
        {
            delegates[typeof(T)] = del;
        }
    }

    //listener can unregister
    public void UnSubscribe<T>(Action<T> del)
    {
        if (!delegates.ContainsKey(typeof(T))) return;
        delegates[typeof(T)] = Delegate.Remove(delegates[typeof(T)],del);

        //remove之后剩下的给currentDel
        var currentDel = Delegate.Remove(delegates[typeof(T)],del);

        if (currentDel == null)
            delegates.Remove(typeof(T));
        else
            delegates[typeof(T)] = currentDel;
        

    }

    //all listener can invoke the methods;
    public void Publish<T>(T t)
    {
        if (t == null)
        {
            Debug.Log($"Invalid event argument");
            //debug .log ($invalid event argument:{e.gettype()}")

        }
        if (delegates.ContainsKey(t.GetType()))
            delegates[typeof(T)].DynamicInvoke(t);
           

    }

}

