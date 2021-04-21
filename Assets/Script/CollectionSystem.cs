using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public PacMan Player;

    private void OnEnable()
    {

        Evently.Instance.Subscribe<CollectionEvent>(OnCollectionEvent);
     

    }

    private void OnDisable()
    {
        Evently.Instance.UnSubscribe<CollectionEvent>(OnCollectionEvent);

    }

    //collection event that's the key
    private void OnCollectionEvent(CollectionEvent evt)
    {
        Debug.Log("we collect something!");
    }

 
}
    public  class CollectionEvent

    {

    }
