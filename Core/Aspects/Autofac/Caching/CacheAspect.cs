using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            //$ kısmı içinde namespace +method ismi
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList(); //parametrelerini listeye çevir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // parametre değeri varsa ekle yoksa null //??=varsa bunu yoksa bunu
            if (_cacheManager.IsAdd(key)) //bellekte varmı kontrol
            {
                invocation.ReturnValue = _cacheManager.Get(key); //varsa bellekte methodu çalıştırmadan geri dön,cacheden al
                return;
            }
            invocation.Proceed(); //yoksa invocationu devam ettir
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //ekle
        }
    }
}
