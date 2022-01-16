using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GyroDrop : MonoBehaviour
{
    public static GyroDrop Gyro;

    public float upSpeed = 2f;
    public float downSpeed = 15f;
    public float rotaSpeed = 4f;


    public bool upMove;
    public bool downMove;

    private void Awake()
    {
        if (Gyro == null)
        {
            Gyro = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       // GyodropPlay();
    }

    public void GyodropPlay()
    {
        CenterUPMove();
        CenterDownMove();

        
    }


    void CenterUPMove()
    {
        if (upMove == true)
        {
            // 꼭대기까지 올라갈때~
            if (transform.localPosition.y <= 10f)
            {
                transform.Translate(Vector3.up * upSpeed * Time.deltaTime);
                transform.Rotate(new Vector3(0, rotaSpeed * Time.deltaTime, 0));
                
            }
            else
            {
                StartCoroutine(CenterDownDelay());

            }
        }

    }

    void CenterDownMove()
    {
        if (downMove == true)
        {
            if (transform.localPosition.y >= -75f)
            {
                transform.Translate(Vector3.down * downSpeed * Time.deltaTime);
            }
            else
            {
                downMove = false;
            }
          
            
        }
    }

    IEnumerator CenterDownDelay()
    {
        yield return new WaitForSeconds(2f);
        downMove = true;
        upMove = false;
        print(" 내려갑니다");


    }
}
