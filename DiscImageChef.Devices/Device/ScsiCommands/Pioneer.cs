﻿// /***************************************************************************
// The Disc Image Chef
// ----------------------------------------------------------------------------
//
// Filename       : Pioneer.cs
// Version        : 1.0
// Author(s)      : Natalia Portillo
//
// Component      : Pioneer vendor commands
//
// Revision       : $Revision$
// Last change by : $Author$
// Date           : $Date$
//
// --[ Description ] ----------------------------------------------------------
//
// Description
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
// Copyright (C) 2011-2015 Claunia.com
// ****************************************************************************/
// //$Id$
using System;
using DiscImageChef.Console;

namespace DiscImageChef.Devices
{
    public partial class Device
    {
        /// <summary>
        /// Sends the Pioneer READ CD-DA command
        /// </summary>
        /// <returns><c>true</c> if the command failed and <paramref name="senseBuffer"/> contains the sense buffer.</returns>
        /// <param name="buffer">Buffer where the Pioneer READ CD-DA response will be stored</param>
        /// <param name="senseBuffer">Sense buffer.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        /// <param name="duration">Duration in milliseconds it took for the device to execute the command.</param>
        /// <param name="lba">Start block address.</param>
        /// <param name="transferLength">How many blocks to read.</param>
        /// <param name="blockSize">Block size.</param>
        /// <param name="subchannel">Subchannel selection.</param>
        public bool PioneerReadCdDa(out byte[] buffer, out byte[] senseBuffer, uint lba, uint blockSize, uint transferLength, PioneerSubchannel subchannel, uint timeout, out double duration)
        {
            senseBuffer = new byte[32];
            byte[] cdb = new byte[12];
            bool sense;

            cdb[0] = (byte)ScsiCommands.ReadCdDa;
            cdb[2] = (byte)((lba & 0xFF000000) >> 24);
            cdb[3] = (byte)((lba & 0xFF0000) >> 16);
            cdb[4] = (byte)((lba & 0xFF00) >> 8);
            cdb[5] = (byte)(lba & 0xFF);
            cdb[7] = (byte)((transferLength & 0xFF0000) >> 16);
            cdb[8] = (byte)((transferLength & 0xFF00) >> 8);
            cdb[9] = (byte)(transferLength & 0xFF);
            cdb[10] = (byte)subchannel;

            buffer = new byte[blockSize * transferLength];

            lastError = SendScsiCommand(cdb, ref buffer, out senseBuffer, timeout, ScsiDirection.In, out duration, out sense);
            error = lastError != 0;

            DicConsole.DebugWriteLine("SCSI Device", "PIONEER READ CD-DA took {0} ms.", duration);

            return sense;
        }

        /// <summary>
        /// Sends the Pioneer READ CD-DA MSF command
        /// </summary>
        /// <returns><c>true</c> if the command failed and <paramref name="senseBuffer"/> contains the sense buffer.</returns>
        /// <param name="buffer">Buffer where the Pioneer READ CD-DA MSF response will be stored</param>
        /// <param name="senseBuffer">Sense buffer.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        /// <param name="duration">Duration in milliseconds it took for the device to execute the command.</param>
        /// <param name="startMsf">Start MM:SS:FF of read encoded as 0x00MMSSFF.</param>
        /// <param name="endMsf">End MM:SS:FF of read encoded as 0x00MMSSFF.</param>
        /// <param name="blockSize">Block size.</param>
        /// <param name="subchannel">Subchannel selection.</param>
        public bool PioneerReadCdDaMsf(out byte[] buffer, out byte[] senseBuffer, uint startMsf, uint endMsf, uint blockSize, PioneerSubchannel subchannel, uint timeout, out double duration)
        {
            senseBuffer = new byte[32];
            byte[] cdb = new byte[12];
            bool sense;

            cdb[0] = (byte)ScsiCommands.ReadCdMsf;
            cdb[3] = (byte)((startMsf & 0xFF0000) >> 16);
            cdb[4] = (byte)((startMsf & 0xFF00) >> 8);
            cdb[5] = (byte)(startMsf & 0xFF);
            cdb[7] = (byte)((endMsf & 0xFF0000) >> 16);
            cdb[8] = (byte)((endMsf & 0xFF00) >> 8);
            cdb[9] = (byte)(endMsf & 0xFF);
            cdb[10] = (byte)subchannel;

            uint transferLength = (uint)((cdb[6] - cdb[3]) * 60 * 75 + (cdb[7] - cdb[4]) * 75 + (cdb[8] - cdb[5]));

            buffer = new byte[blockSize * transferLength];

            lastError = SendScsiCommand(cdb, ref buffer, out senseBuffer, timeout, ScsiDirection.In, out duration, out sense);
            error = lastError != 0;

            DicConsole.DebugWriteLine("SCSI Device", "PIONEER READ CD-DA MSF took {0} ms.", duration);

            return sense;
        }

        /// <summary>
        /// Sends the Pioneer READ CD-XA command
        /// </summary>
        /// <returns><c>true</c> if the command failed and <paramref name="senseBuffer"/> contains the sense buffer.</returns>
        /// <param name="buffer">Buffer where the Pioneer READ CD-XA response will be stored</param>
        /// <param name="senseBuffer">Sense buffer.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        /// <param name="duration">Duration in milliseconds it took for the device to execute the command.</param>
        /// <param name="errorFlags">If set to <c>true</c>, returns all sector data with 294 bytes of error flags. Superseedes <paramref name="wholeSector"/></param>
        /// <param name="wholeSector">If set to <c>true</c>, returns all 2352 bytes of sector data.</param>
        /// <param name="lba">Start block address.</param>
        /// <param name="transferLength">How many blocks to read.</param>
        public bool PioneerReadCdXa(out byte[] buffer, out byte[] senseBuffer, uint lba, uint transferLength, bool errorFlags, bool wholeSector, uint timeout, out double duration)
        {
            senseBuffer = new byte[32];
            byte[] cdb = new byte[12];
            bool sense;

            cdb[0] = (byte)ScsiCommands.ReadCdXa;
            cdb[2] = (byte)((lba & 0xFF000000) >> 24);
            cdb[3] = (byte)((lba & 0xFF0000) >> 16);
            cdb[4] = (byte)((lba & 0xFF00) >> 8);
            cdb[5] = (byte)(lba & 0xFF);
            cdb[7] = (byte)((transferLength & 0xFF0000) >> 16);
            cdb[8] = (byte)((transferLength & 0xFF00) >> 8);
            cdb[9] = (byte)(transferLength & 0xFF);

            if (errorFlags)
            {
                buffer = new byte[2646 * transferLength];
                cdb[6] = 0x1F;
            }
            else if (wholeSector)
            {
                buffer = new byte[2352 * transferLength];
                cdb[6] = 0x0F;
            }
            else
            {
                buffer = new byte[2048 * transferLength];
                cdb[6] = 0x00;
            }

            lastError = SendScsiCommand(cdb, ref buffer, out senseBuffer, timeout, ScsiDirection.In, out duration, out sense);
            error = lastError != 0;

            DicConsole.DebugWriteLine("SCSI Device", "PIONEER READ CD-XA took {0} ms.", duration);

            return sense;
        }
    }
}

