using UnityEngine;

public class RonController {

    private GameObject ronCharacter;
    private Animator ronAnimator;
    private float moveSpeed = 1.0f;

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
        // 1, 先把原来的角色从界面上隐藏掉
        this._removeOldCharacter();

        // 2, 注册信息
        this._registerInputEvent();

        string name = "RonAniGameObject";
        this.ronCharacter = Resources.Load("RonAniGameObject") as GameObject;
        GameObject parent = GameObject.Find("GameManager");
        if(parent != null)
        {
            this.ronCharacter = GameObject.Instantiate(this.ronCharacter);
            this.ronCharacter.name = name;
            this.ronCharacter.transform.parent = parent.transform;
            Debug.Log($"Ron startGame ==> {this.ronCharacter.name}, parent ==> {this.ronCharacter.transform.parent.name}");   
        }
        
        Animator animator = this.ronCharacter.GetComponent<Animator>();
        animator.SetBool("isRun", true);
        this.ronAnimator = animator;
    }


    /// <summary>
    /// 先把对方的主角隐藏掉 
    /// </summary>
    private void _removeOldCharacter()
    {
        GameObject character = GameObject.Find("Character");
        character.SetActive(false);
    }


    /// <summary>
    /// 
    /// </summary>
    private void _registerInputEvent()
    {
        PlayerController.Instance.wInputAction += this.wInputEvent;
        PlayerController.Instance.aInputAction += this.aInputEvent;
        PlayerController.Instance.sInputAction += this.sInputEvent;
        PlayerController.Instance.dInputAction += this.dInputEvent;

        PlayerController.Instance.UpArrowAction += this.upArrowActionEvent;
        PlayerController.Instance.DownArrowAction += this.downArrowActionEvent;
        PlayerController.Instance.LeftArrowAction += this.leftArrowActionEvent;
        PlayerController.Instance.RightArrowAction += this.rightArrowActionEvent;
    }

    /// <summary>
    /// 
    /// </summary>
    private void wInputEvent()
    {
        this.ronCharacter.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    private void aInputEvent()
    {
        this.ronCharacter.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 
    /// </summary>
    private void sInputEvent()
    {
        this.ronCharacter.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }


    /// <summary>
    /// 
    /// </summary>
    private void dInputEvent()
    {
        this.ronCharacter.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }


    /// <summary>
    /// 
    /// </summary>
    private void upArrowActionEvent()
    {

    }


    /// <summary>
    /// 
    /// </summary>
    private void downArrowActionEvent()
    {

    }


    /// <summary>
    /// 
    /// </summary>
    private void leftArrowActionEvent()
    {

    }


    /// <summary>
    /// 
    /// </summary>
    private void rightArrowActionEvent()
    {

    }



}