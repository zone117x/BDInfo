﻿//============================================================================
// BDInfo - Blu-ray Video and Audio Analysis Tool
// Copyright © 2010 Cinema Squid
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
//=============================================================================

namespace BDInfoLib.BDROM;

public abstract class TSCodecPGS
{

    public struct Frame
    {
        public bool Started;
        public bool Forced;
        public bool Finished;
    }

    public static void Scan(TSGraphicsStream stream, TSStreamBuffer buffer, ref string tag)
    {
        var segmentType = buffer.ReadByte(false);

        switch (segmentType)
        {
            case 0x15: // ODS: Object Definition Segment
                tag = ReadODS(stream, buffer);
                break;
            case 0x16: // PCS: Presentation Composition Segment
                ReadPCS(stream, buffer);
                break;
            case 0x80:
                if (!stream.LastFrame.Finished)
                    stream.LastFrame.Finished = true;
                break;
            default:
                break;
        }
        stream.IsVBR = true;
    }

    private static string ReadODS(TSGraphicsStream stream, TSStreamBuffer buffer)
    {
        var tag = string.Empty;
        int segmentSize = buffer.ReadBits2(16, false);
        int objectID = buffer.ReadBits2(16, false); // object ID

        if (stream.LastFrame.Finished) return tag;

        if (stream.LastFrame.Forced)
        {
            stream.ForcedCaptions++;
            tag = "F";
        }
        else
        {
            stream.Captions++;
            tag = "N";
        }

        return tag;
    }

    private static void ReadPCS(TSGraphicsStream stream, TSStreamBuffer buffer)
    {
        int segmentSize = buffer.ReadBits2(16, false);
        if (!stream.IsInitialized)
        {
            stream.Width = buffer.ReadBits2(16, false);
            stream.Height = buffer.ReadBits2(16, false);
            stream.IsInitialized = true;
        }
        else
        {
            buffer.ReadBits2(16, false);
            buffer.ReadBits2(16, false);
        }

        buffer.ReadByte();
        int compositionNumber = buffer.ReadBits2(16, false);
        int compositionState = buffer.ReadByte(false);
        buffer.ReadBits2(16, false);
        int numCompositionObjects = buffer.ReadByte(false);

        for (var i = 0; i < numCompositionObjects; i++)
        {
            int objectID = buffer.ReadBits2(16, false); // object ID
            buffer.ReadByte(false); // Window ID
            var forced = buffer.ReadByte(false); // Object Cropped Flag
            buffer.ReadBits2(16, false); // Object Horizontal Position
            buffer.ReadBits2(16, false); // Object Vertical Position
            buffer.ReadBits2(16, false); // Object Cropping Horizontal Position
            buffer.ReadBits2(16, false); // Object Cropping Vertical Position
            buffer.ReadBits2(16, false); // Object Cropping Width
            buffer.ReadBits2(16, false); // Object Cropping Height Position

            stream.LastFrame = new Frame { Started = true, Forced = (forced & 0x40) == 0x40, Finished = false };

            if (!stream.CaptionIDs.ContainsKey(compositionNumber))
            {
                stream.CaptionIDs[compositionNumber] = stream.LastFrame;
            }
        }
    }
}