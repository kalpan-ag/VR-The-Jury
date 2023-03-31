using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCustomer : MonoBehaviour
{
    public GameObject customerParent;
    public Vector3 newCustomerPos;
    public Vector3 newCustomerRot;

    // Start is called before the first frame update
    void Start()
    {
        customerParent.transform.position = newCustomerPos;
        customerParent.transform.rotation = Quaternion.Euler(newCustomerRot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
