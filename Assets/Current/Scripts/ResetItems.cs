using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetItems : MonoBehaviour
{
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;

    public void Reset()
    {
            item1.transform.position =  item1.GetComponent<Item>().origin;
            item1.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            item2.transform.position =  item2.GetComponent<Item>().origin;
            item2.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            item3.transform.position =  item3.GetComponent<Item>().origin;
            item3.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }

}
