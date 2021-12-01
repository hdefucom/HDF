
HDFDeskBend --> 任务栏拓展工具
暂时只添加了翻译功能，后续可能会添加更多功能

使用前置条件
----------------------------
1.首先申请百度通用翻译API接口获得AppId和秘钥
2.把appid和秘钥配置到config文件（以文本方式打开）中，第一行为appid，第二行为秘钥
3.安装.NetFramework4.0的运行时环境
----------------------------

使用cmd以管理员身份运行安装（不同电脑下方的目录版本号可能不一致，修改成本机的真实目录即可）

安装脚本
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /codebase HDF.DeskBand.dll

卸载脚本
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /unregister HDF.DeskBand.dll