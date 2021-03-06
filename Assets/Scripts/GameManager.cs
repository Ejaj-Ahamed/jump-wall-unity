using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spwanPoint;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpwanObstacles(){
        while (true)
        {
            float waitTime = Random.Range(0.7f, 2f);
            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spwanPoint.position, Quaternion.identity);
        }
    }
    void ScoreUp(){
        score++;
        scoreText.text = score.ToString();
    }
    public void GameStart()
    {
        player.SetActive(true);
        obstacle.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpwanObstacles");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
    public void HideObstacle(){
        obstacle.SetActive(false);
    }
}
