using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �ǂ����o������A���̂Ȃ��Ƃ�������o���Ĉړ��𐧌䂷��R���|�[�l���g
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MoveController : MonoBehaviour
{
    /// <summary>�ړ����x</summary>
    [SerializeField] float _moveSpeed = 1f;
    /// <summary>�ǂ����o���邽�߂� line �̃I�t�Z�b�g</summary>
    [SerializeField] Vector2 _lineForWall = Vector2.right;
    /// <summary>�ǂ̃��C���[�i���C���[�̓I�u�W�F�N�g�ɐݒ肳��Ă���j</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>�ړ�����</summary>
    Vector2 _moveDirection = Vector2.right;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveWithTurn();
    }

  
    // �O���ɕǂ����o����܂ŉE�Ɉړ����A�ǂ����o�����獶�Ɉړ����鏈��
   
    void MoveWithTurn()
    {
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _lineForWall);
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);
        Vector2 velo = Vector2.zero;    // velo �͑��x�x�N�g��

        if (hit.collider)
        {
            //_moveDirection.x *= -1;
            _lineForWall.x *= -1;
            _moveSpeed = _moveSpeed * -1;
            GetComponent<SpriteRenderer>().flipX = true;  //���������甽�]
            if (_lineForWall.x == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

        }

        velo = _moveDirection.normalized * _moveSpeed;
        velo.y = _rb.velocity.y;
        _rb.velocity = velo;
    }
}