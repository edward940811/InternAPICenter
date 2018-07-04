using System;
using System.Collections.Generic;
using System.Text;
using ESHCloud.Bulletine;
using ESHCloud.Base;
using ESHClouds.ApiCenter.StoreHouse.Model;
using ESHCloud.Bulletine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ESHCloudsBulletineTest
    {
        BulletineClass _service = new BulletineClass();

        [TestMethod]
        public void ESHCloudsBulletine正確回傳()
        {
            BulletineViewModel model = new BulletineViewModel
            {
                CompanyId = "tina",
                Description = "tina gone",
                Top = true,
                Type = "type1",
                Date = DateTime.Now,
                Module = "Chem",
            };
            string result = _service.Create(model);
            Assert.AreNotEqual(result, null);
        }
    }
}
