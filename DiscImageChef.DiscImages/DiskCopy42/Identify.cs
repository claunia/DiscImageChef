﻿// /***************************************************************************
// The Disc Image Chef
// ----------------------------------------------------------------------------
//
// Filename       : Identify.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : Disk image plugins.
//
// --[ Description ] ----------------------------------------------------------
//
//     Identifies Apple DiskCopy 4.2 disk images.
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
// Copyright © 2011-2019 Natalia Portillo
// ****************************************************************************/

using System;
using System.IO;
using Claunia.Encoding;
using DiscImageChef.CommonTypes.Interfaces;
using DiscImageChef.Console;

namespace DiscImageChef.DiscImages
{
    public partial class DiskCopy42
    {
        public bool Identify(IFilter imageFilter)
        {
            Stream stream = imageFilter.GetDataForkStream();
            stream.Seek(0, SeekOrigin.Begin);
            byte[] buffer  = new byte[0x58];
            byte[] pString = new byte[64];
            stream.Read(buffer, 0, 0x58);

            // Incorrect pascal string length, not DC42
            if(buffer[0] > 63) return false;

            Dc42Header tmpHeader = new Dc42Header();

            Array.Copy(buffer, 0, pString, 0, 64);

            BigEndianBitConverter.IsLittleEndian = BitConverter.IsLittleEndian;

            tmpHeader.DiskName     = StringHandlers.PascalToString(pString, Encoding.GetEncoding("macintosh"));
            tmpHeader.DataSize     = BigEndianBitConverter.ToUInt32(buffer, 0x40);
            tmpHeader.TagSize      = BigEndianBitConverter.ToUInt32(buffer, 0x44);
            tmpHeader.DataChecksum = BigEndianBitConverter.ToUInt32(buffer, 0x48);
            tmpHeader.TagChecksum  = BigEndianBitConverter.ToUInt32(buffer, 0x4C);
            tmpHeader.Format       = buffer[0x50];
            tmpHeader.FmtByte      = buffer[0x51];
            tmpHeader.Valid        = buffer[0x52];
            tmpHeader.Reserved     = buffer[0x53];

            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.diskName = \"{0}\"",      tmpHeader.DiskName);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.dataSize = {0} bytes",    tmpHeader.DataSize);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.tagSize = {0} bytes",     tmpHeader.TagSize);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.dataChecksum = 0x{0:X8}", tmpHeader.DataChecksum);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.tagChecksum = 0x{0:X8}",  tmpHeader.TagChecksum);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.format = 0x{0:X2}",       tmpHeader.Format);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.fmtByte = 0x{0:X2}",      tmpHeader.FmtByte);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.valid = {0}",             tmpHeader.Valid);
            DicConsole.DebugWriteLine("DC42 plugin", "tmp_header.reserved = {0}",          tmpHeader.Reserved);

            if(tmpHeader.Valid != 1 || tmpHeader.Reserved != 0) return false;

            // Some versions seem to incorrectly create little endian fields
            if(tmpHeader.DataSize + tmpHeader.TagSize + 0x54 != imageFilter.GetDataForkLength() &&
               tmpHeader.Format                              != kSigmaFormatTwiggy)
            {
                tmpHeader.DataSize     = BitConverter.ToUInt32(buffer, 0x40);
                tmpHeader.TagSize      = BitConverter.ToUInt32(buffer, 0x44);
                tmpHeader.DataChecksum = BitConverter.ToUInt32(buffer, 0x48);
                tmpHeader.TagChecksum  = BitConverter.ToUInt32(buffer, 0x4C);

                if(tmpHeader.DataSize + tmpHeader.TagSize + 0x54 != imageFilter.GetDataForkLength() &&
                   tmpHeader.Format                              != kSigmaFormatTwiggy) return false;
            }

            if(tmpHeader.Format != kSonyFormat400K  && tmpHeader.Format != kSonyFormat800K    &&
               tmpHeader.Format != kSonyFormat720K  && tmpHeader.Format != kSonyFormat1440K   &&
               tmpHeader.Format != kSonyFormat1680K && tmpHeader.Format != kSigmaFormatTwiggy &&
               tmpHeader.Format != kNotStandardFormat)
            {
                DicConsole.DebugWriteLine("DC42 plugin", "Unknown tmp_header.format = 0x{0:X2} value",
                                          tmpHeader.Format);

                return false;
            }

            if(tmpHeader.FmtByte != kSonyFmtByte400K          && tmpHeader.FmtByte != kSonyFmtByte800K    &&
               tmpHeader.FmtByte != kSonyFmtByte800KIncorrect && tmpHeader.FmtByte != kSonyFmtByteProDos  &&
               tmpHeader.FmtByte != kInvalidFmtByte           && tmpHeader.FmtByte != kSigmaFmtByteTwiggy &&
               tmpHeader.FmtByte != kFmtNotStandard           && tmpHeader.FmtByte != kMacOSXFmtByte)
            {
                DicConsole.DebugWriteLine("DC42 plugin", "Unknown tmp_header.fmtByte = 0x{0:X2} value",
                                          tmpHeader.FmtByte);

                return false;
            }

            if(tmpHeader.FmtByte != kInvalidFmtByte) return true;

            DicConsole.DebugWriteLine("DC42 plugin", "Image says it's unformatted");

            return false;
        }
    }
}