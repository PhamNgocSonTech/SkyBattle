using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //tốc độ di chuyển của E
    [SerializeField] private float moveSpeed;

    //các điểm E di chuyển
    [SerializeField] private Transform[] wayPoints;

    //chỉ số điểm hiện tại
    private int currentWayPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //điểm tiếp theo
        int nextWayPoint = currentWayPointIndex+ 1;
        
        //điểm tiếp theo vượt độ dài của mảng chứa các điểm, thì reset về 0
        if (nextWayPoint > wayPoints.Length - 1)
            nextWayPoint = 0;


        //di chuyển tuyến tính Enemy đến điểm đích

                                                 //vị trí hiện tại   //điểm đích                       //khoảng cách tối đa
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextWayPoint].position, moveSpeed * Time.deltaTime);

        //nếu vị trí hiện tại = vị trí đích thì gán chỉ số hiện tại cho currentWayPointIndex (để enemy quay đầu lại điểm ban đầu)
        if (transform.position == wayPoints[nextWayPoint].position)
            currentWayPointIndex = nextWayPoint;

        Debug.Log("Transform Position: " + transform.position);

        Debug.Log("WayPoints[" + nextWayPoint + "].position: " + wayPoints[nextWayPoint].position);

        Debug.Log("Current WayPoint: " + currentWayPointIndex);

        //lấy vị trí cuối - vị trí hiện tại để tính độ dài quãng đường
        Vector3 direction = wayPoints[nextWayPoint].position - transform.position;
        //Debug.Log("Direction: " + direction);

        //tính góc đo giữa 2 vector =                         //đổi từ Rad sang Độ
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log("Angle: " + angle);

        //Vector3.forward đại diện cho Vector3(0, 0, 1).
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
