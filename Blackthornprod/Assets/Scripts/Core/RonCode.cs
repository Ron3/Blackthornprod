using UnityEngine;

public class RonController {

	private static RonController instance;
	public static RonController Instance {
		get {
			if(instance == null) {
				instance = new RonController();
			}
			return instance;
		}
	}
	private RonController() {}


    /// <summary>
    /// 当回车键按下
    /// </summary>
    public void OnEnterPress()
    {
            
    }

    
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void startGame()
    {
        GameObject ronGo = Resources.Load("RonAniGameObject") as GameObject;
        GameObject parent = GameObject.Find("GameManager");
        if(parent != null)
        {
            ronGo = GameObject.Instantiate(ronGo);
            ronGo.transform.parent = parent.transform;
            Debug.Log($"Ron startGame ==> {ronGo.name}, parent ==> {ronGo.transform.parent.name}");   
        }
        
    }
}