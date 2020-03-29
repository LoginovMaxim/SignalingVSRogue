using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoguePatrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private bool _isRightView;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _isRightView = true;
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        if (transform.position.x > target.position.x && _isRightView)
        {
            Flip();
        }
        else if (transform.position.x < target.position.x && !_isRightView)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 direction;

        if (_isRightView)
        {
            direction = new Vector3(-1, 1, 1);
        }
        else
        {
            direction = new Vector3(1, 1, 1);
        }

        transform.localScale = direction;

        _isRightView = !_isRightView;
    }
}
