# SixLabors.Fonts

**SixLabors.Fonts** is a new cross-platform font loadings and drawing library.

### Packages

|         Name       | Release (NuGet) | Build Status | License | Chat |
|--------------------|-----------------|--------------|---------|------|
| `SixLabors.Fonts`   | [![Download](https://img.shields.io/myget/imagesharp-latency/v/SixLabors.Fonts.svg)](https://www.myget.org/F/imagesharp-latency/api/v2/package/SixLabors.Fonts/1.0.1) | [![imagesharp-latency MyGet Build Status](https://www.myget.org/BuildSource/Badge/imagesharp-latency?identifier=16b7c29c-eded-4309-aaf9-86efabce2e65)](https://www.myget.org/) | [![License](https://img.shields.io/badge/license-Apache%202-blue.svg)](https://raw.githubusercontent.com/Latency/ImageSharp.Core/master/LICENSE) | [![Chat](https://camo.githubusercontent.com/da2edb525cde1455a622c58c0effc3a90b9a181c/68747470733a2f2f6261646765732e6769747465722e696d2f4a6f696e253230436861742e737667)](https://gitter.im/ImageSharp/General?utm_source=badge&amp;utm_medium=badge&amp;utm_campaign=pr-badge&amp;utm_content=badge) |

### Manual build

If you prefer, you can compile SixLabors.Shapes yourself (please do and help!), you'll need:

- [Visual Studio 2017](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
- The [.NET Core 1.0 SDK Installer](https://www.microsoft.com/net/core#windows) - Non VSCode link.

To clone it locally click the "Clone in Windows" button above or run the following git commands.

```bash
git clone https://github.com/SixLabors/Fonts.git
```

### Features
- Reading font description (name, family, subname etc plus other string metadata)
- Loading True type fonts
- Loading WOFF fonts
- Load all compatable fornts from local machine store (windows only at the moment)

#### Limitations
Only support for otf and woff fonts with True Type outlines.

## API Examples

### Read font description

```c#
FontDescription description = null;
using(var fs = File.OpenReader("Font.ttf")){
    description = FontDescription.Load(fs); // once it has loaded the data the stream is no longer required and can be disposed off
}

string name = description.FontName;

```

### Popluating a font collection

```c#
FontCollection fonts = new FontCollection();
FontFamily font1 = fonts.Install("./path/to/font1.ttf");
FontFamily font2 = fonts.Install("./path/to/font2.woff");

```

### How can you help?

Please... Spread the word, contribute algorithms, submit performance improvements, unit tests. 

### Projects using SixLabors.Fonts

* [ImageSharp](https://github.com/Latency/ImageSharp) - cross platform, fully manged, image manipultion and drawing library.
