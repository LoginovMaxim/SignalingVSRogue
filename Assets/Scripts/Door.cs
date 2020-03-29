using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private float _speed;

    private Vector3 _openPosition;
    private Vector3 _closePosition;
    private bool _isOpen = false;

    private void Start()
    {
        _closePosition = transform.position;
        _openPosition = transform.position + new Vector3(0, _offset, 0);
    }

    private void Update()
    {
        if (_isOpen)
        {
            if(transform.position != _openPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, _openPosition, _speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position != _closePosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, _closePosition, _speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RoguePatrol>())
        {
            _isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RoguePatrol>())
        {
            _isOpen = false;
        }
    }
}
