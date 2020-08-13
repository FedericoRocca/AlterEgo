using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;
    bool pressed = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }

        if (pressed)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(hit.point, path);
                if (path.status == NavMeshPathStatus.PathPartial || path.status == NavMeshPathStatus.PathComplete)
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}