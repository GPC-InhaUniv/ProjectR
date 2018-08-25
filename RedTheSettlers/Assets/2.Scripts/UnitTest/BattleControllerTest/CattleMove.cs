using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTheSettlers.UnitTest
{
    public class CattleMove : MonoBehaviour
    {
        public GameObject Cattle;
        
        public void SpawnCattle()
        {

            Quaternion angle = Quaternion.Euler(0f, Random.Range(0,360f), 0f);
            GameObject tempCow = Instantiate(Cattle);
            tempCow.transform.position = new Vector3(0f, 0f, 0f);
            tempCow.transform.rotation = angle;
            tempCow.GetComponent<Rigidbody>().AddForce(Vector3.forward);
        }
    }
}