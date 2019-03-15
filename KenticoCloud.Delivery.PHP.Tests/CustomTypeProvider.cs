using KenticoCloud.Delivery;
using Models;
using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kc_peachpie_test
{
    public class CustomTypeProvider : TypeMapperInterface
    {
        private static readonly Dictionary<Type, string> _codenames = new Dictionary<Type, string>
        {
            {typeof(Article), "article"}
        };

        public PhpValue getTypeClass(PhpValue typeName)
        {
            Type objectType = _codenames.Keys.FirstOrDefault(type => GetCodename(type).Equals(typeName.String));
            return PhpValue.Create("\\" + objectType.FullName.Replace('.', '\\'));
        }

        public string GetCodename(Type contentType)
        {
            return _codenames.TryGetValue(contentType, out var codename) ? codename : null;
        }
    }
}