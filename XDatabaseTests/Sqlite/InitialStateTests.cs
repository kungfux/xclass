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
    public class InitialStateTests
    {
        [Test]
        public void TestInitialStateOfErrorMessageIsNull()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsNull(xQuery.LastErrorMessage);
        }

        [Test]
        public void TestInitialStateOfTimeoutIs30s()
        {
            var xQuery = new XQuerySqlite();
            Assert.AreEqual(TimeSpan.FromSeconds(30).Seconds, xQuery.Timeout);
        }

        [Test]
        public void TestInitialStateOfConnectionStringIsNull()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsNull(xQuery.ConnectionString);
        }

        [Test]
        public void TestInitialStateOfIsActiveConnectionIsFalse()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.IsConnectionActive);
        }

        [Test]
        public void TestInitialStateOfIsTransactionModeIsFalse()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.IsInTransactionMode);
        }

        [Test]
        public void TestKeepConnectionOpenIsFalseByDefault()
        {
            var xQuery = new XQuerySqlite();
            Assert.IsFalse(xQuery.KeepConnectionOpen);
        }

        [Test]
        public void TestSqliteInstanceTypeEqualsToSqlite()
        {
            var xQuery = new XQuerySqlite();
            Assert.AreEqual(typeof(XQuerySqlite), xQuery.GetType());
        }
    }
}
