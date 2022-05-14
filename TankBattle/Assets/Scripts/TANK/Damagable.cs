using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Damagable : MonoBehaviour
{
    public static Damagable instance;
    public int MaxHealth = 100;

    [SerializeField]
    private int health = 0;//máu hiện tại
                           // private float temDamage;
    public static bool isDie;
    private void Awake()
    {
        instance = this;
    }
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }


    public UnityEvent OnDead;//sự kiện khi chết
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;//sự kiện trúng đạn và hồi máu


    private void Start()
    {
       // temDamage = Bullet.instance.BulletData.damage;

        if (health == 0)
            Health = MaxHealth;

        
    }

    //phương thức trúng đạn
    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            isDie = true;
            OnDead?.Invoke();
            Debug.Log(isDie);
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    //phương thức này để hồi máu
    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        if(health>MaxHealth)
        {
            health = MaxHealth;
        }    
        //OnHeal?.Invoke();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KitHealth")
        {
            Heal(70);
            Destroy(collision.gameObject);
        }

        
    }

       

}
