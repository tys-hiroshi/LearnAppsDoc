# ASP.NET MVC の説明

参考文献:

https://www.amazon.co.jp/ASP-NET-MVC5%E5%AE%9F%E8%B7%B5%E3%83%97%E3%83%AD%E3%82%B0%E3%83%A9%E3%83%9F%E3%83%B3%E3%82%B0-%E5%B1%B1%E7%94%B0-%E7%A5%A5%E5%AF%9B/dp/4798041793/ref=sr_1_1?ie=UTF8&qid=1524141823&sr=8-1&keywords=mvc

## Model,Controller,View

Model:

Controller:

View:


## LINQ

参考:

https://qiita.com/nskydiving/items/c9c47c1e48ea365f8995

http://ufcpp.net/study/csharp/sp3_linq.html

http://ufcpp.net/study/csharp/sp3_stdquery.html

一言で言うと、SQLっぽいデータベースを操作する言語。


### ControllerからViewにデータを渡す時の注意

Controller側

```
public ActionResult Index()
{
    Product product = new Prodcut();

    return View(product);  //productのデータ型はProduct Class
}
```

View側

```
@model 【データ型】
```

【データ型】にはView()のカッコ内に記載した変数のデータ型を記載する。(この場合は、Productと記載)
@model はcshtmlファイルに一つしかかけない。

#### 具体例

Controller側

```
public ActionResult SelectProduct()
{
    _sessionId = Session[Const.Session.SESSION_ID].ToString();
    _aspId = Session[Const.Session.ASP_ID].ToString();
    var orderProduct = from mst_Price in _db.MST_Price
                        join mst_Product in _db.MST_Product on mst_Price.ProductId equals mst_Product.ProductId
                        where mst_Price.ASP_ID == _aspId
                        orderby mst_Product.ProductId
                        select new OrderModel.Product
                        {
                            ProductId = mst_Price.ProductId,
                            ProductName = mst_Product.ProductName,
                            Price = (decimal)mst_Price.Price
                        };
    List<OrderModel.Product> orderProductList = orderProduct.ToList();

    return View(orderProductList);
}
```

View側(cshtml)

```
@model List<OrderModel.Product>
```


### DBのレコード更新について

以下でも良いけど、Attach,Entryしないといけないから面倒。

```
using(var _db = new LearnAppsEntities())
{
  MST_Price mst_Price = new MST_Price();
  mst_Price.ProductId = 1;
  mst_Price.Price = 100;
  mst_Price.ASP_ID = "0001";

  _db.MST_Price.Attach(mst_Price);
  _db.Entry(mst_Price).Property(m => m.Price).IsModified = true; // 対象フィールドを更新指定
  _db.SaveChanges();
}

```


以下のように書いたほうが楽。

```
using(var _db = new LearnAppsEntities())
{
  var mst_Price = (from mst in _db.MST_Price
                   where mst.ASP_ID == "0001" && mst.ProductId == 1
                   select mst).SingleOrDefault();
  mst_Price.Price = 100;  //100に書き換え
  _db.SaveChanges();
}

```

一般的には以下の通り。
```
using(var _db = new 【Entities】)
{
  var 【変数名】 = (from 【一時的な変数名】 in _db.【テーブル名】
                   where 【一時的な変数名】.【テーブルのカラム】 == 【条件に合う値】
                   select 【一時的な変数名】).SingleOrDefault();  //SingleOrDefault();を付けると一つレコードまたは1つも条件に一致しなかったらNull
  【変数名】.【テーブルの変更したいカラム】 = 【変更したい値】;
  _db.SaveChanges();  //保存処理の実行(ここで実行される)
}

```


参考:
http://kobarin.hateblo.jp/entry/2017/07/05/102834
https://densan-labs.net/tech/codefirst/adddelete.html
