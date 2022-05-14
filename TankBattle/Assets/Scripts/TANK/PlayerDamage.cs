using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    public static PlayerDamage instance;
    public int MaxHealth = 100;

    [SerializeField]
    private int health = 0;//máu hiện tại

    public static bool isBullet02;
    public int index;

    float timeDown = 10;

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
        index = 0;
        isBullet02 = false;
        if (health == 0)
            Health = MaxHealth;
    }

    //phương thức trúng đạn
    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            OnDead?.Invoke();
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
        if (health > MaxHealth)
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

        if (collision.gameObject.tag == "Bullet02")
        {
            isBullet02 = true;
            timeDown -= Time.deltaTime;
            Debug.Log("cahm");
            Destroy(collision.gameObject);
            if (timeDown == 0)
                isBullet02 = false;
            // StartCoroutine(time());
        }
    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(3f);
        isBullet02 = false;

    }
}
