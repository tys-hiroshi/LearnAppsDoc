# Step1

## Lecture04
Order.xml ファイルを正常かチェックするアプリケーション(CheckXmlTool)がある。
このアプリケーションはOrder.xmlファイルを読み込み、生産工場に送信するファイルが正しいかチェックするアプリケーションである。
異常がある場合は、対象のOrder.xmlファイルごとにLogファイルを出力する。

チェック対象のタグは以下の通りである。

| タグ要素 | 必須 | チェック方法 |
| ---- | ---- | ---- |
|  |  |  |

### 課題

#### 記述問題
1. ログ出力ファイルの問題点

    -
#### 実践問題
- サンプルアプリ(MVCWebApplication)を以下の通り改修すること
1. ログ出力先のパスが存在しない場合でもログ出力を可能とする

    - ./MVCWebApplication/MVCWebApplication/Common/Log.cs はログ出力のクラスである。
    ログ出力先は、「C:\Gitrepo\LearnApps\MVCWebApplication\log\webapplication.log」である
     「C:\Gitrepo\LearnApps\MVCWebApplication\log」のディレクトリが存在しないとエラーが発生する。
     「C:\Gitrepo\LearnApps\MVCWebApplication\log」のディレクトリが存在しなくともエラーが発生せず、ログ出力が行われるようにしなさい。
     ※「C:\Gitrepo\LearnApps\MVCWebApplication」のディレクトリは存在しているものとする。
     ~/Order/SelectProduct (GetMethod)に記載の「throw new Exception()」という行のコメントアウトを外すことで強制的に例外を発生させることによりログ出力できることを確認しなさい。

2. ログ出力ファイル名の変更
    - 「C:\Gitrepo\LearnApps\MVCWebApplication\log\webapplication.log」は単一のファイルであり、今後このファイルにログ出力される。
       ログファイル名を「webapplication.log」から「webapplication_(日付).log」へ変更すること。※(日付)にはyyyyMMddHHmmssの形式とする。例えば、「webapplication_20170715223350.log」というファイル名とすること。※String.Format()を使用すること。

1. ~/Order/SelectProduct で選択した商品を確認する画面（注文確認画面）を用意すること
    - アクション名はConfirmとすること
    - 選択した商品データはSession変数で保存すること （注文データをSession変数に保存用のClassを定義すること。ただし、基底クラスをOrderModelクラスのProductクラスとして継承すること。ヒント：Serializable属性をつけることでSession変数にデータを保存できる）
    - 注文確認画面で注文確定ボタンを押下できるようにすること。
    - 注文確定ボタンを押下後、OrderManageテーブルのカラム名：OrderDate（Datetime型）に注文日を設定すること （カラムは自分で追加すること）
    - 表示内容は商品名、商品価格、商品詳細を表示すること。ラベルと値を対に表示すること。※ラベルの表示は、@Html.LabelForと@Html.Label の両方を利用すること
    - 氏名（姓と名）を入力できるようにすること。姓はOrderManage.LastName、名はOrderManage.FirstNameに保存すること。※@Html.TextBoxForを利用すること
    - 氏名の入力制限は必須かつ最大20文字とし、全角10文字（半角20文字）とすること。
    - 入力制限を満たしていない場合は、エラーメッセージを表示すること。（参考：http://qiita.com/mrpero/items/607c31895d77815a77cb）
    - メールアドレスも必須とし、入力制限をつけること（半角100文字とし、正規表現の入力制限を利用すること。メールアドレスの正規表現は正確なものは難しいため、ネットにある正規表現を利用すること。）
2. Headerに戻るボタンを用意すること
    - 注文完了画面に遷移したら、戻るボタンは表示させないこと
3. OrderControllerのL.35〜L.46とL.86~L.96はほぼ同じコードなので、新たにメソッドを作成し、まとめて下さい。
