using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private enum AnimationKeys
    {
        Walking
    }

    private NavMeshAgent _agent;
    private Animator _animator;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                _agent.SetDestination(hit.point);
                _animator.SetBool(AnimationKeys.Walking.ToString(), true);
            }
        }

        if (!_agent.pathPending && _agent.remainingDistance < 0.1f)
        {
            _animator.SetBool(AnimationKeys.Walking.ToString(), false);
        }
    }
}
