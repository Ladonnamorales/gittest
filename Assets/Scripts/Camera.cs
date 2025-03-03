using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    //Unity 自动处理了组件引用的序列化
    //不需要自己引用，可以在檢查器裏引用
    //测试注释
    //测试注释2
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        //給相機的位置賦值
    }
}
