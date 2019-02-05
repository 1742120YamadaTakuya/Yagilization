using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private const float WIDTH = 6400.0f;        // 全体マップの幅
    private const float HEIGHT = 3600.0f;       // 全体マップの高さ

    private const float CAM_SIZE_FIX = 600.0f;  // マウスホイールの移動量の補正倍率
    private const float CAM_MOVE_FIX = 0.5f;    // マウスの移動量の補正倍率

    [SerializeField]
    private float MAX_MG = 10.0f;               // カメラの最大倍率

    private float cam_size_max;                 // カメラのsize(描画範囲)の最大値
    private float cam_size_min;                 // カメラのsize(描画範囲)の最小値


    Camera cam;

    void Start()
    {
        cam_size_max = HEIGHT / 2.0f;
        cam_size_min = HEIGHT / 2.0f / MAX_MG;

        cam = Camera.main;
        cam.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, -100.0f);
        cam.orthographicSize = cam_size_max;

    }


    // void scaleCamera (float axis) - スクロールの値だけカメラの拡大縮小を行う
    public void scaleCamera(float axis)
    {
        cam.orthographicSize -= axis * CAM_SIZE_FIX;

        if(cam.orthographicSize < cam_size_min)
            cam.orthographicSize = cam_size_min;

        if (cam.orthographicSize > cam_size_max)
            cam.orthographicSize = cam_size_max;

        Vector2 position = cam.gameObject.transform.localPosition;
        fixPosition(position);
    }


    // void moveCamera (Vector2 movement) - 与えられた変化量だけカメラの移動を行う
    public void moveCamera(Vector2 movement)
    {
        movement *= CAM_MOVE_FIX * (cam.orthographicSize / cam_size_min);

        Vector3 position = cam.gameObject.transform.localPosition;

        position.x += movement.x;
        position.y += movement.y;
        position.z = -100.0f;

        fixPosition(position);

    }


    // void fixPosition(Vector2 position) - カメラが範囲外を映してないか確認し、映していたら修正してカメラ座標に反映させる
    private void fixPosition(Vector2 position)
    {
        
        if (position.x - cam.orthographicSize * (WIDTH / HEIGHT) < -WIDTH / 2.0f){
            position.x = -WIDTH / 2.0f + cam.orthographicSize * (WIDTH / HEIGHT);
        }
        else if (position.x + cam.orthographicSize * (WIDTH / HEIGHT) > WIDTH / 2.0f){
            position.x = WIDTH / 2.0f - cam.orthographicSize * (WIDTH / HEIGHT);
        }

        if (position.y - cam.orthographicSize < -HEIGHT / 2.0f){
            position.y = -HEIGHT / 2.0f + cam.orthographicSize;
        }
        else if (position.y + cam.orthographicSize > HEIGHT / 2.0f){
            position.y = HEIGHT / 2.0f - cam.orthographicSize;
        }

        cam.gameObject.transform.localPosition = new Vector3(position.x, position.y, -100.0f);
    }


}
