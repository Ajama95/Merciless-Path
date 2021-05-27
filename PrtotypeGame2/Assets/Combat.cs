using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator Animator;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemeylayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }

    void attack()
    {
        Animator.SetTrigger("Attack");
        Collider[] hitenemies = Physics.OverlapSphere(attackpoint.position, attackrange, enemeylayer);
        foreach(Collider enemy in hitenemies)
        {
            enemy.GetComponent<Enemy_patrolling>().alive = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
