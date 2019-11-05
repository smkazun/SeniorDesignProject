using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenSourceBlog.Test
{
    public interface IRepositoryTest
    {
        [TestInitialize]
        void TestSetup();

        [TestMethod]
        void GetAll();

        [TestMethod]
        void Get();

        [TestMethod]
        void Create();

        [TestMethod]
        void Update();

        [TestMethod]
        void Delete();

    }
}