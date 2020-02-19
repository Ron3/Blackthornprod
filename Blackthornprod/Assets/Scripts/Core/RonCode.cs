using UnityEngine;

public class RonController {

    private GameObject ronGo;

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
        string name = "RonAniGameObject";
        this.ronGo = Resources.Load("RonAniGameObject") as GameObject;
        GameObject parent = GameObject.Find("GameManager");
        if(parent != null)
        {
            this.ronGo = GameObject.Instantiate(this.ronGo);
            this.ronGo.name = name;
            this.ronGo.transform.parent = parent.transform;
            Debug.Log($"Ron startGame ==> {this.ronGo.name}, parent ==> {this.ronGo.transform.parent.name}");   
        }
        
        Animator animator = this.ronGo.GetComponent<Animator>();
        animator.SetBool("isRun", true);

        
    }
}