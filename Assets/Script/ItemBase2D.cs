using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase2D : MonoBehaviour
{
    /// <summary>�A�C�e������������ɖ���ʉ�</summary>
    [Tooltip("�A�C�e������������ɖ炷���ʉ�")]
    [SerializeField] AudioClip _sound = default;

    public abstract void Activate();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }

            Activate();
            Destroy(this.gameObject);

        }
    }
}
