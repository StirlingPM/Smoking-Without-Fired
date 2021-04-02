using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmoker : MonoBehaviour
{
    [SerializeField] float points;
    GameObject cigarette;
    Vector3 cigStartPos;
    float drag = 0;
    // Start is called before the first frame update
    void Start()
    {
        cigarette = GameObject.Find("cigarette").gameObject;
        cigStartPos = cigarette.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameState == CurrentGameState.Game)
        {
            if (Input.GetMouseButtonDown(0))
            {
                drag = 1;
                cigarette.transform.localPosition = cigStartPos;
            }

            if (Input.GetMouseButton(0))
            {
                GameManager.isSmoking = true;
                if (drag > 0)
                {
                    cigarette.transform.Translate(Vector3.down * .40f * Time.deltaTime);
                    drag -= Time.deltaTime;
                    print("smoking");
                    points += Time.deltaTime;
                    cigarette.SetActive(true);
                    GameManager.scoreText.text = string.Format("{0:0.##}", points);
                }
            }
            else
            {
                GameManager.isSmoking = false;

                cigarette.SetActive(false);
            }
        }
      
    }
}
