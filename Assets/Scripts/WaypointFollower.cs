using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //創建路徑點的數組
    private int currentWaypointIndex = 0; //索引

    [SerializeField] private float speed = 2f; //速度

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) //檢測是否到達第一個點
        {
            currentWaypointIndex++; //切換到下一個點
            if (currentWaypointIndex >= waypoints.Length) //如果到達路徑點的末尾
            {
                currentWaypointIndex = 0; //切換到起點
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        //用movetowards方法移動
        //Time.deltaTime * speed 主要用于 确保移动速率不受帧率影响
    }

}
