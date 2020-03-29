using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class Home : MonoBehaviour
{
    [SerializeField] private UnityEvent _opened;
    [SerializeField] private UnityEvent _closed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RoguePatrol>())
        {
            GetComponent<Tilemap>().color = new Color(1, 1, 1, 0);
            _opened.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<RoguePatrol>())
        {
            GetComponent<Tilemap>().color = new Color(1, 1, 1, 0.8f);
            _closed.Invoke();
        }
    }
}
