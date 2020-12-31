﻿// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : Properties.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : Disk image plugins.
//
// --[ Description ] ----------------------------------------------------------
//
//     Contains properties for MAME Compressed Hunks of Data disk images.
//
// --[ License ] --------------------------------------------------------------
//
//     This library is free software; you can redistribute it and/or modify
//     it under the terms of the GNU Lesser General Public License as
//     published by the Free Software Foundation; either version 2.1 of the
//     License, or (at your option) any later version.
//
//     This library is distributed in the hope that it will be useful, but
//     WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//     Lesser General Public License for more details.
//
//     You should have received a copy of the GNU Lesser General Public
//     License along with this library; if not, see <http://www.gnu.org/licenses/>.
//
// ----------------------------------------------------------------------------
// Copyright © 2011-2021 Natalia Portillo
// ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Aaru.CommonTypes;
using Aaru.CommonTypes.Exceptions;
using Aaru.CommonTypes.Structs;
using Schemas;

namespace Aaru.DiscImages
{
    public sealed partial class Chd
    {
        public ImageInfo Info   => _imageInfo;
        public string    Name   => "MAME Compressed Hunks of Data";
        public Guid      Id     => new Guid("0D50233A-08BD-47D4-988B-27EAA0358597");
        public string    Format => "Compressed Hunks of Data";
        public string    Author => "Natalia Portillo";

        public List<Partition> Partitions
        {
            get
            {
                if(_isHdd)
                    throw new
                        FeaturedNotSupportedByDiscImageException("Cannot access optical tracks on a hard disk image");

                return _partitions;
            }
        }

        public List<Track> Tracks
        {
            get
            {
                if(_isHdd)
                    throw new
                        FeaturedNotSupportedByDiscImageException("Cannot access optical tracks on a hard disk image");

                return _tracks.Values.ToList();
            }
        }

        public List<Session> Sessions
        {
            get
            {
                if(_isHdd)
                    throw new
                        FeaturedNotSupportedByDiscImageException("Cannot access optical sessions on a hard disk image");

                throw new NotImplementedException();
            }
        }

        public List<DumpHardwareType> DumpHardware => null;
        public CICMMetadataType       CicmMetadata => null;
    }
}