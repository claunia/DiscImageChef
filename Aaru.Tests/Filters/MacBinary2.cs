﻿// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : MacBinary2.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : Aaru unit testing.
//
// --[ License ] --------------------------------------------------------------
//
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as
//     published by the Free Software Foundation, either version 3 of the
//     License, or (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// ----------------------------------------------------------------------------
// Copyright © 2011-2021 Natalia Portillo
// ****************************************************************************/

using System.IO;
using Aaru.Checksums;
using Aaru.CommonTypes.Interfaces;
using Aaru.Filters;
using NUnit.Framework;

namespace Aaru.Tests.Filters
{
    [TestFixture]
    public class MacBinary2
    {
        const    string EXPECTED_FILE     = "a8daa55a65432353e95dc4c61d42660f";
        const    string EXPECTED_CONTENTS = "c2be571406cf6353269faa59a4a8c0a4";
        const    string EXPECTED_RESOURCE = "a972d27c44193a7587b21416c0953cc3";
        readonly string _location;

        public MacBinary2() =>
            _location = Path.Combine(Consts.TEST_FILES_ROOT, "Filters", "MacBinary", "macbinary2.bin");

        [Test]
        public void CheckContents()
        {
            IFilter filter = new MacBinary();
            filter.Open(_location);
            Stream str  = filter.GetDataForkStream();
            byte[] data = new byte[737280];
            str.Read(data, 0, 737280);
            str.Close();
            str.Dispose();
            filter.Close();
            string result = Md5Context.Data(data, out _);
            Assert.AreEqual(EXPECTED_CONTENTS, result);
        }

        [Test]
        public void CheckCorrectFile()
        {
            string result = Md5Context.File(_location, out _);
            Assert.AreEqual(EXPECTED_FILE, result);
        }

        [Test]
        public void CheckFilterId()
        {
            IFilter filter = new MacBinary();
            Assert.AreEqual(true, filter.Identify(_location));
        }

        [Test]
        public void CheckResource()
        {
            IFilter filter = new MacBinary();
            filter.Open(_location);
            Stream str  = filter.GetResourceForkStream();
            byte[] data = new byte[286];
            str.Read(data, 0, 286);
            str.Close();
            str.Dispose();
            filter.Close();
            string result = Md5Context.Data(data, out _);
            Assert.AreEqual(EXPECTED_RESOURCE, result);
        }

        [Test]
        public void Test()
        {
            IFilter filter = new MacBinary();
            filter.Open(_location);
            Assert.AreEqual(true, filter.IsOpened());
            Assert.AreEqual(737280, filter.GetDataForkLength());
            Assert.AreNotEqual(null, filter.GetDataForkStream());
            Assert.AreEqual(286, filter.GetResourceForkLength());
            Assert.AreNotEqual(null, filter.GetResourceForkStream());
            Assert.AreEqual(true, filter.HasResourceFork());
            filter.Close();
        }
    }
}