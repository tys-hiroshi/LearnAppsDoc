# Step1

## Lecture01

### 目的

1. 業務で利用するソースコードを読めるようになる
2. 書けるようになる
3. 最低限必要な知識を身につける

### 目標
1. サンプルコードに基づいて、Asp.Net MVCのWebアプリを作成する

#### 具体的にできてほしいこと
1. MVCとは何か理解する
1. DBからデータを取得する
1. DBにデータをインサートする
1. DBのデータを更新する
1. Controllerを追加する
1. Modelを追加する
1. Viewを追加する
1. Linqの構文が書ける
1. HTMLのformタグが生成できる・正しく使える
1. Get MethodとPost Methodの違いが分かる・使える



### まず初めに
#### MVCとは

MVC は、多くの開発者が使い慣れている標準のデザイン パターンです。
MVC フレームワークは、次のコンポーネントで構成されます。
1. モデル(Model)
2. コントローラー(Controller)
3. ビュー(View)

参考：

https://msdn.microsoft.com/ja-jp/library/dd381412(v=vs.108).aspx

http://www.objective-php.net/mvc/about

1. Gitのリポジトリを取得する。(URL:,branche:develop)
    - C:\Gitrepo\LearnApps 内に取得する。

1. IISにWebサイトを追加する
    - サイト名：LearnApps、アプリケーションプール：LearnApps、コンテンツディレクトリ：C:\Gitrepo\LearnApps、ポート：6012
    - アプリケーションプール:LearnAppsの「.Net CLRバージョン」をv4.0にする
    - Webサイト：LearnAppsにアプリケーションを追加する
    - エイリアス：MVCWebApplication、アプリケーションプール：LearnApps、物理パス：C:\Gitrepo\LearnApps\MVCWebApplication\MVCWebApplication

1. サンプルアプリを動かす
    - Cloneしたリポジトリ内のソリューションファイル(.sln)を(管理者権限で)起動する

### サンプルアプリの説明
サンプルアプリは商品の注文可能なサンプルアプリである

#### DB構成 (* は主キー)

- テーブル名：MST_Product (商品管理マスタテーブル)

|カラム名|データ型|NULL許容|備考|
|---------|----------|---------|-------|
|* ProductId  |int        |Unchecked|商品ID|
|ProductName|varchar(50)|Checked  |商品名|

- テーブル名：MST_Price(ASPIDごとの商品管理・商品価格管理マスタテーブル)

|カラム名|データ型|NULL許容|備考|
|---------|----------|---------|---------|
|* ASP_ID   |varchar(8)|Unchecked|連携先ID|
|* ProductId|int       |Unchecked|商品ID|
|Price    |money     |Checked  |商品価格|

- テーブル名：OrderManage(注文データテーブル)

|カラム名|データ型|NULL許容|備考|
|---------|----------|---------|---------|
|* SessionId|varchar(50)|Unchecked|セッションID(一注文を特定するID)|
|OrderId  |varchar(50)|Checked  |注文ID|
|ProductId|int        |Checked  |商品ID|
|Price    |money      |Checked  |商品価格|

※マスタテーブルは管理者のみが変更できるテーブルである

1. ソリューションエクスプローラ のプロジェクト：MVCWebApplicationのプロパティを開く
2. 左ペインの「Web」を選択し、「サーバー」はローカルIISを選択する
3. プロジェクトのURLは「http://localhost:6012/MVCWebApplication」を設定して、保存する
4. (Google Chromeで)Debugする
5. http://localhost:6012/MVCWebApplication/Order/Index のトップページが開く

#### 画面遷移
(以下、~はhttp://localhost:6012/MVCWebApplication を表す)

画面遷移は以下の通り。

1. ~/Order/Index (注文Top)
2. ~/Order/SelectProduct (商品一覧、商品選択)
3. ~/Order/End (注文完了)

##### 画面の説明
1. では、注文に必要なセッションID発行(セッション変数に格納)とASPIDの設定をしている
2. では、MST_Product,MST_PriceからASPIDに対応する商品情報を取得して、表示する
    - 商品一覧を表示、DropdownのComponentを用意するなど
    - 商品選択のDropdownで選択した商品をHttp PostでPOST Methodへ送信する
    - GET MethodとPOST Methodの違い：http://qiita.com/Sekky0905/items/dff3d0da059d6f5bfabf
    - 送信された情報をDBにInsertする
    - 注文完了画面に遷移する
3. ではセッション変数の削除をし、注文完了の画面を表示


### 課題
#### 記述問題
- HTTP のGET Method とPOST Methodの違いを記載すること
- OrderController.cs のL.49でOrderUtil.SelectProductName() Method にアクセスできないのはなぜか？
- MVCのModel,Controller, Viewのそれぞれを説明しなさい

#### 実践問題
- サンプルアプリを以下の通り改修すること
1. MST_Productテーブルにカラム：Detail (データ型:varchar(100))を追加し、「商品一覧、商品選択」画面の商品一覧で追加したカラムの値を表示すること (Detailは商品詳細)
1. ASPID:0001(or 0002)の管理者がMST_Productの商品名(MST_Product.ProductName)と商品詳細(MST_Product.Detail)を変更できるようにすること
    - 管理画面の商品一覧画面と商品詳細を作成すること
    - Manage/Index にQueryParameter:aspidとamanageuseridを追加して、当該のASPIDにmanageuseridが存在する場合、商品、商品名、商品詳細を編集可能にすること(ASPIDとManageUserIdの組み合わせはテーブル：MST_Managerに定義されている)
    - コントローラ：ManageController、モデル：ManageModelを追加し、画面のURL、Viewは適宜、自分で追加・Method名を決めること
    - 商品一覧を画面では商品一覧を表示し、商品名(ProductName)のリンクをクリックしたら、当該の商品詳細画面を表示して、商品名と商品詳細を変更できるようにすること。
1. 2.で作成した管理画面の商品一覧画面で商品の新規追加ボタンを押下したら、商品新規追加画面に遷移し、商品ID、商品名、商品詳細を入力し商品を追加できるようにすること
2. 1. 2.で作成した商品詳細画面に遷移し、商品を削除できるようにすること
