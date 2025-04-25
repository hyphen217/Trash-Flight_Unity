# 🛠️ Unityプロジェクトの実行方法

ゲーム名：Trash Flight
 
以下の手順に従って、他のPCでも正しく実行できます。

---

## 📦 1. リポジトリのクローン

### GitHub Desktopの場合：
1. GitHub Desktopを起動  
2. `File > Clone repository...` を選択  
3. このプロジェクトを選択し、保存場所を指定して `Clone` を押下  

### Gitコマンドの場合：

```bash
git clone https://github.com/あなたのユーザー名/このプロジェクト名.git
```

---

## 🔧 2. Unity Hubでプロジェクトを開く

1. Unity Hubを起動  
2. `Open` を押下  
3. クローンしたフォルダを選択  
   例：`Trash-Flight_Unity`  
4. Unityが自動的にプロジェクトを読み込みます  

> ⚠️ 初回起動時はライブラリの再生成に時間がかかることがあります。

---

## 🧩 3. 使用するUnityバージョンとモジュール

### 必須バージョン：

| バージョン | 備考         |
|------------|--------------|
| 2022.3.60f1 | LTS版。必須。|

### 推奨モジュール構成：

- ✅ Microsoft Visual Studio Community 2022  
- ✅ Android Build Support  
  - OpenJDK  
  - Android SDK & NDK Tools  
- ✅ iOS Build Support（iOS開発を行う場合）

> Unity Hubの `Installs` タブからモジュールの確認と追加ができます。

---

## ▶️ 4. ゲームの実行

1. Unityエディタ上部の ▶（再生）ボタンを押下  
2. ゲームがUnity内でプレイできます

---

## 🎮 操作方法（概要）

- 主人公の移動：  
  - マウスのX座標通りに動きます
- ミサイルは自動で発射します

---

## 📄 注意事項

- `Library/` や `Temp/` フォルダは `.gitignore` によりGitに含まれていません（Unityが自動生成）
- `.meta` ファイルは絶対に削除しないでください（アセット識別に必要）
- バージョンエラーが出る場合は、Unity Hubで2022.3.60f1を選択または追加してください

---

## 🧪 開発・動作確認環境

| 項目 | 内容 |
|------|------|
| OS | Windows 10 |
| Unity | 2022.3.60f1 |
| エディタ | Visual Studio 2022 |
