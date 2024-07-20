using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] Transform attackPos;

    [SerializeField] Vector2 attackBoxSize;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, attackBoxSize);
    }
    void Damage()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, attackBoxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider != null)
            {
                if (collider.tag == "Monster")
                {
                    collider.GetComponent<Enemy>().Destroy();
                }
            }
        }
    }
}
