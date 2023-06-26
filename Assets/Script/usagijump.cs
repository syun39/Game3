using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsagiJump : MonoBehaviour
{
    /// <summary>
    /// �E�T�M�̃L�����N�^�[���W�����v����R���|�[�l���g
    /// </summary>
    /// <summary>���E�ړ������</summary>
    [SerializeField] float _moveJumpPower = 5f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float _jumpPower = 15f;
  
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    
    /// <summary>���������̓��͒l</summary>
    float _h;
    float _scaleX;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 _initialPosition;
    bool _Ground = false;
    int _count = 0;
    bool _isJump;
    int _wjump = 0;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        // �����ʒu���o���Ă���
        _initialPosition = this.transform.position;
    }

    void Update()
    {
        // ���͂��󂯎��
        _h = Input.GetAxisRaw("Horizontal");

        // �e����͂��󂯎��
        if (Input.GetKeyDown(KeyCode.Space)&& _count < 1)
        {
            _rb.AddForce(Vector2.up * _moveJumpPower, ForceMode2D.Impulse);
            _count++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
 
    {
        if (collision.gameObject.tag == "Ground")
        {
            _Ground = true;
            _count = 0;
        }
    }
}
