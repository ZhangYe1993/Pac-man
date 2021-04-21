using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DelegateExamples : MonoBehaviour
{
    // Start is called before the first frame update

        //DELEGATES are convertes to classes by the compiler
        //and since they'are classes , we can creat new objects;

    private delegate void MeDelegate();
    private MeDelegate testdelegate;
    private delegate bool MedelegateTakeIntReturnBool(int number);
    private delegate bool MedelegatelessthanFive(int i);

    private delegate int MeDelegateReturnInt();
    private delegate T MeDelegateGeneric<T>();

    private Action myaction;

    //两者传的参数一定要一样，才可以用delegate 来调用另外的methods;
    //reference them, assign the veriable 
    //allow us to methods another ,can referrence anther methods ,passerd anther methods to ,
    //将一个方法传到另一个方法，将方法作为参数或者变量在另一个方法中
public void OnEnable()
    {
        //MeDelegate meDelegate = new MeDelegate(Foo);
        //meDelegate.Invoke();
        //meDelegate();

        //MeDelegate meDelegate1 = Goo;
        //// if we write this ,the compiler will replace this with an invoke call
        ////we not invoke foo here ,we're just passing it..

        ////this is shorthans sugar
        //meDelegate1();

        //// when this is compiles ,we will get a new medelegate.,and it's invoke method will be calles
        ////with delegates ,we are able to treat methods like first class objects
        ///
        MedelegateTakeIntReturnBool medel = FooTakeInt;

        ////the same reason we parameterize this ,is why we parameterize code ,or reference to code (_methods /functions)
        //var resultlessthanfive = GetallthenumbersLessThanFive(new List<int>() { 1, 2, 10, 58, 56, 204, });
        //foreach(var number in resultlessthanfive)
        //{

        //}
        ////list 后方可以在定义一个变量，来数出其中的数字
        //var resultlessthanTen = GetallthenumbersLessThanTen(new List<int>() { 20, 25, 10, 58, 56, 204, });
        //foreach (var number in resultlessthanTen)
        //{

        //}

        var numbers = new List<int> { 2, 30, 45, 62, 10, 12 };
       var numbersLessThanFive = RunNumbersThroughTheGauntlet(numbers, lessThanFive);



        MedelegatelessthanFive minigauntlet = lessThanFive;
        //this is great but we  still have to deal with making these methods
    
        //Lambads =>
       // var resultlessThanFive = RunNumbersThroughTheGauntlet(numbers, n => n < 5);

        var resultlessThanFive = numbers.Where(n => n < 5);
        //only have what we need   
        //take the lambads  if i create a lamba when i compile the programm it can automaticaly creat a methods for you;
        //add delegating and moving delegating
        //WE know we can assign delegate and create new objects/targets like this
        //MeDelegate meDelegate = MOO;
        //meDelegate = (MeDelegate)Delegate.Combine(meDelegate, (MeDelegate)BOO);
        //meDelegate = meDelegate + BOO;
        //meDelegate.Invoke();
        //meDelegate -= BOO;

        //their are no  targets for moo and sue,since they are static methods ,and are callled by themself;
        //foreach(var DEL in meDelegate.GetInvocationList())
        //{
        //    Debug.Log("");

        //}
        //what will get return;
        //only get the last value
        MeDelegateReturnInt meDelRetInt = ReturnFive;
        meDelRetInt += ReturnTen;
        var value = meDelRetInt();
        Debug.Log(value);

        foreach(var del in meDelRetInt.GetInvocationList())
        {
            Debug.Log(del.DynamicInvoke());
        }

        //we can also generify our delegate
        MeDelegateGeneric<int> meDelegate = ReturnFive;
        meDelegate += ReturnTen;

        //usually ,just like with generics ,we don't have to creat our own delegates, because we have actions and func
        //func have a return
        //Func<int> meFunc = ReturnFive;
        //meFunc += ReturnTen;

        //foreach(var f in meFunc.GetInvocationList())
        //{
        //    Debug.Log(f.DynamicInvoke());
        //}

        //actions have no return (return void)
        Action<int> meAct = TakeAnIntReturnVoid;
        //Action returnNothing = nothing;
        meAct(15);
        //big diffient between is act return nothing;

        //the difference between delegates and events...
        //an event is a delegates,with two restrictions, you can't assign them directly ,and you can't invoke them directly

        //myaction = ReturnTen;
       


    }
    private void TakeAnIntReturnVoid(int n)
    {
        Debug.Log(n);
    }
    private bool lessThanFive(int n)
    {
        return n < 5;
    }
    private int ReturnFive()
    {
        return 5;
    }

    private int ReturnTen()
    {
        return 10;
    }

    private List<int> RunNumbersThroughTheGauntlet(List<int> numbers, MedelegatelessthanFive gauntlet)
    {
        var gauntletSurivivors = new List<int>();
        foreach(var number in numbers)
        {
            if(gauntlet(number))
            {
                gauntletSurivivors.Add(number);
            }
        }
        return gauntletSurivivors;
    }

    //private bool 
    //private object GetallthenumbersLessThanTen(List<int> ints)
    //{
    //    foreach (var number in ints)
    //    {
    //        if (number < 10)
    //        {
    //            numberslessThanTen.Add(number);
    //        }
    //    }
    //}

    //private List<int> GetallthenumbersLessThanFive(List<int> ints)
    //{
    //    var numberslessThanFive = new List<int>();
    //    foreach(var number in ints)
    //    {
    //        if(number<5)
    //        {
    //            numberslessThanFive.Add(number);
    //        }
    //    }

    //}





    //private float getthenumber(float i)
    //{

    //}
    private void MOO()
    {
        Debug.Log("Mooooo");
    }
    private void BOO()
    {
        Debug.Log("BOOOOO");
    }
    private float Square(float i)
    {
        return i * i;
    }

    private void Foo()
    {
        Debug.Log("FOO!");

    }
    //signature should match
    private static void Goo()
    {
        Debug.Log("GOO!");
    }

    private bool FooTakeInt(int number)
    {
        Debug.Log("foo return int!");
        return false;
    }

    private void ATrainsComing()
    {
        Debug.Log("ewwwwwwwwww");
    }
}
public class TrainSingal
{
    public event Action TrainsComing;
    public void HereComesATrain()
    {
        if(TrainsComing != null)
        {
            TrainsComing.Invoke();
        }
    }
}

