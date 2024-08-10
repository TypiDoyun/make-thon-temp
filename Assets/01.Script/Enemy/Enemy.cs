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
        // 마우스 왼쪽 버튼 클릭 감지
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
        // 현재 hitcount가 배열 범위 내에 있는지 확인
        if (hitcount > 0 && hitcount <= objects.Length)
        {
            // 해당 오브젝트의 애니메이터를 가져와서 터지는 애니메이션 재생
            Animator animator = objects[hitcount - 1].GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("panggg"); // "Explode"는 애니메이션 트리거 이름
            }
        }
    }
    public void TakeDamage(float damage)
    {
        // 피격 애니메이션 트리거
        animator.SetTrigger("HitTrigger");
        Debug.Log("나 맞았엄");
        hitcount++;
        TriggerExplosion();
        // 여기에 데미지 처리 로직을 추가
        // 예를 들어, 체력을 줄이거나 적을 제거하는 로직
    }
}
