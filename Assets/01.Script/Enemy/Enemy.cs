using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Enemy_prefab;
    public GameObject[] objects;
    public int hitcount = 0;
    

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ����
        if (hitcount == 1)
        {
            TriggerExplosion();
        }
        if (hitcount == 2)
        {
            TriggerExplosion();
        }
        if (hitcount == 3)
        {
            TriggerExplosion();
        }
        if (hitcount == 4)
        {
            GameObject.Destroy(Enemy_prefab);
        }
    }

    void TriggerExplosion()
    {
        // ���� hitcount�� �迭 ���� ���� �ִ��� Ȯ��
        if (hitcount > 0 && hitcount <= objects.Length)
        {
            // �ش� ������Ʈ�� �ִϸ����͸� �����ͼ� ������ �ִϸ��̼� ���
            Animator animator = objects[hitcount - 1].GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("panggg"); // "Explode"�� �ִϸ��̼� Ʈ���� �̸�
            }
        }
    }
    public void TakeDamage(float damage)
    {
        // �ǰ� �ִϸ��̼� Ʈ����
        animator.SetTrigger("HitTrigger");
        Debug.Log("�� �¾Ҿ�");
        hitcount++;
        TriggerExplosion();
        // ���⿡ ������ ó�� ������ �߰�
        // ���� ���, ü���� ���̰ų� ���� �����ϴ� ����
    }
}
