using AutoWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Result
    {
        [AutoWrapperPropertyMap(Prop.Result)]
        public object Data { get; set; }
    }
}
