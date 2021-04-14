using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    int wayPointIndex = 0;
    void Start()
    {
        gameObject.transform.position = waypoints[0].position;
    }

    void SetWayPoint()
    {
        wayPointIndex += 1;
    }

    public void SetWayPointBack()
    {
        wayPointIndex -= 1;
    }
 
    public Transform GetWayPoint()
    {
        SetWayPoint();
        return waypoints[wayPointIndex].transform;
    }

    public Transform GetWayPointBack()
    {
        SetWayPointBack();
        return waypoints[wayPointIndex].transform;
    }
    public int GetPoint()
    {
        return wayPointIndex;
    }

}
