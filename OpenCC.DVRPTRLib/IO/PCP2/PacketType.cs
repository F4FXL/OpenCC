using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    // ReSharper disable InconsistentNaming
    /// <summary>
    /// </summary>
    public enum PacketType : byte
    {
        RPTR_STATUS = 0x10,
        RPTR_GET_VERSION = 0x11,
        RPTR_GET_SERIAL = 0x12,
        RPTR_GET_CONFIG = 0x13,
        RPTR_SET_CONFIG = 0x14,
        RPTR_RXPREAMBLE = 0x15,
        RPTR_START = 0x16,
        RPTR_HEADER = 0x17,
        RPTR_RXSYNC = 0x18,
        RPTR_DATA = 0x19,
        RPTR_EOT = 0x1A,
        RPTR_RXLOST = 0x1B,
        //         reserved                = 0x1C,
        //         reserved                = 0x1D,
        RPTR_SFC = 0x1F,

        Answer_RPTRSTATUS = 0x10 | 0x80,
        Answer_RPTRGET_VERSION = 0x11 | 0x80,
        Answer_RPTRGET_SERIAL = 0x12 | 0x80,
        Answer_RPTRGET_CONFIG = 0x13 | 0x80,
        Answer_RPTRSET_CONFIG = 0x14 | 0x80,
        Answer_RPTRRXPREAMBLE = 0x15 | 0x80,
        Answer_RPTRSTART = 0x16 | 0x80,
        Answer_RPTRHEADER = 0x17 | 0x80,
        Answer_RPTRRXSYNC = 0x18 | 0x80,
        Answer_RPTRDATA = 0x19 | 0x80,
        Answer_RPTREOT = 0x1A | 0x80,
        Answer_RPTRRXLOST = 0x1B | 0x80,
        //         reserved                = 0x1C | 0x80,
        //         reserved                = 0x1D | 0x80,
        Answer_RPTRSFC = 0x1F | 0x80
    }
}

