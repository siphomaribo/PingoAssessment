using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pingo.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreForSqlAttribute : Attribute
    {
    }
}
