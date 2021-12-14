using System;

namespace CatchThemAll.Application.Interfaces
{
    public interface ICaptureAppService : IDisposable
    {
        int Capture(string moves);
    }
}
