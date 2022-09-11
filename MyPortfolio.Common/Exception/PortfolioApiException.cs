using System;
using System.Globalization;

namespace MyPortfolio.Common.Exception
{
    public class PortfolioApiException : System.Exception
    {
        public PortfolioApiException() : base()
        {
        }

        public PortfolioApiException(string? message) : base(message)
        {
        }

        public PortfolioApiException(string message, params object[] args)
                : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
