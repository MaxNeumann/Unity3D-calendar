using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Date : MonoBehaviour
{

    public Image[] _listImage;
    public Image[] _listImagePast;
    public Image[] _listImageFuture;
    public ScrollRectSnap_CS Scroll1;

    // Use this for initialization
    public void Start()
    {
        CalculateDates();


    }


    public void FillMonth(DateTime currentDay, Image[] _list, int targetMonth)
    {
        foreach (Image item in _list)
        {
            Text _t = item.gameObject.GetComponentsInChildren<Text>()[0];
            _t.text = currentDay.Day.ToString();

            if (currentDay.Month != targetMonth)
            {
                _t.color = Color.gray;
            }
            else
            {
                if (currentDay.Date == DateTime.Today.Date)
                {
                    _t.color = Color.cyan;
                }
                else
                {
                    _t.color = Color.black;
                }
            }

            currentDay = currentDay.AddDays(1);

        }
    }



    public void CalculateDates()
    {
        DateTime currentDay = DateTime.Today;
        int todayDay = (int)currentDay.Day;
        currentDay = currentDay.AddDays(-todayDay);
        //current day = последний день предыдущего месяца
        int daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
        currentDay = currentDay.AddDays(-daysMonth + 1);
        // current day = первый день текущего месяца
        int targetM = currentDay.Month;
        int dayOfWeekonthStart = (int)currentDay.DayOfWeek;
        currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);




        FillMonth(currentDay, _listImagePast, targetM);


        currentDay = DateTime.Today;
        targetM = currentDay.Month;
        todayDay = (int)currentDay.Day;
        currentDay = currentDay.AddDays(-todayDay + 1);
        //current day = первый день текущего месяца
        dayOfWeekonthStart = (int)currentDay.DayOfWeek;
        currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);


        FillMonth(currentDay, _listImage, targetM);


        daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
        currentDay = currentDay.AddDays(daysMonth);
        targetM = currentDay.Month;
        dayOfWeekonthStart = (int)currentDay.DayOfWeek;
        currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);


        FillMonth(currentDay, _listImageFuture, targetM);

    }

    public static DateTime currentDay = DateTime.Today;
    public static int todayDay = (int)currentDay.Day;
    public static int daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
    public static int targetM = currentDay.Month;
    public static int dayOfWeekonthStart = (int)currentDay.DayOfWeek;

    public void Update()
    {
        //DateTime currentDay = DateTime.Today;
        //int dayOfWeekonthStart = (int)currentDay.DayOfWeek;
        //int targetM = currentDay.Month;
        //int daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
        //int todayDay = (int)currentDay.Day;
        Debug.Log(todayDay);

            if (Scroll1.distReposition[0] > 700)
            {
               
                if (currentDay.Month == targetM)
                {

                    currentDay = new DateTime(currentDay.Year, currentDay.Month, 1);
                    daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
                    currentDay = currentDay.AddDays(daysMonth);
                    targetM = currentDay.Month;
                   
                    dayOfWeekonthStart = (int)currentDay.DayOfWeek;
                    currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);
                }
                else
                {

                    currentDay = currentDay.AddDays(8);
                    currentDay = new DateTime(currentDay.Year, currentDay.Month, 1);

                    daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
                    currentDay = currentDay.AddDays(daysMonth);
                    targetM = currentDay.Month;
                    dayOfWeekonthStart = (int)currentDay.DayOfWeek;
                    currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);
                }


                FillMonth(currentDay, _listImageFuture, targetM);

                if (currentDay.Month == targetM)
                {


                    currentDay = currentDay.AddDays(daysMonth);
                    targetM = currentDay.Month;
                    dayOfWeekonthStart = (int)currentDay.DayOfWeek;
                    currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);
                }
                else
                {

                    currentDay = currentDay.AddDays(8);
                    currentDay = new DateTime(currentDay.Year, currentDay.Month, 1);

                    daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
                    currentDay = currentDay.AddDays(daysMonth);
                    targetM = currentDay.Month;
                    dayOfWeekonthStart = (int)currentDay.DayOfWeek;
                    currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);
                }



                FillMonth(currentDay, _listImagePast, targetM);

                if (currentDay.Month == targetM)
                {

                    //daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);

                    currentDay = currentDay.AddDays(daysMonth);
                    targetM = currentDay.Month;
                    dayOfWeekonthStart = (int)currentDay.DayOfWeek;
                    currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);
                }
                else
                {

                    currentDay = currentDay.AddDays(8);
                    currentDay = new DateTime(currentDay.Year, currentDay.Month, 1);

                    daysMonth = DateTime.DaysInMonth(currentDay.Year, currentDay.Month);
                    currentDay = currentDay.AddDays(daysMonth);
                    targetM = currentDay.Month;
                    dayOfWeekonthStart = (int)currentDay.DayOfWeek;
                    currentDay = currentDay.AddDays(-dayOfWeekonthStart + 1);
                }


                FillMonth(currentDay, _listImage, targetM);
            }
        }
    }