namespace AutomationLib.Automation
{
    public class WebAutomation : IAutomation
    {
        private bool _disposed = false;
        protected readonly IWebAutomation _automation;

        public WebAutomation(IWebAutomation automation)
        {
            _automation = automation ?? throw new ArgumentNullException(nameof(automation));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _automation.Dispose();
                ReleaseResources();
            }

            _disposed = true;
        }

        protected virtual void ReleaseResources()
        {
        }
    }
}
