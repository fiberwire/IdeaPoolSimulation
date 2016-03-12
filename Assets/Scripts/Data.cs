using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

public class Data : MonoBehaviour {
    /// <summary>
    /// All users
    /// </summary>
    public List<User> users {
        get {
            return (from u in GameObject.FindGameObjectsWithTag("User")
                select u.GetComponent<User>()).ToList();
        }
    }

    /// <summary>
    /// The total number of points in the system across all users
    /// </summary>
    public float PointsInCirculation {
        get {
            float points = (from u in users
                select u.Points).Sum();

            pointsInCirculation = points;

            return points;
        }
    }

    /// <summary>
    /// The total amount of money the company has made from this
    /// </summary>
    public float GrossRevenueFromPointsSales {
        get {
            float points = (from u in users
                select u.TotalMoneySpent).Sum();

            grossRevenueFromPointsSales = points;

            return points;
        }
    }

    /// <summary>
    /// The total number of points bought
    /// </summary>
    public float PointsBought {
        get {
            var points = (from u in users
                select u.TotalPointsBought).Sum();

            pointsBought = points;
            return points;
        }
    }

    /// <summary>
    /// The total number of points sold
    /// </summary>
    public float PointsSold {
        get {
            var points = (from u in users
                select u.TotalPointsSold).
                Sum();

            pointsSold = points;

            return points;
        }
    }

    /// <summary>
    /// The total amount of money given out from people selling points
    /// </summary>
    public float MoneyBought {
        get {
            var money = (from u in users
                select u.TotalMoneyBought).Sum();

            moneyBought = money;

            return money;
        }
    }

    /// <summary>
    /// The total amount of money received from people buying points
    /// </summary>
    public float MoneySold;

    /// <summary>
    /// How much each point costs to buy
    /// </summary>
    public float MoneyCostPerPoint;

    /// <summary>
    /// How much money you make for each point sold
    /// </summary>
    public float MoneyMadePerPointSold;

    /// <summary>
    /// How many points each point of rating will earn the person who submitted the idea
    /// </summary>
    public float IdeaRewardPerRating;

    /// <summary>
    /// How many point an idea will cost per point of rating
    /// </summary>
    public float IdeaCostPerRating;

    /// <summary>
    /// All of the ideas actively in circulation
    /// </summary>
    public List<Idea> ActiveIdeas;

    /// <summary>
    /// All of the ideas that people have bought
    /// </summary>
    public List<Idea> BoughtIdeas;

    [SerializeField] private float pointsInCirculation;
    [SerializeField] private float grossRevenueFromPointsSales;
    [SerializeField] private float pointsBought;
    [SerializeField] private float pointsSold;
    [SerializeField] private float moneyBought;


    // Use this for initialization
    private void Start() {
        ActiveIdeas = new List<Idea>();
        BoughtIdeas = new List<Idea>();
    }

    // Update is called once per frame
    private void Update() {
    }
}