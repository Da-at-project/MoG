using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float nowHP;
    public float damage;

    public void OnDamage(int damage)
    {
        nowHP -= damage;
        Debug.Log(nowHP);
        if(nowHP<=0)
        {
            Debug.Log("Enemy");
            Destroy(gameObject);
        }
    }
}
