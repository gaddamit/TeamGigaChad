using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Crab : MonoBehaviour
{
    enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    [SerializeField] private float _distanceToMove = 1.27f;
    [SerializeField] private Direction _direction = Direction.None;

    // Animate the crab base on assigned direction
    void Start()
    {
        switch (_direction)
        {
            case Direction.Left:
                transform.DOLocalMoveX(transform.position.x - _distanceToMove, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                break;
            case Direction.Right:
                transform.DOLocalMoveX(transform.position.x + _distanceToMove, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                break;
            case Direction.Up:
                transform.DOLocalMoveY(transform.position.y + _distanceToMove, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                break;
            case Direction.Down:
                transform.DOLocalMoveY(transform.position.y - _distanceToMove, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
