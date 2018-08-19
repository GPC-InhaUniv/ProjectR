using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITradeTest : MonoBehaviour {

    public RectTransform MovingObject;
    public RectTransform BasisObject;
    public Camera cam;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveObject();
        }
       
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = BasisObject.position.z;
        MovingObject.position = cam.ScreenToWorldPoint(pos);
    }


}
