using System;

namespace HackathonTestAutomationNetCore.Tests.Classes.Helpers
{
    internal static class TypeHelper
    {
        internal static TEntity Instantiate<TEntity>() where TEntity : class, new()
        {
            return (TEntity)typeof(TEntity)
                        .GetConstructor(new Type[] { })
                        .Invoke(new object[] { });
        }
    }
}
