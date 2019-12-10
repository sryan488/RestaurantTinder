using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApi.DAL;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace SampleApi.Tests.DAL.SQL
{
    [TestClass]
    class UserDAOTests
    {
        string connectionString;
        UserSqlDAO dao;

        private TransactionScope transaction;

        [TestInitialize]
        public void TestInitializer()
        {
            this.transaction = new TransactionScope();

            connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DemoDB;Integrated Security=True";
            dao = new UserSqlDAO(connectionString);
        }
        [TestCleanup]
        public void TestCleaner()
        {
            this.transaction.Dispose();
        }
        [TestMethod]
        public void GetUsersTest()
        {
            User user = dao.GetUser("Alex");
            Assert.IsFalse(user is null, "List should not be null.");
            Assert.IsTrue(!(user is null), "List should not be empty.");
        }
    }
}
