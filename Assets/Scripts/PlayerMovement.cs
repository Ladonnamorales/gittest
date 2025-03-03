using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    //創建引用變量

    [SerializeField] private LayerMask JumpableGround;
    //这个变量用于存储可以跳跃的地面层（LayerMask），用于 Physics2D.BoxCast 进行地面检测

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    //創建移動速度變量

    private enum MovementState { idle, running, jump, falling };
    //創建枚舉以判斷人物狀態,枚舉是值類型的變量 enum是自定义数据类型 類似於class，定義了一個枚舉

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //得到對象裏的組件内容
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        //創建浮點型變量並用自帶的方法得到橫向的數據

        rb.linearVelocity = new Vector2(dirX*moveSpeed,rb.linearVelocity.y);
        //橫向移動，速度計算

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
        }
        //縱向移動，如果按下jump綁定的按鍵

        UpdateAnimationState();
        //在update方法裏使用更新動畫狀態方法
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        //實例化，創建枚舉值對象變量 这里创建了一个 MovementState 类型的变量 state，但它默认没有初始化值

        if (dirX > 0f)
        {
            state = MovementState.running;
            //用動畫機裏的設置布爾值方法設置running的狀態
            sprite.flipX = false;
            //設置渲染器裏x軸的翻轉bool值
        }

        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else 
        {
            state = MovementState.idle;
        }

        if (rb.linearVelocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if(rb.linearVelocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state); //将 state 的值转换成整数，赋值给 Animator 的 "state" 参数
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(
            coll.bounds.center, //碰撞盒子的中心
            coll.bounds.size,   //碰撞盒子的大小 .bounds.size 代表碰撞体的宽度和高度,用这个作为 BoxCast 的大小，保证射线检测的范围等于角色的碰撞体大小
            0f,                 //旋轉角度(2D一般為0)
            Vector2.down,       //施加射綫的方向(向下)
            .1f,                //射綫長度(距離) 这个值决定射线检测的深度 0.1f 代表 稍微低于角色碰撞体的距离，防止误判
            JumpableGround);    //只檢測可跳躍地面
    }
    //通过 Physics2D.BoxCast 进行碰撞检测,
    //BoxCast 允许在一个矩形区域进行射线检测，比 Raycast 更适合角色检测地面
    //Physics2D.BoxCast(中心点, 盒子大小, 旋转角, 方向, 检测距离, 检测层)
}
