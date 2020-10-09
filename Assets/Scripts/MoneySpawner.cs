using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject m_MoneyPrefab;
    public List<GameObject> m_SpawnedDollars;
    private int m_MaxQtdPerScreen = 1;
    private BoxCollider2D m_Collider;
    void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if(m_SpawnedDollars.Count < m_MaxQtdPerScreen){            
            Vector2 _colliderPosition = new Vector2(
                m_Collider.transform.position.x + m_Collider.offset.x,
                m_Collider.transform.position.y + m_Collider.offset.y
            );

            float _horizontalPosition = Random.Range(
                _colliderPosition.x - m_Collider.size.x / 2,
                _colliderPosition.x + m_Collider.size.x / 2
            );        

            float _verticalPosition = Random.Range(
                _colliderPosition.y - m_Collider.size.y / 2,
                _colliderPosition.y + m_Collider.size.y / 2
            );                
        
            GameObject _Dollar = Instantiate(m_MoneyPrefab, new Vector3(_horizontalPosition, _verticalPosition, -1f), Quaternion.identity);
            m_SpawnedDollars.Add(_Dollar);            
        }
    }
}
