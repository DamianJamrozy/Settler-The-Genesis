using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpWithOutEquip : MonoBehaviour
{
    public float maxDistance = 5;
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

    public void PickUp1()
    {
        Destroy(gameObject);
        Quest1.Instance.inQuestCounter = 2;
    }

    public void PickUp2()
    {
        Destroy(gameObject);
        Quest2.Instance.tomatoCounter += 1;
    }

    private void OnMouseDown()
    {
        if(Quest1.Instance.inQuestCounter == 1)
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
                            Invoke(nameof(PickUp1), 1f);
                        }
                    }else
                        return;
        }else if(Quest2.Instance.inQuestCounter == 1)
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
                            Invoke(nameof(PickUp2), 1f);
                        }
                    }else
                        return;
        }else return;;
    }

}
