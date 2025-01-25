using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _movSpeed = 2.5f;
    private int currentWaypoint = 0;

    void Start()
    {
        transform.position = _waypoints[currentWaypoint].position;
    }
    void Update()
    {
        if (transform.position != _waypoints[currentWaypoint].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[currentWaypoint].position, _movSpeed * Time.deltaTime);
        }
    }

    public void nextWaypoint()
    { 
        currentWaypoint++;
    }  
}
