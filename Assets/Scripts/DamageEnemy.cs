using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

    public Enemy enemy;
    public float maxDistance = 5;
    public Camera cam;
    public static DamageEnemy Instance;

    public float health;

    void Awake()
    {
        health = enemy.health;
        Instance = this;
    }

    void Update()
    {

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.transform.TryGetComponent(out DamageEnemy enemy))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    TakeDamage();
                }
            }
        }
    }

    public void TakeDamage()
    {
        health -= Controller.Instance.damage;

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }

    // private void OnMouseDown()
    // {
    //     TakeDamage();
    // }


}
