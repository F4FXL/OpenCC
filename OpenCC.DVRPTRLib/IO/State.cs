using System;

namespace OpenCC.DVRPTRLib.IO
{
    [Flags]
    public enum State
    {
        ReceiverEnabled = 1,
        TransmitterEnabled = 2,
        PCWtachdogEnabled = 4,
        ChecksumCalculationEnabled = 8,
        IO21Status = 16,
        IO23Status = 32,
        Reserved = 64,
        PhysicalLayerNotConfigured = 128,
        Receiving = 256,
        Transmitting = 512,
        PCWatchdogOccured = 1024,
        PCP2ChecksumCheckedOnReception = 2048
    }
}

