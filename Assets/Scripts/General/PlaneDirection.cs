using System;
using UnityEngine;

namespace General{
	[Serializable]
	public enum PlaneDirection{
		zero=0,right=1,left=-1,up=2,down=-2,Horizontal=10,Vertical=20
	}

	public static class DirectionEnumExtend{
		public static int GetSign(this PlaneDirection plane_direction){
			var dir_int = (int) plane_direction;
			return dir_int==0?0:Math.Sign(dir_int);
		}
		public static PlaneDirection GetCross(this PlaneDirection plane_direction){
			return (PlaneDirection)(Math.Abs((int)plane_direction) *10);
		}

		public static PlaneDirection GetReverse(this PlaneDirection plane_direction){
			return (PlaneDirection) ((int) plane_direction * -1);
		}
		public static Vector2 Convert2Vector(this PlaneDirection plane_direction){
			return plane_direction.GetCross() == PlaneDirection.Horizontal ?
				new Vector2(plane_direction.GetSign(),0) : new Vector2(0,plane_direction.GetSign());
		}
	}

	public static class DirectionUtil{
		public static PlaneDirection GetHorizontal(float x){
			return (PlaneDirection) Math.Sign(x);
		}
		public static PlaneDirection GetVertical(float x){
			return (PlaneDirection) (Math.Sign(x)*2);
		}
	}
}