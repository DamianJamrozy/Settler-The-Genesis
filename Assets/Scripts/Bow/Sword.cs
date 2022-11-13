using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public static Sword Instance;

    [System.Serializable]
    public class SwordSettings
    {
        [Header("Sword Equip & UnEquip Settings")]
        public Transform EquipPos;
        public Transform UnEquipPos;
        public Transform UnEquipParent;
        public Transform EquipParent;
    }
    [SerializeField]
    public SwordSettings swordSettings;

    public bool isAttacking = false;
    public bool canAttack = true;

    
    void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag !="Player")
        {
            
            if(collision.gameObject.TryGetComponent<DamageEnemy>(out DamageEnemy damageEnemy) && isAttacking)
            {
                Debug.Log("xD");
                damageEnemy.TakeDamage();
            }
        }
        
    }

    public void EquipSword()
    {
        this.transform.position = swordSettings.EquipPos.position;
        this.transform.rotation = swordSettings.EquipPos.rotation;
        this.transform.parent = swordSettings.EquipParent;
    }

    public void UnEquipSword()
    {
        this.transform.position = swordSettings.UnEquipPos.position;
        this.transform.rotation = swordSettings.UnEquipPos.rotation;
        this.transform.parent = swordSettings.UnEquipParent;
    }
}
