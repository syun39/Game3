using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �G�ꂽobj�̐e���ړ����ɂ���
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �G�ꂽobj�̐e���Ȃ���
            other.transform.SetParent(null);
        }
    }
}
