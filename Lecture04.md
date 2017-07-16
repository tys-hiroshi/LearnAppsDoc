# Step1

## Lecture04
Order.xml ファイルを正常かチェックするアプリケーション(CheckXmlTool)がある。
このアプリケーションはOrder.xmlファイルを読み込み、生産工場に送信するファイルが正しいかチェックするアプリケーションである。
チェック結果を対象のOrder.xmlファイルごとにLogファイル(CSV形式)を出力する。

確認用のOrder.xmlファイルは CheckXmlTool/CheckXmlTool/xml/Order01 やOrder02フォルダ内に存在する。

チェック対象のタグ(Tag0~Tag4、Attributes)は以下の通りである。(以下、Format.csvという)
URL：https://github.com/infinith4/CheckXmlTool/blob/develop/CheckXmlTool/csv/Format.csv

|Tag0       |Tag1 |Tag2    |Tag3    |Tag4     |Attributes|Required|Conditions                                                      |
|-----------|-----|--------|--------|---------|----------|--------|----------------------------------------------------------------|
|CenterOrder|     |        |        |         |          |◎       |                                                                |
|           |Order|        |        |         |AppId     |◎       |AttributesのAppIdは0001 or 0002とする                                |
|           |     |OrderId |        |         |          |◎       |OrderIdは6桁とする                                                   |
|           |     |PayType |        |         |          |◎       |「2、4、5、7」のみとする                                                  |
|           |     |ShipType|        |         |          |◎       |「2、3、6」のみとする                                                    |
|           |     |Option  |        |         |          |        |                                                                |
|           |     |Option1 |        |         |          |×       |                                                                |
|           |     |Articles|        |         |ArticleNum|◎       |ArticleNumがArticles内のArticleTagの数と等しいこと。ArticleNumは1以上とする。                         |
|           |     |        |*Article|         |          |◎       |                                                               |
|           |     |        |        |ProductId|          |〇       |Articleタグが存在する場合は、当該のタグが存在しなければならない。MST_PriceのASP_IDとOrderタグのAttributes:AppIdに一致するデータのProductIdであること|
|           |     |        |        |Price    |          |〇       | Articleタグが存在する場合は、当該のタグが存在しなければならない。                                                               |


※ 「\*Article」のように「\*」が付く場合は複数のタグが存在を許容する。


#### チェック方法

- 必須チェック

    - Requiredとは、Tag0~Tag4、Attributesに対する必須・不要を表す。(Tag0~Tag4が必須の場合はAttributesも必須である)

| Required | 説明 | 備考 |
| ---- | ---- | ---- |
| ◎ | 必須 | |
| 〇 | 条件付き必須 | 条件は各タグのConditionsに記載 |
|  | タグが存在してもしなくてもよい | |
| × | タグ自体、存在してはならない | |

- 条件チェック

    - 上記のFormat.csvのConditionsの条件を満たさなければならない。満たさない場合は、ログ出力(Logファイル)されなければならない。

#### ログ出力(CSV)の形式

- Order.xmlに対するチェック結果はCSV形式で出力されなければならない。
Format.csv と同様の形式で以下の通りとする。


|Tag0       |Tag1 |Tag2    |Tag3    |Tag4     | -- |Result |
|-----------|-----|--------|----|----|----|----|-------|
|CenterOrder|     |        |       |         ||True   |
|           |Order|        |       |         ||True   |
|           |     |OrderId |       |         ||False  |
|           |     |PayType |       |         ||True-10|
|           |     |ShipType|       |         ||True  |
|           |     |Option  |       |         ||True  |
|           |     |Option1 |       |         ||True  |
|           |     |Articles|       |         ||True  |
|           |     |        |Article|         ||True  |
|           |     |        |       |ProductId||False-ProductIdのタグが存在しない  |
|           |     |        |       |Price    ||True  |


※Headerは出力されない。Resultの先頭には、RequiredとConditionsを満たしている場合はTrue、満たさない場合はFalseとして、Falseの場合は必ず、Falseの後に「-」(ハイフン)で原因を出力すること。

PayType、ShipTypeについては変換した結果を「-」(ハイフン)の後に出力すること。
変換表は以下の通り。

| PayType | 変換した値 |
|----|----|
| 2 | 10 |
| 4 | 10 |
| 5 | 15 |
| 7 | 17 |

| ShipType | 変換した値 |
|----|----|
| 2 | 1 |
| 3 | 8 |
| 6 | 8 |


### 課題

#### 実践問題
- サンプルアプリ(CheckXmlTool)を以下の通り改修すること。

  - URL：https://github.com/infinith4/CheckXmlTool
  - Git Repository:https://github.com/infinith4/CheckXmlTool.git (branch:develop)
  - 確認用のOrder.xmlファイルは CheckXmlTool/CheckXmlTool/xml/Order01 やOrder02フォルダ内に存在する。 適宜自分でOrder.xmlファイルを修正して確認すること。


1. FormatUtil.ConvertPayType() ではPayTypeを変換している。ShipTypeも同様に上記の表の通り(Switch文を用いて)変換し、CSVに出力しなさい。

2. 現状、Order タグのAttributes:AspIdのチェックがされていない。チェックをしなさい。
  チェック条件は三項演算子を用いること。

3. OrderIdの値が6桁という条件をチェックしなさい。

4. ShipType以降のタグのチェックとCSV出力が不完全である。タグ(Attributesも含む)のRequiredチェックとConditionsのチェックをし、CSV出力をしなさい。
「ProductId」についてはMST_PriceのASP_IDとOrderタグのArttributes：AppIdが一致するデータ、かつ、ProductIdが一致することを条件とする。
