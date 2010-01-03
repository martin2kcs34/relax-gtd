﻿using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class InputPresenterTestFixture
    {
        private Mock<IAction> _fakeAction;
        private Mock<IWorkspace> _fakeWorkspace;

        [SetUp]
        public void SetUp()
        {
            _fakeWorkspace = new Mock<IWorkspace>();
            _fakeAction = new Mock<IAction>();
        }

        private InputPresenter BuildDefaultInputViewPresenter()
        {
            return new InputPresenter(_fakeWorkspace.Object, () => _fakeAction.Object);
        }

        [Test]
        public void Action__ReturnsAction()
        {
            InputPresenter test = BuildDefaultInputViewPresenter();

            Assert.AreSame(_fakeAction.Object, test.Action);
        }

        [Test]
        public void Add_WhenTitleIsNotEmpty_AddsItemToInbox()
        {
            InputPresenter test = BuildDefaultInputViewPresenter();

            test.Add();

            _fakeWorkspace.Verify(x => x.Add(_fakeAction.Object));
        }

        [Test]
        public void CanAdd_WhenTitleIsEmpty_IsFalse()
        {
            _fakeAction.Setup(x => x.Title).Returns(string.Empty);

            InputPresenter test = BuildDefaultInputViewPresenter();

            Assert.IsFalse(test.CanAdd());
        }

        [Test]
        public void CanAdd_WhenTitleIsNotEmpty_IsTrue()
        {
            _fakeAction.Setup(x => x.Title).Returns("This action has a title");

            InputPresenter test = BuildDefaultInputViewPresenter();

            Assert.IsTrue(test.CanAdd());
        }

        [Test]
        public void Constructor__SetsActionStateToInbox()
        {
            InputPresenter test = BuildDefaultInputViewPresenter();

            _fakeAction.VerifySet(x => x.ActionState = State.Inbox);
        }
    }
}