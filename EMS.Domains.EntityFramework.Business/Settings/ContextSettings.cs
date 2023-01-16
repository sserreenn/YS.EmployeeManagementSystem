using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domains.EntityFramework.Business.Settings;

public interface IContextSettings
{
    string DefaultConnection { get; set; }
    string ApplicationName { get; set; }
}
public class ContextSettings : IContextSettings
{
    public string DefaultConnection { get; set; }
    public string ApplicationName { get; set; }
}