﻿using System;
using Caliburn.Testability.Extensions;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;
using Action = Relax.Domain.Models.Action;

namespace Relax.Domain.Tests.Models
{
    public class ActionTestFixture : TestDataBuilder
    {
        [Fact]
        public void TimeRequired_WhenSet_RaisesPropertyChanged()
        {
            TimeSpan newTimeRequired = TimeSpan.FromMinutes(30);

            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.TimeRequired).
                When(() => test.TimeRequired = newTimeRequired);
            Assert.Equal(newTimeRequired, test.TimeRequired);
        }

        [Fact]
        public void MentalEnergyRequired_WhenSet_RaisesPropertyChanged()
        {
            const EnergyLevel mentalEnergyRequired = EnergyLevel.Medium;

            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.MentalEnergyRequired).
                When(() => test.MentalEnergyRequired = mentalEnergyRequired);
            Assert.Equal(mentalEnergyRequired, test.MentalEnergyRequired);
        }

        [Fact]
        public void PhysicalEnergyRequired_WhenSet_RaisesPropertyChanged()
        {
            const EnergyLevel energyLevel = EnergyLevel.Medium;

            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.PhysicalEnergyRequired).
                When(() => test.PhysicalEnergyRequired = energyLevel);
            Assert.Equal(energyLevel, test.PhysicalEnergyRequired);
        }

        [Fact]
        public void ActionState_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ActionState).
                When(() => test.ActionState = State.SomedayMaybe);
        }

        [Fact]
        public void ActionState_Initially_IsInbox()
        {
            var test = new Action();

            Assert.Equal(State.Inbox, test.ActionState);
        }

        [Fact]
        public void BlockingActions_Initially_IsEmpty()
        {
            Assert.Empty(new Action().BlockingActions);
        }

        [Fact]
        public void Notes_Initially_IsEmpty()
        {
            Assert.Empty(new Action().Notes);
        }

        [Fact]
        public void Deadline_WhenSet_RaisesPropertyChanged()
        {
            DateTime newDeadline = DateTime.UtcNow;
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Deadline).
                When(() => test.Deadline = newDeadline);
            Assert.Equal(newDeadline, test.Deadline);
        }

        [Fact]
        public void Delegation_WhenSet_RaisesPropertyChanged()
        {
            IDelegation newDelegation = new Mock<IDelegation>().Object;

            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Delegation).
                When(() => test.Delegation = newDelegation);
            Assert.Equal(newDelegation, test.Delegation);
        }

        [Fact]
        public void DeferUntil_WhenSet_RaisesPropertyChanged()
        {
            DateTime newDeferUntil = DateTime.UtcNow;
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DeferUntil).
                When(() => test.DeferUntil = newDeferUntil);
            Assert.Equal(newDeferUntil, test.DeferUntil);
        }

        [Fact]
        public void CompletedDate_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            DateTime completedDate = DateTime.UtcNow;
            test.AssertThatChangeNotificationIsRaisedBy(x => x.CompletedDate).
                When(() => test.CompletedDate = completedDate);
            Assert.Equal(completedDate, test.CompletedDate);
        }

        [Fact]
        public void CompletedDate_WhenSetToFuture_Throws()
        {
            var test = new Action();

            DateTime completedDate = DateTime.UtcNow + TimeSpan.FromDays(1);

            Assert.Throws(typeof (ArgumentOutOfRangeException), () => test.CompletedDate = completedDate);
        }

        [Fact]
        public void Review_WhenSet_RaisesPropertyChanged()
        {
            IReview newReview = new Mock<IReview>().Object;

            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).
                When(() => test.Review = newReview);
            Assert.Equal(newReview, test.Review);
        }

        [Fact]
        public void Priority_WhenSet_RaisesPropertyChanged()
        {
            const Priority newPriority = Priority.Should;

            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Priority).
                When(() => test.Priority = newPriority);
            Assert.Equal(newPriority, test.Priority);
        }

        [Fact]
        public void Repetition_WhenSet_RaisesPropertyChanged()
        {
            IRepetition newRepetition = ARepetition.Build();
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Repetition).
                When(() => test.Repetition = newRepetition);
            Assert.Same(newRepetition, test.Repetition);
        }

        [Fact]
        public void Context_WhenSet_RaisesPropertyChanged()
        {
            IGtdContext newContext = AContext.Build();
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Context).
                When(() => test.Context = newContext);
            Assert.Same(newContext, test.Context);
        }

        [Fact]
        public void AddBlockingAction_GivenAction_AddsActionToBlockingActions()
        {
            var test = new Action();

            IAction blockingAction = AnAction.Build();
            test.AddBlockingAction(blockingAction);

            Assert.Contains(blockingAction, test.BlockingActions);
        }
    }
}