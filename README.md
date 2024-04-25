# dotnet_BlazorHybrid4+MudBlazor

## 概要
* 試行錯誤中
* ベース: [dotnet_BlazorHybrid4](https://github.com/Tobotobo/dotnet_BlazorHybrid4)
* [MudBlazor](https://mudblazor.com/)
* [MudBlazor-カタログ](https://mudblazor.com/docs/overview)

## 参考サイト
感謝！
* [ねこじょーかー/Blazor HybridとBlazor Web AppのUIをRCLで共通化する手順](https://blazor-master.com/blazor-hybrid-maui-rcl/)
* [nekojoker/BlazorHybrid](https://github.com/nekojoker/BlazorHybrid)
    > .NET MAUI Blazor アプリと Blazor Web App の Razor コンポーネントや静的資産を Razor クラスライブラリで共通化したプロジェクトです。  
    > .NET 8 に対応しています。

## 環境
```
> dotnet --info   
.NET SDK:
 Version:           8.0.204   
 Commit:            c338c7548c
 Workload version:  8.0.200-manifests.c4df6daf

ランタイム環境:
 OS Name:     Windows
 OS Version:  10.0.19045
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\8.0.204\
```

## 詳細

### MudBlazor

```
dotnet add ./BlazorHybrid.View package MudBlazor
```

BlazorHybrid.View/_Imports.razor
```
@using MudBlazor
```

BlazorHybrid.Forms/wwwroot/index.html  
BlazorHybrid.Web/Components/App.razor
```html
<link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
<link href="_content/MudBlazor/MudBlazor.min.css" rel="stylesheet" />
<script src="_content/MudBlazor/MudBlazor.min.js"></script>
```

BlazorHybrid.View/Initializer.cs
```cs
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace BlazorHybrid.View
{
    public static class Initializer
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddMudServices();
        }
    }
}
```

BlazorHybrid.Web/Program.cs
```cs
BlazorHybrid.View.Initializer.Initialize(builder.Services);
```

BlazorHybrid.Forms/Form1.cs
```cs
BlazorHybrid.View.Initializer.Initialize(services);
```

### watch 実行　※ Web
* `Ctrl + Shift + B` またはタスクから `watch` を実行

### publish 実行　※ Forms の exe 作成
* タスクから `publish` を実行
* ルートに publish フォルダが生成される