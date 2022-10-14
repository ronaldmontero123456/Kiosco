using DPFP;
using DPFP.Capture;

namespace Test1;

public class pdff : EventHandler
{

    private DPFP.Capture.Capture? Capturer;

    protected virtual void Init()
    {
        try
        {
            Capturer = new DPFP.Capture.Capture();              // Create a capture operation.

            if (null != Capturer)
                Capturer.EventHandler = this;                   // Subscribe for capturing events.
        }
        catch
        {
            throw;

        }
    }

    public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
    {
        throw new System.NotImplementedException();
    }

    public void OnFingerGone(object Capture, string ReaderSerialNumber)
    {
        throw new System.NotImplementedException();
    }

    public void OnFingerTouch(object Capture, string ReaderSerialNumber)
    {
        throw new System.NotImplementedException();
    }

    public void OnReaderConnect(object Capture, string ReaderSerialNumber)
    {
        throw new System.NotImplementedException();
    }

    public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
    {
        throw new System.NotImplementedException();
    }

    public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
    {
        throw new System.NotImplementedException();
    }

}
