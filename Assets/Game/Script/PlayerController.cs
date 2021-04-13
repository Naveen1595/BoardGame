using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    int wayPointIndex = 0;
    void Start()
    {
        gameObject.transform.position = waypoints[32].position;
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
        return waypoints[wayPointIndex-1].transform;
    }

    public Transform GetWayPointBack()
    {
        SetWayPointBack();
        return waypoints[wayPointIndex - 1].transform;
    }
    public int GetPoint()
    {
        return wayPointIndex;
    }

}
