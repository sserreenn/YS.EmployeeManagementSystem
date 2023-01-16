using System.Globalization;

namespace EMS.Core.Extensions;


public class AppException : Exception
{
    private readonly int _code;
    private readonly string _appMessage;

    public virtual int Code
    {
        get { return this._code; }
    }

    public virtual string AppMessage
    {
        get { return this._appMessage; }
    }

    public AppException() : base() { }

    public AppException(string message) : base(message) { }

    public AppException(int code, string appMessage) : base()
    {
        this._code = code;
        this._appMessage = appMessage;
    }

    public AppException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
}
