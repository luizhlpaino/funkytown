using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float m_Speed = 5.0f;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        rb2d.velocity = Vector2.up * m_Speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            GameManager _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _gameManager.CallGameOver();
        }
    }

    private void OnDestroy() {
        GameObject _carSpawner = GameObject.Find("CarSpawner");
        if(_carSpawner != null)
            _carSpawner.GetComponent<CarSpawnerManager>().m_SpawnedCars.Remove(this.gameObject);                
    }
}
