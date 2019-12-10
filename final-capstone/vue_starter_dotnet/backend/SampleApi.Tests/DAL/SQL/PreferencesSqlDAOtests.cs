using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApi.DAL.SQL;
using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace SampleApi.Tests.DAL.SQL
{
    [TestClass]
    public class PreferencesSqlDAOtests
    {
        string connectionString;
        PreferencesSqlDAO dao;

        private TransactionScope transaction;

        [TestInitialize]
        public void TestInitializer()
        {
            this.transaction = new TransactionScope();

            connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DemoDB;Integrated Security=True";
            dao = new PreferencesSqlDAO(connectionString);
        }
        [TestCleanup]
        public void TestCleaner()
        {
            this.transaction.Dispose();
        }

        [TestMethod]
        public void GetAllPreferencesTest()
        {
            List<Preferences> prefsList = dao.GetAllPrefs();
            Assert.IsFalse(prefsList is null, "List should not be null.");
            Assert.IsTrue(prefsList.Count > 0, "List should not be empty.");
        }
        [TestMethod]
        public void GetUserPrefsTest()
        {
            //TODO: put a new user transaction in here to make test resilient
            var userPrefs = dao.GetUserPrefs(3);
        }
    }
}
