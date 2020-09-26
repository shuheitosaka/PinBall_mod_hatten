
using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
         //スマホ対応
        for (int i = 0; i < Input.touchCount; i++)//画面がタッチされていた場合
        {
            Touch touch = Input.GetTouch(i);//i番目にタッチされている指の情報を取得する。

            if (tag == "LeftFripperTag")//LeftFripperTagに関して
            {
                if (touch.position.x <= Screen.width / 2)//座標が画面の左側で
                {
                    if (touch.phase == TouchPhase.Began)//画面がタッチされた瞬間に
                    {
                        SetAngle(this.flickAngle);//LeftFripperをFlickAngleにする
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)//画面から指が離れた瞬間に
                    {
                        SetAngle(this.defaultAngle); //LeftFripperをDefaultAngleにする
                    }
                }
            }

            if (tag == "RightFripperTag")//RightFripperTagに関して
            {
                if (touch.position.x >= Screen.width / 2)//座標が画面の右側で
                {
                    if (touch.phase == TouchPhase.Began)//画面がタッチされた瞬間に
                    {
                        SetAngle(this.flickAngle);//LeftFripperをFlickAngleにする
                    }
                    else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)//画面から指が離れた瞬間に
                    {
                        SetAngle(this.defaultAngle);//LeftFripperをDefaultAngleにする
                    }
                }
            }

        }

        //PC対応
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetMouseButtonUp(0) && Input.mousePosition.x <= Screen.width / 2 && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetMouseButtonUp(0) && Input.mousePosition.x >= Screen.width / 2 && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}