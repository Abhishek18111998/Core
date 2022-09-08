using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SchoolBloodDonar.Controllers;
using SchoolBloodDonar.Core.Interface;
using SchoolBloodDonar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonarTest
{
    [TestClass]
    public class BloodTest
    {
        private Mock<IDonars> _donarMock;
        private Fixture _fixture;
        private DonarController _donarController;
        public BloodTest()
        {
            _fixture = new Fixture();
            _donarMock = new Mock<IDonars>();
        }
        [TestMethod]
        public async Task DisplayDonarsReturnOk()
        {
            var donarList = _fixture.CreateMany<SchoolModel>(3).ToList();//Duplicate
            _donarMock.Setup(repo => repo.DisplayAllDonars()).Returns(Task.FromResult(donarList));
            _donarController = new DonarController(_donarMock.Object);
            var result = await _donarController.DisplayDonars();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task DisplayDonarsThrowException()
        {
            _donarMock.Setup(repo => repo.DisplayAllDonars()).Throws(new Exception());
            _donarController = new DonarController(_donarMock.Object);
            var result = await _donarController.DisplayDonars();
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }
        [TestMethod]
        public async Task PostDonarReturnOk()
        {
            var schoolModel = _fixture.Create<SchoolModel>();
            _donarMock.Setup(repo => repo.AddNewDonar(It.IsAny<SchoolModel>())).Returns(Task.FromResult(schoolModel));
            _donarController = new DonarController(_donarMock.Object);
            var result = await _donarController.AddingDonar(schoolModel);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task PostDonarThrowException()
        {
            var schoolModel = new SchoolModel();
            _donarMock.Setup(repo => repo.AddNewDonar(It.IsAny<SchoolModel>())).Throws(new Exception());
            _donarController = new DonarController(_donarMock.Object);
            var result = await _donarController.AddingDonar(schoolModel);
            var obj = result as ObjectResult;
            Assert.AreEqual(400, obj.StatusCode);
        }

    }
}
