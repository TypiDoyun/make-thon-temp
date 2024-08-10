using System.Collections;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public Animator animator; // Animator ������Ʈ
    public float attackRange = 10f; // ��Ʈ��ĵ ������ ����
    public LayerMask enemyLayer; // �� ���̾�
    public float damageAmount = 10f; // ���� ������

    private void Update()
    {
        // ���콺 Ŭ�� �� ����
        if (Input.GetMouseButtonDown(0))
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        if (animator != null)
        {
            // �ִϸ��̼� ���
            animator.SetTrigger("Attack");
            Debug.Log("Attack trigger called");
        }
        else
        {
            Debug.LogError("Animator is not assigned.");
        }

        // ���콺 ��ġ�� �÷��̾��� ��ġ ���̸� ����Ͽ� ������ ����
        Vector2 attackDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

        // 2D ȯ�濡���� `Vector2`�� ����մϴ�
        RaycastHit2D hit = Physics2D.Raycast(transform.position, attackDirection.normalized, attackRange, enemyLayer);

        if (hit.collider != null)
        {
            // ���� ���� ���
            Debug.Log("Hit: " + hit.collider.name);
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
    }
}
