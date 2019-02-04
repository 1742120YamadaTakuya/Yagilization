using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public const float CAM_SIZE_MAX = 1800.0f;  // カメラのsize(描画範囲)の最大値 等倍ズーム(マップ全体が写る)
    public const float CAM_SIZE_MIN = 360.0f;   // カメラのsize(描画範囲)の最小値  8倍ズーム
    public const float CAM_SIZE_MG = 600.0f;    // カメラのsize(描画範囲)の変化倍率

    public const float CAM_MOVE_MG = 1.0f;    // カメラの移動量の変化倍率

    public const float WIDTH = 6400.0f;         // 全体マップの幅
    public const float HEIGHT = 3600.0f;        // 全体マップの高さ

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        cam.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, -100.0f);
        cam.orthographicSize = CAM_SIZE_MAX;
    }


    // void scaleCamera (float axis) - スクロールの値だけカメラの拡大縮小を行う
    public void scaleCamera(float axis)
    {
        cam.orthographicSize -= axis * CAM_SIZE_MG;

        if(cam.orthographicSize < CAM_SIZE_MIN)
            cam.orthographicSize = CAM_SIZE_MIN;

        if (cam.orthographicSize > CAM_SIZE_MAX)
            cam.orthographicSize = CAM_SIZE_MAX;

        Vector2 position = cam.gameObject.transform.localPosition;
        fixPosition(position);
    }


    // void moveCamera (Vector2 movement) - 与えられた変化量だけカメラの移動を行う
    public void moveCamera(Vector2 movement)
    {
        movement *= CAM_MOVE_MG;

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
