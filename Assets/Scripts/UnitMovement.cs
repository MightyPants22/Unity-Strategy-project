using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    Camera cam;
    UnityEngine.AI.NavMeshAgent agent;
    public LayerMask ground;

    public bool isCommandToMove;

    private void Start()
    {
    cam = Camera.main;
    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                isCommandToMove = true;
                agent.SetDestination(hit.point);
            }
        }
        //Agent reached destination
        if (agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance)
        {
            isCommandToMove = false;
        }
    }

}
