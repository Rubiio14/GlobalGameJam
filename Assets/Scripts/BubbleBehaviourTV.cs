using UnityEngine;

public class BubbleBehaviourTV : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _movSpeed = 2.5f;
    public int currentWaypoint = 0;



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
        if (currentWaypoint >= _waypoints.Length)
        {
            Debug.Log("Se han recorrido todos los waypoints. Desactivando la burbuja.");
            this.gameObject.SetActive(false);
            //Empezar Cinemática
        }
    }
}
