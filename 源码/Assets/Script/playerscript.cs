using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { none,left,right,up,down,}
public enum Position { left,right,mid,}

public class playerscript : MonoBehaviour {
    public int moveSpeed = 5;
    public Direction curDirection = Direction.none;
    public Position standPos = Position.mid;
    public Position beforStandPos;
    
    public Vector3  moveDirection=Vector3.zero;
    public Vector3 VectorX = Vector3.zero;

    public CharacterController charactercontroller;
	// Use this for initialization
	void Start () {
		  
	}
	
	// Update is called once per frame
	void Update () {
        if (Wndmanage._instance.isAlive)
        {

            //transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
            GetDirecction();
            MoveHorizontal();

            MoveForward();

            moveDirection.z = moveSpeed;
            moveDirection.y -= 10 * Time.deltaTime;
            charactercontroller.Move((VectorX * 5 + moveDirection) * Time.deltaTime);
        }
        else {
            moveSpeed = 0;
        }
        
	}
    void GetDirecction() {

        curDirection = Direction.none;

        if (Input.GetMouseButtonUp(0))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            Debug.Log("x:" + x);
            Debug.Log("y:" + y);

            float value = Mathf.Abs(x) - Mathf.Abs(y);
            Debug.Log("value :" + value);
            //如果x的绝.对值大于y的绝对值
            if (value > 0)
            {
                if (x > 0)
                {
                    curDirection = Direction.left;
                    Debug.Log("left");
                }
                if (x < 0)
                {
                    curDirection = Direction.right;
                    Debug.Log("right");
                }

            }
            else if (value < 0)
            {
                Debug.Log("Mathf.Abs(x) < Mathf.Abs(y)");
                if (y > 0)
                {
                    curDirection = Direction.up;
                    Debug.Log("up");
                }
                if (y < 0)
                {
                    curDirection = Direction.down;
                    Debug.Log("down");
                }

            }


        }

        if (Input.GetKeyDown("s")) {
            curDirection = Direction.down;
            Debug.Log("down");
        }
        if (Input.GetKeyDown("w"))
        {
            curDirection = Direction.up;
            Debug.Log("up");
        }
        if (Input.GetKeyDown("a"))
        {
            curDirection = Direction.left;
            Debug.Log("left");
        }
        if (Input.GetKeyDown("d"))
        {
            curDirection = Direction.right;
            Debug.Log("right");
        }
    }
    /// <summary>
    /// 水平注释
    /// </summary>

    void MoveHorizontal(){
        //向左移动
        if(curDirection==Direction.left){
            MoveLeft();
        }
        //向右移动
        if (curDirection == Direction.right)
        {
            MoveRight();
        }

        //超出右边的道路界限
        if (standPos == Position.left) {
            if (transform.position.x <= -1.7f) {
                VectorX = Vector3.zero;
                transform.position = new Vector3(-1.7f,transform.position.y,transform.position.z);
            }
        }
        //超出中间的道路界限
        if (standPos == Position.mid)
        {
            if (transform.position.x >= 0 || transform.position.x <= 0)
            {
                VectorX = Vector3.zero;
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
        }
        //超出左边的道路界限
        if (standPos == Position.right)
        {
            if (transform.position.x >= 1.7f)
            {
                VectorX = Vector3.zero;
                transform.position = new Vector3(1.7f, transform.position.y, transform.position.z);
            }
        }
      
    }

    void MoveLeft(){
        
        if (standPos != Position.left) {
           //向左的力
            VectorX = Vector3.left;
            PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.PlayJumpLeft;

            if (standPos == Position.mid){
                standPos = Position.left;
                beforStandPos = Position.mid;
            }
            if (standPos == Position.right)
            {
                standPos = Position.mid;
                beforStandPos = Position.right;
            }

        }
    }

    void MoveRight()
    {
        //向右的力
        if (standPos != Position.right)
        {
            PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.PlayJumpRight;

            VectorX = Vector3.right;

            if (standPos == Position.mid)
            {
                standPos = Position.right;
                beforStandPos = Position.mid;
            }
            if (standPos == Position.left)
            {
                standPos = Position.mid;
                beforStandPos = Position.left;
            }

        }
    }

    void MoveForward() {
        if (curDirection == Direction.down) {
            PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.PlayJumpRoll;
        }

        if (charactercontroller.isGrounded) { //在地面上
            moveDirection=Vector3.zero;
            if (curDirection == Direction.up)
            {
                PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.PlayJumpUp;
                moveDirection.y += 7;
            }

        }else{//在地面上
            //2连跳
            if (curDirection == Direction.up)
            {
                PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.PlayJumpUp;
                moveDirection.y += 7;
            }
            //快速下落
            if (curDirection == Direction.down)
            {
                PlayerAnimation._instatnce.animationUpdate = PlayerAnimation._instatnce.PlayJumpDown;
                moveDirection.y -= 10;
            }
        }
    }
}
