![Icon](https://raw.github.com/johnverbiest/TransformOnBuild/master/icon/32.png) Transform Text Templates On Build
============

Automatically transforms on build all files with a build action of `None` or `Content` that have the `TextTemplatingFileGenerator` or `TransformOnBuild` custom tools associated.

[![Build, Test and Deploy Nuget package](https://github.com/johnverbiest/TransformOnBuild/actions/workflows/dotnet.yml/badge.svg)](https://github.com/johnverbiest/TransformOnBuild/actions/workflows/dotnet.yml)

## Installation

To install Transform Text Templates On Build, run the following command in the Package Manager Console:

```
PM> Install-Package JohnVerbiest.TransformOnBuild 
```

Unlike the [officially suggested way](http://msdn.microsoft.com/en-us/library/ee847423.aspx), this package does not require any Visual Studio SDK to be installed on the machine or build server.

If a full Visual Studio installation is not available on the build server, you can still transform the templates by placing the TextTransform.exe in a known location. Then, you can simply override the path expected by the targets with:

    <PropertyGroup>
        <TextTransformPath>MyTools\TextTransform.exe</TextTransformPath>
    </PropertyGroup>


With that in place, the transformation will be performed using that file instead, if found.

If you would like to pass parameters to TextTransform.exe, define a group of TextTransformParameter items as follows:

    <ItemGroup>
        <TextTransformParameter Include="Foo">
            <Value>bar</Value>
            <InProject>false</InProject>
        </TextTransformParameter>
        <TextTransformParameter Include="Config">
            <Value>$(Configuration)</Value>
            <InProject>false</InProject>
        </TextTransformParameter>
    </ItemGroup>


The Include attribute specifies the parameter name, and the Value metadata element specifies the parameter value.

To access the parameter values from your text template, set `hostspecific` in the `template` directive and invoke `this.Host.ResolveParameterValue(...)`. For example:

    <#@ template language="C#" hostspecific="true" #>
    <#
        var foo = this.Host.ResolveParameterValue("", "", "Foo");
        var config = this.Host.ResolveParameterValue("", "", "Config");
    #>

### History

> Originally forked from https://github.com/clariuslabs/TransformOnBuild
> Original NuPkg: https://www.nuget.org/packages/Clarius.TransformOnBuild/
      