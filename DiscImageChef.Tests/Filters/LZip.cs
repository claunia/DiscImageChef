﻿// /***************************************************************************
// The Disc Image Chef
// ----------------------------------------------------------------------------
//
// Filename       : LZip.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : DiscImageChef unit testing.
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
// Copyright © 2011-2019 Natalia Portillo
// ****************************************************************************/

using System.IO;
using DiscImageChef.Checksums;
using DiscImageChef.CommonTypes.Interfaces;
using NUnit.Framework;

namespace DiscImageChef.Tests.Filters
{
    [TestFixture]
    public class LZip
    {
        static readonly byte[] ExpectedFile =
            {0x3f, 0x7b, 0x77, 0x3e, 0x52, 0x48, 0xd5, 0x26, 0xf4, 0xb1, 0xac, 0x15, 0xb2, 0xb3, 0x5f, 0x87};
        static readonly byte[] ExpectedContents =
            {0x18, 0x90, 0x5a, 0xf9, 0x83, 0xd8, 0x2b, 0xdd, 0x1a, 0xcc, 0x69, 0x75, 0x4f, 0x0f, 0x81, 0x5e};
        readonly string location;

        public LZip()
        {
            location = Path.Combine(Consts.TestFilesRoot, "filters", "lzip.lz");
        }

        [Test]
        public void CheckCorrectFile()
        {
            byte[] result = Md5Context.File(location);
            Assert.AreEqual(ExpectedFile, result);
        }

        [Test]
        public void CheckFilterId()
        {
            IFilter filter = new DiscImageChef.Filters.LZip();
            Assert.AreEqual(true, filter.Identify(location));
        }

        [Test]
        public void Test()
        {
            IFilter filter = new DiscImageChef.Filters.LZip();
            filter.Open(location);
            Assert.AreEqual(true,    filter.IsOpened());
            Assert.AreEqual(1048576, filter.GetDataForkLength());
            Assert.AreNotEqual(null, filter.GetDataForkStream());
            Assert.AreEqual(0,     filter.GetResourceForkLength());
            Assert.AreEqual(null,  filter.GetResourceForkStream());
            Assert.AreEqual(false, filter.HasResourceFork());
            filter.Close();
        }

        [Test]
        public void CheckContents()
        {
            IFilter filter = new DiscImageChef.Filters.LZip();
            filter.Open(location);
            Stream str  = filter.GetDataForkStream();
            byte[] data = new byte[1048576];
            str.Read(data, 0, 1048576);
            str.Close();
            str.Dispose();
            filter.Close();
            Md5Context.Data(data, out byte[] result);
            Assert.AreEqual(ExpectedContents, result);
        }
    }
}