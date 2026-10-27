using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfLibrary1;
using System;

namespace TestProject1
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calc;

        [TestInitialize]
        public void Setup()
        {
            _calc = new Calculator();
        }

        [TestMethod]
        public void Сложение_2Плюс3_Возвращает5()
        {
            Assert.AreEqual(5.0, _calc.Compute("2+3"), 0.001);
        }

        [TestMethod]
        public void Вычитание_10Минус4_Возвращает6()
        {
            Assert.AreEqual(6.0, _calc.Compute("10-4"), 0.001);
        }

        [TestMethod]
        public void Умножение_6УмножитьНа7_Возвращает42()
        {
            Assert.AreEqual(42.0, _calc.Compute("6*7"), 0.001);
        }

        [TestMethod]
        public void Деление_15РазделитьНа3_Возвращает5()
        {
            Assert.AreEqual(5.0, _calc.Compute("15/3"), 0.001);
        }

        [TestMethod]
        public void Степень_3ВСтепени2_Возвращает9()
        {
            Assert.AreEqual(9.0, _calc.Compute("3^2"), 0.001);
        }

        [TestMethod]
        public void Степень_Минус2ВКвадратеПлюс1Плюс4_Возвращает9()
        {
            Assert.AreEqual(9.0, _calc.Compute("-2^2+(1+4)"), 0.001);
        }

        [TestMethod]
        public void Приоритет_3Плюс5УмножитьНа2_Возвращает13()
        {
            Assert.AreEqual(13.0, _calc.Compute("3+5*2"), 0.001);
        }

        [TestMethod]
        public void Скобки_2Плюс3СкобкаУмножитьНа4_Возвращает20()
        {
            Assert.AreEqual(20.0, _calc.Compute("(2+3)*4"), 0.001);
        }

        [TestMethod]
        public void ДелениеНаНоль_ВыбрасываетИсключение()
        {
            Assert.ThrowsException<DivideByZeroException>(() => _calc.Compute("10/0"));
        }

        [TestMethod]
        public void ПустаяСтрока_ВыбрасываетИсключение()
        {
            Assert.ThrowsException<ArgumentException>(() => _calc.Compute(""));
        }
    }
}