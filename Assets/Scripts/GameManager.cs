using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int m_Dollars = 0;
    public Text m_DollarsText;
    public Text m_ResultText;
    public GameObject GameOverPanel;

    public void CallGameOver(){
        GameOverPanel.SetActive(true);
    }

    public void SetDollar(){
        m_Dollars++;
        m_DollarsText.text = "$"+m_Dollars+",00";
        m_ResultText.text = "$"+m_Dollars+",00";
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
