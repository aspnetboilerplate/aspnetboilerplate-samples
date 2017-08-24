using System;

namespace TesterApp
{
    public class TestResult
    {
        public bool Success { get; set; }

        public string Method { get; set; }

        public TimeSpan Duration { get; set; }

        public string ErrorMessage { get; set; }
    }
}
