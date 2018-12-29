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
//     Identifies CDRWin cuesheets (cue/bin).
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
using System.Text.RegularExpressions;
using DiscImageChef.CommonTypes.Interfaces;
using DiscImageChef.Console;

namespace DiscImageChef.DiscImages
{
    public partial class CdrWin
    {
        // Due to .cue format, this method must parse whole file, ignoring errors (those will be thrown by OpenImage()).
        public bool Identify(IFilter imageFilter)
        {
            cdrwinFilter = imageFilter;

            try
            {
                imageFilter.GetDataForkStream().Seek(0, SeekOrigin.Begin);
                byte[] testArray = new byte[512];
                imageFilter.GetDataForkStream().Read(testArray, 0, 512);
                imageFilter.GetDataForkStream().Seek(0, SeekOrigin.Begin);
                // Check for unexpected control characters that shouldn't be present in a text file and can crash this plugin
                bool twoConsecutiveNulls = false;
                for(int i = 0; i < 512; i++)
                {
                    if(i >= imageFilter.GetDataForkStream().Length) break;

                    if(testArray[i] == 0)
                    {
                        if(twoConsecutiveNulls) return false;

                        twoConsecutiveNulls = true;
                    }
                    else twoConsecutiveNulls = false;

                    if(testArray[i] < 0x20 && testArray[i] != 0x0A && testArray[i] != 0x0D && testArray[i] != 0x00)
                        return false;
                }

                cueStream = new StreamReader(cdrwinFilter.GetDataForkStream());

                while(cueStream.Peek() >= 0)
                {
                    string line = cueStream.ReadLine();

                    Regex sr = new Regex(REGEX_SESSION);
                    Regex rr = new Regex(REGEX_COMMENT);
                    Regex cr = new Regex(REGEX_MCN);
                    Regex fr = new Regex(REGEX_FILE);
                    Regex tr = new Regex(REGEX_CDTEXT);

                    // First line must be SESSION, REM, CATALOG,  FILE or CDTEXTFILE.
                    Match sm = sr.Match(line ?? throw new InvalidOperationException());
                    Match rm = rr.Match(line);
                    Match cm = cr.Match(line);
                    Match fm = fr.Match(line);
                    Match tm = tr.Match(line);

                    return sm.Success || rm.Success || cm.Success || fm.Success || tm.Success;
                }

                return false;
            }
            catch(Exception ex)
            {
                DicConsole.ErrorWriteLine("Exception trying to identify image file {0}", cdrwinFilter);
                DicConsole.ErrorWriteLine("Exception: {0}",                              ex.Message);
                DicConsole.ErrorWriteLine("Stack trace: {0}",                            ex.StackTrace);
                return false;
            }
        }
    }
}