using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public int num;
    public Emit EmitDisk;
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Disk")
        {
            EmitDisk = (Emit)other.gameObject.GetComponent<DiskData>().action;
            EmitDisk.Destory();
        }
    }
}