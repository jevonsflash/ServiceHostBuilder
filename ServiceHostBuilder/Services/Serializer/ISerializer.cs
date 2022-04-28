using System;

namespace ServiceHostBuilder.Services.Serializer
{
    public interface ISerializer
    {
        T Serialize<T>(object instance);

        TResult Deserialize<T, TResult>(T data) where TResult : class;
        object Deserialize<T>(T data, Type type);
    }
}