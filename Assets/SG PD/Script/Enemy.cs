using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;  // 몬스터의 이동 속도
    private Transform player;  // 플레이어의 Transform을 참조합니다.

    void Start()
    {
        // 태그 "Player"를 가진 오브젝트를 찾습니다.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    void Update()
    {
        // 플레이어가 없으면 스크립트를 종료합니다.
        if (player == null)
            return;

        // 플레이어와 몬스터 사이의 방향 벡터를 계산합니다.
        Vector3 directionToPlayer = player.position - transform.position;

        // 몬스터의 왼쪽과 오른쪽 벡터를 계산합니다.
        Vector3 leftDirection = -transform.right;
        Vector3 rightDirection = transform.right;

        // 플레이어가 몬스터의 왼쪽에 있는지 오른쪽에 있는지 확인합니다.
        float dotProductLeft = Vector3.Dot(directionToPlayer, leftDirection);
        float dotProductRight = Vector3.Dot(directionToPlayer, rightDirection);

        if (dotProductLeft > dotProductRight)
        {
            // 플레이어가 왼쪽에 있을 때 왼쪽으로 이동
            MoveInDirection(leftDirection);
        }
        else
        {
            // 플레이어가 오른쪽에 있을 때 오른쪽으로 이동
            MoveInDirection(rightDirection);
        }
    }

    void MoveInDirection(Vector3 direction)
    {
        // 방향으로 이동합니다.
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
