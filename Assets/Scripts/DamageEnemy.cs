using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

    public Enemy enemy;
    public float maxDistance = 5;
    public Camera cam;
    public static DamageEnemy Instance;
    Animator anim;
    private UnityEngine.AI.NavMeshAgent _agent;
    public GameObject pref;

    public bool canAttack;

    public float health;

    void Awake()
    {
        health = enemy.health;
        Instance = this;
        anim = GetComponent<Animator>();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if(Controller.Instance.sword.activeInHierarchy)
        {
            canAttack = true;
        }else
        {
            canAttack = false;
        }
        Debug.Log(health);
        
    }

    public void TakeDamage()
    {
        
    }

    public void TakeDamageSword()
    {
        RaycastHit hit2;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit2, maxDistance))
        {
            if(hit2.transform.TryGetComponent<DamageEnemy>(out DamageEnemy enemy))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    health -= Controller.Instance.damage;

                    if(health <=0)
                    {
                        anim.SetBool("isDead", true);
                    }
                }
            }
        }
    }

    // private void OnMouseDown()
    // {
    //     TakeDamage();
    // }


}
