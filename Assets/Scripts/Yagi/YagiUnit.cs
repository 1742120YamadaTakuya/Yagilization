using System.Collections;
using System.Collections.Generic;
using General;
using UnityEngine;
using UnityEngine.UI;

public class YagiUnit {
    public int YagiNum { get; private set;}//ヤギの数
    public int OwnerNo { get; private set;}//所有者のNo
    public PlaneDirection MovePlaneDirection { get; private set;}//今の移動方向
    public CellPosition myPosition { get; private set; }//今のってるセル

    public YagiUnit(int yagi_num, int owner_no, PlaneDirection move_plane_direction, CellPosition my_position) {
        YagiNum = yagi_num;
        OwnerNo = owner_no;
        MovePlaneDirection = move_plane_direction;
        myPosition = my_position;
    }
}
