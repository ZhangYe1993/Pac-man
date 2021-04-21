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
        private readonly Dictionary<Type, Delegate> delegates = new Dictionary<Type, Delegate>(); 

        public void Subscribe<T>(Action<T> del)
    {
        if(delegates.Containskey(typeof(T))) 
        {
            delegates[typeof(T)] = Delegate.Combine(delegates[typeof(T)], del);

        }
        else
        {
            delegates[typeof(T)] = del;
        }
    }

    public void UnSubscribe<T>(Action<T> del)
    {
  
        delegates[typeof(T)] = Delegate.Remove(delegates[typeof(T)]),del);

    }

    public void Publish<T>(T t)
    {
        if(t = null)
        {
            Debug.log($"Invalid event argument");
            //debug .log ($invalid event argument:{e.gettype()}")

        }
        if(delegates.Containskey(t.gettype))
        return;

    }
    
    }

