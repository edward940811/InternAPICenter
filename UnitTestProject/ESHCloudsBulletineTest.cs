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
        public void Bulletine正確建立 ()
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
        [TestMethod]
        public void Bulletine正確取得()
        {          
            IEnumerable<BulletineViewModel> result = _service.GetAll();
            Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void Bulletine正確更新()
        {
            BulletineViewModel model = new BulletineViewModel
            {
                Id = 2002,
                CompanyId = "hahahahahah",
                Description = "busted",
                Top = true,
                Type = "type2",
                Date = DateTime.Now,
                Module = "Chem",
            };
            string result = _service.Update(model);
            Assert.AreNotEqual(result, null);
        }
        [TestMethod]
        public void Bulletine正確軟刪除()
        {
            int id = 2002;
            string result = _service.Delete(id);
            Assert.AreNotEqual(result, null);
        }
    }
}
