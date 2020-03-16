using UnityEngine;
using System.Collections;

public class RendMega : MonoBehaviour {

	public Vector3 	  StartPosition = Vector3.zero;
	public Vector3	  FingerPosition = Vector3.zero;
	public Transform  SkillPosition = null;
	public Transform  SkillPositionForm = null;
	public GameObject m_kPath	   = null;
 	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update()
	{

		MyRenderPath();

	}

	public void MyRenderPath()
	{
		Vector3 v3FromPos 	=  SkillPosition.position;
		Vector3 v3TargetPos =  SkillPositionForm.position;
		Vector3 v3MidPos    = (v3FromPos + v3TargetPos)/2;

		v3MidPos+=new Vector3(0,1,0);

		Vector3 V3Midvect = (v3TargetPos - v3FromPos)/4;


		Vector3 v3FromAnchorIn   = 	v3FromPos+new Vector3(0,-(v3MidPos.y/3),0) ;
		Vector3 v3FromAnchorOut  = 	v3FromPos+new Vector3(0,(v3MidPos.y/3),0)  ;

		Vector3 v3TarGetAnchorIn  = v3TargetPos +new Vector3(0,(v3MidPos.y/3),0) ;
		Vector3 v3TarGetAnchorOut = v3TargetPos +new Vector3(0,-(v3MidPos.y/3),0) ;

		Vector3 v3MidAnchorIn 	  =	v3MidPos - V3Midvect;
		Vector3 v3MidAnchorOut 	  =	v3MidPos + V3Midvect ;



		m_kPath.GetComponent<MegaShapeArc>().SetKnotEx(0,0,v3FromPos,v3FromAnchorIn,v3FromAnchorOut);
		m_kPath.GetComponent<MegaShapeArc>().SetKnotEx(0,1,v3MidPos,v3MidAnchorIn,v3MidAnchorOut);
		m_kPath.GetComponent<MegaShapeArc>().SetKnotEx(0,2,v3TargetPos,v3TarGetAnchorIn,v3TarGetAnchorOut);

	}




}
