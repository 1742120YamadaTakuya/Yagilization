using System.Runtime.CompilerServices;
using General;
using UnityEngine;

namespace Relay {
    public class Ui2Yagi : MonoBehaviour {
        //クリック地点に　（上）何もない（下）ある（適宜数値弄って
        public YagiUnit Click(Vector2 world_position) {
            //return null;
            return new YagiUnit(0,0,PlaneDirection.zero,null);
        }
        
        //方向指定する。停止の時はzeroを渡す
        public void SetDirection(YagiUnit yagi_unit, PlaneDirection plane_direction) {
            
        }
        
    }
}