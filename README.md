## 說明

包含DDD框架的實作以及相關的測試

包含一些常用的工具庫

相依Zenject、UniRx、MessagePipe、UniTask

更多資訊 See [Wiki](https://github.com/L1247/rStarUtility/wiki)

如果採用 PackageManager則不需要自己Import其他相依插件，會自動安裝

import from PackageManager [see here](https://github.com/L1247/rStarUtility#from-package-manager)

## Tests and Build Status

| Description             | Status |
|-------------------------|--------|
| [Tests and Build](https://github.com/marketplace/actions/unity-test-runner) | ![CI routine workflow](https://github.com/L1247/rStarUtility/actions/workflows/ci-routine-check.yml/badge.svg) |

## 環境

Unity 版本: `2021.3.3f1`

## 相關可選用的模組
RPG Module： https://github.com/L1247/RPG-Module


# Import

## from Unity Package : https://github.com/L1247/rStarUtility/releases

## from Package Manager

### Quick overview gif
![image](https://github.com/L1247/rStarUtility/blob/master/ScreenShots/rStarUtility.gif?raw=true)

### Please follow the instrustions:
* open Edit/Project Settings/Package Manager
* add a new Scoped Registry (or edit the existing OpenUPM entry)
```
Name: package.openupm.com
URL: https://package.openupm.com
Scope(s): 
         com.svermeulen.extenject
         com.cysharp.unitask
         com.cysharp.messagepipe
         com.cysharp.messagepipe.zenject
         com.neuecc.unirx
```
* click +
* paste scope
* click Save (or Apply)

![](https://github.com/L1247/rStarUtility/blob/master/ScreenShots/Unity_Package.Openupm.png?raw=true)

### add package from git URL
```
https://github.com/L1247/rStarUtility.git?path=Assets/rStarUtility
```

![](https://github.com/L1247/rStarUtility/blob/master/ScreenShots/Unity_AddPackageFromGitURL_New.png?raw=true)

### Done
![](https://github.com/L1247/rStarUtility/blob/master/ScreenShots/Unity_Overview.png?raw=true)

### Depandencies
![](https://github.com/L1247/rStarUtility/blob/master/ScreenShots/Unity_Depandencies.png?raw=true)

### 導入後，若需要更新到最新版只需要點Package的Update按鈕即可
![](https://github.com/L1247/rStarUtility/blob/master/ScreenShots/Unity_UpdateToNewVersion.png?raw=true)

## from Package Manager (using project manifest)

For example, modify `Packages/manifest.json` as the following:

```json
{
  "scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.cysharp.messagepipe",
        "com.cysharp.messagepipe.zenject",
        "com.cysharp.unitask",
        "com.openupm",
        "com.neuecc.unirx",
        "com.svermeulen.extenject"
      ]
    }
  ],
  "dependencies": {
    "com.rstar.rstarutility": "https://github.com/L1247/rStarUtility.git?path=Assets/rStarUtility"
  }
}
```
