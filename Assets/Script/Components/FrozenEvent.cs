using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenEvent : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("eat it!");
            Destroy (gameObject);


        }
        

    }


  void OnTriggerExit(Collider other)
    {
        print("leave me ");
    }

    public void  TimeStop()
    {
        //if(isStopping == true)
        //{

        //}
    }




}
