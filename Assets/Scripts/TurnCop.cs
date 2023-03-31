using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCop : MonoBehaviour
{
    public GameObject copParent;
    public Vector3 newCopPos;
    public Vector3 newCopRot;

    // Start is called before the first frame update
    void Start()
    {
        copParent.transform.position = newCopPos;
        copParent.transform.rotation = Quaternion.Euler(newCopRot);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
