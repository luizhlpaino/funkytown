using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerManager : MonoBehaviour
{
    public int m_MaxCarsInScreen = 2;
    public GameObject[] m_Cars;
    public List<GameObject> m_SpawnedCars = new List<GameObject>();
    private BoxCollider2D m_Collider;
    private float m_SpawnCountdown = 0.0f;
    private float m_MaxSpawnCountdown = 1.0f;


    IEnumerator SpawnCountdown(){
        m_SpawnCountdown = m_MaxSpawnCountdown;
        do {
            m_SpawnCountdown -= Time.deltaTime;
            if(m_SpawnCountdown < 0.0f)
                m_SpawnCountdown = 0.0f;
            yield return null;
        } while(m_SpawnCountdown > 0.0f);
    }

    private void Awake() {
        m_Collider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if(m_SpawnedCars.Count < m_MaxCarsInScreen && m_SpawnCountdown == 0.0f){
            int _selectCarIndex = Random.Range(0, m_Cars.Length-1);

            Vector2 _colliderPosition = new Vector2(
                m_Collider.transform.position.x + m_Collider.offset.x,
                m_Collider.transform.position.y + m_Collider.offset.y
            );

            float _horizontalPosition = Random.Range(
                _colliderPosition.x - m_Collider.size.x / 2,
                _colliderPosition.x + m_Collider.size.x / 2
            );            
        
            GameObject _car = Instantiate(m_Cars[_selectCarIndex], new Vector3(_horizontalPosition, transform.position.y, -1f), Quaternion.identity);
            m_SpawnedCars.Add(_car);
            StartCoroutine("SpawnCountdown");
        }
    }
    
}
