# 中间件管道模型测试

## 说明

目标是搭建一个管道模型，利用Ioc容器注入领域对象，构造一些列的Use扩展方法实现应用程序可伸缩可配置。

用这个管道模型搭建一个冲咖啡的程序，给自己冲一杯咖啡。

```
var containerBuilder = new WindsorContainer();
var hostBuilder = new CoffieeServiceHostBuilder(containerBuilder)
                  .UseMilk(50) 
                  .UseSuggar();
using (var host = hostBuilder.Build())
{
    host.Run();
}
```

![image](https://user-images.githubusercontent.com/11273359/165701356-3feb0774-dbb2-4a9c-92fc-d1014dc941fc.png)



当你不想放糖和牛奶时，只需要注释掉这两行就行
```
.UseMilk(50) 
.UseSuggar();
```

## 运行

```cd ServiceHostBuilder.Sample```

```dotnet run```
