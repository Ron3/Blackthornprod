using UnityEngine;
using System.Collections;

public class PosCtrl : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_end_obj = null;
	void OnGUI()
	{
		if (Input.GetMouseButton(0)) {
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);					
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))//函数是对射线碰撞的检测，这个out是什么意思？
			{
				m_end_obj.transform.position = hit.point;
			}
		}
	}
}
