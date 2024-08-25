using CardGame.Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CardGame.Tests
{
    [TestClass]
    public class InputsTests
    {
        private Inputs _inputs;
        private StringWriter _consoleOutput;
        private StringReader _consoleInput;

        [TestInitialize]
        public void Setup()
        {
            _inputs = new Inputs();
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
            _inputs = new Inputs();
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);

        }
        private void SetInput(string input)
        {
            _consoleInput = new StringReader(input);
            Console.SetIn(_consoleInput);
        }

        [TestMethod]
        public void InputAccepted()
        {
            SetInput("2c\nstop");
            var expectedOutput = "Recorded";
            RunGameLoop();
            var output = _consoleOutput.ToString();
            Assert.IsTrue(output.Contains(expectedOutput));
        }
        [TestMethod]
        public void MultiInput()
        {
            SetInput("2c, 3c\nstop");
            var expectedOutput = "Recorded";
            RunGameLoop();
            var output = _consoleOutput.ToString();
            Assert.IsTrue(output.Contains(expectedOutput));
        }
        [TestMethod]
        public void ScoreWorks()
        {
            SetInput("score\nstop");
            var expectedOutput = "h";
            RunGameLoop();
            var output = _consoleOutput.ToString();
            Assert.IsTrue(output.Contains(expectedOutput));
        }
        [TestMethod]
        public void InvalidInput()
        {
            SetInput("invalidCard\nstop");
            var expectedOutput = "Card not recognised";
            RunGameLoop();

            var output = _consoleOutput.ToString();
            Assert.IsTrue(output.Contains(expectedOutput));
        }
        [TestMethod]
        public void StopWorks()
        {

            SetInput("Stop\n2c");
            RunGameLoop();
            var output = _consoleOutput.ToString();
            Assert.IsFalse(output.Contains("Recorded"));
        }
        private void RunGameLoop()
        {
            var input = new Inputs();
            bool gameRunning = true;
            Console.WriteLine("Welcome to Number Cards. \nPlease enter your list of cards. \nE.g. '2C' or '2C, 3C' \nIf you would like to see your score just type 'Score'\nIf you would like the game to stop type 'Stop'");
            while (gameRunning)
            {
                string response = input.Checker(Console.ReadLine());
                if (response.ToLower() == "stop")
                {
                    gameRunning = false;
                }
            }
        }
        [TestMethod]
        public void Checker_InvalidCharacter_ShouldPrintInvalidInput()
        {
            string[] invalidInputs = { "card\\", "card/", "card|", "card!" };

            foreach (var input in invalidInputs)
            {
                string result = _inputs.Checker(input);
                Assert.AreEqual("a", result);
                Assert.IsTrue(_consoleOutput.ToString().Contains("Invalid input string"));
                _consoleOutput.GetStringBuilder().Clear();
            }
        }
        [TestMethod]
        public void ScoreClear()
        {
            string result = _inputs.Checker("score");
            Assert.AreEqual("Failed input", result);
            var output = _consoleOutput.ToString();
            Assert.IsTrue(output.Contains("0") || output.Contains("expected calculated score"));
        }
        [TestMethod]
        public void CardWorks()
        {
            string result = _inputs.Checker("2c");
            Assert.AreEqual("Failed input", result);
            Assert.IsTrue(_consoleOutput.ToString().Contains("Recorded"));
        }
        [TestMethod]
        public void DuplicateFail()
        {
            _inputs.Checker("2c");
            string result = _inputs.Checker("2c");
            Assert.AreEqual("Failed input", result);
            Assert.IsTrue(_consoleOutput.ToString().Contains("Cards cannot be duplicated"));
        }
        [TestMethod]
        public void JokerWorks()
        {
            string result = _inputs.Checker("jk");
            Assert.AreEqual("Failed input", result);
            Assert.IsTrue(_consoleOutput.ToString().Contains("Recorded jk"));
        }
        [TestMethod]
        public void JokerFail()
        {
            _inputs.Checker("jk");
            _inputs.Checker("jk");
            string result = _inputs.Checker("jk");
            Assert.AreEqual("Failed input", result);
            Assert.IsTrue(_consoleOutput.ToString().Contains("A hand cannot contain more than two Jokers"));
        }
        [TestMethod]
        public void JokerCalculations()
        {
            _inputs.Checker("ac");
            _inputs.Checker("jk");
            string result = _inputs.Score();
            Assert.AreEqual("h", result);
            Assert.IsTrue(_consoleOutput.ToString().Contains("28"));
        }
        [TestMethod]
        public void CorrectCalculations()
        {
            _inputs.Checker("ac");
            string result = _inputs.Score();
            Assert.AreEqual("h", result);
            Assert.IsTrue(_consoleOutput.ToString().Contains("14"));
        }
    }

}


