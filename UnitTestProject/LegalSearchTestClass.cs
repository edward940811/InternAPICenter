using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Legal.LawSearch;
using Legal.LawSearch.Conditions;


namespace UnitTestProject
{
    [TestFixture]
    public class LegalSearchTestClass
    {
        private LawSearch service;

        [OneTimeSetUp]
        public void Init()
        {
            //
            service = new Legal.LawSearch.LawSearch("jimmy", 1637);
        }
        [Test]
        public void LegalSearchCtrl_搜尋法規()
        {

            LawSearchCondition condition = new LawSearchCondition();


        }
    }
}
