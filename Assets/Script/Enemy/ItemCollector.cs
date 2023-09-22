using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemCollector : MonoBehaviour
{
    //public UnityEngine.UI.Text My_Text;
    public static int scores;
    public int ScorePlus;
    public int BigScore;
    public TextMeshProUGUI scoreText;
    public int currentPoint;
    public static int numHackathon;
    public TextMeshProUGUI hackathonText;

    PlayerHealth playerHealth = new PlayerHealth();
    [SerializeField] private AudioSource collectItemSound;
    private void Start()
    {
        ScorePlus = 1;
        BigScore = 20;
        scores = 0;
        numHackathon = 0;
        hackathonText.text = "";
        scoreText.text = "";
        UpdateScoreText();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            collectItemSound.Play();
            onIncrementScore(ScorePlus);
        }
        if (collision.gameObject.CompareTag("BigGold"))
        {
            Destroy(collision.gameObject);
            collectItemSound.Play();
            onIncrementScore(BigScore);
        }

        if (collision.gameObject.CompareTag("Hackathon"))
        {
            Destroy(collision.gameObject);
            collectItemSound.Play();
            onCollectHackathon(ScorePlus);
        }
        /*   if (collision.gameObject.CompareTag("Heal"))
           {
               Destroy(collision.gameObject);
               collectItemSound.Play();
               playerHealth.Heal(2);
           }*/

    }

    public void onCollectHackathon(int scorePlus)
    {
        numHackathon = numHackathon + scorePlus;
        PlayerPrefs.SetInt("numHackathon", numHackathon);
        PlayerPrefs.Save();
        Debug.Log(numHackathon);

        UpdateHackathonText();
    }
    public void onIncrementScore(int scorePlus)
    {
        scores = scores + scorePlus;
        PlayerPrefs.SetInt("score", scores);
        PlayerPrefs.Save();
        Debug.Log(scores);

        UpdateScoreText();
    }
    public void UpdateHackathonText()
    {
        Debug.Log(numHackathon);
        int point = numHackathon + (int)currentPoint;
            hackathonText.text = "" + point;

    }
    public void UpdateScoreText()
    {
        Debug.Log(scores);
        scoreText.text = "" + scores;
        
    }
}
