using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class User : MonoBehaviour {

    public Data data;

    public float Points;
    public float ideasSubmitted;
    public float TotalPointsBought;
    public float TotalPointsSold;
    public float TotalPointsEarned; //from idea submissions
    public float MoneyInAccount;
    public float MoneyCashedOut;
    public float TotalMoneyBought;
    public float TotalMoneySpent;

    /// <summary>
    /// trade money for points
    /// </summary>
    /// <param name="points"></param>
    public void BuyPoints(float points) {
        var cost = points*data.MoneyCostPerPoint;

        if (MoneyInAccount >= cost) {
            MoneyInAccount -= cost;
            TotalMoneySpent += cost;
            TotalPointsBought += points;
            Points += points;
        }
    }

    /// <summary>
    /// trade points for money
    /// </summary>
    /// <param name="points"></param>
    public void SellPoints(float points) {
        var money = points*data.MoneyMadePerPointSold;

        if (Points >= points) {
            TotalMoneyBought += money;
            MoneyInAccount += money;
            Points -= points;
        }
    }

    /// <summary>
    /// trade ideas for points
    /// </summary>
    public void SubmitIdea() {
        float rating = Random.Range(0, 101); //simulating a rating
        float reward = rating*data.IdeaRewardPerRating;
        float cost = rating*data.IdeaCostPerRating;
        ideasSubmitted++;
        Points += reward;
        TotalPointsEarned += reward;

        var idea = new Idea {
            Rating = rating,
            Reward = reward,
            Cost = cost
        };

        data.ActiveIdeas.Add(idea);
    }

    /// <summary>
    /// Take your money out of your account
    /// </summary>
    /// <param name="money"></param>
    public void CashOut(float money) {
        if (MoneyInAccount >= money) {
            MoneyInAccount -= money;
            MoneyCashedOut += money;
        }
    }







	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
