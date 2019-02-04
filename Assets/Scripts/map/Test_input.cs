
 // Input確認用のコードです
 // 一応置いておきますがいらないので後で消します


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_input : MonoBehaviour
{
    Vector3 movement;
    public CameraManager camMng;
    float scr;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            doSplit(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            doSplit(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)){
            doSplit(5);
        }

        scr = Input.GetAxis("Mouse ScrollWheel");

        camMng.scaleCamera(scr);


        movement = new Vector2(0.0f, 0.0f);

        if (Input.GetKey(KeyCode.LeftArrow)){
            movement.x -= 10.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            movement.x += 10.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            movement.y -= 10.0f;
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            movement.y += 10.0f;
        }

        camMng.moveCamera(movement);
        

    }

    private void doSplit(int n)
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < obj.Length; i++)
        {
            Cell cell = obj[i].GetComponent<Cell>();
            cell.split(n);
        }
            
    }
}
