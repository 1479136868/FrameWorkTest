using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParentMove : MonoBehaviour
{
    public float moveSpeed = 10;//移动速度（父物体）
    public float jumpHeight = 5;//跳跃高度
    public float aSpeed = -9.8f;//重力加速度

    private Vector2 direction;//移动方向（父物体，xy轴平面）
    private bool isJump = false;//跳跃状态
    public bool isAttack = false;//攻击状态
    private float velocity_Y;//跳跃速度(子物体)

    private Animator ani;//动画控制器(子物体)
    private Rigidbody2D rig;//刚体组件(父物体)

    public Transform childTransform;//Transform组件(子物体)
    void Start()
    {
        ani = GetComponentInChildren<Animator>();//初始化获得子物体的动画控制器
        rig = GetComponent<Rigidbody2D>();//初始化获得自身的刚体组件
        childTransform = transform.Find("Model");
    }

    public void MoveUpdate()
    {
        direction.x = Input.GetAxisRaw("Horizontal");//获取键盘x轴输入，赋值给移动方向的x值
        direction.y = Input.GetAxisRaw("Vertical") * 0.7f;//获取键盘x轴输入，赋值给移动方向的x值(*0.7是因为视觉效果，向里走要慢一点，可根据实际效果改变)
    }


    public void PlayerSkillInput()
    {
        //检测键盘跳跃键输入并且跳跃状态为false
        if (Input.GetKeyDown(KeyCode.C) && !isJump && !isAttack)
        {
            isJump = true;//跳跃状态赋值为true
            ReadyJump();//执行准备跳跃方法
        }

        //检测键盘攻击键输入并且攻击状态为false
        if (Input.GetKeyDown(KeyCode.X) && !isAttack && !isJump)
        {
            isAttack = true;//攻击状态赋值为true
            MessManager.GetInstance().SendMes("Attack","1");
        }
    }

    //之所以在FixUpdate里面执行移动和跳跃方法，是因为父物体移动用的是刚体的Velocity方法，子物体跳跃虽然是用Transform，但是为了跳跃时配合移动不出现卡顿，也放在FixUpdate里面执行
    private void FixedUpdate()
    {
        if (isAttack) direction = new Vector2(0, 0);

        Move();//移动方法(父物体)
        Jump();//跳跃方法(子物体)
        Anima();//执行动画控制方法
    }

    void Move()
    {
        rig.velocity = direction * moveSpeed * 50 * Time.fixedDeltaTime;//父物体沿移动方向移动
        if (rig.velocity.x >= 0.05)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);//如果速度向右不翻转
        }
        else if (rig.velocity.x <= -0.05)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0); //如果速度向左翻转180°
        }
    }

    void Jump()
    {
        velocity_Y += aSpeed * Time.fixedDeltaTime;//重力模拟(子物体垂直速度始终受重力加速度影响)
        //判断子物体是在下落状态(velocity小于零)并且距离父物体小于等于0.05
        if (childTransform.position.y <= transform.position.y + 0.05f && velocity_Y < 0)
        {
            //如果满足
            velocity_Y = 0;// 子物体垂直速度清零
            childTransform.position = transform.position;//子物体position与父物体对齐
            //检测是否对齐，理论上多此一举，但是之前有遇到过位置不准确的情况，所以加一个双保险
            if (childTransform.position == transform.position)
            {
                //满足位置对齐
                isJump = false;//则将跳跃状态设置为false，等待下一次跳跃
            }
        }
        childTransform.Translate(new Vector3(0, velocity_Y) * Time.fixedDeltaTime);//子物体按照速度移动
    }

    void ReadyJump()
    {
        velocity_Y = Mathf.Sqrt(jumpHeight * -2f * aSpeed);
    }

    void Anima()
    {
        ani.SetFloat("Velocity", velocity_Y);
        ani.SetBool("isJump", isJump);

        if (!isJump)
        {
            if (Mathf.Abs(rig.velocity.x) >= 0.05 || Mathf.Abs(rig.velocity.y) >= 0.05)
            {
                ani.SetBool("Running", true);
            }
            else ani.SetBool("Running", false);
        }
        else
        {
            ani.SetBool("Running", false);
        }
        if (isAttack)
        {
            ani.SetBool("isAttack", true);
        }


    }
}
