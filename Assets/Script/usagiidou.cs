using System.Collections.Generic;
using UnityEngine;

public class UsagiIdou : MonoBehaviour
{
    /// <summary>
    /// �E�T�M�̃L�����N�^�[���ړ�����R���|�[�l���g
    /// </summary>
    /// <summary>���E�ړ������</summary>
    [SerializeField] public float _movePower = 5f;
    /// <summary>���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O</summary>
    [SerializeField] bool _flipX = false;
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    /// <summary>m_colors �Ɏg���Y��</summary>
    int _colorIndex;
    /// <summary>���������̓��͒l</summary>
    float _h;
    float _scaleX;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 _initialPosition;

    int count;
    bool _isJump;

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

        // �ݒ�ɉ����č��E�𔽓]������
        if (_flipX)
        {
            FlipX(_h);
        }


    }

    private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        _rb.AddForce(Vector2.right * _h * _movePower, ForceMode2D.Force);
    }

    /// <summary>
    /// ���E�𔽓]������
    /// </summary>
    /// <param name="horizontal">���������̓��͒l</param>
    void FlipX(float horizontal)
    {
        /*
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
         * */
        _scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

}








