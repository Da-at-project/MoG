using UnityEngine;

public interface IDamagable
{
    public float Health { set; get; }
    public void OnHit(float damage);
    public void OnHit(float damage, Vector2 knockback);
}