﻿// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : VirtualPC.cs
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
using Aaru.CommonTypes;
using Aaru.CommonTypes.Interfaces;
using Aaru.DiscImages;
using NUnit.Framework;

namespace Aaru.Tests.Images.VirtualBox
{
    [TestFixture]
    public class VirtualPc : BlockMediaImageTest
    {
        public override string DataFolder =>
            Path.Combine(Consts.TEST_FILES_ROOT, "Media image formats", "VirtualBox", "VirtualPC");
        public override IMediaImage _plugin => new Vhd();

        public override BlockImageTestExpected[] Tests => new[]
        {
            new BlockImageTestExpected
            {
                TestFile   = "virtualbox_linux_dynamic_250mb.vhd.lz",
                MediaType  = MediaType.Unknown,
                Sectors    = 512000,
                SectorSize = 512,
                MD5        = "f968f0e74dd1b254de9eac589a5d687d"
            },
            new BlockImageTestExpected
            {
                TestFile   = "virtualbox_linux_fixed_10mb.vhd.lz",
                MediaType  = MediaType.Unknown,
                Sectors    = 20480,
                SectorSize = 512,
                MD5        = "f1c9645dbc14efddc7d8a322685f26eb"
            },
            new BlockImageTestExpected
            {
                TestFile   = "virtualbox_macos_dynamic_250mb.vhd.lz",
                MediaType  = MediaType.Unknown,
                Sectors    = 512000,
                SectorSize = 512,
                MD5        = "09d3dce9e60e9d1a997ad3f04d33c8c5"
            },
            new BlockImageTestExpected
            {
                TestFile   = "virtualbox_macos_fixed_10mb.vhd.lz",
                MediaType  = MediaType.Unknown,
                Sectors    = 20480,
                SectorSize = 512,
                MD5        = "f1c9645dbc14efddc7d8a322685f26eb"
            },
            new BlockImageTestExpected
            {
                TestFile   = "virtualbox_windows_dynamic_250mb.vhd.lz",
                MediaType  = MediaType.Unknown,
                Sectors    = 512000,
                SectorSize = 512,
                MD5        = "284af271786e7def9bf8af7c2da1c4f2"
            },
            new BlockImageTestExpected
            {
                TestFile   = "virtualbox_windows_fixed_10mb.vhd.lz",
                MediaType  = MediaType.Unknown,
                Sectors    = 20480,
                SectorSize = 512,
                MD5        = "f1c9645dbc14efddc7d8a322685f26eb"
            }
        };
    }
}