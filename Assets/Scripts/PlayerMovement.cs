using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    //��������׃��

    [SerializeField] private LayerMask JumpableGround;
    //����������ڴ洢������Ծ�ĵ���㣨LayerMask�������� Physics2D.BoxCast ���е�����

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    //�����Ƅ��ٶ�׃��

    private enum MovementState { idle, running, jump, falling };
    //����ö�e���Д������B,ö�e��ֵ��͵�׃�� enum���Զ����������� ����class�����x��һ��ö�e

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //�õ������Y�ĽM������
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        //�������c��׃���K���Ԏ��ķ����õ��M��Ĕ���

        rb.linearVelocity = new Vector2(dirX*moveSpeed,rb.linearVelocity.y);
        //�M���Ƅӣ��ٶ�Ӌ��

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,jumpForce);
        }
        //�v���Ƅӣ��������jump�����İ��I

        UpdateAnimationState();
        //��update�����Yʹ�ø��Ӯ���B����
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        //������������ö�eֵ����׃�� ���ﴴ����һ�� MovementState ���͵ı��� state������Ĭ��û�г�ʼ��ֵ

        if (dirX > 0f)
        {
            state = MovementState.running;
            //�ÄӮ��C�Y���O�ò���ֵ�����O��running�Ġ�B
            sprite.flipX = false;
            //�O����Ⱦ���Yx�S�ķ��Dboolֵ
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

        anim.SetInteger("state",(int)state); //�� state ��ֵת������������ֵ�� Animator �� "state" ����
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(
            coll.bounds.center, //��ײ���ӵ�����
            coll.bounds.size,   //��ײ���ӵĴ�С .bounds.size ������ײ��Ŀ�Ⱥ͸߶�,�������Ϊ BoxCast �Ĵ�С����֤���߼��ķ�Χ���ڽ�ɫ����ײ���С
            0f,                 //���D�Ƕ�(2Dһ���0)
            Vector2.down,       //ʩ����Q�ķ���(����)
            .1f,                //��Q�L��(���x) ���ֵ�������߼������ 0.1f ���� ��΢���ڽ�ɫ��ײ��ľ��룬��ֹ����
            JumpableGround);    //ֻ�z�y�����S����
    }
    //ͨ�� Physics2D.BoxCast ������ײ���,
    //BoxCast ������һ����������������߼�⣬�� Raycast ���ʺϽ�ɫ������
    //Physics2D.BoxCast(���ĵ�, ���Ӵ�С, ��ת��, ����, ������, ����)
}
