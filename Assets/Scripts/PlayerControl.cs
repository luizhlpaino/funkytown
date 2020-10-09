using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{    
    private float m_Speed = 5.0f;    
    private Rigidbody2D rb2d;
    private Animator anim;
    private Vector3 m_LastTouchPosition;
    private Vector3 m_Direction;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Money")){
            GameManager _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _gameManager.SetDollar();
            
            GameObject _MoneySpawner = GameObject.Find("MoneySpawner");
            if(_MoneySpawner != null)
                _MoneySpawner.GetComponent<MoneySpawner>().m_SpawnedDollars.Remove(other.gameObject);

            Destroy(other.gameObject);

        }
    }

    void Awake(){        
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        
    }

    void Update(){
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            m_LastTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            m_LastTouchPosition.z = 0.0f;
            m_Direction = (m_LastTouchPosition - transform.position);
            rb2d.velocity = new Vector2(m_Direction.x, m_Direction.y) * m_Speed; 

            if(touch.phase == TouchPhase.Ended) 
                rb2d.velocity = Vector2.zero;
        }
    }       
}
