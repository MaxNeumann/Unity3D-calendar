﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScrollRectSnap_CS : MonoBehaviour {

    public RectTransform panel;
    public Button[] bttn;
    public RectTransform center;


    public float[] distance;
    public float[] distReposition;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;
    private int bttnLength;

    void Start()
    {
        bttnLength = bttn.GetLength(0);
        distance = new float[bttnLength];
        distReposition = new float[bttnLength];

        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    void Update()
    {
        for (int i = 0; i < bttn.GetLength(0); i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if (distReposition[i] > 800)
            {

                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;
                Vector2 newAnchoredPos = new Vector2(curX + (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;

            }
            if (distReposition[i] < -800)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;
                Vector2 newAnchoredPos = new Vector2(curX - (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
        }

        float minDistance = Mathf.Min(distance);

        for (int a = 0; a < bttn.GetLength(0); a++)
          {
              if (minDistance == distance[a])
              {
                  minButtonNum = a;
              }
          }

          if (!dragging)
          {
              //LerpToBttn(minButtonNum * -bttnDistance);
              LerpToBttn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
          }
    }

   public void LerpToBttn(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}
