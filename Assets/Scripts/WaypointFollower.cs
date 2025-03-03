using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //����·���c�Ĕ��M
    private int currentWaypointIndex = 0; //����

    [SerializeField] private float speed = 2f; //�ٶ�

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) //�z�y�Ƿ��_��һ���c
        {
            currentWaypointIndex++; //�ГQ����һ���c
            if (currentWaypointIndex >= waypoints.Length) //������_·���c��ĩβ
            {
                currentWaypointIndex = 0; //�ГQ�����c
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        //��movetowards�����Ƅ�
        //Time.deltaTime * speed ��Ҫ���� ȷ���ƶ����ʲ���֡��Ӱ��
    }

}
