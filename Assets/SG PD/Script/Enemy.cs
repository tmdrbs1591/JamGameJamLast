using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;  // ������ �̵� �ӵ�
    private Transform player;  // �÷��̾��� Transform�� �����մϴ�.

    void Start()
    {
        // �±� "Player"�� ���� ������Ʈ�� ã���ϴ�.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    void Update()
    {
        // �÷��̾ ������ ��ũ��Ʈ�� �����մϴ�.
        if (player == null)
            return;

        // �÷��̾�� ���� ������ ���� ���͸� ����մϴ�.
        Vector3 directionToPlayer = player.position - transform.position;

        // ������ ���ʰ� ������ ���͸� ����մϴ�.
        Vector3 leftDirection = -transform.right;
        Vector3 rightDirection = transform.right;

        // �÷��̾ ������ ���ʿ� �ִ��� �����ʿ� �ִ��� Ȯ���մϴ�.
        float dotProductLeft = Vector3.Dot(directionToPlayer, leftDirection);
        float dotProductRight = Vector3.Dot(directionToPlayer, rightDirection);

        if (dotProductLeft > dotProductRight)
        {
            // �÷��̾ ���ʿ� ���� �� �������� �̵�
            MoveInDirection(leftDirection);
        }
        else
        {
            // �÷��̾ �����ʿ� ���� �� ���������� �̵�
            MoveInDirection(rightDirection);
        }
    }

    void MoveInDirection(Vector3 direction)
    {
        // �������� �̵��մϴ�.
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
