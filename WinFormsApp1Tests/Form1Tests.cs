using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using static WinFormsApp1.Form1;

namespace WinFormsApp1.Tests
{
    [TestClass()]
    public class Form1Tests
    {
            //Проверка если число счастливое
            [TestMethod()]
            public void HappyTest()
            {
                var number = 123123;
                var message = Logic.testOfHappy(number);
                Assert.AreEqual("Число счастливое", message);
            }
            //Проверка если число не счастливое
            [TestMethod()]
            public void UnhappyTest()
            {
                var number = 123456;
                var message = Logic.testOfHappy(number);
                Assert.AreEqual(message, "Число не счастливое");
            }
    
    }
}