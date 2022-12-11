using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class TestSuite
    {
        public Controls control;
        public Road road;
        public Moving newСar;
        public Coin coin;
        public Menu menu;
        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/RoadBlock"));
            road = gameGameObject.GetComponent<Road>();
            GameObject gameGameObject2 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Models/Car_1"));
            newCar = gameGameObject2.GetComponent<Moving>();
            newCar.transform.position = Vector3.zero;
        }
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(road.gameObject);
            Object.Destroy(newCar.gameObject);
        }
        [UnityTest]
        public IEnumerator DestroyedCoinRaisesScore()
        {
            GameObject newCoin = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Coin"));
            newCoin.transform.position = Vector3.zero;
            Assert.AreEqual(control.scores, 100);
            Object.Destroy(newCoin.gameObject);
            yield return null;
        }
        [UnityTest]
        public IEnumerator CarMoves()
        {
            float initialXPos = newCar.transform.position.x;
            Assert.Greater(newCar.transform.position.x, initialXPos);
            yield return null;
        }
        [UnityTest]
        public IEnumerator NewGame()
        {
            GameObject Car = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Car_2"));
            Car.transform.position = Vector3.zero;
            yield return new WaitForSeconds(0.1f);
            Assert.False(newCar.isAlive);
            Object.Destroy(Car.gameObject);
        }
    }
}
