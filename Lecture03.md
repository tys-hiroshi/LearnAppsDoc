# Step1

## Lecture03

### 例外処理

アプリケーションでエラーが発生した場合に原因調査のためにログ出力しておくことが必要である。
MVCWebApplication にログクラスを追加した。通常、例外処理が発生した際にログ出力をしている。

以下の通り例外処理を記載する。

```
try
{
   //通常の処理
}
catch(Exception ex)
{
   //例外処理
}
finally
{
   //最後に実行される ※1
}

```
※1 ほとんどの場合、実行されるがfinallyが実行されない場合もある。http://dobon.net/vb/dotnet/beginner/tryfinally.html

### 課題

#### 記述問題
1. ログ出力ファイルの問題点

    - MVCWebApplicationでは「C:\Gitrepo\LearnApps\MVCWebApplication\log\webapplication.log」は単一のファイルであり、今後このファイルにログ出力される。
      問題点は何か指摘して下さい。そして、その問題点に対する対策方法を記載して下さい。

2. ログ出力ファイル「C:\Gitrepo\LearnApps\MVCWebApplication\log\webapplication.log」をテキストエディタで開いたまま、Webアプリケーションで書き込みを行おうとした場合、例外は発生する。なぜか？

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
       ログファイル名を「webapplication.log」から「webapplication_(日付).log」へ変更すること。※(日付)にはyyyyMMddHHmmssの形式とする。例えば、「webapplication_20170715223350.log」というファイル名とすること。※String.Format()もしくは、string.Format()を使用すること。

3. ~/Order/SelectProductにあるtry-catch にfinallyを追加し、最後にログ出力をしなさい。(メッセージは適当にし、ExceptionはNULLでよい)
