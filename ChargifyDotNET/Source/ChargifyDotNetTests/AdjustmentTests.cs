﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChargifyDotNetTests.Base;
using ChargifyNET;

namespace ChargifyDotNetTests
{
    [TestClass]
    public class AdjustmentTests : ChargifyTestBase
    {
        [TestMethod]
        public void Adjustment_Can_Adjust_Zero_Decimal()
        {
            // Arrange
            var subscription = Chargify.GetSubscriptionList().FirstOrDefault(s => s.Value.State == ChargifyNET.SubscriptionState.Active).Value;
            decimal amount = 0m;
            string memo = "test kf";
            var preAdjustmentBalance = subscription.Balance;

            // Act
            var result = Chargify.CreateAdjustment(subscription.SubscriptionID, amount, memo);
            var postAdjustmentSubscription = Chargify.LoadSubscription(subscription.SubscriptionID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(amount, result.Amount);
            Assert.AreEqual(Convert.ToInt32(amount), result.AmountInCents);
            Assert.AreEqual(memo, result.Memo);
            Assert.AreEqual(preAdjustmentBalance+amount, postAdjustmentSubscription.Balance);

            TestContext.WriteLine("SubscriptionID: {0}", subscription.SubscriptionID);
        }

        [TestMethod]
        public void Adjustment_Can_Adjust_Zero_Integer()
        {
            // Arrange
            var subscription = Chargify.GetSubscriptionList().FirstOrDefault(s => s.Value.State == ChargifyNET.SubscriptionState.Active).Value;
            int amount = 0;
            string memo = "test kf";
            var preAdjustmentBalance = subscription.BalanceInCents;

            // Act
            var result = Chargify.CreateAdjustment(subscription.SubscriptionID, amount, memo);
            var postAdjustmentSubscription = Chargify.LoadSubscription(subscription.SubscriptionID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(amount, result.Amount);
            Assert.AreEqual(Convert.ToInt32(amount), result.AmountInCents);
            Assert.AreEqual(memo, result.Memo);
            Assert.AreEqual(preAdjustmentBalance+amount, postAdjustmentSubscription.Balance);

            TestContext.WriteLine("SubscriptionID: {0}", subscription.SubscriptionID);
        }
    }
}
