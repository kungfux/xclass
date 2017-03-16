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

namespace XDatabaseTests
{
    public class XQueryFieldsTests
    {
        private const XDatabaseType DbType = XDatabaseType.SqLite;

        [Test]
        public void TestTimeoutCanBeChanges()
        {
            var timeout = (int)TimeSpan.FromSeconds(10).TotalMilliseconds;
            var xQuery = new XQuery(DbType);
            xQuery.Timeout = timeout;
            Assert.AreEqual(timeout, xQuery.Timeout);
        }

        [Test]
        public void TestTimeoutCannotBeSetToZero()
        {
            var xQuery = new XQuery(DbType);
            var defaultTimeout = xQuery.Timeout;
            xQuery.Timeout = 0;
            Assert.AreEqual(defaultTimeout, xQuery.Timeout);
        }
    }
}
