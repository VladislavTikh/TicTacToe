using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AppContext : IOwinContext
    {
        public IOwinRequest Request => throw new NotImplementedException();

        public IOwinResponse Response => throw new NotImplementedException();

        public IAuthenticationManager Authentication => throw new NotImplementedException();

        public IDictionary<string, object> Environment => throw new NotImplementedException();

        public TextWriter TraceOutput { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public T Get<T>(string key)
        {
                var type = typeof(T);
                return (T)Activator.CreateInstance(type);
        }

        public IOwinContext Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }
    }
}
