using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    //Unity �Զ�������������õ����л�
    //����Ҫ�Լ����ã������ڙz�����Y����
    //����ע��
    //����ע��2
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        //�o���C��λ���xֵ
    }
}
