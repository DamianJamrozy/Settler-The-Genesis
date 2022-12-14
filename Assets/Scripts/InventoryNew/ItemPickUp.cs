using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    public float maxDistance = 5;
    public Camera cam;
    public Transform Player;

    private float speed;

    public void Update()
    {
        StartCoroutine(CalculateSpeed());
    }

    IEnumerator CalculateSpeed()
    {
        Vector3 oldPosition = Player.position;
        yield return new WaitForFixedUpdate();
        speed = (oldPosition - Player.position).magnitude / Time.deltaTime;
    }

    public void PickUp()
    {
        Destroy(gameObject);
        InventoryManager.Instance.Add(Item);
    }

    private void OnMouseDown()
    {
        if(speed < 1)
        {
            float distance = Vector3.Distance(this.transform.position, Player.position);
            if(distance < maxDistance)
            {
                float dist = this.transform.position.y - Player.position.y;
                if(dist >= 0.2)
                    Controller.Instance.playPick(false);
                else
                    Controller.Instance.playPick(true);
                Invoke(nameof(PickUp), 1f);
            }
        }else
            return;
            
        
    }

}
