using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public float invincibilityDuration = 0.5f;

    PlayerMove playerMove;
    SpriteRenderer sprite;
    Rigidbody2D rb;

    public bool isInvincible  = false;

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    
    public void Damage_HP(int _value)
    {
        if (isInvincible)
            return;

        if (!playerMove.isDashing)
        {
            //player_HP -= _value;

            // 무적 상태 시작
            StartCoroutine(InvincibilityCoroutine());

        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        sprite.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
        sprite.color = new Color(1, 1, 1, 1f);
    }
}
