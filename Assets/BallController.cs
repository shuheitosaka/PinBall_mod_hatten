using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject ScoreText;
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合の処理
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";

        }
    }

    void OnCollisionEnter(Collision collision)//ボールが障害物に衝突した場合に得点を加算し表示する。障害物はタグで区別する。
    {
        if (collision.gameObject.name == "SmallStarPrefab")
        {
            score += 10;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }
        else if (collision.gameObject.name == "SmallStar")
        {
            score += 10;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }
        else if (collision.gameObject.name == "LargeCloud")
        {
            score += 20;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }
        else if (collision.gameObject.name == "SmallCloudPrefab")
        {
            score += 30;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }
        else if (collision.gameObject.name == "SmallCloud")
        {
            score += 30;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }
        else if (collision.gameObject.name == "LargeStarPrefab")
        {
            score += 1000;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }
        else if (collision.gameObject.name == "LargeStar")
        {
            score += 1000;
            this.ScoreText.GetComponent<Text>().text =
                "現在の得点は" + score.ToString("F5");
        }

    }
}