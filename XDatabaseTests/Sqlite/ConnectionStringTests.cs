﻿/*
 * Copyright © Alexander Fuks 2017 <Alexander.V.Fuks@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using NUnit.Framework;
using XDatabase;

namespace XDatabaseTests.Sqlite
{
    public class ConnectionStringTests
    {
        [Test]
        public void TestSqliteConnectionCanBeEstablished()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.IsTrue(xQuery.TestConnection());
        }

        [Test]
        public void TestSqliteConnectionCannotBeEstablished()
        {
            string connectionString = $"Data Source={Guid.NewGuid()};FailIfMissing=true;";
            var xQuery = new XQuerySqlite(connectionString);
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestNoErrorWhileCheckingTheConnectionWithNull()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.TestConnection());
        }

        [Test]
        public void TestNoActiveConnectionAfterDefiningConnectionString()
        {
            var xQuery = new XQuerySqlite(SetUp.SqliteConnectionString);
            Assert.IsFalse(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestConnectionIsBeingClosedByChangingKeepConnectionOpen()
        {
            const string select = "select 123;";
            var xQuery = new XQuerySqlite()
            {
                ConnectionString = SetUp.SqliteConnectionString,
                KeepConnectionOpen = true
            };
            xQuery.SelectCellAs<long>(select);
            xQuery.KeepConnectionOpen = false;
            Assert.IsFalse(xQuery.IsConnectionActive);
        }
    }
}
