// /***************************************************************************
// Aaru Data Preservation Suite
// ----------------------------------------------------------------------------
//
// Filename       : MediaTek.cs
// Author(s)      : Natalia Portillo <claunia@claunia.com>
//
// Component      : MediaTek vendor commands.
//
// --[ Description ] ----------------------------------------------------------
//
//     Contains vendor commands for MMC drives with MediaTek chipsets.
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

using Aaru.Console;

namespace Aaru.Devices
{
    public sealed partial class Device
    {
        /// <summary>Reads from the drive's cache.</summary>
        /// <returns><c>true</c> if the command failed and <paramref name="senseBuffer" /> contains the sense buffer.</returns>
        /// <param name="buffer">Buffer where the cache contents will be stored</param>
        /// <param name="senseBuffer">Sense buffer.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        /// <param name="duration">Duration in milliseconds it took for the device to execute the command.</param>
        /// <param name="offset">Starting offset in cache memory.</param>
        /// <param name="length">How much data to retrieve from cache.</param>
        public bool MediaTekReadCache(out byte[] buffer, out byte[] senseBuffer, uint offset, uint length, uint timeout,
                                      out double duration)
        {
            senseBuffer = new byte[32];
            byte[] cdb = new byte[10];
            buffer = new byte[length];

            cdb[0] = (byte)ScsiCommands.MediaTekReadCache;
            cdb[1] = 0x06;
            cdb[2] = (byte)((offset & 0xFF000000) >> 24);
            cdb[3] = (byte)((offset & 0xFF0000)   >> 16);
            cdb[4] = (byte)((offset & 0xFF00)     >> 8);
            cdb[5] = (byte)(offset & 0xFF);
            cdb[6] = (byte)((length & 0xFF000000) >> 24);
            cdb[7] = (byte)((length & 0xFF0000)   >> 16);
            cdb[8] = (byte)((length & 0xFF00)     >> 8);
            cdb[9] = (byte)(length & 0xFF);

            LastError = SendScsiCommand(cdb, ref buffer, out senseBuffer, timeout, ScsiDirection.In, out duration,
                                        out bool sense);

            Error = LastError != 0;

            AaruConsole.DebugWriteLine("SCSI Device", "MediaTek READ CACHE took {0} ms.", duration);

            return sense;
        }
    }
}