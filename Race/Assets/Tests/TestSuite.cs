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
        public Moving car;
        public Coin coin;
        public Menu menu;
        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Road"));
            road = gameGameObject.GetComponent<Road>();
        }
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(road.gameObject);
        }
        [UnityTest]
        public IEnumerator DestroyedCoinRaisesScore()
        {
            GameObject newCar = car.CreateCar();
            newCar.transform.position = Vector3.zero;
            GameObject newCoin = coin.CreateCar();
            newCoin.transform.position = Vector3.zero;
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(control.scores, 100);
        }
        [UnityTest]
        public IEnumerator CarMoves()
        {
            GameObject newCar = car.CreateCar();
            newCar.transform.position = Vector3.zero;
            float initialXPos = newCar.transform.position.x;
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(newCar.transform.position.x, initialXPos);
        }
        [UnityTest]
        public IEnumerator NewGame()
        {
            car.isAlive = true;
            menu.Play();
            Assert.False(car.isAlive);
            yield return null;
        }
    }
}
