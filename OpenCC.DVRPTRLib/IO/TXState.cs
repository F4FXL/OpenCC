using System;

namespace OpenCC.DVRPTRLib.IO
{
    // ReSharper disable InconsistentNaming
    public enum TXState
    {
        /// <summary>
        /// disabled; Tranceiver not active
        /// </summary>
        RPTRTX_disabled,
        /// <summary>
        /// idle; DV-RPTR don't transmit
        /// </summary>
        RPTRTX_idle,
        /// <summary>
        /// TX delay; PTT line active, no modulation
        /// </summary>
        RPTRTX_txdelay,
        /// <summary>
        /// ransmitting 010101... preamble (end with start pattern)
        /// </summary>
        RPTRTX_preamble,
        /// <summary>
        /// header transmission (in this state the app can't update the header with another new one)
        /// </summary>
        RPTRTX_header,
        /// <summary>
        /// voice data
        /// </summary>
        RPTRTX_voicedata,
        /// <summary>
        /// last frame transmission (voice followed by a stop pattern instead of slow data)
        /// </summary>
        RPTRTX_lastframe,
        /// <summary>
        /// EOT transmit end-of-transmission
        /// </summary>
        RPTRTX_eot

    }
}

